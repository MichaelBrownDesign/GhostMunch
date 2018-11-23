using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XInputDotNetPure;

[RequireComponent(typeof(AudioSource))]

public class PauseMenu : MonoBehaviour {

    public GameObject m_pausePanel;
    public GameObject m_resumeButton;
    public GameObject m_inGameGUI;
    public GameObject m_helpGUI;
    public GameObject m_pauseGUI;
    public EventSystem m_events;
    private bool m_bPaused;
    private bool m_bLocked;

    [Header("Audio")]

    public AudioClip m_audioOnResume;
    public AudioClip m_audioOnRestart;
//    public AudioClip m_audioOnOptions;
    public AudioClip m_audioOnMainMenu;

    private AudioSource m_audioSource;

    private string m_sceneName;

    // Use this for initialization
    void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();

        m_bLocked = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (m_bPaused && m_events.currentSelectedGameObject == null)
        {
            m_events.SetSelectedGameObject(m_resumeButton);
        }

        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            SetPaused(!GetIsPaused());
        }
    }

    public void Resume()
    {
        if (m_audioOnResume != null)
            m_audioSource.PlayOneShot(m_audioOnResume);

        SetPaused(false);
    }

    public void RestartButton()
    {
        m_sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(m_sceneName);
        
        SetPaused(false);


    }

    public void HelpButton()
    {
        m_helpGUI.SetActive(true);
        m_inGameGUI.SetActive(false);
        m_pauseGUI.SetActive(false);

        m_bLocked = true;
    }

    public void MainMenuButton()
    {
        SetPaused(false);
        SceneManager.LoadScene(0);
    }

    public void LoadScene(string scene_Name)
    {
        SceneManager.LoadScene(scene_Name);
        Time.timeScale = 1.0f;
    }

    public void SetPaused(bool bPause)
    {
        if (m_bLocked)
            return;

        m_bPaused = bPause;

        Debug.Log("paused");

        if (bPause)
        {
            m_resumeButton.GetComponent<Button>().Select();
            m_pausePanel.SetActive(true);
            m_events.SetSelectedGameObject(null);
            Time.timeScale = 0.0f;
        }
        else
        {
            m_pausePanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public bool GetIsPaused()
    {
        return m_bPaused;
    }

    public void SetLocked(bool bLocked)
    {
        m_bLocked = bLocked;
    }

    public bool GetLocked()
    {
        return m_bLocked;
    }
}
