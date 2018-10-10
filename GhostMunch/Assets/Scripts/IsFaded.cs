using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFaded : MonoBehaviour
{
    private Material m_fadeMat;
    private float m_fFadeLevel;

    private void Awake()
    {
        m_fFadeLevel = 1.1f;

        m_fadeMat = GetComponent<Renderer>().material;
    }

    /*
    Description: Sets whether or not the object is fading or returning. 
    Params:
        bool bFading: Whether or not the object will fade.
    */
    public void SetFade(bool bFading)
    {
        if(bFading)
        {
            StartCoroutine(FadingOut());
        }
        else
        {
            StartCoroutine(FadingIn());
            StopCoroutine(FadingOut());
        }
    }

    // Used to change the value of dissolve percentage over time
    IEnumerator FadingOut()
    {
        m_fFadeLevel -= 0.05f;
        m_fadeMat.SetFloat("_ClipThreshold", m_fFadeLevel);

        if (m_fFadeLevel <= 0.0f)
        {
            StartCoroutine(FadingIn());
        }
            
        yield return new WaitForSeconds(0.01f);
    }

    IEnumerator FadingIn()
    {
        m_fFadeLevel += 0.1f;
        m_fadeMat.SetFloat("_ClipThreshold", m_fFadeLevel);
        yield return new WaitForSeconds(0.01f);

    }
}
