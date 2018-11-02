using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Eating")]
    public float m_fMashStrength = 0.3f;
    public float m_fEatRadius = 2.0f;
    public float m_fUndoRate = 0.2f;
    public GameObject m_eatUIPrefab;

    [Header("GUI")]
    private GameObject m_eatUIInstance;
    private Transform m_eatUINode;
    private RectTransform[] m_eatUIImages;
    private Image m_progressImage;
    private float m_fEatProgress;

    // Self
    private MeshRenderer m_renderer;
    private Collider m_collider;
    private Vector3 m_v3RespawnPosition;
    private GameObject m_eatEffectInstance;
    private ParticleSystem m_eatPS;

    // Human
    private GameObject m_human;
    private PlayerInput m_humanInput;
    private Human m_humanScript;

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

        m_human = GameObject.FindGameObjectWithTag("Human");
        m_humanInput = m_human.GetComponent<PlayerInput>();
        m_humanScript = m_human.GetComponent<Human>();

        m_eatUIInstance = Instantiate(m_eatUIPrefab);
        m_eatUIInstance.transform.position = transform.position;
        m_eatUIInstance.SetActive(false);

        m_eatUINode = m_eatUIInstance.transform.GetChild(1);

        m_eatUIImages = new RectTransform[3];

        for(int i = 0; i < 3; ++i)
        {
            m_eatUIImages[i] = m_eatUIInstance.transform.GetChild(0).transform.GetChild(i).GetComponent<RectTransform>();
        }

        m_progressImage = m_eatUIInstance.GetComponentsInChildren<Image>()[1];
    }

    // Update is called once per frame
    void Update()    {
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

        // Eating...
        float fDistFromHuman = Vector3.Distance(m_human.transform.position, transform.position);

        if (fDistFromHuman < m_fEatRadius && !m_bEaten)
        {
            // Scale eat UI based on camera zoom.
            float fCamZoomfactor = CameraMovement.GetZoomFactor() / 9.0f;

            m_eatUIInstance.transform.localScale = new Vector3(fCamZoomfactor, fCamZoomfactor, 1.0f);

            // Ensure eat UI is shown when within the eat radius.
            if(!m_eatUIInstance.activeInHierarchy)
                m_eatUIInstance.SetActive(true);

            m_eatUIInstance.transform.position = transform.position;

            Vector3 v3ScreenSpaceUIPos = Camera.main.WorldToScreenPoint(m_eatUINode.transform.position);
            for(int i = 0; i < 3; ++i)
            {
                m_eatUIImages[i].position = v3ScreenSpaceUIPos;
            }

            // Check for input.
            bool bInputPassed = (!m_humanInput.m_bUseKeyboard && m_humanInput.GetButton(0))
                || (m_humanInput.m_bUseKeyboard && m_humanInput.GetButton(2));

            if (bInputPassed)
            {
                m_fEatProgress += m_fMashStrength;

                // If the eat progress has maxed out the food is eaten. Add to score and despawn this food item.
                if(m_fEatProgress >= 1.0f)
                {
                    m_humanScript.AddToScore(m_nScoreValue);
                    Eat();
                }
            }
        }
        else
        {
            // Disable UI when the human is outside of the radius.
            if (m_eatUIInstance.activeInHierarchy)
                m_eatUIInstance.SetActive(false);
        }

        // Count down eat progress and ensure it never reaches below zero.
        m_fEatProgress -= Time.deltaTime * m_fUndoRate;

        if (m_fEatProgress < 0.0f)
            m_fEatProgress = 0.0f;

        m_progressImage.fillAmount = m_fEatProgress;
	}

    // Get the score value of the food item.
    public int GetScoreValue()
    {
        return m_nScoreValue;
    }

    // Destroy object as it has been eaten and initialize respawn process.
    public void Eat()
    {
        // Disable UI
        m_eatUIInstance.SetActive(false);

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

        // Reset eat progress.
        m_fEatProgress = 0.0f;
    }
}
