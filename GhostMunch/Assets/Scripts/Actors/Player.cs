using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[
RequireComponent(typeof(MeshRenderer)),
RequireComponent(typeof(PlayerInput)),
RequireComponent(typeof(PlayerMovement)),
RequireComponent(typeof(CharacterController)),
RequireComponent(typeof(BoxCollider)),
RequireComponent(typeof(AudioSource))
]

public class Player : MonoBehaviour
{
    // Score
    [Header("Score")]
    public int m_nScore;

    // Possession
    [Header("Possession")]
    public float m_fPossessionRange = 7.0f;

    private int m_nPossessionMask;

    // Throwing
    [Header("Throwing")]
    public float m_fThrowForce = 1.0f;
    public float m_fThrowCooldown = 0.5f;

    // Possession bobbing animation.
    [Header("Animation")]
    public GameObject m_pointer;
    public float m_fBobSpeed = 1.0f;
    public float m_fTiltSpeed = 1.0f;
    public float m_fBobMoveSpeedInc = 1.0f;
    public float m_fTiltMoveSpeedInc = 1.0f;
    public float m_fTiltStrength = 5.0f;

    private float m_fBobProgress;
    private float m_fTiltProgress;

    // Damage
    [Header("Damage")]
    public float m_fStunTime = 2.0f;
    public float m_fStunForce = 10.0f;
    private float m_fCurrentStunTime;
    private bool m_bStunned;

    // Audio
    [Header("Audio")]
    public AudioClip m_possessClip;
    public AudioClip m_throwClip;

    // Misc
    [Header("Misc")]
    public GameObject m_meshRoot;

    // This object.
    private PlayerInput m_input;
    private PlayerMovement m_movement;
    private CharacterController m_controller;
    private BoxCollider m_collider;
    private AudioSource m_audio;
    private float m_fCurrentThrowCD;
    private bool m_bIsPossessing;
    private int m_nID;

    // Possessed object.
    private GameObject m_possessedObj;
    private Possessible m_possessedScript;
    private Rigidbody m_objectRigidbody;
    private Collider m_objectCollider;
    private float m_fObjectHeight;

    // Human
    private GameObject m_human;
    private CharacterController m_humanController;
    private Human m_humanScript;

    // GUI
    GameGUI m_gui;

    // Misc
    public Material m_wallMat;
    private string m_shaderUniformHandle;

    // Use this for initialization
    void Awake()
    {
        m_input = GetComponent<PlayerInput>();
        m_movement = GetComponent<PlayerMovement>();
        m_controller = GetComponent<CharacterController>();
        m_collider = GetComponent<BoxCollider>();
        m_audio = GetComponent<AudioSource>();

        m_human = GameObject.FindGameObjectWithTag("Human");
        m_humanController = m_human.GetComponent<CharacterController>();
        m_humanScript = m_human.GetComponent<Human>();

        m_gui = GameObject.Find("GameGUI").GetComponent<GameGUI>();

        // Find player ID.
        m_nID = (int)m_input.m_ePlayerIndex;

        // Find all players...
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");

        bool bHasKeyboardPlayer = false;

        // Detect if any player is using the keyboard.
        for(int i = 0; i < allPlayers.Length; ++i)
        {
            if (allPlayers[i].GetComponent<PlayerInput>().m_bUseKeyboard)
                bHasKeyboardPlayer = true;
        }

        // If a player is using the keyboard and this is not that player. Add 1 to the ID.
        if (bHasKeyboardPlayer && !m_input.m_bUseKeyboard)
            m_nID++;

        // Set to player 4 for controller input if using keyboard.
        if (m_input.m_bUseKeyboard)
            m_input.m_ePlayerIndex = XInputDotNetPure.PlayerIndex.Four;

        // Set up possession layer mask.
        int nPossessibleLayer = 1 << 11;
        int nHumanLayer = 1 << 15;
        int nInteriorWall = 1 << 10;

        m_nPossessionMask = nPossessibleLayer | nHumanLayer | nInteriorWall;

        // Get wall shader position handle.
        if (m_wallMat)
            m_shaderUniformHandle = "_Player" + ((int)m_input.m_ePlayerIndex + 1) + "Pos";
    }

