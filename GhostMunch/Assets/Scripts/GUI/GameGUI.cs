using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameGUI : MonoBehaviour
{
    // Misc
    PlayerManager m_manager;

    public PauseMenu m_pauseScript;

    private string m_sceneName;

    // Stats
    public int m_nMaxHungerValue;
    public float m_fGOInputDelay = 2.0f;
    private float[] m_nHungerValues;
    private static int m_nPlayerCount;
    private float m_fGOInputDelayCurrent;

    // Widgets
    [Header("Widgets")]
    public GameObject m_inGameUI;
    public GameObject m_gameOverUI;
    public GameObject[] m_hungerBars;
    public Image[] m_fullHungerBars;
    public GameObject m_gameOverPanel;
    public GameObject m_gameOverTextObj;
    public GameObject m_gameOverRestartButton;
    public EventSystem m_gameOverEvents;
    public GameObject m_playAgainButton;
    private Text m_gameOverText;
    private bool m_bGOButtonSet = false;

    // Use this for initialization
    void Awake()
    {
        m_nPlayerCount = PlayerManager.GetPlayerCount();

        m_nHungerValues = new float[4];

        m_gameOverText = m_gameOverTextObj.GetComponent<Text>();

        for (int i = 0; i < m_fullHungerBars.Length; ++i)
        {
            m_fullHungerBars[i].fillAmount = 0;
        }

        // Disable unused widgets.
        for(int i = 3; i > m_nPlayerCount - 1; --i)
        {
            m_hungerBars[i].SetActive(false);
        }

        m_manager = GetComponent<PlayerManager>();
	}

    private void Update()
    {
        m_fGOInputDelayCurrent -= Time.unscaledDeltaTime;

        m_gameOverEvents.enabled = m_fGOInputDelayCurrent < 0.0f;

        if(!m_bGOButtonSet && m_gameOverEvents.enabled)
        {
            m_gameOverEvents.SetSelectedGameObject(m_gameOverRestartButton);

            m_bGOButtonSet = true;
        }
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

            m_pauseScript.SetLocked(true);

            m_inGameUI.SetActive(false);
            m_gameOverUI.SetActive(true);

            // Since a player has reached full hunger, it is game over.
            m_fGOInputDelayCurrent = m_fGOInputDelay;

            m_gameOverPanel.SetActive(true);
            m_gameOverTextObj.SetActive(true);
            m_gameOverText.text = "Player " + (nPlayerIndex + 1) + " is victorious!";

            Time.timeScale = 0.0f;
        }
        else
        {
            m_nHungerValues[nPlayerIndex] = nNewHunger;
        }

        // Set x value based on hunger value.
        m_fullHungerBars[nPlayerIndex].fillAmount = m_nHungerValues[nPlayerIndex] / m_nMaxHungerValue;
    }

    // Used by the lobby GUI to set the player count that is carried on between scenes.
    public static void SetPlayerCount(int nPlayerCount)
    {
        m_nPlayerCount = nPlayerCount;
    }

    public void PlayAgainButton()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;

        m_sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(m_sceneName);
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1.0f;

        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
