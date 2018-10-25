﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XInputDotNetPure;


public class PauseMenu : MonoBehaviour {

    public GameObject m_pausePanel;
    public GameObject m_resumeButton;
    public EventSystem m_events;
    private bool m_bPaused;

	// Use this for initialization
	void Awake()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_bPaused && m_events.currentSelectedGameObject == null)
        {
            m_events.SetSelectedGameObject(m_resumeButton);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPaused(!GetIsPaused());
        }
    }

    public void Resume()
    {
        SetPaused(false);
    }

    public void RestartButton()
    {
        SetPaused(false);
        SceneManager.LoadScene(1);
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
        m_bPaused = bPause;
        //    pausePanel.SetActive(m_bPaused);


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
}
