using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public PauseMenu m_pauseScript;

    public GameObject m_thisCanvas;
    public GameObject m_inGameGUICanvas;
    public GameObject m_mainMenuCanvas;

    // To exit the help menu.


    public void BackButton()
    {
        m_mainMenuCanvas.SetActive(true);

        if (m_inGameGUICanvas)
            m_inGameGUICanvas.SetActive(true);

        m_thisCanvas.SetActive(false);

        m_pauseScript.SetLocked(false);
    }
}
