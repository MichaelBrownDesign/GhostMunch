using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDissolve : MonoBehaviour {

    public Transform target;
    public GameObject currentPlane;

    public LayerMask playerMask;
    public LayerMask planeMask;

    private float f_dissolveAmount;
    private bool isFaded = false;

    RaycastHit hit;
//    private CheckFaded faded;
	// Use this for initialization
	void Start ()
    {
//        faded = GetComponent<CheckFaded>();
        currentPlane = GameObject.FindWithTag("Dissolvable");	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float timer = Time.deltaTime;

        this.transform.LookAt(target);

        Debug.DrawRay(transform.position, transform.forward * 1000.0f, Color.red);

        // if the raycast is hitting the plane then dissolve it
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, planeMask))
        {
            currentPlane = hit.transform.gameObject;
            if (!isFaded)
            {
                StartCoroutine(FadingOut());
                if (f_dissolveAmount <= 0)
                    isFaded = true;
            }
            currentPlane.GetComponent<Renderer>().material.SetFloat("_DissolveRatio", f_dissolveAmount);
            Debug.Log("Plane");
        }

        // if the raycast is NOT hitting the plane then stop dissolving
        else /*if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))*/
        {
            if (f_dissolveAmount < 5)
            { 
                StartCoroutine(FadingIn());
            }
            if (isFaded)
            {
                StartCoroutine(FadingIn());
                if (f_dissolveAmount >= 5)
                    isFaded = false;

            }
            currentPlane.GetComponent<Renderer>().material.SetFloat("_DissolveRatio", f_dissolveAmount);
            Debug.Log("Player");

        }

    }
    // used to change the value of dissolve percentage over time
    IEnumerator FadingOut()
    {
        f_dissolveAmount -= 0.25f;
        //for (f_dissolveAmount = 0; f_dissolveAmount < 1; f_dissolveAmount += 0.02f)
        //{
            yield return new WaitForSeconds(0.01f);
        //}
    }
    
    IEnumerator FadingIn()
    {
        f_dissolveAmount += 0.35f;
        //for (f_dissolveAmount = 1; f_dissolveAmount > 0; f_dissolveAmount -= 0.01f)
        //{
            yield return new WaitForSeconds(0.01f);
        //}
    }


}
