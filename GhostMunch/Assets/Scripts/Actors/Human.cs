using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    RequireComponent(typeof(PlayerInput)),
    RequireComponent(typeof(PlayerMovement)),
    RequireComponent(typeof(CharacterController)),
    RequireComponent(typeof(AudioSource))
]

public class Human : MonoBehaviour
{
    // This object.
    [Header("Display")]
    public GameObject m_pointer;
    public Animator m_animationController;

    // Audio
    [Header("Audio")]
    public AudioClip[] m_footsteps;
    public AudioClip m_hitClip;
    [Tooltip("The amount of time waited between footstep sounds when running.")]
    public float m_fFootstepInterval;
    public float m_fMinPitch = 0.8f;
    public float m_fMaxPitch = 1.0f;

    // This object.
    private PlayerInput m_input;
    private PlayerMovement m_movement;
    private CharacterController m_controller;
    private AudioSource m_audio;
    private bool m_bPossessed;
    private float m_fFootstepTime;
    

    // Possessor
    private Player m_ownerPScript;

    // Determines if the human is susceptible to posession.
    private bool m_bSusceptible;

    // If the human was hit this frame
    bool m_bIsHit = false;

    // Use this for initialization
    void Awake()
    {
        m_input = GetComponent<PlayerInput>();
        m_movement = GetComponent<PlayerMovement>();
        m_controller = GetComponent<CharacterController>();
        m_audio = GetComponent<AudioSource>();

        // Human starts off not possessed, and simply dead on the floor.
        m_input.enabled = false;
        m_movement.enabled = false;
        m_bSusceptible = true;

        m_fFootstepTime = m_fFootstepInterval;
	}
	
	// Update is called once per frame
	void Update()
    {
        // Ensure ghost player is at the same position as the human for the camera.
        if(m_ownerPScript != null)
        {
            m_ownerPScript.gameObject.transform.position = transform.position;

            // Footstep effects.
            m_fFootstepTime -= m_movement.GetMovementMagnitude() * Time.deltaTime;

            if (m_audio != null && m_fFootstepTime <= 0.0f)
            {
                // Play random sound from footstep sound array.
                int nRandSoundIndex = Random.Range(0, m_footsteps.Length);
                float fRandPitch = Random.Range(m_fMinPitch, m_fMaxPitch);

                m_audio.pitch = fRandPitch;
                m_audio.PlayOneShot(m_footsteps[nRandSoundIndex]);

                // Reset timer.
                m_fFootstepTime = m_fFootstepInterval;
            }
        }

        //Set animation walk speed
        m_animationController.SetFloat("Speed", m_movement.GetMovementMagnitude());

        m_animationController.SetBool("IsHit", m_bIsHit);

        m_animationController.SetBool("IsPossessed", m_bPossessed);
        
    }

    public void OnStep(int _foot)
    {
        Debug.Log("OnStep!!");
    }

    private void LateUpdate()
    {
        m_animationController.SetBool("IsEating", false);
        m_bIsHit = false;
    }

    public void OnEat()
    {
        m_animationController.SetBool("IsEating", true);
    }

    // Returns if the Human is susceptible to getting possessed.
    public bool GetIsSusceptible()
    {
        return m_bSusceptible;
    }

    /*
    Description: Set the owner of the human (who takes control of him).
    Params:
        int nIndex: The PlayerIndex of the player to take control.
    */
    public void SetOwner(Player ownerPScript, PlayerInput ownerInput, int nIndex)
    {
        // Set owner script.
        m_ownerPScript = ownerPScript;

        // Human is no longer susceptible.
        m_bSusceptible = false;

        // Set player index for input.
        m_input.SetPlayer((XInputDotNetPure.PlayerIndex)nIndex);

        // Enable human input script.
        m_input.enabled = true;
        m_input.m_bUseKeyboard = ownerInput.m_bUseKeyboard;
        m_movement.enabled = true;
        m_controller.enabled = true;

        // Enable look pointer.
        m_pointer.SetActive(true);
    }

    public void Separate(Vector3 v3PropDirectopn)
    {
        if (m_bSusceptible)
            return;

        // Disable human player controls.
        m_input.enabled = false;
        m_movement.enabled = false;
        m_bSusceptible = true;

        // Kick player out of human.
        m_ownerPScript.KickFromHuman(v3PropDirectopn);

        // Disable look pointer.
        m_pointer.SetActive(false);

        m_ownerPScript = null;

        // Play hit sound.
        if (m_hitClip != null)
            m_audio.PlayOneShot(m_hitClip);

        m_bIsHit = true;

    }

    // Sets whether or not the human is currently unavailable due to being possessed.
    public void SetPossessed(bool bPossessed)
    {
        m_bPossessed = bPossessed;
    }

    // Returns whether or not the human is currently unavailable due to being possessed.
    public bool GetPossessed()
    {
        return m_bPossessed;
    }

    public void AddToScore(int nScore)
    {
        m_ownerPScript.AddToScore(nScore);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    // Detect food items and query if they are within eating range. If they are within range, eat them.
    //    if (other.gameObject.tag == "Food" && m_ownerPScript != null)
    //    {
    //        // Get food item script.
    //        FoodScript script = other.GetComponent<FoodScript>();
    //
    //        // Eat item and add score.
    //        script.Eat();
    //        m_ownerPScript.AddToScore(script.GetScoreValue());
    //    }
    //}
}
