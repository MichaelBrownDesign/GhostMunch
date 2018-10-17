using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] m_players;

    private GameGUI m_gui;
    private static int m_nPlayerCount = 0;

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
}
