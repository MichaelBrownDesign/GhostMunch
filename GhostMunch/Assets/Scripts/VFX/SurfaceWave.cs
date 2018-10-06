using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SurfaceWave : MonoBehaviour
{
    Material m_Material;

	void Start ()
    {
        m_Material = GetComponent<Renderer>().material;
    }
	
	void Update ()
    {
        m_Material.SetVector("_WorldPosition", transform.position);
    }
}
