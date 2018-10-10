using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFaded : MonoBehaviour
{
    private Material m_fadeMat;
    private float m_fFadeLevel;
    private bool m_bFading;

    private void Awake()
    {
        m_fFadeLevel = 1.1f;

        m_fadeMat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if(!m_bFading)
        {
            m_fFadeLevel += Time.deltaTime;
            m_fadeMat.SetFloat("_ClipThreshold", m_fFadeLevel);

            if (m_fFadeLevel >= 1.1f)
            {
                m_bFading = false;
                enabled = false;
            } 
        }

        m_bFading = false;
    }

    /*
    Description: Sets whether or not the object is fading or returning. 
    Params:
        bool bFading: Whether or not the object will fade.
    */
    public void FadeOut()
    {
        enabled = true;
        m_bFading = true;

        if(m_fFadeLevel > 0.0f)
            m_fFadeLevel -= Time.deltaTime;

        m_fadeMat.SetFloat("_ClipThreshold", m_fFadeLevel);
    }

    // Used to change the value of dissolve percentage over time
    //IEnumerator FadingOut()
    //{
    //    m_fFadeLevel -= 0.05f;
    //    m_fadeMat.SetFloat("_ClipThreshold", m_fFadeLevel);
    //
    //    if (m_fFadeLevel <= 0.0f)
    //    {
    //        StartCoroutine(FadingIn());
    //    }
    //
    //    yield return new WaitForSeconds(0.01f);
    //}
    //
    //IEnumerator FadingIn()
    //{
    //    m_fFadeLevel += 0.1f;
    //    m_fadeMat.SetFloat("_ClipThreshold", m_fFadeLevel);
    //    yield return new WaitForSeconds(0.01f);
    //
    //}
}
