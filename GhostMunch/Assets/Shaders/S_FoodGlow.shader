// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-4503-RGB,normal-8686-RGB,emission-2666-OUT;n:type:ShaderForge.SFN_Tex2d,id:6795,x:32115,y:32919,ptovrint:False,ptlb:Emissive,ptin:_Emissive,varname:node_6795,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-1498-OUT;n:type:ShaderForge.SFN_TexCoord,id:6710,x:31557,y:32901,varname:node_6710,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Color,id:1872,x:32109,y:33111,ptovrint:False,ptlb:EmissionColor,ptin:_EmissionColor,varname:node_1872,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.85,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:2666,x:32404,y:32981,varname:node_2666,prsc:2|A-6795-RGB,B-1872-RGB,C-6393-OUT,D-2390-OUT;n:type:ShaderForge.SFN_Slider,id:2390,x:31952,y:33282,ptovrint:False,ptlb:EmissionStrength,ptin:_EmissionStrength,varname:node_2390,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Fresnel,id:6393,x:32168,y:33400,varname:node_6393,prsc:2|NRM-8245-OUT,EXP-3910-OUT;n:type:ShaderForge.SFN_NormalVector,id:8245,x:31919,y:33400,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:3910,x:31762,y:33582,ptovrint:False,ptlb:FresnelStrength,ptin:_FresnelStrength,varname:node_3910,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.692308,max:10;n:type:ShaderForge.SFN_Tex2d,id:4503,x:32111,y:32551,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_4503,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4574-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:4574,x:31863,y:32551,varname:node_4574,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:7836,x:31755,y:32901,varname:node_7836,prsc:2,spu:1,spv:1|UVIN-6710-UVOUT;n:type:ShaderForge.SFN_Slider,id:7065,x:31598,y:33088,ptovrint:False,ptlb:PanSpeed,ptin:_PanSpeed,varname:node_7065,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2136752,max:5;n:type:ShaderForge.SFN_Multiply,id:1498,x:31934,y:32936,varname:node_1498,prsc:2|A-7836-UVOUT,B-7065-OUT;n:type:ShaderForge.SFN_Tex2d,id:8686,x:32111,y:32730,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_8686,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True|UVIN-3645-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:3645,x:31863,y:32730,varname:node_3645,prsc:2,uv:0,uaff:False;proporder:6795-1872-2390-3910-4503-7065-8686;pass:END;sub:END;*/

Shader "Shader Forge/S_FoodGlow" {
    Properties {
        _Emissive ("Emissive", 2D) = "white" {}
        _EmissionColor ("EmissionColor", Color) = (0,0.85,1,1)
        _EmissionStrength ("EmissionStrength", Range(0, 5)) = 1
        _FresnelStrength ("FresnelStrength", Range(0, 10)) = 2.692308
        _Diffuse ("Diffuse", 2D) = "white" {}
        _PanSpeed ("PanSpeed", Range(0, 5)) = 0.2136752
        _Normal ("Normal", 2D) = "bump" {}
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
            uniform sampler2D _Emissive; uniform float4 _Emissive_ST;
            uniform float4 _EmissionColor;
            uniform float _EmissionStrength;
            uniform float _FresnelStrength;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _PanSpeed;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
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
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = _Diffuse_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_4147 = _Time + _TimeEditor;
                float2 node_1498 = ((i.uv0+node_4147.g*float2(1,1))*_PanSpeed);
                float4 _Emissive_var = tex2D(_Emissive,TRANSFORM_TEX(node_1498, _Emissive));
                float3 emissive = (_Emissive_var.rgb*_EmissionColor.rgb*pow(1.0-max(0,dot(i.normalDir, viewDirection)),_FresnelStrength)*_EmissionStrength);
/// Final Color:
                float3 finalColor = diffuse + emissive;
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
            uniform sampler2D _Emissive; uniform float4 _Emissive_ST;
            uniform float4 _EmissionColor;
            uniform float _EmissionStrength;
            uniform float _FresnelStrength;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _PanSpeed;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = _Diffuse_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
