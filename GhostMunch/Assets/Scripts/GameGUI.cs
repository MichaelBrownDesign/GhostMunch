using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour
{
    // Misc
    PlayerManager m_manager;

    // Stats
    public int m_nMaxHungerValue;
    private float m_fBarWidth;
    private float[] m_nHungerValues;
    private static int m_nPlayerCount;

    // Widgets
    [Header("Widgets")]
    public GameObject m_inGameUI;
    public GameObject m_gameOverUI;
    public GameObject[] m_hungerBars;
    public RectTransform[] m_fullHungerBars;
    public GameObject m_gameOverPanel;
    public GameObject m_gameOverTextObj;
    private Text m_gameOverText;

	// Use this for initialization
	void Awake()
    {
        m_nPlayerCount = PlayerManager.GetPlayerCount();

        m_nHungerValues = new float[4];

        m_gameOverText = m_gameOverTextObj.GetComponent<Text>();

        // Get hunger bar width...
        m_fBarWidth = m_hungerBars[0].GetComponent<RectTransform>().sizeDelta.x;

        // Get full hunger bars (Appearance of these will depend on player scores).
        for(int i = 0; i < m_fullHungerBars.Length; ++i)
        {
            m_fullHungerBars[i].sizeDelta = new Vector2(0.0f, m_fullHungerBars[i].sizeDelta.y);
        }

        // Disable unused widgets.
        for(int i = 3; i > m_nPlayerCount - 1; --i)
        {
            m_hungerBars[i].GetComponent<RectTransform>().localScale = Vector3.zero;
            m_fullHungerBars[i].GetComponent<RectTransform>().localScale = Vector3.zero;
        }

        m_manager = GetComponent<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    /*
    Description: Adjust the hunger bar display for the specified player to match the input value.
    Params:
        int nPlayerIndex: The index of the player bar to adjust (0-4).
        int nNewHunger: The new hunger value to display.
    */
    public void SetHunger(int nPlayerIndex, float nNewHunger)
    {
        // Clamp value to max hunger value.
        if(nNewHunger >= m_nMaxHungerValue)
        {
            m_nHungerValues[nPlayerIndex] = m_nMaxHungerValue;

            m_manager.DisablePlayerInput();

            m_inGameUI.SetActive(false);
            m_gameOverUI.SetActive(true);

            // Since a player has reached full hunger, it is game over.
            m_gameOverPanel.SetActive(true);
            m_gameOverTextObj.SetActive(true);
            m_gameOverText.text = "Player " + (nPlayerIndex + 1) + " is victorious!";
        }
        else
        {
            m_nHungerValues[nPlayerIndex] = nNewHunger;
        }

        // Get scale vector of bar.
        Vector2 v2BarScale = m_fullHungerBars[nPlayerIndex].sizeDelta;

        // Set x value based on hunger value.
        v2BarScale.x = (m_nHungerValues[nPlayerIndex] / m_nMaxHungerValue) * m_fBarWidth;

        // Apply changes.
        m_fullHungerBars[nPlayerIndex].sizeDelta = v2BarScale;
    }

    // Used by the lobby GUI to set the player count that is carried on between scenes.
    public static void SetPlayerCount(int nPlayerCount)
    {
        m_nPlayerCount = nPlayerCount;
    }

    public void PlayAgainButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
