using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDissolve : MonoBehaviour {

    public Transform[] m_targets;

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

    // Use this for initialization
    void Awake()
    {
        dissolveSpeedStatic = dissolveSpeed;
        undissolveSpeedStatic = undissolveSpeed;
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
                    currentHitObject.GetComponentInParent<IsFaded>().FadeOut();
                }
            }
        }
    }


}
