using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerInput : MonoBehaviour
{
    public enum EGamePadButton
    {
        A,
        B,
        X,
        Y,
        UP,
        DOWN,
        LEFT,
        RIGHT,
        LEFT_BUMPER,
        RIGHT_BUMPER
    }

    public enum EGamePadAxis
    {
        LEFT_TRIGGER,
        RIGHT_TRIGGER,
        LEFT_THUMBSTICK_X,
        RIGHT_THUMBSTICK_X,
        LEFT_THUMBSTICK_Y,
        RIGHT_THUMBSTICK_Y
    }

    // General input
    [Header("General")]
    public bool m_bUseKeyboard;
    public PlayerIndex m_ePlayerIndex;

    private GamePadState m_prevGpdState;
    private GamePadState m_gpdState;

    // Bindings
    [Header("Bindings")]

    [Tooltip("Button bindings for Gamepad.")]
    public EGamePadButton[] m_buttonBindings = 
    {
        EGamePadButton.A,
        EGamePadButton.B,
        EGamePadButton.X,
        EGamePadButton.Y,
        EGamePadButton.UP,
        EGamePadButton.DOWN,
        EGamePadButton.LEFT,
        EGamePadButton.RIGHT,
        EGamePadButton.LEFT_BUMPER,
        EGamePadButton.RIGHT_BUMPER
    };

    [Space()]

    [Tooltip("Button bindings for PC keyboard.")]
    public KeyCode[] m_buttonKeyBindings = 
    {
        KeyCode.Space,
        KeyCode.W,
        KeyCode.A,
        KeyCode.S,
        KeyCode.D,
        KeyCode.E,
        KeyCode.F,
        KeyCode.Q,
        KeyCode.Tab,
        KeyCode.Escape
    };

    [Space()]

    [Tooltip("Button bindings for Gamepad axes.")]
    public EGamePadAxis[] m_axisBindings = 
    {
        EGamePadAxis.RIGHT_TRIGGER,
        EGamePadAxis.LEFT_TRIGGER,
        EGamePadAxis.LEFT_THUMBSTICK_X,
        EGamePadAxis.LEFT_THUMBSTICK_Y,
        EGamePadAxis.RIGHT_THUMBSTICK_X,
        EGamePadAxis.RIGHT_THUMBSTICK_Y
    };

    // Dictionaries and Func pointers
    delegate bool GPDButton(GamePadState state);

    Dictionary<EGamePadButton, GPDButton> m_buttons;

    delegate float GPDAxis(GamePadState state);

    Dictionary<EGamePadAxis, GPDAxis> m_axes;

    void AssignButton(EGamePadButton button)
    {   
        try
        {
            switch (button) // Check enum value and assign the correct input function.
            {
                case EGamePadButton.A:
                    m_buttons.Add(button, APressed);
                    break;

                case EGamePadButton.B:
                    m_buttons.Add(button, BPressed);
                    break;

                case EGamePadButton.X:
                    m_buttons.Add(button, XPressed);
                    break;

                case EGamePadButton.Y:
                    m_buttons.Add(button, YPressed);
                    break;

                case EGamePadButton.UP:
                    m_buttons.Add(button, DPadUpPressed);
                    break;

                case EGamePadButton.DOWN:
                    m_buttons.Add(button, DPadDownPressed);
                    break;

                case EGamePadButton.LEFT:
                    m_buttons.Add(button, DPadLeftPressed);
                    break;

                case EGamePadButton.RIGHT:
                    m_buttons.Add(button, DPadRightPressed);
                    break;

                case EGamePadButton.LEFT_BUMPER:
                    m_buttons.Add(button, LeftBumperPressed);
                    break;

                case EGamePadButton.RIGHT_BUMPER:
                    m_buttons.Add(button, RightBumperPressed);
                    break;
            }
        }
        catch(ArgumentException e) // If there are duplicate bindings are found an argument exception will be thrown.
        {
            if(e.GetType() == typeof(ArgumentException))
                Debug.LogWarning("PlayerInput.cs: Multiple inputs detected with the same binding!");
        }
    }

    void AssignAxis(EGamePadAxis axis)
    {
        try
        {
            switch (axis) // Check enum value and assign the correct axis input function.
            {
                case EGamePadAxis.LEFT_TRIGGER:
                    m_axes.Add(axis, LeftTriggerValue);
                    break;

                case EGamePadAxis.RIGHT_TRIGGER:
                    m_axes.Add(axis, RightTriggerValue);
                    break;

                case EGamePadAxis.LEFT_THUMBSTICK_X:
                    m_axes.Add(axis, LeftStickValueX);
                    break;

                case EGamePadAxis.RIGHT_THUMBSTICK_X:
                    m_axes.Add(axis, RightStickValueX);
                    break;

                case EGamePadAxis.LEFT_THUMBSTICK_Y:
                    m_axes.Add(axis, LeftStickValueY);
                    break;

                case EGamePadAxis.RIGHT_THUMBSTICK_Y:
                    m_axes.Add(axis, RightStickValueY);
                    break;
            }
        }
        catch (ArgumentException e)
        {
            if (e.GetType() == typeof(ArgumentException)) // If there are duplicate bindings are found an argument exception will be thrown.
                Debug.LogWarning("PlayerInput.cs: Multiple inputs detected with the same binding!");
        }
    }

    // Use this for initialization
    void Awake()
    {
        // If the player is using the keyboard, they will be set to player 4's controller input.
        if(m_bUseKeyboard)
            m_ePlayerIndex = PlayerIndex.Four;

        m_buttons = new Dictionary<EGamePadButton, GPDButton>();
        m_axes = new Dictionary<EGamePadAxis, GPDAxis>();

        // Assign bindings to functions...
        for(int i = 0; i < m_buttonBindings.Length; ++i)
        {
            AssignButton(m_buttonBindings[i]);
        }

        for(int i = 0; i < m_axisBindings.Length; ++i)
        {
            AssignAxis(m_axisBindings[i]);
        }
    }
	
	// Update is called once per frame
	void Update()
    {
        m_prevGpdState = m_gpdState;
        m_gpdState = GamePad.GetState(m_ePlayerIndex);
	}

    // -------------------------------------------------------------------------------
    // Button hold functions

    // Returns true when the specified button is held down.
    public bool GetButtonPressed(int nButtonIndex)
    {
        return m_buttons[m_buttonBindings[nButtonIndex]](m_gpdState) || (Input.GetKey(m_buttonKeyBindings[nButtonIndex]) && m_bUseKeyboard);
    }

    // Returns true when the specified button is NOT held down.
    public bool GetButtonReleased(int nButtonIndex)
    {
        return !(m_buttons[m_buttonBindings[nButtonIndex]](m_gpdState) || (Input.GetKey(m_buttonKeyBindings[nButtonIndex]) && m_bUseKeyboard));
    }

    // Returns true when the specified button is pressed and released. (PC buttons activate when first pressed but that usually makes little difference).
    public bool GetButton(int nButtonIndex)
    {
        return (!m_buttons[m_buttonBindings[nButtonIndex]](m_prevGpdState) && m_buttons[m_buttonBindings[nButtonIndex]](m_gpdState)) 
            || (Input.GetKeyDown(m_buttonKeyBindings[nButtonIndex]) && m_bUseKeyboard);
    }
    // -------------------------------------------------------------------------------

    // -------------------------------------------------------------------------------
    // Misc buttons

    // Returns true when the start button on the gamepad is pressed and released.
    public bool StartPressed()
    {
        return (m_prevGpdState.Buttons.Start == ButtonState.Released && m_gpdState.Buttons.Start == ButtonState.Pressed);
    }

    // Returns true when the back button on the gamepad is pressed and released.
    public bool BackPressed()
    {
        return (m_prevGpdState.Buttons.Back == ButtonState.Released && m_gpdState.Buttons.Back == ButtonState.Pressed);
    }
    // -------------------------------------------------------------------------------

    // -------------------------------------------------------------------------------
    // Axes

    // Returns the current value of the specified axis.
    public float GetAxis(int nAxisIndex)
    {
        return m_axes[m_axisBindings[nAxisIndex]](m_gpdState);
    }

    // Returns the value of the specified axis from the previous frame.
    public float GetAxisLast(int nAxisIndex)
    {
        return m_axes[m_axisBindings[nAxisIndex]](m_prevGpdState);
    }
    // -------------------------------------------------------------------------------

    // -------------------------------------------------------------------------------
    // Hidden input queries
    bool APressed(GamePadState state)
    {
        return state.Buttons.A == ButtonState.Pressed;
    }

    bool BPressed(GamePadState state)
    {
        return state.Buttons.B == ButtonState.Pressed;
    }

    bool XPressed(GamePadState state)
    {
        return state.Buttons.X == ButtonState.Pressed;
    }

    bool YPressed(GamePadState state)
    {
        return state.Buttons.Y == ButtonState.Pressed;
    }

    bool DPadUpPressed(GamePadState state)
    {
        return state.DPad.Up == ButtonState.Pressed;
    }

    bool DPadDownPressed(GamePadState state)
    {
        return state.DPad.Down == ButtonState.Pressed;
    }

    bool DPadLeftPressed(GamePadState state)
    {
        return state.DPad.Left == ButtonState.Pressed;
    }

    bool DPadRightPressed(GamePadState state)
    {
        return state.DPad.Right == ButtonState.Pressed;
    }

    bool LeftBumperPressed(GamePadState state)
    {
        return state.Buttons.LeftShoulder == ButtonState.Pressed;
    }

    bool RightBumperPressed(GamePadState state)
    {
        return state.Buttons.RightShoulder == ButtonState.Pressed;
    }

    float LeftTriggerValue(GamePadState state)
    {
        return state.Triggers.Left;
    }

    float RightTriggerValue(GamePadState state)
    {
        return state.Triggers.Right;
    }

    float LeftStickValueX(GamePadState state)
    {
        return state.ThumbSticks.Left.X;
    }

    float LeftStickValueY(GamePadState state)
    {
        return state.ThumbSticks.Left.Y;
    }

    float RightStickValueX(GamePadState state)
    {
        return state.ThumbSticks.Right.X;
    }

    float RightStickValueY(GamePadState state)
    {
        return state.ThumbSticks.Right.Y;
    }
    // -------------------------------------------------------------------------------

    public void SetPlayer(PlayerIndex eIndex)
    {
        m_ePlayerIndex = eIndex;
    }

    public int GetPlayer()
    {
        return (int)m_ePlayerIndex;
    }
}