    // Update is called once per frame
    void Update()
    {
        // Update wall fade shader position.
        if (m_wallMat)
        {
            Vector4 v4ShaderPos = transform.position;
            m_wallMat.SetVector(m_shaderUniformHandle, v4ShaderPos);
        }

        // Posession input.
        bool bThrowInput = m_input.GetButton(2);
        bool bDropInput = m_input.GetButton(1);

        // Object throwing
        if (m_possessedObj != null)
        {
            if(m_bIsPossessing) // While lerping to the object to possess...
            {
                // Keep same Y position.
                float y = transform.position.y;

                transform.position = Vector3.Lerp(transform.position, m_possessedObj.transform.position, 0.2f);
                transform.position = new Vector3(transform.position.x, y, transform.position.z);

                float fDistanceToObj = Vector2.Distance
                (
                    new Vector2(m_possessedObj.transform.position.x, m_possessedObj.transform.position.z), 
                    new Vector2(transform.position.x, transform.position.z)
                );

                // Take control of object once within range.
                if(fDistanceToObj < 1.1f)
                {
                    if (m_possessedObj != m_human)
                        PossessObject();
                    else
                        PossessHuman();
                }
            }
            else if(m_possessedObj != m_human) // Runs while the object is possessed...
            {
                Vector3 v3LocalPos = m_possessedObj.transform.localPosition;
                Vector3 v3EulerRotation = m_possessedObj.transform.localRotation.eulerAngles;
                float fFinalPosY = 0.0f;
                float fFinalRotationZ = 0.0f;

                // Bobbing effect.
                if (m_movement.GetIsMoving())
                {
                    float fMovementMag = m_movement.GetMovementMagnitude();

                    // Animation progression...
                    m_fBobProgress += Time.deltaTime * m_fBobSpeed + (m_fBobMoveSpeedInc * fMovementMag);
                    m_fTiltProgress += Time.deltaTime * m_fTiltSpeed + (m_fTiltMoveSpeedInc * fMovementMag);

                    // Calculate sin values and apply animation to Pos Y.
                    fFinalPosY = Mathf.Lerp(v3LocalPos.y, Mathf.Sin(m_fBobProgress) * (m_fObjectHeight * 0.25f), 0.2f);

                    // Calculate sin of Z rotation and apply.
                    float fFinalRotation = Mathf.Sin(m_fTiltProgress) * m_fTiltStrength;

                    fFinalRotationZ = Mathf.LerpAngle(v3EulerRotation.z, fFinalRotation, 0.2f);

                    m_possessedScript.SetEffectFloat(true);

                    // Show pointer when the player is moving.
                    m_pointer.SetActive(true);
                }
                else
                {
                    fFinalPosY = Mathf.Lerp(v3LocalPos.y, -1.0f, 0.1f);
                    fFinalRotationZ = Mathf.LerpAngle(v3EulerRotation.z, 0.0f, 0.05f);
                    m_possessedScript.SetEffectFloat(false);

                    // Hide pointer when the player is still.
                    m_pointer.SetActive(false);
                }

                m_possessedObj.transform.localPosition = new Vector3(v3LocalPos.x, fFinalPosY, v3LocalPos.z);
                m_possessedObj.transform.localRotation = Quaternion.Euler(new Vector3(v3EulerRotation.x, v3EulerRotation.y, fFinalRotationZ));

                // Thowing input.

                if (m_possessedObj != m_human && bThrowInput)
                {
                    ThrowPossessed();
                }
                else if(m_possessedObj != m_human && bDropInput)
                {
                    DropPossessed();
                }
            }
        }

        // Thow cooldown.
        m_fCurrentThrowCD -= Time.deltaTime;

        m_fCurrentStunTime -= Time.deltaTime;

        // Player stunning
        if (m_fCurrentStunTime < 0.0f && m_bStunned)
        {
            // Unfreeze player input.
            m_movement.DisableInput(false);

            // No longer stunned.
            m_bStunned = false;
            m_input.enabled = true;

            m_movement.m_AnimationController.SetBool("IsStunned", false);

            // Can collide with human again.
            Physics.IgnoreCollision(m_controller, m_humanController, false);
        }
        
        // Possession detection.
        if(bThrowInput)
        {
            RaycastHit hit;
            RaycastHit humanRayHit;

            bool bHit = Physics.Raycast
            (
                transform.position - transform.forward + (Vector3.down * 0.7f),
                transform.forward,
                out hit,
                m_fPossessionRange,
                m_nPossessionMask
            );

            bool bHumanHit = Physics.Raycast
            (
                transform.position - transform.forward,
                transform.forward,
                out humanRayHit,
                m_fPossessionRange,
                m_nPossessionMask
            );

            if (bHumanHit)
            {
                if (humanRayHit.collider.gameObject == m_human && m_fCurrentThrowCD <= 0.0f && m_possessedObj == null)
                {
                    // Human cannot be possessed if there is another ghost in him that has not been knocked out.
                    if (m_humanScript.GetIsSusceptible())
                    {
                        PursuePossess(m_human);
                    }
                }
            }

            if (bHit)
            {
                Debug.DrawLine(transform.position + (Vector3.down * 0.8f), hit.point);

                // Detect targets using trigger collider and allow posession if the input and misc conditions are corret.
                if (hit.collider.tag == "Possessible" && m_possessedObj == null && m_fCurrentThrowCD <= 0.0f)
                {
                    PursuePossess(hit.collider.gameObject);
                }
            }
        }

        // Pause
        if(m_input.StartPressed())
        {
            PauseMenu pauseScript = m_gui.GetComponent<PauseMenu>();
            pauseScript.SetPaused(!pauseScript.GetIsPaused());
        }
    }

