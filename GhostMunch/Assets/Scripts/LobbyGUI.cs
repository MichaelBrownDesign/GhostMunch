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

    private PlayerIndex[] m_playerIndices;
    private GamePadState[] m_playerStates;
    private GamePadState[] m_prevPlayerStates;
    private Text[] m_playerTexts;
    private int m_nPlayerCount;
    private bool[] m_bPlayersJoined;
    private bool m_bKeyboardUsed;

    struct PlayerLobbyData
    {
        public PlayerIndex m_eIndex;
        public Text m_text;
    };

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
        m_playerTexts = new Text[4];

        for(int i = 0; i < 4; ++i)
        {
            m_playerTexts[i] = m_playerPanels[i].GetComponentInChildren<Text>();
        }

        // Make sure play button is disabled at first.
        m_playButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update()
    {
        bool bSpacePressed = Input.GetKeyDown(KeyCode.Space);

        // Lobby join and leave.
        for (int i = 0; i < m_playerPanels.Length; ++i)
        {
            m_prevPlayerStates[i] = m_playerStates[i];
            m_playerStates[i] = GamePad.GetState(m_playerIndices[i]);

            bool bAPressed = m_prevPlayerStates[i].Buttons.A == ButtonState.Released && m_playerStates[i].Buttons.A == ButtonState.Pressed;

            // Joining...
            
        }

        // Play button management.
        m_playButton.interactable = m_nPlayerCount > 1;
	}

    public void LaunchMatch()
    {
        PlayerManager.SetPlayerCount(m_nPlayerCount, m_bKeyboardUsed);
        SceneManager.LoadScene(1);
    }

    public void OnBackClick()
    {
        // Reset variables...
        PlayerManager.SetPlayerCount(0, false);

        m_playerIndices[0] = PlayerIndex.One;
        m_playerIndices[1] = PlayerIndex.Two;
        m_playerIndices[2] = PlayerIndex.Three;
        m_playerIndices[3] = PlayerIndex.Four;

        m_bPlayersJoined[0] = true;
        m_bPlayersJoined[1] = false;
        m_bPlayersJoined[2] = false;
        m_bPlayersJoined[3] = false;

        m_playerTexts[0].text = "  Join";
        m_playerTexts[1].text = "  Join";
        m_playerTexts[2].text = "  Join";
        m_playerTexts[3].text = "  Join";

        m_bKeyboardUsed = false;

        m_nPlayerCount = 0;

        m_mainMenuCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
