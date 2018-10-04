using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possessible : MonoBehaviour
{
    public float m_fRespawnTime;


    private Rigidbody m_rigidbody;
    private Collider m_collider;
    private MeshRenderer m_renderer;

    private Vector3 m_v3RespawnPosition;
    private float m_fCurrentRespawnTimer;
    private bool m_bThown;

    private GameObject m_human;
    private Human m_humanScript;

    private CharacterController m_ownerController;
    private BoxCollider m_ownerDetector;

    // Use this for initialization
    void Awake()
    {
        m_renderer = GetComponent<MeshRenderer>();
        m_rigidbody = GetComponent<Rigidbody>();
        m_collider = GetComponent<Collider>();

        m_human = GameObject.FindGameObjectWithTag("Human");
        m_humanScript = m_human.GetComponent<Human>();

        m_v3RespawnPosition = transform.position;
        m_fCurrentRespawnTimer = m_fRespawnTime;
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
	}

    // Marks this object as thrown so it will respawn after colliding.
    public void SetThown(CharacterController ownerController, BoxCollider ownerDetector)
    {
        // Set player colliders. (Used for respawning)
        m_ownerController = ownerController;
        m_ownerDetector = ownerDetector;

        // Mark as thown.
        m_bThown = true;

        // Set respawn timer.
        m_fCurrentRespawnTimer = 5.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(m_bThown)
        {
            m_fCurrentRespawnTimer = m_fRespawnTime;
            m_rigidbody.isKinematic = true;
            m_renderer.enabled = false;

            // Separate ghost from human if the collision is with the human.
            if(collision.gameObject == m_human)
            {
                m_humanScript.Separate();
            }
        }
    }

    private void Respawn()
    {
        // Reset position and rotation.
        transform.position = m_v3RespawnPosition;
        transform.rotation = Quaternion.Euler(Vector3.zero);

        // Re-enable collisions between previous owner and this object.
        Physics.IgnoreCollision(m_ownerController, m_collider, false);
        Physics.IgnoreCollision(m_ownerDetector, m_collider, false);

        // Enable gravity and reset velocity.
        m_rigidbody.useGravity = true;
        m_rigidbody.isKinematic = false;
        m_rigidbody.velocity = Vector3.zero;
        m_rigidbody.angularVelocity = Vector3.zero;

        // Enable rendering.
        m_renderer.enabled = true;

        // Mark as thrown no longer.
        m_bThown = false;
    }
}
