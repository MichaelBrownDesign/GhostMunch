using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera)), ExecuteInEditMode]
public class CameraMovement : MonoBehaviour {

    public Transform[] m_players;


    public float lerpSpeed = 2.0f;


    //extra zoom out so that the units dont clip off the edge
    public float DISTANCE_MARGIN = 10.0f;

    private float m_fzoom;

    private Vector3 middlePoint;
    private float cameraDistance;
    private float aspectRatio;
    private float tanFov;

    private float distanceBetweenPlayers;

    private float m_timer;
    private float m_fdist;

    private float lerpDistance;

    public float zCorrection = 15;
    public float yCorrection = 20;

    //private float 

    private Camera m_Camera;


	// Use this for initialization
	void Start ()
    {
        m_Camera = GetComponent<Camera>();
        aspectRatio = Screen.width / Screen.height;
        tanFov = Mathf.Tan(Mathf.Deg2Rad * m_Camera.fieldOfView / 2.0f);

        GameObject[] playersInScene = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < m_players.Length; ++i)
        {
            m_players[i] = playersInScene[i].transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
        m_timer = Time.deltaTime;
        float interpolation = lerpSpeed * m_timer;
        //positioning the camera
        Vector3 newCameraPos = transform.position;


        newCameraPos.x = Mathf.Lerp(this.transform.position.x, middlePoint.x, interpolation);
        newCameraPos.z = Mathf.Lerp(this.transform.position.z, middlePoint.z - zCorrection, interpolation);
        newCameraPos.y = Mathf.Lerp(this.transform.position.y, middlePoint.y + yCorrection, interpolation);


        transform.position = newCameraPos;

        //finding the middlepoint between players




        //if 2 player
        if (m_players.Length == 2)
        {
            middlePoint = (m_players[0].position + m_players[1].position) / 2;

            float f_dist1_2 = Vector3.Distance(m_players[0].position, m_players[1].position);

            m_fzoom = f_dist1_2;
        }

        //if 3 player
        else if(m_players.Length == 3)
        {
            middlePoint = (m_players[0].position + m_players[1].position + m_players[2].position) / 3;
          
            float f_dist1_2 = Vector3.Distance(m_players[0].position, m_players[1].position);
            float f_dist1_3 = Vector3.Distance(m_players[0].position, m_players[2].position);
            float f_dist2_3 = Vector3.Distance(m_players[1].position, m_players[2].position);

          
            m_fzoom = Mathf.Max(f_dist1_2, f_dist1_3, f_dist2_3);
        }

        //if 4 player
        else if(m_players.Length == 4)
        {
        middlePoint = (m_players[0].position + m_players[1].position + m_players[2].position + m_players[3].position) / 4;
       
        float f_dist1_2 = Vector3.Distance(m_players[0].position, m_players[1].position);
        float f_dist1_3 = Vector3.Distance(m_players[0].position, m_players[2].position);
        float f_dist1_4 = Vector3.Distance(m_players[0].position, m_players[3].position);
        float f_dist2_3 = Vector3.Distance(m_players[1].position, m_players[2].position);
        float f_dist2_4 = Vector3.Distance(m_players[1].position, m_players[3].position);
        float f_dist3_4 = Vector3.Distance(m_players[2].position, m_players[3].position);
      
        m_fzoom = Mathf.Max(f_dist1_2, f_dist1_3, f_dist1_4, f_dist2_3, f_dist2_4, f_dist3_4);
        }


      


        //calculating the new distance
        cameraDistance = (m_fzoom / 2.0f / aspectRatio) / tanFov;
        //setting the camera to the new position
        Vector3 dir = (transform.position - middlePoint).normalized;

        Vector3 v3FinalTarget = middlePoint + dir * (cameraDistance + DISTANCE_MARGIN);


        transform.position = Vector3.Lerp(transform.position, v3FinalTarget, interpolation); 


    }
}
