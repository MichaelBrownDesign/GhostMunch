using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using XInputDotNetPure;

public class LobbyGUI : MonoBehaviour
{
    // GUI
    public GameObject m_mainMenuCanvas;
    public GameObject[] m_playerPanels;
    public Button m_playButton;
    public Button m_joinButton;

    LinkedList<int> m_players;
    private GamePadState[] m_playerStates;
    private GamePadState[] m_prevPlayerStates;
    private Text[] m_textObjs;

    private void Awake()
    {
        m_players = new LinkedList<int>();

        // Initialize arrays.
        m_playerStates = new GamePadState[4];
        m_prevPlayerStates = new GamePadState[4];

        m_textObjs = new Text[4];

        // Find text scripts on GUI panels.
        for (int i = 0; i < 4; ++i)
        {
            m_textObjs[i] = m_playerPanels[i].GetComponentInChildren<Text>();
        }
    }

    private void Update()
    {
        // Input
        bool bSpacePressed = Input.GetKeyDown(KeyCode.Space);

        // There are 5 possible players (4 controller, 1 Keyboard).
        for (int i = 0; i < 5; ++i)
        {
            bool bAPressed = false;

            // Do not check controller input if this is the 5th player.
            if (i != 4)
            {
                m_prevPlayerStates[i] = m_playerStates[i];
                m_playerStates[i] = GamePad.GetState((PlayerIndex)i);

                bAPressed = m_prevPlayerStates[i].Buttons.A == ButtonState.Released && m_playerStates[i].Buttons.A == ButtonState.Pressed;
            }

            // Joining and leaving...
            if (!m_players.Contains(i) && m_players.Count < 4) // Ensure existing players can't be added again and the max player count of 4 is not exceeded.
            {
                if (bSpacePressed && i == 4) // If potential keyboard player...
                {
                    // I is added and will function as the controller player index if it is not the 5th player (index of 4).
                    m_players.AddLast(i);
                }
                else if (i != 4 && bAPressed)
                {
                    // I is added and will function as the controller player index if it is not the 5th player (index of 4).
                    m_players.AddLast(i);
                }
            }
            else
            {
                if (bSpacePressed && i == 4) // Remove potential keyboard player...
                {
                    // I is added and will function as the controller player index if it is not the 5th player (index of 4).
                    m_players.Remove(i);
                }
                else if (i != 4 && bAPressed)
                {
                    // I is added and will function as the controller player index if it is not the 5th player (index of 4).
                    m_players.Remove(i);
                }
            }
        }

        // Display
        LinkedListNode<int> m_currentNode = m_players.First;
        for (int i = 0; i < 4; ++i)
        {
            if (m_currentNode != null && m_currentNode.Value == 4) // If the player exists and is the keyboard player...
            {
                m_textObjs[i].text = "  Player " + (i + 1) + " [Keyboard]";
            }
            else if (m_currentNode != null) // If the player exists and is not the keyboard player...
            {
                m_textObjs[i].text = "  Player " + (i + 1) + " [Controller" + m_currentNode.Value + "]";
            }
            else // If the player does not exist...
            {
                m_textObjs[i].text = "  Join";
            }

            if (m_currentNode != null)
                m_currentNode = m_currentNode.Next;
        }
    }

    public void BackButton()
    {
        // Reset panel text.
        for (int i = 0; i < 4; ++i)
        {
            m_textObjs[i].text = "  Join";
        }

        // Remove all player data.
        m_players.Clear();

        // Activate main menu canvas and deactivate this one.
        m_mainMenuCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void PlayButton()
    {
        // Set player count.
        PlayerManager.SetPlayerCount(m_players.Count);

        // Send index of keyboard player (if any).
        LinkedListNode<int> m_currentNode = m_players.First;
        for (int i = 0; i < m_players.Count; ++i)
        {
            if (m_currentNode.Value == 4)
                PlayerManager.SetUsesKeyboard(true);

            PlayerManager.SetPlayerIndex(i, m_currentNode.Value);

            m_currentNode = m_currentNode.Next;
        }

        // Transition to game scene.
        SceneManager.LoadScene(1);
    }
}
