using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSoundEvent : MonoBehaviour
{
	public AudioClip m_Thunder1;
	public float m_Delay1 = 0.0f;

	public AudioClip m_Thunder2;
	public float m_Delay2 = 0.0f; 

	AudioSource m_Source;

	void Start()
	{
		m_Source = GetComponent<AudioSource> ();
	}

	void Play1()
	{
		m_Source.PlayOneShot (m_Thunder1);
	}

	void Play2()
	{
		m_Source.PlayOneShot (m_Thunder2);
	}

	public void PlaySound()
	{
		Invoke ("Play1", m_Delay1);
		Invoke ("Play2", m_Delay2);
	}
}
