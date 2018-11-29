using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Possessible : MonoBehaviour
{
    public float m_fRespawnTime;

    // Particle effects
    [Header("Effects")]
    public GameObject m_possessEffect;
    public GameObject m_breakEffect;

    public Material m_material;
    private ParticleSystem m_possessEffectInst;
    private ParticleSystem m_breakEffectInst;

    // Object flight
    [Header("Flight")]
    public Collider m_thrownCollider;
    public float m_fHeightOffset;
    public float m_fRotationSpeed = 5.0f;
    public bool m_bRotateX = true;
    public bool m_bRotateY = true;
    public bool m_bRotateZ = true;

    private float m_fThrowZOffset;

    //audio
    [Header("Audio")]
    public AudioClip m_audioOnBreak;
    private AudioSource m_audioSource;    
    
    // Self
    private Rigidbody m_rigidbody;
    private Collider m_collider;
    private MeshRenderer m_renderer;

    private Vector3 m_v3RespawnPosition;
    private Quaternion m_respawnRotation;
    private Vector3 m_v3ThrowDirection;
    private float m_fCurrentRespawnTimer;
    private float m_fPossessFade;
    private float m_fCurrentPossessFade;
    private bool m_bThown;
    private bool m_bPossessed;

    // Human
    private GameObject m_human;
    private Human m_humanScript;

    // Ghost
    private CharacterController m_ownerController;

    List<Transform> m_Children;

    // Use this for initialization
    void Awake()
    {
        m_renderer = GetComponentInChildren<MeshRenderer>();
        m_rigidbody = GetComponent<Rigidbody>();
        m_collider = GetComponent<Collider>();

        m_fThrowZOffset = m_collider.bounds.extents.z;

        m_human = GameObject.FindGameObjectWithTag("Human");
        m_humanScript = m_human.GetComponent<Human>();

        m_v3RespawnPosition = transform.position;
        m_respawnRotation = transform.rotation;
        m_fCurrentRespawnTimer = m_fRespawnTime;

        if (m_possessEffect != null)
        {
            m_possessEffectInst = Instantiate(m_possessEffect).GetComponent<ParticleSystem>();
            m_possessEffectInst.gameObject.transform.parent = transform;
        }

        if (m_breakEffect != null)
        {
            m_breakEffectInst = Instantiate(m_breakEffect).GetComponent<ParticleSystem>();
            m_breakEffectInst.gameObject.transform.parent = transform;
        }

        m_audioSource = GetComponent<AudioSource>();

        Material[] allMats = m_renderer.materials;

        for(int i = 0; i < allMats.Length; ++i)
        {
            if(allMats[i].name.Contains("M_Prop"))
            {
                m_material = allMats[i];
                break;
            }
        }

        m_Children = new List<Transform>();
        for(int i = 0; i < transform.childCount; ++i)
        {
            m_Children.Add(transform.GetChild(i));
        }
	}
	
	// Update is called once per frame
	void Update()
    {
        m_fCurrentRespawnTimer -= Time.deltaTime;

        if(m_fCurrentRespawnTimer <= 0.0f && m_bThown)
        {
            // Respawn...
            Respawn();
        }

        m_fCurrentPossessFade = Mathf.Lerp(m_fCurrentPossessFade, m_fPossessFade, 0.1f);
        if (m_material != null)
            m_material.SetFloat("_Possessed", m_fCurrentPossessFade);
    }

    // Marks this object as thrown so it will respawn after colliding.
    public void SetThown(CharacterController ownerController, Vector3 v3ThrowDir)
    {
        // Set player colliders. (Used for respawning)
        m_ownerController = ownerController;

        // Mark as thown.
        m_bThown = true;

        // Set collision layer to "Flying Prop"
        gameObject.layer = 13;

        // Set throw direction used for knock-out knockback.
        m_v3ThrowDirection = v3ThrowDir;

        // Set respawn timer.
        m_fCurrentRespawnTimer = 5.0f;

        // Disable possessed effect.
        m_fPossessFade = 0.0f;

        // Swap colliders.
        if (m_thrownCollider != null)
        {
            m_collider.enabled = false;
            m_thrownCollider.enabled = true;
        }
        else
        {
            m_collider.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(m_bThown)
        {
            m_fCurrentRespawnTimer = m_fRespawnTime;
            m_rigidbody.isKinematic = true;
            m_renderer.enabled = false;
            m_collider.enabled = false;

            foreach(Transform child in m_Children)
            {
                child.gameObject.SetActive(false);
            }

            if (m_thrownCollider != null)
                m_thrownCollider.enabled = false;

            if(m_breakEffect != null)
            {
                // Play break effect.
                m_breakEffectInst.gameObject.transform.position = transform.position;
                m_breakEffectInst.Play();

                //play break audio
                if(m_audioOnBreak != null)
                    m_audioSource.PlayOneShot(m_audioOnBreak);
            }

            // Separate ghost from human if the collision is with the human.
            if(collision.gameObject == m_human)
            {
                m_humanScript.Separate(m_v3ThrowDirection);
            }
        }
    }

    private void Respawn()
    {
        // Reset position and rotation.
        transform.position = m_v3RespawnPosition;
        transform.rotation = m_respawnRotation;

        // Re-enable collisions between previous owner and this object.
        Physics.IgnoreCollision(m_ownerController, m_collider, false);

        // Enable gravity and reset velocity.
        m_rigidbody.useGravity = true;
        m_rigidbody.isKinematic = false;
        m_rigidbody.velocity = Vector3.zero;
        m_rigidbody.angularVelocity = Vector3.zero;

        // Enable rendering.
        m_renderer.enabled = true;

        // Mark as possessed no longer.
        m_bPossessed = false;

        // Mark as thrown no longer.
        m_bThown = false;

        // Reset colliders.
        SwapColliders();

        // Reset collision layer to default.
        gameObject.layer = 11;

        foreach (Transform child in m_Children)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void SwapColliders()
    {
        m_collider.enabled = !m_collider.enabled;
        if (m_collider != null && m_thrownCollider != null)
        {
            m_thrownCollider.enabled = !m_thrownCollider.enabled;
        }
    }

    // Sets whether or not the human is currently unavailable due to being possessed.
    public void SetPossessed(bool bPossessed)
    {
        m_bPossessed = bPossessed;

        if(bPossessed && m_possessEffect != null)
        {
            // Play Possession effect.
            m_possessEffectInst.gameObject.transform.position = transform.position;
            m_possessEffectInst.Play();

            // Enable shader effect.
            m_fPossessFade = 1.0f;
        }
        else if(m_material != null)
        {
            m_fPossessFade = 0.0f;
        }
    }

    // Returns whether or not the human is currently unavailable due to being possessed.
    public bool GetPossessed()
    {
        return m_bPossessed;
    }

    // Returns a vector representing what axes are used for throw rotation.
    public Vector3 GetRotations()
    {
        Vector3 v3Result = Vector3.zero;

        if (m_bRotateX)
            v3Result.x = 1.0f;

        if (m_bRotateY)
            v3Result.y = 1.0f;

        if (m_bRotateZ)
            v3Result.z = 1.0f;

        return v3Result;
    }

    public float GetHeightOffset()
    {
        return m_fHeightOffset;
    }

    public float GetRotationSpeed()
    {
        return m_fRotationSpeed;
    }

    public float GetThrowZOffset()
    {
        return m_fThrowZOffset;
    }

    public void SetEffectFloat(bool bRunEffect)
    {
        if(bRunEffect)
        {
            m_fPossessFade = 1.0f;
        }
        else
        {
            m_fPossessFade = 0.0f;
        }
    }
}
