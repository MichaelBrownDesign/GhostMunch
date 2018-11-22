using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepParticle : MonoBehaviour
{
    public ParticleSystem m_PSFootstepLeft;
    public ParticleSystem m_PSFootstepRight;

    public int m_ParticlesPerStep = 10;

    AudioSource m_AudioSource;

    public List<AudioClip> m_FootstepSoundEffects;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void OnStep(int _foot)
    {
        if (_foot == 0)
        {
            m_PSFootstepLeft.Emit(m_ParticlesPerStep);
        }
        else
        {
            m_PSFootstepRight.Emit(m_ParticlesPerStep);
        }

        m_AudioSource.PlayOneShot(m_FootstepSoundEffects[Random.Range(0, m_FootstepSoundEffects.Count-1)]);

    }
}
