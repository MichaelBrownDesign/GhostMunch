using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool m_bDebugMode;
    public GameObject[] m_players;
    public GameObject m_human;

    private static int[] m_nPlayerIndices = new int[4];
    private static int m_nPlayerCount = 0;

    // Use this for initialization
    void Awake()
    {
        if (m_bDebugMode)
        {
            m_nPlayerCount = m_players.Length;
            return;
        }

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
                continue;
            }

            // Check if this player exceeds the player count, and if so, disable them.
            if (i + 1 > m_nPlayerCount)
                m_players[i].SetActive(false);

            // Set player input indices.
            PlayerInput input = m_players[i].GetComponent<PlayerInput>();

            input.m_ePlayerIndex = (PlayerIndex)m_nPlayerIndices[i];
            input.m_bUseKeyboard = m_nPlayerIndices[i] == 4;
        }
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    public static void SetPlayerCount(int nPlayerCount)
    {
        m_nPlayerCount = nPlayerCount;
        GameGUI.SetPlayerCount(nPlayerCount);
    }

    public static void SetPlayerIndex(int nLocation, int nIndex)
    {
        m_nPlayerIndices[nLocation] = nIndex;
    }

    public static int GetPlayerCount()
    {
        return m_nPlayerCount;
    }

    // Disables input on all active players.
    public void DisablePlayerInput()
    {
        for(int i = 0; i < m_players.Length; ++i)
        {
            m_players[i].GetComponent<PlayerInput>().enabled = false;
            m_players[i].GetComponent<PlayerMovement>().enabled = false;
        }

        m_human.GetComponent<PlayerInput>().enabled = false;
        m_human.GetComponent<PlayerMovement>().enabled = false;
    }
}
