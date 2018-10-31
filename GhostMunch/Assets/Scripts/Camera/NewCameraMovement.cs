using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraMovement : MonoBehaviour
{

    public Transform[] m_players;
    public Transform m_mapOrigin;

    public float m_fDist;
    public float m_fEdgeGap;

    private Vector3 m_v3OriginalPos;

    private float m_fXMax;
    private float m_fXMin;
    private float m_fZMax;
    private float m_fZMin;


    // Use this for initialization
    void Awake()
    {
        m_v3OriginalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //m_fXMax = Mathf.Max(m_players[0].position.x, m_players[1].position.x, m_players[2].position.x, m_players[3].position.x);
        //m_fXMin = Mathf.Min(m_players[0].position.x, m_players[1].position.x, m_players[2].position.x, m_players[3].position.x);
        //
        //m_fZMax = Mathf.Max(m_players[0].position.z, m_players[1].position.z, m_players[2].position.z, m_players[3].position.z);
        //m_fZMin = Mathf.Min(m_players[0].position.z, m_players[1].position.z, m_players[2].position.z, m_players[3].position.z);

        m_fXMax = 0;
        m_fXMin = 0;
        m_fZMax = 0;
        m_fZMin = 0;

        // Get min/max x/z offsets from the map origin of all players.
        for (int i = 0; i < m_players.Length; ++i)
        {
            float fXDist = m_players[i].transform.position.x - m_mapOrigin.transform.position.x;
            float fZDist = m_players[i].transform.position.z - m_mapOrigin.transform.position.z;

            if (fXDist < m_fXMin)
                m_fXMin = fXDist;

            if (fXDist > m_fXMax)
                m_fXMax = fXDist;

            if (fZDist < m_fZMin)
                m_fZMin = fZDist;

            if (fZDist > m_fZMax)
                m_fZMax = fZDist;
        }

        // Calculate new centre for the camera.
        Vector3 v3MidPoint = Vector3.zero;

        v3MidPoint.x = (m_fXMax + m_fXMin) / 2;
        v3MidPoint.z = (m_fZMax + m_fZMin) / 2;

        v3MidPoint += m_mapOrigin.transform.position;

        Vector3 v3BoundingDimensions = Vector3.zero;

        v3BoundingDimensions.x = Mathf.Sqrt(Mathf.Pow(m_fXMin, 2) + Mathf.Pow(m_fXMax, 2));
        v3BoundingDimensions.z = Mathf.Sqrt(Mathf.Pow(m_fZMin, 2) + Mathf.Pow(m_fZMax, 2));


        Vector3 v3Dir = -transform.forward;

        transform.position = Vector3.zero;

        Vector3 v3ScreenDimensions = Camera.main.WorldToScreenPoint(v3BoundingDimensions);

        float fZoomFactor = v3ScreenDimensions.magnitude / new Vector2(Screen.width, Screen.height).magnitude;

        float fFinalFactor = fZoomFactor * m_fDist;

        //if(fZoomFactorX >= fZoomFactorY)
        //{
        //    fFinalFactor = fZoomFactorX * m_fDist;
        //}
        //else
        //{
        //    fFinalFactor = fZoomFactorY * m_fDist;
        //}

        transform.position = v3MidPoint + (v3Dir * fFinalFactor);

    }
}
