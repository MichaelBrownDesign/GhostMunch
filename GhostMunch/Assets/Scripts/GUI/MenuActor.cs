using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]

public class MenuActor : MonoBehaviour
{
    public Scene[] scenes;

    public GameObject m_lobbyCanvas;
    public GameObject m_helpGUI;
    public GameObject m_creditsGUI;

    public GameObject m_mainMenuGUI;

    [Header("Audio")]
    public AudioClip m_audioOnPlay;
//    public AudioClip m_audioOnOptions;
    public AudioClip m_audioOnQuit;
    private AudioSource m_audioSource;


    // Use this for initialization
    void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnPlayClick()
    {
        // Swap between main menu and lobby interfaces.
        if (m_audioOnPlay != null)
            m_audioSource.PlayOneShot(m_audioOnPlay);
        
        m_lobbyCanvas.SetActive(true);
        m_mainMenuGUI.SetActive(false);
        //gameObject.SetActive(false);
    }

    public void OnHelpClick()
    {
//       if (m_audioOnPlay != null)
//            m_audioSource.PlayOneShot(m_audioOnOptions);

        m_helpGUI.SetActive(true);
        m_mainMenuGUI.SetActive(false);
    }

    public void OnCreditsClick()
    {
        m_creditsGUI.SetActive(true);
        m_mainMenuGUI.SetActive(false);
    }

    public void OnBackClick()
    {
        m_mainMenuGUI.SetActive(true);
        m_creditsGUI.SetActive(false);
    }

    public void Quit()
    {
        if (m_audioOnQuit != null)
            m_audioSource.PlayOneShot(m_audioOnQuit);

        Application.Quit();
    }

    
}
