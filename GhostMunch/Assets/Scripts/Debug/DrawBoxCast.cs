using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBoxCast : MonoBehaviour
{
    public Vector4 m_v4Centre;
    public Vector3 m_v3HalfExtents;
    public Vector3 m_v3Direction;
    public float m_fMaxDistance;

    private Vector4[] m_v4TopTransformedVertices;
    private Vector4[] m_v4BottomTransformedVertices;
    private Vector4[] m_v4TopVertices;
    private Vector4[] m_v4BottomVertices;
    private Matrix4x4 m_rotationMatrix;
    public Quaternion m_rotation;
    private float m_fBoxLength;
    private int m_nBoxCount;

    // Use this for initialization
    void Awake()
    {
        m_v4TopTransformedVertices = new Vector4[4];
        m_v4BottomTransformedVertices = new Vector4[4];
        m_v4TopVertices = new Vector4[4];
        m_v4BottomVertices = new Vector4[4];
        m_v4Centre = transform.position;
        m_rotation = transform.rotation;

        ConstructBox();
	}

    void SetRotation()
    {
        m_rotationMatrix.SetTRS(m_v4Centre, m_rotation, m_v3HalfExtents);

        for(int i = 0; i < 4; ++i)
        {
            m_v4TopTransformedVertices[i] = m_rotationMatrix * m_v4TopVertices[i];
            m_v4BottomTransformedVertices[i] = m_rotationMatrix * m_v4BottomVertices[i];
        }
    }

    void ConstructBox()
    {
        // Create vertices using centre and half extents.

        // Top 4 vertices.
        m_v4TopVertices[0] = new Vector4(m_v3HalfExtents.x, m_v3HalfExtents.y, m_v3HalfExtents.z);
        m_v4TopVertices[1] = new Vector4(-m_v3HalfExtents.x, m_v3HalfExtents.y, m_v3HalfExtents.z, 0.0f);
        m_v4TopVertices[2] = new Vector4(-m_v3HalfExtents.x, m_v3HalfExtents.y, -m_v3HalfExtents.z, 0.0f);
        m_v4TopVertices[3] = new Vector4(m_v3HalfExtents.x, m_v3HalfExtents.y, -m_v3HalfExtents.z, 0.0f);

        // Bottom 4 vertices.
        m_v4BottomVertices[0] = new Vector4(m_v3HalfExtents.x, -m_v3HalfExtents.y, m_v3HalfExtents.z);
        m_v4BottomVertices[1] = new Vector4(-m_v3HalfExtents.x, -m_v3HalfExtents.y, m_v3HalfExtents.z);
        m_v4BottomVertices[2] = new Vector4(-m_v3HalfExtents.x, -m_v3HalfExtents.y, -m_v3HalfExtents.z);
        m_v4BottomVertices[3] = new Vector4(m_v3HalfExtents.x, -m_v3HalfExtents.y, -m_v3HalfExtents.z);

        // Set rotation vertices.
        SetRotation();
    }

    /*
    Description: Draw a box cast using unity debug.
    Params:
        Vector3 v3Centre: The centre of the box to cast.
        Vector3 v3HalfExtents: The half scale of the box to cast.
        Quaternion rotation: The rotation of each box.
        Vector3 v3Direction: The direction in which to cast the boxes.
    */
    public void Draw(Vector3 v3Centre, Vector3 v3HalfExtents, Quaternion rotation, Vector3 v3Direction, float fMaxDistance = 100.0f)
    {
        m_v4Centre = new Vector4(v3Centre.x, v3Centre.y, v3Centre.z);
        m_v3HalfExtents = v3HalfExtents;
        m_rotation = rotation;
        m_v3Direction = v3Direction;
        m_fMaxDistance = fMaxDistance;

        ConstructBox();

        m_fBoxLength = m_v3HalfExtents.z * 2;
        m_nBoxCount = (int)(m_fMaxDistance / m_fBoxLength);

        for (int i = 0; i < m_nBoxCount; ++i)
        {
            for (int j = 0; j < 4; ++j)
            {
                if (j < 3)
                {
                    // Top and bottom non-final lines.
                    Debug.DrawLine(m_v4Centre + m_v4TopTransformedVertices[j], m_v4Centre + m_v4TopTransformedVertices[j + 1], Color.red);
                    Debug.DrawLine(m_v4Centre + m_v4BottomTransformedVertices[j], m_v4Centre + m_v4BottomTransformedVertices[j + 1], Color.red);
                }
                else
                {
                    // Final lines.
                    Debug.DrawLine(m_v4Centre + m_v4TopTransformedVertices[j], m_v4Centre + m_v4TopTransformedVertices[0], Color.red);
                    Debug.DrawLine(m_v4Centre + m_v4BottomTransformedVertices[j], m_v4Centre + m_v4BottomTransformedVertices[0], Color.red);
                }

                // Vertical lines.
                Debug.DrawLine(m_v4Centre + m_v4TopTransformedVertices[j], m_v4Centre + m_v4BottomTransformedVertices[j], Color.red);
            }

            // Add length multiplied by direction onto the position to add the next box.
            Vector3 v3NextPos = new Vector3(m_v4Centre.x, m_v4Centre.y, m_v4Centre.z) + (m_v3Direction.normalized * (Mathf.Pow(m_fBoxLength, 2) / 2));
            m_v4Centre = new Vector4(v3NextPos.x, v3NextPos.y, v3NextPos.z, 0.0f);
        }
    }
}