    /*
    Description: Initiate movement into object to possess.
    Params:
        GameObject obj: The object to pursue.
    */ 
    public void PursuePossess(GameObject obj)
    {
        if (m_possessedObj != null)
            return;

        m_possessedObj = obj;

        // Get possessible script of object. (Will be NULL for human).
        m_possessedScript = m_possessedObj.GetComponent<Possessible>();

        // If the object or human is already possessed, bail out.
        if((m_possessedScript != null && m_possessedScript.GetPossessed()) || (m_possessedObj == m_human && m_humanScript.GetPossessed()))
        {
            m_possessedObj = null;
            m_possessedScript = null;
            return;
        }

        if (m_possessedScript != null)
            m_possessedScript.SetPossessed(true);
        else
            m_humanScript.SetPossessed(true);
        
        m_objectCollider = m_possessedObj.GetComponent<Collider>();

        // Prevent object from colliding with it's thrower.
        Physics.IgnoreCollision(m_controller, m_objectCollider);

        // Mark player as possessing an object.
        m_bIsPossessing = true;

        // Disable player movement.
        m_movement.enabled = false;

        // Play possess sound.
        if (m_possessClip != null)
            m_audio.PlayOneShot(m_possessClip);
    }

    /*
    Description: Parent it to this object and enter possession state. 
    Params:
        GameObject obj: The object to possess.
    */
    public void PossessObject()
    {
        m_bIsPossessing = false;

        // Disable the player's meshes.
        m_meshRoot.SetActive(false);

        // Allow player movement again.
        m_movement.enabled = true;

        // Set object's parent to this and zero it's local offset.
        m_possessedObj.transform.SetParent(transform);
        m_possessedObj.transform.localPosition = Vector3.zero;
        m_possessedObj.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        // Get object's height for bobbing animation.
        m_fObjectHeight = m_objectCollider.bounds.extents.y;

        // Get object's rigidbody.
        m_objectRigidbody = m_possessedObj.GetComponent<Rigidbody>();

        // Disable object physics.
        m_objectRigidbody.isKinematic = true;

        // Disable object collider.
        m_objectCollider.enabled = false;

        // Reset throw cooldown.
        m_fCurrentThrowCD = m_fThrowCooldown;
    }

    /*
    Description: Parent it to this object and enter possession state. 
    Params:
        GameObject obj: The object to possess.
    */
    public void PossessHuman()
    {
        m_bIsPossessing = false;

        // Disable the player's meshes.
        m_meshRoot.SetActive(false);

        // Disable look pointer.
        m_pointer.SetActive(false);

        // Disable the player's input.
        m_input.enabled = false;

        // Parent this ghost to the human.
        transform.SetParent(m_human.transform);
        transform.localPosition = Vector3.zero;

        // Disable movement and character controller scripts.
        m_movement.enabled = false;
        m_controller.enabled = false;

        // Re-enable collision between player and human.
        Physics.IgnoreCollision(m_controller, m_objectCollider, false);

        // Make this player have ownership of the human and control him.
        m_humanScript.SetOwner(this, m_input, m_input.GetPlayer());
    }

