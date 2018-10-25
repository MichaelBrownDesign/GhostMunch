using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform Player1;
    public Transform Player2;
    public Transform Player3;
    public Transform Player4;

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


	// Use this for initialization
	void Start () {
        aspectRatio = Screen.width / Screen.height;
        tanFov = Mathf.Tan(Mathf.Deg2Rad * Camera.main.fieldOfView / 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
        m_timer = Time.deltaTime;
        float interpolation = lerpSpeed * m_timer;
        //positioning the camera
        Vector3 newCameraPos = Camera.main.transform.position;


        newCameraPos.x = Mathf.Lerp(this.transform.position.x, middlePoint.x, interpolation);
        newCameraPos.z = Mathf.Lerp(this.transform.position.z, middlePoint.z - zCorrection, interpolation);
        newCameraPos.y = Mathf.Lerp(this.transform.position.y, middlePoint.y + yCorrection, interpolation);


        Camera.main.transform.position = newCameraPos;
      
        //finding the middlepoint between players
      
        //if 2 player
        middlePoint = (Player1.position + Player2.position) / 2;
      
        float f_dist1_2 = Vector3.Distance(Player1.position, Player2.position);
      
        m_fzoom = f_dist1_2;
      
      
        //if 3 player
    //    middlePoint = (Player1.position + Player2.position + Player3.position) / 3;
    //  
    //    float f_dist1_2 = Vector3.Distance(Player1.position, Player2.position);
    //    float f_dist1_3 = Vector3.Distance(Player1.position, Player3.position);
    //    float f_dist1_4 = Vector3.Distance(Player1.position, Player4.position);
    //    float f_dist2_3 = Vector3.Distance(Player2.position, Player3.position);
    //    float f_dist2_4 = Vector3.Distance(Player2.position, Player4.position);
    //  
    //    m_fzoom = Mathf.Max(f_dist1_2, f_dist1_3, f_dist1_4, f_dist2_3, f_dist2_4);
      
      
        //if 4 player
    //    middlePoint = (Player1.position + Player2.position + Player1.position + Player3.position) / 4;
    //   
    //    float f_dist1_2 = Vector3.Distance(Player1.position, Player2.position);
    //    float f_dist1_3 = Vector3.Distance(Player1.position, Player3.position);
    //    float f_dist1_4 = Vector3.Distance(Player1.position, Player4.position);
    //    float f_dist2_3 = Vector3.Distance(Player2.position, Player3.position);
    //    float f_dist2_4 = Vector3.Distance(Player2.position, Player4.position);
    //    float f_dist3_4 = Vector3.Distance(Player3.position, Player4.position);
    //  
    //    m_fzoom = Mathf.Max(f_dist1_2, f_dist1_3, f_dist1_4, f_dist2_3, f_dist2_4, f_dist3_4);
      


        //calculating the new distance
        cameraDistance = (m_fzoom / 2.0f / aspectRatio) / tanFov;
        //setting the camera to the new position
        Vector3 dir = (Camera.main.transform.position - middlePoint).normalized;

        Vector3 v3FinalTarget = middlePoint + dir * (cameraDistance + DISTANCE_MARGIN);


        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, v3FinalTarget, interpolation); 


    }
}
