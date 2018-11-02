using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawner : MonoBehaviour
{
    public RenderTexture m_groundTex;
    public GameObject m_grassPrefab;
    public GameObject m_grassPlane;

    public int m_nGrassChancePerPixel = 10;

    private Texture2D m_samplerTex;
    private bool m_bRender = true;

	// Use this for initialization
	void Awake ()
    {
        // Create new texture instance.
        m_samplerTex = new Texture2D(m_groundTex.width, m_groundTex.height);
	}
	
    IEnumerator ReadPixelsFromBuffer()
    {
        yield return new WaitForEndOfFrame();

        // Set active rendertexture to the ground texture,
        RenderTexture currentRT = BackgroundCamera.GetBackgroundTexture();
        RenderTexture.active = currentRT;

        m_samplerTex.ReadPixels(new Rect(0, 0, m_groundTex.width, m_groundTex.height), 0, 0);
        m_samplerTex.Apply();

        // Revert active rendertexture to null.
        RenderTexture.active = null;

        Vector3 v3GrassPos = new Vector3();
        Vector3 v3PlaneOrigin = m_grassPlane.transform.position - new Vector3(m_grassPlane.transform.lossyScale.x, 0, m_grassPlane.transform.lossyScale.z) * 5;

        for (int i = 0; i < m_groundTex.width; ++i)
        {
            for (int j = 0; j < m_groundTex.width; ++j)
            {
                Color pixelColor = m_samplerTex.GetPixel(i, j);

                Debug.Log(pixelColor);

                if (pixelColor.r >= 0.1f)
                {
                    // Randomly create grass.

                    int nRandVal = Random.Range(0, 100);

                    if(nRandVal < 2 && m_grassPrefab != null)
                    {
                        // Determine position of grass.
                        v3GrassPos.x = (i / (float)m_groundTex.width) * m_grassPlane.transform.lossyScale.x * 10;
                        v3GrassPos.z = (j / (float)m_groundTex.height) * m_grassPlane.transform.lossyScale.z * 10;

                        v3GrassPos += v3PlaneOrigin;

                        v3GrassPos.y = m_grassPlane.transform.position.y;

                        // Instaniate grass object.
                        GameObject grassInstance = Instantiate(m_grassPrefab);

                        grassInstance.transform.position = v3GrassPos;
                    }
                }
            }
        }

        m_bRender = false;
    }

	// Update is called once per frame
	void Update ()
    {
		if(m_bRender)
        {
            StartCoroutine(ReadPixelsFromBuffer());
        }
	}
}