    public void KickFromHuman(Vector3 v3PropDirection)
    {
        // Enable the player's meshes.
        m_meshRoot.SetActive(true);

        // Enable look pointer.
        m_pointer.SetActive(true);

        // Stun player.
        Stun();

        // Disable collision between this player and the human.
        Physics.IgnoreCollision(m_controller, m_humanController, true);

        // Throw player:
        // Ensure ghost position is equal to the human's position.
        transform.parent = null;
        transform.position = m_human.transform.position;

        // Enable movement.
        m_movement.enabled = true;
        m_controller.enabled = true;

        v3PropDirection.y = 0.0f;

        // Add direction vector to up force, normalize and multiply by stun force and add the force.
        m_movement.ResetVelocity(); // Ensure any previous velocity of the ghost doesn't remain.
        m_movement.AddForce(v3PropDirection * m_fStunForce);
        m_movement.AddForce(Vector3.up * m_fStunForce);

        // Mark human as not possessed.
        m_humanScript.SetPossessed(false);

        m_possessedObj = null;
    }

    /*
    Description: Releases the possessed object and throws it in the direction the player is facing. 
    */
    private void ThrowPossessed()
    {
        // Re-enable object meshes.
        m_meshRoot.SetActive(true);

        // Ensure the pointer is active when the object is thrown.
        m_pointer.SetActive(true);

        // Free object.
        m_possessedScript.SetThown(m_controller, m_collider, transform.forward);
        m_possessedObj.transform.localPosition = new Vector3(0.0f, m_possessedScript.GetHeightOffset(), m_possessedScript.GetThrowZOffset());
        m_possessedObj.transform.localRotation = Quaternion.Euler(Vector3.zero);
        m_possessedObj.transform.parent = null;
        m_objectRigidbody.isKinematic = false;
        m_objectRigidbody.useGravity = false;

        // Thow object.
        m_objectRigidbody.velocity = transform.forward * m_fThrowForce;
        m_objectRigidbody.AddTorque(m_possessedScript.GetRotations() * m_possessedScript.GetRotationSpeed(), ForceMode.VelocityChange);

        // Reset throw cooldown.
        m_fCurrentThrowCD = m_fThrowCooldown;

        // Set object values to null.
        m_objectRigidbody = null;
        m_objectCollider = null;
        m_possessedObj = null;

        if (m_throwClip != null)
            m_audio.PlayOneShot(m_throwClip);
    }

    void DropPossessed()
    {
        // Re-enable object meshes.
        m_meshRoot.SetActive(true);

        // Ensure the pointer is active when the object is thrown.
        m_pointer.SetActive(true);

        // Free object.
        m_possessedScript.SetPossessed(false);
        m_possessedScript.SwapColliders();
        m_possessedObj.transform.localRotation = Quaternion.Euler(Vector3.zero);
        m_possessedObj.transform.parent = null;
        m_objectRigidbody.isKinematic = false;
        m_objectRigidbody.useGravity = true;

        // Reset throw cooldown.
        m_fCurrentThrowCD = m_fThrowCooldown;

        // Set object values to null.
        m_objectRigidbody = null;
        m_objectCollider = null;
        m_possessedObj = null;
    }

    // Suspends player movement input for a short period of time.
    void Stun()
    {
        m_fCurrentStunTime = m_fStunTime;
        m_bStunned = true;

        m_movement.DisableInput(true);

        m_movement.m_AnimationController.SetBool("IsStunned", true);
    }

    // Set the score of the individual player and update GUI.
    public void SetScore(int nScore)
    {
        m_nScore = nScore;
        m_gui.SetHunger(m_nID, m_nScore);
    }

    // Add to the score of the individual player and update GUI.
    public void AddToScore(int nScore)
    {
        m_nScore += nScore;
        m_gui.SetHunger(m_nID, m_nScore);
    }
}
