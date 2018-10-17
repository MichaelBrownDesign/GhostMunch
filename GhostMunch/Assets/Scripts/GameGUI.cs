using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour
{
    // Stats
    public int m_nMaxHungerValue;
    private float m_fBarWidth;
    private float[] m_nHungerValues;
    private int m_nPlayerCount;

    // Widgets
    [Header("Widgets")]
    public GameObject[] m_hungerBars;
    public GameObject m_gameOverPanel;
    public GameObject m_gameOverTextObj;
    private Text m_gameOverText;
    private RectTransform[] m_fullHungerBars;

	// Use this for initialization
	void Awake()
    {
        m_fullHungerBars = new RectTransform[4];
        m_nHungerValues = new float[4];

        m_gameOverText = m_gameOverTextObj.GetComponent<Text>();

        // Get hunger bar width...
        m_fBarWidth = m_hungerBars[0].GetComponent<RectTransform>().sizeDelta.x;

        // Get full hunger bars (Appearance of these will depend on player scores).
        for(int i = 0; i < 4; ++i)
        {
            m_fullHungerBars[i] = m_hungerBars[i].transform.GetChild(0).gameObject.GetComponent<RectTransform>();

            RectTransform barTransform = m_fullHungerBars[i].GetComponent<RectTransform>();

            barTransform.sizeDelta = new Vector2(0.0f, barTransform.sizeDelta.y);
        }

        // Disable unused widgets.
        for(int i = 3; i > m_nPlayerCount - 1; --i)
        {
            m_hungerBars[i].GetComponent<RectTransform>().localScale = Vector3.zero;
            m_fullHungerBars[i].GetComponent<RectTransform>().localScale = Vector3.zero;
        }
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

    public void SetPlayerCount(int nPlayerCount)
    {
        m_nPlayerCount = nPlayerCount;
    }
}
