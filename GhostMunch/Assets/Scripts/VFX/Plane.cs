using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Plane : MonoBehaviour
{
    public int m_VertexCount = 10;

    public float m_PlaneSize = 1.0f;

    List<Vector3> m_Vertices;
    List<Vector2> m_UVs;
    List<int> m_Indices;

    Mesh m_Mesh;

    public bool m_Regenerate = false;

	void Start ()
    {
        Initialize();	
	}

    void Initialize()
    {
        m_Vertices = new List<Vector3>();
        m_UVs = new List<Vector2>();
        m_Indices = new List<int>();

        float triSize = (float)m_PlaneSize / (float)m_VertexCount;
        float halfSize = m_PlaneSize * 0.5f;

        for (int y = 0; y < m_VertexCount; ++y)
        {
            for(int x = 0; x < m_VertexCount; ++x)
            {
                m_Vertices.Add(transform.position + new Vector3(x*triSize, 0, y* triSize));
                m_UVs.Add(new Vector2((float)x/(float)m_VertexCount, (float)y/ (float)m_VertexCount));
                if (x < m_VertexCount - 1 && y < m_VertexCount - 1)
                {
                    int i = y * m_VertexCount + x;
                    m_Indices.Add(i + 1);
                    m_Indices.Add(i);
                    m_Indices.Add(i + m_VertexCount);

                    m_Indices.Add(i + 1);
                    m_Indices.Add(i + m_VertexCount);
                    m_Indices.Add(i + m_VertexCount + 1);
                }
            }
        }


        m_Mesh = new Mesh();
        m_Mesh.vertices = m_Vertices.ToArray();
        m_Mesh.uv = m_UVs.ToArray();
        m_Mesh.triangles = m_Indices.ToArray();
        m_Mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = m_Mesh;
    }
	
	void Update ()
    {
		if(m_Regenerate)
        {
            Initialize();
            m_Regenerate = false;
        }
	}
}
