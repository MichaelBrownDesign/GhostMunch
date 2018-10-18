using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PauseMenu : MonoBehaviour {

    public GameObject pausePanel;
   
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("escape") && !pausePanel.activeSelf || Input.GetKeyDown("w") && !pausePanel.activeSelf)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else if (Input.GetKeyDown("escape") && pausePanel.activeSelf || Input.GetKeyDown("w") && pausePanel.activeSelf)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1.0f;
        }	    
	}

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void LoadScene(string scene_Name)
    {
        SceneManager.LoadScene(scene_Name);
        Time.timeScale = 1.0f;
    }
}
