using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepParticle : MonoBehaviour
{
    public ParticleSystem m_PSFootstepLeft;
    public ParticleSystem m_PSFootstepRight;

    public int m_ParticlesPerStep = 10;

    public void OnStep(int _foot)
    {
        if(_foot == 0)
        {
            m_PSFootstepLeft.Emit(m_ParticlesPerStep);
        }
        else
        {
            m_PSFootstepRight.Emit(m_ParticlesPerStep);
        }
        Debug.Log("OnStep: " + _foot.ToString());

    }
}
