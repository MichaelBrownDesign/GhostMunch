using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{ 
    // This object.
    private PlayerInput m_input;
    private PlayerMovement m_movement;
    private CharacterController m_controller;
    private bool m_bPossessed;

    // Possessor
    private Player m_ownerPScript;

    // Determines if the human is susceptible to posession.
    private bool m_bSusceptible;

    // Use this for initialization
    void Awake()
    {
        m_input = GetComponent<PlayerInput>();
        m_movement = GetComponent<PlayerMovement>();
        m_controller = GetComponent<CharacterController>();

        // Human starts off not possessed, and simply dead on the floor.
        m_input.enabled = false;
        m_movement.enabled = false;
        m_bSusceptible = true;
	}
	
	// Update is called once per frame
	void Update()
    {
        // Ensure ghost player is at the same position as the human for the camera.
        if(m_ownerPScript != null)
            m_ownerPScript.gameObject.transform.position = transform.position;
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

        m_ownerPScript = null;
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
}
