using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XInputDotNetPure;


public class PauseMenu : MonoBehaviour {

    public GameObject pausePanel;
    private bool m_bPaused;

	// Use this for initialization
	void Awake()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
          
	}

    public void Resume()
    {
        SetPaused(false);
    }

    public void LoadScene(string scene_Name)
    {
        SceneManager.LoadScene(scene_Name);
        Time.timeScale = 1.0f;
    }

    public void SetPaused(bool bPause)
    {
        m_bPaused = bPause;
        pausePanel.SetActive(m_bPaused);

        if (bPause)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
    }

    public bool GetIsPaused()
    {
        return m_bPaused;
    }
}
