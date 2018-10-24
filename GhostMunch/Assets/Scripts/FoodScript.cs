using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]

public class FoodScript : MonoBehaviour
{
    // Effects
    [Header("Effects")]
    public GameObject m_eatEffect;

    // Respawning
    [Header("Respawning")]
    public float m_fRespawnTime;

    private float m_fCurrentRspwnTime;
    private bool m_bEaten;

    [Header("Score")]
    public int m_nScoreValue;

    [Header("Audio")]
    public AudioClip m_audioOnEat;
    private AudioSource m_audioSource;

    // Self
    private MeshRenderer m_renderer;
    private Collider m_collider;
    private Vector3 m_v3RespawnPosition;
    private GameObject m_eatEffectInstance;
    private ParticleSystem m_eatPS;

	// Use this for initialization
	void Awake()
    {
        m_renderer = GetComponentInChildren<MeshRenderer>();

        // If the renderer is not on a child, then it should be on the food object itself.
        if (m_renderer == null)
            m_renderer = GetComponent<MeshRenderer>();

        m_collider = GetComponent<Collider>();

        m_v3RespawnPosition = transform.position;

        // Get instance of particle effect.
        m_eatEffectInstance = Instantiate(m_eatEffect);

        // Get particle instance component.
        m_eatPS = m_eatEffectInstance.GetComponent<ParticleSystem>();

        // Parent eat effect to food item and set local position to zero.
        m_eatEffectInstance.transform.SetParent(transform);
        m_eatEffectInstance.transform.localPosition = Vector3.zero;

        m_audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // Respawning...
        m_fCurrentRspwnTime -= Time.deltaTime;

        if(m_bEaten && m_fCurrentRspwnTime < 0.0f)
        {
            // Undo changes made from Eat() function call.

            m_renderer.enabled = true;
            m_collider.enabled = true;

            m_bEaten = false;

            // Reset position to respawn position.
            transform.position = m_v3RespawnPosition;
        }
	}

    // Get the score value of the food item.
    public int GetScoreValue()
    {
        return m_nScoreValue;
    }

    // Destroy object as it has been eaten and initialize respawn process.
    public void Eat()
    {
        // Disable collision and rendering.
        m_renderer.enabled = false;
        m_collider.enabled = false;

        // Emmitt particles.
        m_eatPS.Play();
        
        // play eaten sound
        if(m_audioOnEat != null)
            m_audioSource.PlayOneShot(m_audioOnEat);

        // Mark as eaten.
        m_bEaten = true;

        // Reset respawn timer.
        m_fCurrentRspwnTime = m_fRespawnTime;
    }
}
