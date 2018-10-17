using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] m_players;

    private GameGUI m_gui;
    private static int m_nPlayerCount = 0;
    private static bool m_bKeyboardUsed;

    // Use this for initialization
    void Awake()
    {
        m_nPlayerCount = 2;

        // Check if player objects are valid.
		for(int i = 0; i < m_players.Length; ++i)
        {
            // Skip the player if they are null.
            if (m_players[i] == null)
                continue;

            if(m_players[i].tag != "Player" || m_players[i].GetComponent<Player>() == null || m_players[i].GetComponent<PlayerInput>() == null 
                || m_players[i].GetComponent<PlayerMovement>() == null || m_players[i].GetComponent<CharacterController>() == null)
            {
                Debug.LogError("Player: " + m_players[i].name + " is not a valid player!");
            }

            // Check if this player exceeds the player count, and if so, disable them.
            if (i + 1 > m_nPlayerCount)
                m_players[i].SetActive(false);

            // Set player input indices.
            PlayerInput input = m_players[i].GetComponent<PlayerInput>();

            if(m_bKeyboardUsed && i == 0)
            {
                input.m_ePlayerIndex = PlayerIndex.Four;
                input.m_bUseKeyboard = true;
            }
            else
            {
                int nKeyboard = 0;

                if (m_bKeyboardUsed)
                    nKeyboard = 1;

                input.m_ePlayerIndex = (PlayerIndex)(i - nKeyboard);
                input.m_bUseKeyboard = false;
            }
            
            
        }

        // Access GUI script...
        m_gui = GameObject.Find("GameGUI").GetComponent<GameGUI>();

        m_gui.SetPlayerCount(m_nPlayerCount);
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    public static void SetPlayerCount(int nPlayerCount)
    {
        m_nPlayerCount = nPlayerCount;
    }

    public static void SetPlayerCount(int nPlayerCount, bool bUseKeyboard)
    {
        m_nPlayerCount = nPlayerCount;
        m_bKeyboardUsed = bUseKeyboard;
    }
}
