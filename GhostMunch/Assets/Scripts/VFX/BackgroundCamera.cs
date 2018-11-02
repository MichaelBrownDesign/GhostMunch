using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera)), ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class BackgroundCamera : MonoBehaviour
{

    Camera m_Camera;
    Material m_Bloom;

    [SerializeField]
    Shader m_BloomShader;

    public Material m_BackgroundMaterial;

    [Range(0, 2.0f)]
    public float m_Threshold = 1.0f;
    [Range(0, 1.0f)]
    public float m_SoftThreshold = 1.0f;

    [Range(0,16)]
    public float m_Intensity = 1.0f;
    [Range(0,16)]
    public int m_Iterations = 1;

    RenderTexture[] m_Textures = new RenderTexture[16];

    const int m_BoxDownPrefilterPass = 0;
    const int m_BoxDownPass = 1;
    const int m_BoxUpPass = 2;
    const int m_ApplyBloomPass = 3;

    static RenderTexture m_OriginalSource;

    void Start ()
    {
        m_Camera = GetComponent<Camera>();
    }

    public static RenderTexture GetBackgroundTexture()
    {
        return m_OriginalSource;
    }

    private void OnRenderImage(RenderTexture _source, RenderTexture _destination)
    {
        m_OriginalSource = _source;

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
        RenderTexture bloomFinal = RenderTexture.GetTemporary(_source.width, _source.height);
        Graphics.Blit(currentSource, bloomFinal, m_Bloom, m_ApplyBloomPass);

        m_BackgroundMaterial.SetTexture("_BlurTex", m_OriginalSource);
        m_BackgroundMaterial.SetTexture("_MainTex", bloomFinal);
        Graphics.Blit(bloomFinal, _destination, m_BackgroundMaterial);

        RenderTexture.ReleaseTemporary(bloomFinal);
        //RenderTexture.ReleaseTemporary(originalSource);
        RenderTexture.ReleaseTemporary(currentSource);
    }
}
