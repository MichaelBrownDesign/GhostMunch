using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class PostEffect : MonoBehaviour
{
    public Material m_PostEffect;
    public Shader m_BloomShader;

    [Range(1, 16)]
    public int m_Iterations = 1;

    [Range(0, 10)]
    public int m_Threshold = 1;

    [Range(0, 1)]
    public float m_SoftThreshold = 0.5f;

    [Range(0, 10)]
    public float m_Intensity = 1.0f;

    RenderTexture[] m_Textures = new RenderTexture[16];
    
    Material m_Bloom;

    const int m_BoxDownPrefilterPass = 0;
    const int m_BoxDownPass = 1;
    const int m_BoxUpPass = 2;
    const int m_ApplyBloomPass = 3;

    Camera m_Camera;

    private void Start()
    {
        m_Camera = GetComponent<Camera>();
        m_Camera.depthTextureMode = DepthTextureMode.DepthNormals;
    }

    
    void OnRenderImage(RenderTexture _source, RenderTexture _destination)
    {
        if (m_Bloom == null)
        {
            m_Bloom = new Material(m_BloomShader);
            m_Bloom.hideFlags = HideFlags.HideAndDontSave;
        }

        //m_Bloom.SetFloat("_Threshold", m_Threshold);
        //m_Bloom.SetFloat("_SoftThreshold", m_SoftThreshold);

        float knee = m_Threshold * m_SoftThreshold;
        Vector4 filter;
        filter.x = m_Threshold;
        filter.y = filter.x - knee;
        filter.z = 2f * knee;
        filter.w = 0.25f / (knee + 0.00001f);

        m_Bloom.SetVector("_Filter", filter);
        m_Bloom.SetFloat("_Intensity", Mathf.GammaToLinearSpace(m_Intensity));

        int width = _source.width / 2;
        int height = _source.height / 2;
        RenderTextureFormat format = _source.format;

        RenderTexture currentDestination = m_Textures[0] = RenderTexture.GetTemporary(width, height, 0, format);

        Graphics.Blit(_source, currentDestination, m_Bloom, m_BoxDownPrefilterPass);
        RenderTexture currentSource = currentDestination;

        int i = 1;
        for (; i < m_Iterations; ++i)
        {
            width /= 2;
            height /= 2;

            if (height < 2)
                break;

            currentDestination = m_Textures[i] = RenderTexture.GetTemporary(width, height, 0, format);
            Graphics.Blit(currentSource, currentDestination, m_Bloom, m_BoxDownPass);
            currentSource = currentDestination;
        }

        for(i -= 2; i >= 0; i--)
        {
            currentDestination = m_Textures[i];
            m_Textures[i] = null;
            Graphics.Blit(currentSource, currentDestination, m_Bloom, m_BoxUpPass);
            RenderTexture.ReleaseTemporary(currentSource);
            currentSource = currentDestination;
        }

        //Graphics.Blit(currentSource, _destination, m_Bloom, m_BoxUpPass);

        m_Bloom.SetTexture("_SourceTex", _source);
        Graphics.Blit(currentSource, _source, m_Bloom, m_ApplyBloomPass);
        Graphics.Blit(_source, _destination, m_PostEffect);
        RenderTexture.ReleaseTemporary(currentSource);
        

        ///////

    
    }

	
}
