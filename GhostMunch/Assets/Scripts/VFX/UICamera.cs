using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamera : MonoBehaviour
{
    RenderTexture m_Frame;
    public Material m_RenderEffect;

	void Start ()
    {
        GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
	}

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, m_RenderEffect);
        m_Frame = destination;
    }
}
