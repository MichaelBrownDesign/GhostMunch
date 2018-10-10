﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDissolve : MonoBehaviour {

    public Transform[] m_targets;
    //public GameObject currentPlane;

    public LayerMask playerMask;
    public LayerMask planeMask;

    public float dissolveSpeed;
    public float undissolveSpeed;

    private static float dissolveSpeedStatic;
    private static float undissolveSpeedStatic;

    public static float DissolveSpeed
    {
        get { return dissolveSpeedStatic; }
    }

    public static float UnDissolveSpeed
    {
        get { return undissolveSpeedStatic; }
    }

//   public static float dissolveSpeedStatic;
//   public static float undissolveSpeedStatic;

    private float f_dissolveAmount;
    private bool isFaded = false;

    //    private CheckFaded faded;
    // Use this for initialization
    void Awake()
    {
        dissolveSpeedStatic = dissolveSpeed;
        undissolveSpeedStatic = undissolveSpeed;

        //faded = GetComponent<CheckFaded>();

        //currentPlane = GameObject.FindWithTag("Dissolvable");	
    }
	
	// Update is called once per frame
	void Update ()
    {
        float timer = Time.deltaTime;

        for (int i = 0; i < m_targets.Length; ++i)
        {
            Transform currentTarget = m_targets[i];

            Vector3 v3TargetDir = (currentTarget.position - transform.position).normalized;

            RaycastHit hit;
            Physics.Raycast(transform.position, v3TargetDir, out hit);

            float fDistToHit = Vector3.Distance(transform.position, hit.point);

            Debug.DrawRay(transform.position, v3TargetDir * fDistToHit, Color.red);

            if (hit.collider != null)
            {
                GameObject currentHitObject = hit.transform.gameObject;

                if(currentHitObject != currentTarget.gameObject && currentHitObject.tag != "Player" && currentHitObject.tag != "Human" && currentHitObject.tag != "Possessible")
                {
                    // Object is not the player, fade it.
                    currentHitObject.GetComponent<IsFaded>().FadeOut();
                }
            }
        }

        //Debug.DrawRay(transform.position, transform.forward * Vector3.Distance(transform.position, target.position), Color.red);
        //
        //// if the raycast is hitting the plane then dissolve it
        //if (Physics.Raycast(transform.position, transform.forward, out hit, Vector3.Distance(transform.position, target.position), planeMask))
        //{
        //    
        //
        //    if (!isFaded)
        //    {
        //        StartCoroutine(FadingOut());
        //        if (f_dissolveAmount <= 0)
        //            isFaded = true;
        //    }
        //    currentPlane.GetComponent<Renderer>().material.SetFloat("_ClipThreshold", f_dissolveAmount);
        //    Debug.Log("Plane");
        //}
        //
        //// if the raycast is NOT hitting the plane then stop dissolving
        //else if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, playerMask))
        //{
        //    if (f_dissolveAmount < 1.1f)
        //    { 
        //        StartCoroutine(FadingIn());
        //    }
        //    if (isFaded)
        //    {
        //        StartCoroutine(FadingIn());
        //        if (f_dissolveAmount >= 1.1f)
        //            isFaded = false;
        //
        //    }
        //    currentPlane.GetComponent<Renderer>().material.SetFloat("_ClipThreshold", f_dissolveAmount);
        //    Debug.Log("Player");
        //
        //}

    }


}
