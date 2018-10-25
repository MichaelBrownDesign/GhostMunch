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
    public Text[] m_keyboardButtonTexts;
    public Text[] m_controllerButtonTexts;
    public Button m_applyButton;
    public StandaloneInputModule m_guiInput;
    public GameObject m_darkPanel;
    public string[] m_buttonNames;
    public string[] m_axisNames;

    private BindingData[] m_bindingData;
    private BindingData m_currentData;
    private GamePadState m_gpdState;
    private GamePadState m_prevGpdState;
    private InputWaitState m_eWaitState;
    private int m_nControlIndex;
    private bool m_bChangesMade;

    private int m_nWaitFrames;

    private static PlayerIndex m_eCurrentPlayer;

    // Use this for initialization
    void Awake()
    {
        m_bindingData = new BindingData[4];

        for (int i = 0; i < m_bindingData.Length; ++i)
        {
            m_bindingData[i] = new BindingData();
        }

        m_currentData = m_bindingData[0];
        m_eCurrentPlayer = PlayerIndex.One;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_guiInput == null)
            return;

        m_prevGpdState = m_gpdState;
        m_gpdState = GamePad.GetState(m_eCurrentPlayer);

        if (m_nWaitFrames <= 0)
        {
            switch (m_eWaitState)
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
        else
        {
            --m_nWaitFrames;
        }

        if (m_applyButton != null)
        {
            m_applyButton.interactable = m_bChangesMade;
        }
    }

    int GetButton()
    {
        if (m_prevGpdState.Buttons.A == ButtonState.Released && m_gpdState.Buttons.A == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.A;
        }
        else if (m_prevGpdState.Buttons.B == ButtonState.Released && m_gpdState.Buttons.B == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.B;
        }
        else if (m_prevGpdState.Buttons.X == ButtonState.Released && m_gpdState.Buttons.X == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.X;
        }
        else if (m_prevGpdState.Buttons.Y == ButtonState.Released && m_gpdState.Buttons.Y == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.Y;
        }
        else if (m_prevGpdState.DPad.Up == ButtonState.Released && m_gpdState.DPad.Up == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.UP;
        }
        else if (m_prevGpdState.DPad.Down == ButtonState.Released && m_gpdState.DPad.Down == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.DOWN;
        }
        else if (m_prevGpdState.DPad.Left == ButtonState.Released && m_gpdState.DPad.Left == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.LEFT;
        }
        else if (m_prevGpdState.DPad.Right == ButtonState.Released && m_gpdState.DPad.Right == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.RIGHT;
        }
        else if (m_prevGpdState.Buttons.LeftShoulder == ButtonState.Released && m_gpdState.Buttons.LeftShoulder == ButtonState.Pressed)
        {
            return (int)PlayerInput.EGamePadButton.LEFT_BUMPER;
        }
        else if (m_prevGpdState.Buttons.RightShoulder == ButtonState.Released && m_gpdState.Buttons.RightShoulder == ButtonState.Pressed)
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
        int key = -1;

        // Find which key was pressed (if any).
        foreach (KeyCode k in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(k))
                key = (int)k;
        }

        if ((KeyCode)key == KeyCode.Escape)
        {
            m_eWaitState = InputWaitState.INPUT_NONE;
            m_currentData.m_keys[m_nControlIndex] = (KeyCode)(-1);
            m_keyboardButtonTexts[m_nControlIndex].GetComponentInChildren<Text>().text = "NO BINDING";

            m_bChangesMade = true;

            m_darkPanel.SetActive(false);

            return;
        }

        // If a key was found assign it.
        if (key > -1)
        {
            m_currentData.m_keys[m_nControlIndex] = (KeyCode)key;

            m_keyboardButtonTexts[m_nControlIndex].GetComponentInChildren<Text>().text = ((KeyCode)key).ToString();

            m_eWaitState = InputWaitState.INPUT_NONE;
            m_nWaitFrames = 2;
            m_bChangesMade = true;

            m_darkPanel.SetActive(false);
        }
    }

    void AssignController()
    {
        if (m_prevGpdState.Buttons.Back == ButtonState.Released && m_gpdState.Buttons.Back == ButtonState.Pressed)
        {
            m_eWaitState = InputWaitState.INPUT_NONE;
            m_currentData.m_axes[m_nControlIndex] = (PlayerInput.EGamePadAxis)(-1);
            m_controllerButtonTexts[m_nControlIndex].text = "NO BINDING";

            m_bChangesMade = true;

            m_darkPanel.SetActive(false);

            return;
        }

        // Get button or axis input.
        int button = GetButton();
        int axis = GetAxis();

        // Assign button or axis if detected.
        if (button > -1)
        {
            m_currentData.m_buttons[m_nControlIndex] = (PlayerInput.EGamePadButton)button;
            m_currentData.m_bIsButton[m_nControlIndex] = true;

            m_controllerButtonTexts[m_nControlIndex].text = m_buttonNames[button];

            m_nWaitFrames = 2;
            m_eWaitState = InputWaitState.INPUT_NONE;
            m_bChangesMade = true;

            m_darkPanel.SetActive(false);

            return;
        }
        else if (axis > -1)
        {
            m_currentData.m_axes[m_nControlIndex] = (PlayerInput.EGamePadAxis)axis;

            m_controllerButtonTexts[m_nControlIndex].text = m_axisNames[axis];

            m_nWaitFrames = 2;
            m_eWaitState = InputWaitState.INPUT_NONE;
            m_bChangesMade = true;

            m_darkPanel.SetActive(false);
        }
    }

    public void ActiveKeyboard(int nIndex)
    {
        if (m_nWaitFrames > 0)
            return;

        m_darkPanel.SetActive(true);

        m_eWaitState = InputWaitState.INPUT_KEYBOARD;
        m_nWaitFrames = 2;
        m_nControlIndex = nIndex;
    }

    public void ActiveController(int nIndex)
    {
        if (m_nWaitFrames > 0)
            return;

        m_darkPanel.SetActive(true);

        m_eWaitState = InputWaitState.INPUT_CONTROLLER;
        m_nWaitFrames = 2;
        m_nControlIndex = nIndex;
    }

    public void ApplyChanges()
    {
        if (m_bChangesMade)
        {
            // Write bindings to file.
            SaveBindings();

            // Reset changes made.
            m_bChangesMade = false;
        }
    }

    public void ResetBindings()
    {
        LoadBindings();

        // Set button texts...

        // Keyboard buttons...
        for(int i = 0; i < m_keyboardButtonTexts.Length; ++i)
        {
            m_keyboardButtonTexts[i].text = ((KeyCode)(m_bindingData[(int)m_eCurrentPlayer].m_keys[i])).ToString();
        }

        // Controller buttons...
        for(int i = 0; i < m_controllerButtonTexts.Length; ++i)
        {
            BindingData currentData = m_bindingData[(int)m_eCurrentPlayer];

            if(currentData.m_bIsButton[i])
            {
                // Use button names if this is a button binding.
                m_controllerButtonTexts[i].text = m_buttonNames[(int)currentData.m_buttons[i]];
            }
            else
            {
                // Use axis names if this is an axis binding.
                m_controllerButtonTexts[i].text = m_axisNames[(int)currentData.m_axes[i]];
            }
        }

        m_bChangesMade = true;
    }

    void SaveBindings()
    {
        // Open or create file.
        FileStream fs = null;
        try
        {
            fs = new FileStream(Application.temporaryCachePath + "/bindings.dat", FileMode.OpenOrCreate);
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError("Could not create or overwrite file, reason: " + e.Message);
            return;
        }

        BinaryFormatter formatter = new BinaryFormatter();

        // Save...
        try
        {
            formatter.Serialize(fs, m_bindingData);
        }
        catch (SerializationException e)
        {
            Debug.LogError("Error: Could not save bindings, reason: " + e.Message);
        }
        finally
        {
            fs.Close();
        }
    }

    void LoadBindings()
    {
        // Create file object and load from file.
        FileStream fs = null;
        try
        {
            fs = new FileStream(Application.temporaryCachePath + "/bindings.dat", FileMode.Open);
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError("Could not find bindings file, reason: " + e.Message);
            return;
        }

        BinaryFormatter formatter = new BinaryFormatter();

        // Deserialize file.
        try
        {
            m_bindingData = (BindingData[])formatter.Deserialize(fs);
        }
        catch (SerializationException e)
        {
            Debug.LogError("Could not load bindings file, reason: " + e.Message);
            return;
        } 
        finally
        {
            fs.Close();
        }
    }
}


[System.Serializable]
class BindingData
{
    public PlayerInput.EGamePadButton[] m_buttons = new PlayerInput.EGamePadButton[4];
    public PlayerInput.EGamePadAxis[] m_axes = new PlayerInput.EGamePadAxis[4];
    public bool[] m_bIsButton = new bool[4];
    public KeyCode[] m_keys = new KeyCode[6];
}
