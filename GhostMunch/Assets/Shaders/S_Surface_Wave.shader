// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32902,y:32670,varname:node_4013,prsc:2|diff-1304-RGB,voffset-8438-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32501,y:32534,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:1888,x:32089,y:33113,ptovrint:False,ptlb:Amplitude,ptin:_Amplitude,varname:node_1888,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Vector4Property,id:297,x:31417,y:32897,ptovrint:False,ptlb:WorldPosition,ptin:_WorldPosition,varname:node_297,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_FragmentPosition,id:6495,x:31417,y:33051,varname:node_6495,prsc:2;n:type:ShaderForge.SFN_Subtract,id:5460,x:31708,y:32996,varname:node_5460,prsc:2|A-297-Z,B-6495-Z;n:type:ShaderForge.SFN_Sin,id:4000,x:32089,y:32954,varname:node_4000,prsc:2|IN-5038-OUT;n:type:ShaderForge.SFN_Time,id:9306,x:31727,y:32841,varname:node_9306,prsc:2;n:type:ShaderForge.SFN_Append,id:4640,x:32449,y:33029,varname:node_4640,prsc:2|A-8195-OUT,B-4632-OUT,C-8195-OUT;n:type:ShaderForge.SFN_Vector1,id:8195,x:32256,y:33113,varname:node_8195,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:4632,x:32256,y:32982,varname:node_4632,prsc:2|A-4000-OUT,B-1888-OUT;n:type:ShaderForge.SFN_Add,id:5038,x:31918,y:32890,varname:node_5038,prsc:2|A-9306-T,B-5460-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:2972,x:31810,y:33437,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_2972,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5602,x:32251,y:33249,varname:node_5602,prsc:2,ntxv:0,isnm:False|UVIN-4336-UVOUT,TEX-2972-TEX;n:type:ShaderForge.SFN_Tex2d,id:6587,x:32259,y:33433,varname:node_6587,prsc:2,ntxv:0,isnm:False|UVIN-5572-UVOUT,TEX-2972-TEX;n:type:ShaderForge.SFN_TexCoord,id:8795,x:31810,y:33249,varname:node_8795,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:4336,x:32021,y:33167,varname:node_4336,prsc:2,spu:0.1,spv:0.1|UVIN-8795-UVOUT;n:type:ShaderForge.SFN_Panner,id:5572,x:32021,y:33311,varname:node_5572,prsc:2,spu:0.073,spv:0.069|UVIN-8795-UVOUT;n:type:ShaderForge.SFN_Multiply,id:8699,x:32476,y:33311,varname:node_8699,prsc:2|A-5602-RGB,B-6587-RGB;n:type:ShaderForge.SFN_NormalVector,id:8246,x:32476,y:33433,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:2868,x:32674,y:33368,varname:node_2868,prsc:2|A-8699-OUT,B-8246-OUT;n:type:ShaderForge.SFN_Multiply,id:6728,x:32856,y:33393,varname:node_6728,prsc:2|A-2868-OUT,B-5577-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5577,x:32716,y:33556,ptovrint:False,ptlb:Noise Amplitude,ptin:_NoiseAmplitude,varname:node_5577,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Add,id:8438,x:32700,y:33054,varname:node_8438,prsc:2|A-4640-OUT,B-6728-OUT;proporder:1304-1888-297-2972-5577;pass:END;sub:END;*/

Shader "Shader Forge/S_Surface_Wave" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _Amplitude ("Amplitude", Float ) = 1
        _WorldPosition ("WorldPosition", Vector) = (0,0,0,0)
        _Noise ("Noise", 2D) = "white" {}
        _NoiseAmplitude ("Noise Amplitude", Float ) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _Amplitude;
            uniform float4 _WorldPosition;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _NoiseAmplitude;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float node_8195 = 0.0;
                float4 node_9306 = _Time + _TimeEditor;
                float3 node_4640 = float3(node_8195,(sin((node_9306.g+(_WorldPosition.b-mul(unity_ObjectToWorld, v.vertex).b)))*_Amplitude),node_8195);
                float4 node_6417 = _Time + _TimeEditor;
                float2 node_4336 = (o.uv0+node_6417.g*float2(0.1,0.1));
                float4 node_5602 = tex2Dlod(_Noise,float4(TRANSFORM_TEX(node_4336, _Noise),0.0,0));
                float2 node_5572 = (o.uv0+node_6417.g*float2(0.073,0.069));
                float4 node_6587 = tex2Dlod(_Noise,float4(TRANSFORM_TEX(node_5572, _Noise),0.0,0));
                float3 node_6728 = (((node_5602.rgb*node_6587.rgb)*v.normal)*_NoiseAmplitude);
                v.vertex.xyz += (node_4640+node_6728);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = _Color.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _Amplitude;
            uniform float4 _WorldPosition;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _NoiseAmplitude;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float node_8195 = 0.0;
                float4 node_9306 = _Time + _TimeEditor;
                float3 node_4640 = float3(node_8195,(sin((node_9306.g+(_WorldPosition.b-mul(unity_ObjectToWorld, v.vertex).b)))*_Amplitude),node_8195);
                float4 node_7130 = _Time + _TimeEditor;
                float2 node_4336 = (o.uv0+node_7130.g*float2(0.1,0.1));
                float4 node_5602 = tex2Dlod(_Noise,float4(TRANSFORM_TEX(node_4336, _Noise),0.0,0));
                float2 node_5572 = (o.uv0+node_7130.g*float2(0.073,0.069));
                float4 node_6587 = tex2Dlod(_Noise,float4(TRANSFORM_TEX(node_5572, _Noise),0.0,0));
                float3 node_6728 = (((node_5602.rgb*node_6587.rgb)*v.normal)*_NoiseAmplitude);
                v.vertex.xyz += (node_4640+node_6728);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = _Color.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Amplitude;
            uniform float4 _WorldPosition;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _NoiseAmplitude;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float node_8195 = 0.0;
                float4 node_9306 = _Time + _TimeEditor;
                float3 node_4640 = float3(node_8195,(sin((node_9306.g+(_WorldPosition.b-mul(unity_ObjectToWorld, v.vertex).b)))*_Amplitude),node_8195);
                float4 node_9239 = _Time + _TimeEditor;
                float2 node_4336 = (o.uv0+node_9239.g*float2(0.1,0.1));
                float4 node_5602 = tex2Dlod(_Noise,float4(TRANSFORM_TEX(node_4336, _Noise),0.0,0));
                float2 node_5572 = (o.uv0+node_9239.g*float2(0.073,0.069));
                float4 node_6587 = tex2Dlod(_Noise,float4(TRANSFORM_TEX(node_5572, _Noise),0.0,0));
                float3 node_6728 = (((node_5602.rgb*node_6587.rgb)*v.normal)*_NoiseAmplitude);
                v.vertex.xyz += (node_4640+node_6728);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
