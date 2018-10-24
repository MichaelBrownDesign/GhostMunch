// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:1,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:False,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:1,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:6,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:1,qpre:4,rntp:5,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33221,y:33525,varname:node_2865,prsc:2|emission-4676-OUT;n:type:ShaderForge.SFN_TexCoord,id:4219,x:31728,y:33191,cmnt:Default coordinates,varname:node_4219,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Relay,id:8397,x:31953,y:33191,cmnt:Refract here,varname:node_8397,prsc:2|IN-4219-UVOUT;n:type:ShaderForge.SFN_Tex2dAsset,id:4430,x:31728,y:33378,ptovrint:False,ptlb:MainTex,ptin:_MainTex,cmnt:MainTex contains the color of the scene,varname:node_9933,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7542,x:32129,y:33308,varname:node_1672,prsc:2,ntxv:0,isnm:False|UVIN-8397-OUT,TEX-4430-TEX;n:type:ShaderForge.SFN_SceneDepth,id:4523,x:31655,y:33556,varname:node_4523,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2435,x:32410,y:33469,varname:node_2435,prsc:2|A-7542-RGB,B-3953-OUT;n:type:ShaderForge.SFN_Multiply,id:4054,x:31854,y:33629,varname:node_4054,prsc:2|A-4523-OUT,B-6993-OUT;n:type:ShaderForge.SFN_OneMinus,id:3953,x:32027,y:33629,varname:node_3953,prsc:2|IN-4054-OUT;n:type:ShaderForge.SFN_Slider,id:6993,x:31498,y:33721,ptovrint:False,ptlb:DepthScale,ptin:_DepthScale,varname:node_6993,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.1;n:type:ShaderForge.SFN_If,id:4676,x:32850,y:33632,varname:node_4676,prsc:2|A-3953-OUT,B-5189-OUT,GT-2435-OUT,EQ-4624-OUT,LT-4624-OUT;n:type:ShaderForge.SFN_TexCoord,id:7960,x:31498,y:34030,varname:node_7960,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:4624,x:32193,y:33916,varname:node_4624,prsc:2|A-3842-RGB,B-7233-RGB,C-2355-OUT;n:type:ShaderForge.SFN_Tex2d,id:3842,x:31901,y:33825,varname:node_3842,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-290-UVOUT,TEX-756-TEX;n:type:ShaderForge.SFN_Panner,id:290,x:31725,y:33825,varname:node_290,prsc:2,spu:0.11798,spv:0.06598|UVIN-7960-UVOUT;n:type:ShaderForge.SFN_Panner,id:4575,x:31725,y:34009,varname:node_4575,prsc:2,spu:0.05649,spv:-0.059784|UVIN-7960-UVOUT;n:type:ShaderForge.SFN_Tex2dAsset,id:756,x:31498,y:33857,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_756,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7233,x:31901,y:34009,varname:node_7233,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-4575-UVOUT,TEX-756-TEX;n:type:ShaderForge.SFN_ValueProperty,id:2355,x:31901,y:34189,ptovrint:False,ptlb:FogBrightness,ptin:_FogBrightness,varname:node_2355,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:5189,x:32465,y:33688,ptovrint:False,ptlb:FogDistance,ptin:_FogDistance,varname:node_5189,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.01;proporder:4430-6993-756-2355-5189;pass:END;sub:END;*/

Shader "Shader Forge/S_Post_DepthBlend" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _DepthScale ("DepthScale", Range(0, 0.1)) = 0
        _Noise ("Noise", 2D) = "white" {}
        _FogBrightness ("FogBrightness", Float ) = 1
        _FogDistance ("FogDistance", Float ) = 0.01
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Overlay+1"
            "RenderType"="Overlay"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZTest Always
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _DepthScale;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _FogBrightness;
            uniform float _FogDistance;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 projPos : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float node_3953 = (1.0 - (sceneZ*_DepthScale));
                float node_4676_if_leA = step(node_3953,_FogDistance);
                float node_4676_if_leB = step(_FogDistance,node_3953);
                float4 node_221 = _Time + _TimeEditor;
                float2 node_290 = (i.uv0+node_221.g*float2(0.11798,0.06598));
                float4 node_3842 = tex2D(_Noise,TRANSFORM_TEX(node_290, _Noise));
                float2 node_4575 = (i.uv0+node_221.g*float2(0.05649,-0.059784));
                float4 node_7233 = tex2D(_Noise,TRANSFORM_TEX(node_4575, _Noise));
                float3 node_4624 = (node_3842.rgb*node_7233.rgb*_FogBrightness);
                float2 node_8397 = i.uv0; // Refract here
                float4 node_1672 = tex2D(_MainTex,TRANSFORM_TEX(node_8397, _MainTex));
                float3 emissive = lerp((node_4676_if_leA*node_4624)+(node_4676_if_leB*(node_1672.rgb*node_3953)),node_4624,node_4676_if_leA*node_4676_if_leB);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
