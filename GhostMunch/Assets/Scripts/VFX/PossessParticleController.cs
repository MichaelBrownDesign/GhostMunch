using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessParticleController : MonoBehaviour {

    public ParticleSystem[] m_effects;
    public float m_fDuration = 1.0f;

    private float m_fCurrentDuration;

	// Use this for initialization
	void Awake ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_fCurrentDuration += Time.deltaTime;

        if(m_fCurrentDuration >= m_fDuration)
        {
            // Stop effects.
            for(int i = 0; i < m_effects.Length; ++i)
            {
                m_effects[i].Stop();
            }

            // Disable to stop update overhead.
            enabled = false;
        }
	}

    public void PlayEffects()
    {
        // Enable script to enable Update() calls.
        enabled = true;

        // Play effects.
        for (int i = 0; i < m_effects.Length; ++i)
        {
            m_effects[i].Play();
        }
    }
}
