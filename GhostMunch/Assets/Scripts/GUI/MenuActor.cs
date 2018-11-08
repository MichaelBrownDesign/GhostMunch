﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class MenuActor : MonoBehaviour
{
    public Scene[] scenes;

    public GameObject m_lobbyCanvas;
    public GameObject m_optionsGUI;

    public GameObject m_mainMenuGUI;

    [Header("Audio")]
    public AudioClip m_audioOnPlay;
    public AudioClip m_audioOnOptions;
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

    public void OnOptionsClick()
    {
        if (m_audioOnPlay != null)
            m_audioSource.PlayOneShot(m_audioOnOptions);

        m_optionsGUI.SetActive(true);
        m_mainMenuGUI.SetActive(false);
    }

    public void Quit()
    {
        if (m_audioOnQuit != null)
            m_audioSource.PlayOneShot(m_audioOnQuit);

        Application.Quit();
    }

    
}
