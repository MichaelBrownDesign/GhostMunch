using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Transforms")]
    public Transform[] m_players;

    [Header("Zooming")]
    public float m_fZoomSpeed = 0.1f;
    public float m_fMinDistance = 10.0f;
    public float m_fMaxDistance = 100.0f;
    public float m_fZoomOutMult = 1.0f;

    private float m_fOriginalXRotation;

    // Min max X and Z values to calculate the player bounding box.
    private float m_fXMax;
    private float m_fXMin;
    private float m_fZMax;
    private float m_fZMin;

    private static float m_fFinalZoomFactor = 0.0f;

    // Use this for initialization
    void Awake()
    {
        m_fOriginalXRotation = transform.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_players.Length == 0)
            return;

        m_fXMax = 0.0f;
        m_fXMin = 0.0f;
        m_fZMax = 0.0f;
        m_fZMin = 0.0f;

        // Find midpoint between all players.
        Vector3 v3MidPoint = Vector3.zero;

        for (int i = 0; i < m_players.Length; ++i)
        {
            v3MidPoint += m_players[i].position;
        }
        
        v3MidPoint.y = 0;
        v3MidPoint /= m_players.Length;

        Debug.DrawLine(v3MidPoint, v3MidPoint + Vector3.up * 10, Color.green);

        // Get min/max x/z offsets from the map origin of all players.
        for (int i = 0; i < m_players.Length; ++i)
        {
            float fXDist = m_players[i].transform.position.x - v3MidPoint.x;
            float fZDist = m_players[i].transform.position.z - v3MidPoint.z;

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
        Vector3 v3FinalPos = Vector3.zero;

        v3FinalPos.x = (m_fXMax + m_fXMin) / 2;
        v3FinalPos.z = (m_fZMax + m_fZMin) / 2;

        // Add map origin to midpoint to translate it to the correct position.
        v3FinalPos += v3MidPoint;

        // Calculate the bounding box all players reside within.
        Vector3 v3BoundingDimensions = Vector3.zero;

        v3BoundingDimensions.x = Mathf.Sqrt(Mathf.Pow(m_fXMin, 2) + Mathf.Pow(m_fXMax, 2));
        v3BoundingDimensions.z = Mathf.Sqrt(Mathf.Pow(m_fZMin, 2) + Mathf.Pow(m_fZMax, 2));

        // Get position from last frame for later use.
        Vector3 v3LastFramePos = transform.position;

        // Temporarily move the camera to the origin and look down to get accuratre screen space values for the bounding box.
        transform.position = Vector3.up * m_fZoomOutMult;
        transform.rotation = Quaternion.Euler(90, 0, 0);

        // Get screen space dimensions of the box.
        Vector3 v3ScreenDimensions = Camera.main.WorldToScreenPoint(v3BoundingDimensions);

        // Get X and Y zoom factors.
        float fZoomFactorX = v3ScreenDimensions.x / Screen.width;
        float fZoomFactorY = v3ScreenDimensions.y / Screen.height;

        m_fFinalZoomFactor = Mathf.Max(fZoomFactorX, fZoomFactorY);

        // Use the highest zoom factor and multiply by the zoom out multiplier.
        float fFinalFactor = m_fFinalZoomFactor * m_fZoomOutMult * 2;

        // Clamp final zoom level.
        fFinalFactor = Mathf.Clamp(fFinalFactor, m_fMinDistance, m_fMaxDistance);

        // Reset rotation and lerp between the last frame position and the new position.
        transform.rotation = Quaternion.Euler(m_fOriginalXRotation, 0, 0);

        transform.position = Vector3.Lerp(v3LastFramePos, v3FinalPos + (-transform.forward * fFinalFactor), m_fZoomSpeed);
    }

    public static float GetZoomFactor()
    {
        return m_fFinalZoomFactor;
    }
}
