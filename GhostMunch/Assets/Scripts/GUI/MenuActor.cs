using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuActor : MonoBehaviour
{
    public Scene[] scenes;
    

    public GameObject m_lobbyCanvas;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayClick()
    {
        // Swap between main menu and lobby interfaces.
        m_lobbyCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    
}
