using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using XInputDotNetPure;

public enum InputWaitState
{
    INPUT_NONE,
    INPUT_KEYBOARD,
    INPUT_CONTROLLER
}

public class OptionsGUI : MonoBehaviour
{
    public float m_fAxisDeadzone = 0.2f;
    public Button[] m_keyboardButtons;
    public Button[] m_controllerButtons;
    public StandaloneInputModule m_guiInput;

    private BindingData[] m_bindingData;
    private BindingData m_currentData;
    private GamePadState m_gpdState;
    private InputWaitState m_eWaitState;
    private int m_nControlIndex;
    private bool m_bChangesMade;

    private static PlayerIndex m_eCurrentPlayer;

    // Use this for initialization
    void Awake()
    {
        m_bindingData = new BindingData[4];
        m_currentData = m_bindingData[0];
        m_eCurrentPlayer = PlayerIndex.One;
    }

    // Update is called once per frame
    void Update()
    {
        m_gpdState = GamePad.GetState(m_eCurrentPlayer);

        if (m_guiInput == null)
            return;

        switch(m_eWaitState)
        {
            case InputWaitState.INPUT_NONE:
                m_guiInput.enabled = true;
                break;
            case InputWaitState.INPUT_KEYBOARD:
                AssignKeyboard();
                break;
            case InputWaitState.INPUT_CONTROLLER:
                AssignController();
                break;
            default:
                break;
        }
    }

    int GetButton()
    {
        if (m_gpdState.Buttons.A == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.A;
        }
        else if (m_gpdState.Buttons.B == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.B;
        }
        else if (m_gpdState.Buttons.X == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.X;
        }
        else if (m_gpdState.Buttons.Y == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.Y;
        }
        else if (m_gpdState.DPad.Up == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.UP;
        }
        else if (m_gpdState.DPad.Down == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.DOWN;
        }
        else if (m_gpdState.DPad.Left == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.LEFT;
        }
        else if (m_gpdState.DPad.Right == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.RIGHT;
        }
        else if (m_gpdState.Buttons.LeftShoulder == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.LEFT_BUMPER;
        }
        else if (m_gpdState.Buttons.RightShoulder == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.RIGHT_BUMPER;
        }

        return -1;
    }

    int GetAxis()
    {
        if (m_gpdState.Triggers.Left >= m_fAxisDeadzone)
        {
            return (int)PlayerInput.EGamePadAxis.LEFT_TRIGGER;
        }
        else if (m_gpdState.Triggers.Right >= m_fAxisDeadzone)
        {
            return (int)PlayerInput.EGamePadAxis.RIGHT_TRIGGER;
        }
        else if (m_gpdState.ThumbSticks.Left.X >= m_fAxisDeadzone || m_gpdState.ThumbSticks.Left.X <= -m_fAxisDeadzone)
        {
            return (int)PlayerInput.EGamePadAxis.LEFT_THUMBSTICK_X;
        }
        else if (m_gpdState.ThumbSticks.Left.Y >= m_fAxisDeadzone || m_gpdState.ThumbSticks.Left.Y <= -m_fAxisDeadzone)
        {
            return (int)PlayerInput.EGamePadAxis.LEFT_THUMBSTICK_Y;
        }
        else if (m_gpdState.ThumbSticks.Right.X >= m_fAxisDeadzone || m_gpdState.ThumbSticks.Right.X <= -m_fAxisDeadzone)
        {
            return (int)PlayerInput.EGamePadAxis.RIGHT_THUMBSTICK_X;
        }
        else if (m_gpdState.ThumbSticks.Right.Y >= m_fAxisDeadzone || m_gpdState.ThumbSticks.Right.Y <= -m_fAxisDeadzone)
        {
            return (int)PlayerInput.EGamePadAxis.RIGHT_THUMBSTICK_Y;
        }

        return -1;
    }

    void AssignKeyboard()
    {
        m_guiInput.enabled = false;

        int key = -1;

        // Find which key was pressed (if any).
        foreach (KeyCode k in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(k))
                key = (int)k;
        }

        // If a key was found assign it.
        if(key > -1)
        {
            m_currentData.m_keys[m_nControlIndex] = (KeyCode)key;
            m_eWaitState = InputWaitState.INPUT_NONE;
            m_bChangesMade = true;
        }
    }

    void AssignController()
    {
        m_guiInput.enabled = false;

        // Get button or axis input.
        int button = GetButton();
        int axis = GetAxis();

        // Assign button or axis if detected.
        if (button > -1)
        {
            m_currentData.m_buttons[m_nControlIndex] = (PlayerInput.EGamePadButton)button;
            m_eWaitState = InputWaitState.INPUT_NONE;
            m_bChangesMade = true;
        } 
        else if(axis > -1)
        {
            m_currentData.m_axes[m_nControlIndex] = (PlayerInput.EGamePadAxis)axis;
            m_eWaitState = InputWaitState.INPUT_NONE;
            m_bChangesMade = true;
        }
    }

    public void ActiveKeyboard(int nIndex)
    {
        m_eWaitState = InputWaitState.INPUT_KEYBOARD;
        m_nControlIndex = nIndex;
    }

    public void ActiveController(int nIndex)
    {
        m_eWaitState = InputWaitState.INPUT_CONTROLLER;
        m_nControlIndex = nIndex;
    }
}


[System.Serializable]
class BindingData
{
    public PlayerInput.EGamePadButton[] m_buttons = new PlayerInput.EGamePadButton[4];
    public PlayerInput.EGamePadAxis[] m_axes = new PlayerInput.EGamePadAxis[4];
    public KeyCode[] m_keys = new KeyCode[4];
}
