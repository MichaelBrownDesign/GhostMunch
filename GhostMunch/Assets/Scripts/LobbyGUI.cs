using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class LobbyGUI : MonoBehaviour
{
    public GameObject[] m_playerPanels;

    private PlayerIndex[] m_playerIndices;
    private GamePadState[] m_playerStates;
    private GamePadState[] m_prevPlayerStates;
    private bool[] m_bPlayersJoined;
    private bool m_bKeyboardUsed;

	// Use this for initialization
	void Awake()
    {
        m_playerIndices = new PlayerIndex[4];

        m_playerIndices[0] = PlayerIndex.One;
        m_playerIndices[1] = PlayerIndex.Two;
        m_playerIndices[2] = PlayerIndex.Three;
        m_playerIndices[3] = PlayerIndex.Four;

        m_playerStates = new GamePadState[m_playerPanels.Length];
        m_prevPlayerStates = new GamePadState[m_playerPanels.Length];

        m_bPlayersJoined = new bool[4];
	}
	
	// Update is called once per frame
	void Update()
    {
        bool bSpacePressed = Input.GetKeyDown(KeyCode.Space);

        for (int i = 0; i < m_playerPanels.Length; ++i)
        {
            m_prevPlayerStates[i] = m_playerStates[i];
            m_playerStates[i] = GamePad.GetState(m_playerIndices[i]);

            bool bAPressed = m_prevPlayerStates[i].Buttons.A == ButtonState.Released && m_playerStates[i].Buttons.A == ButtonState.Pressed;

            // Joining...
            if (bAPressed && (i > 0 || !m_bKeyboardUsed))
            {
                m_bPlayersJoined[i] = !m_bPlayersJoined[i];

                if(m_bPlayersJoined[i])
                {
                    m_playerPanels[i].GetComponentInChildren<Text>().text = "  Player " + (i + 1);
                }
                else
                {
                    m_playerPanels[i].GetComponentInChildren<Text>().text = "  Join";
                }
            }
            else if((bAPressed || bSpacePressed) && i == 0)
            {
                m_bPlayersJoined[i] = !m_bPlayersJoined[i];

                if (m_bPlayersJoined[i])
                {
                    m_playerPanels[i].GetComponentInChildren<Text>().text = "  Player " + (i + 1);

                    // Since the first player is using the keyboard. Player indices are changed such the player 2 uses controller player 1 input.
                    m_playerIndices[0] = PlayerIndex.Four;
                    m_playerIndices[1] = PlayerIndex.One;
                    m_playerIndices[2] = PlayerIndex.Two;
                    m_playerIndices[3] = PlayerIndex.Three;

                    m_bKeyboardUsed = true;
                }
                else
                {
                    m_playerPanels[i].GetComponentInChildren<Text>().text = "  Join";

                    // Since the first player is using the keyboard. Player indices are changed such the player 2 uses controller player 1 input.
                    m_playerIndices[0] = PlayerIndex.One;
                    m_playerIndices[1] = PlayerIndex.Two;
                    m_playerIndices[2] = PlayerIndex.Three;
                    m_playerIndices[3] = PlayerIndex.Four;

                    m_bKeyboardUsed = false;
                }
            }
        }
	}

    public void LaunchMatch()
    {
        // Count amount of players joined and set player count...
        int nPlayerCount = 0;

        for(int i = 0; i < m_bPlayersJoined.Length; ++i)
        {
            if (m_bPlayersJoined[i])
                ++nPlayerCount;
        }

        PlayerManager.SetPlayerCount(nPlayerCount, m_bKeyboardUsed);
        SceneManager.LoadScene(1);
    }
}
