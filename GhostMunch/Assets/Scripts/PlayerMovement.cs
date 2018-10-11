using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("The rate of increase in falling velocity due to gravity in m/s")]
    public float m_fGravityScale = 9.81f;
    [Tooltip("The maximum falling velocity in m/s")]
    public float m_fTerminalFallVelocity = 53.0f;
    public float m_fMoveSpeed = 5.0f;
    public float m_fAcceleration = 30.0f;
    public float m_fDecelleration = 15.0f;

    [Header("Jumping")]
    public bool m_bAllowJump = true;
    public float m_fJumpForce = 5.0f;

    [Header("Rolling")]
    public AnimationCurve m_rollCurve;
    public float m_fRollSpeed = 5.0f;
    public float m_fRollTime = 1.0f;
    public float m_fRollDelay = 1.0f;

    [Header("Rotation")]
    [Tooltip("Enables use of the right thumbstick to look around in a twin-stick shooter fashion.")]
    public float m_fRotationLerpT = 0.2f;
    public float m_fFreeLookDeadZone = 0.2f;
    public bool m_bAllowFreeLook = false;

    private CharacterController m_controller;
    private PlayerInput m_input;

    private Vector3 m_v3Velocity;
    private Vector3 m_v3TargetRotation;
    private Vector2 m_v2RollDirection;
    private float m_fCurrentSpeed;
    private float m_fCurrentRollTime;
    private float m_fCurrentRollDelay;
    private float m_fInputMagnitude;
    private bool m_bIsGrounded;
    private bool m_bIsMoving;
    private bool m_bIsRolling;
    private bool m_bUseInput;

    private Vector2 m_v2InputMovement;
    private Vector2 m_v2InputLook;

	// Use this for initialization
	void Awake()
    {
        m_controller = GetComponent<CharacterController>();
        m_input = GetComponent<PlayerInput>();

        m_bUseInput = true;
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        // Movement direction this frame.
        m_v2InputMovement = Vector2.zero;

        // Look direction this frame.
        m_v2InputLook = Vector2.zero;

        if(!m_input.m_bUseKeyboard)
        {
            // Controller input...
            // Move direction
            m_v2InputMovement = new Vector2
            (
                m_input.GetAxis(3),
                m_input.GetAxis(2)
            );

            // Look direction.
            m_v2InputLook = new Vector2
            (
                m_input.GetAxis(5),
                m_input.GetAxis(4)
            );
        }
        else
        {
            // PC movement direction input.
            if(m_input.GetButtonPressed(4))
            {
                m_v2InputMovement.x = 1.0f;
            }
            if (m_input.GetButtonPressed(5))
            {
                m_v2InputMovement.y = -1.0f;
            }
            if (m_input.GetButtonPressed(6))
            {
                m_v2InputMovement.x = -1.0f;
            }
            if (m_input.GetButtonPressed(7))
            {
                m_v2InputMovement.y = 1.0f;
            }
        }

        m_fInputMagnitude = m_v2InputMovement.magnitude;

        // Main movement
        if (!m_bIsRolling)
        {
            // Vertical
            m_v3Velocity += Vector3.forward * m_v2InputMovement.x * m_fAcceleration * Time.deltaTime;

            // Horizontal
            m_v3Velocity += Vector3.right * m_v2InputMovement.y * m_fAcceleration * Time.deltaTime;
        }
        else // Rolling movement
        {
            float fRollProgress = 1.0f - (m_fCurrentRollTime / m_fRollTime);
            float fRollVal = m_fMoveSpeed + m_rollCurve.Evaluate(fRollProgress) * m_fRollSpeed;

            m_v2RollDirection.Normalize();

            m_v3Velocity.x = m_v2RollDirection.y * fRollVal;
            m_v3Velocity.z = m_v2RollDirection.x * fRollVal;

            m_fCurrentRollTime -= Time.deltaTime;
            m_bIsRolling = m_fCurrentRollTime > 0.0f;
        }

        // Clamp input magnitude to 1..
        if (m_fInputMagnitude > 1.0f)
            m_fInputMagnitude = 1.0f;

        m_bIsMoving = m_fInputMagnitude != 0.0f && m_bUseInput;

        if(!m_bIsRolling) // Does not apply when rolling...
        {
            if (m_bIsMoving)
            {
                // Prevent further acceleration if speed percentage matches input magnitude.
                if (m_fCurrentSpeed < m_fMoveSpeed * m_fInputMagnitude)
                    m_fCurrentSpeed += m_fAcceleration * Time.deltaTime;

                // Clamp speed...
                if (m_fCurrentSpeed > m_fMoveSpeed)
                    m_fCurrentSpeed = m_fMoveSpeed;
            }
            else
            {
                m_fCurrentSpeed -= m_fDecelleration * Time.deltaTime;

                // Clamp speed...
                if (m_fCurrentSpeed < 0.0f)
                    m_fCurrentSpeed = 0.0f;
            }

            // Clamp velocity to current speed...
            if (m_v3Velocity.magnitude > m_fCurrentSpeed)
            {
                Vector3 v3ClampedVelocity = m_v3Velocity.normalized * m_fCurrentSpeed;

                m_v3Velocity.x = v3ClampedVelocity.x;
                m_v3Velocity.z = v3ClampedVelocity.z;
            }
        }
       
        // Acceleration due to gravity.
        m_v3Velocity.y -= m_fGravityScale * Time.fixedDeltaTime;

        // Preventy falling velocity from becoming greater than terminal velocity.
        if (m_v3Velocity.y < -m_fTerminalFallVelocity)
            m_v3Velocity.y = -m_fTerminalFallVelocity;

        // Detect if on ground using a raycast (Unity's player controller isGrounded variable is unreliable).
        Debug.DrawLine(transform.position, transform.position - (new Vector3(0.0f, (m_controller.height * 0.5f) + 0.5f, 0.0f)), Color.red);
        m_bIsGrounded = Physics.Raycast(transform.position, Vector3.down, (m_controller.height * 0.5f) + 0.5f);

        // While the character controller does stop falling it does not stop the falling velocity from increasing...
        // The controller grounded variable used to stop falling since it is more accurate than a raycast, and reliable enough in this case.
        if (m_controller.isGrounded)
            m_v3Velocity.y = 0.0f;

        // Use right stick to look around.
        if (m_bAllowFreeLook)
        {
            m_v3TargetRotation.x = 0.0f;

            if (m_v2InputLook.magnitude >= 0.2f)
                m_v3TargetRotation.y = Mathf.Atan2(m_v2InputLook.y, m_v2InputLook.x) * 180.0f / Mathf.PI;

            m_v3TargetRotation.z = 0.0f;
        }
        else // Rotate to face movement direction (If free look is disabled).
        {
            m_v3TargetRotation.x = 0.0f;

            // Only set Y rotation if the player is moving, otherwise thier rotation will snap to an incorrect value when not moving.
            if (m_bIsMoving)
                m_v3TargetRotation.y = Mathf.Atan2(m_v2InputMovement.y, m_v2InputMovement.x) * 180.0f / Mathf.PI;

            m_v3TargetRotation.z = 0.0f;
        }
    }

    void Update()
    {
        // Jumping (Had to put this in Update instead of FixedUpdate() due to jumping sometimes failing due to mismatching framerates between the two functions).
        if (m_bIsGrounded && m_bAllowJump && m_bUseInput && m_input.GetButton(1))
        {
            m_v3Velocity.y = m_fJumpForce;
        }

        // Count down roll delay.
        m_fCurrentRollDelay -= Time.deltaTime;

        // Rolling...
        if(!m_bIsRolling && m_bIsGrounded && m_bIsMoving && m_bUseInput && m_fCurrentRollDelay <= 0.0f && m_input.GetButton(0))
        {
            m_bIsRolling = true;

            m_fCurrentRollDelay = m_fRollDelay;
            m_fCurrentRollTime = m_fRollTime;
            m_v2RollDirection = m_v2InputMovement;

            
        }

        // Update rotation.
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(m_v3TargetRotation), m_fRotationLerpT);
        transform.rotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, 0.0f);

        // Update velocity.
        m_controller.Move(m_v3Velocity * Time.deltaTime);
    }

    public void Freeze(bool bFreeze)
    {
        m_bUseInput = !bFreeze;
    }

    public float GetMovementMagnitude()
    {
        if (m_fInputMagnitude > 1.0f)
            return 1.0f;

        return m_fInputMagnitude;
    }

    public void ResetVelocity()
    {
        m_v3Velocity = Vector3.zero;
        m_fCurrentSpeed = 0.0f;
    }

    public void AddForce(Vector3 v3Force)
    {
        m_v3Velocity += v3Force;
        m_fCurrentSpeed = v3Force.magnitude;
    }
}
