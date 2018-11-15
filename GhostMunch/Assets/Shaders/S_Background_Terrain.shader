// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33161,y:32716,varname:node_2865,prsc:2|diff-5261-OUT,spec-358-OUT,normal-502-RGB,emission-5261-OUT,custl-9799-OUT,clip-8123-OUT,voffset-6319-OUT,tess-8206-OUT;n:type:ShaderForge.SFN_Slider,id:358,x:32250,y:32780,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:30963,y:33945,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Vector3,id:5127,x:32001,y:33198,varname:node_5127,prsc:2,v1:0,v2:1,v3:0;n:type:ShaderForge.SFN_Multiply,id:1107,x:32204,y:33180,varname:node_1107,prsc:2|A-4948-OUT,B-5127-OUT,C-6438-OUT,D-359-RGB;n:type:ShaderForge.SFN_Tex2d,id:4991,x:31290,y:32550,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_4991,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Subtract,id:4948,x:31530,y:32685,varname:node_4948,prsc:2|A-4991-RGB,B-6124-RGB;n:type:ShaderForge.SFN_Tex2d,id:6124,x:31285,y:32760,ptovrint:False,ptlb:BlurTex,ptin:_BlurTex,varname:node_6124,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:936,x:31966,y:33442,ptovrint:False,ptlb:Tessellation,ptin:_Tessellation,varname:node_936,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1,max:64;n:type:ShaderForge.SFN_Slider,id:6438,x:31854,y:33304,ptovrint:False,ptlb:HeightScale,ptin:_HeightScale,varname:node_6438,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Multiply,id:5261,x:31959,y:32687,varname:node_5261,prsc:2|A-4948-OUT,B-6168-RGB,C-4630-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:1587,x:31324,y:33125,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_1587,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:359,x:31541,y:33020,varname:node_359,prsc:2,ntxv:0,isnm:False|UVIN-9488-UVOUT,TEX-1587-TEX;n:type:ShaderForge.SFN_TexCoord,id:9488,x:31324,y:32955,varname:node_9488,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:8123,x:32407,y:32974,varname:node_8123,prsc:2|A-9813-R,B-9813-G,C-9813-B;n:type:ShaderForge.SFN_ComponentMask,id:9813,x:32242,y:32964,varname:node_9813,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-4948-OUT;n:type:ShaderForge.SFN_Color,id:1,x:31739,y:32812,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_LightAttenuation,id:493,x:32272,y:33978,varname:node_493,prsc:2;n:type:ShaderForge.SFN_LightColor,id:7832,x:32272,y:33844,varname:node_7832,prsc:2;n:type:ShaderForge.SFN_LightVector,id:116,x:31396,y:33546,varname:node_116,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:3216,x:31396,y:33674,prsc:2,pt:True;n:type:ShaderForge.SFN_HalfVector,id:1783,x:31396,y:33825,varname:node_1783,prsc:2;n:type:ShaderForge.SFN_Dot,id:2430,x:31608,y:33589,cmnt:Lambert,varname:node_2430,prsc:2,dt:1|A-116-OUT,B-3216-OUT;n:type:ShaderForge.SFN_Dot,id:4770,x:31608,y:33763,cmnt:Blinn-Phong,varname:node_4770,prsc:2,dt:1|A-3216-OUT,B-1783-OUT;n:type:ShaderForge.SFN_Multiply,id:4126,x:32003,y:33758,cmnt:Specular Contribution,varname:node_4126,prsc:2|A-2430-OUT,B-8064-OUT,C-5238-RGB;n:type:ShaderForge.SFN_Multiply,id:7766,x:32003,y:33585,cmnt:Diffuse Contribution,varname:node_7766,prsc:2|A-5261-OUT,B-2430-OUT;n:type:ShaderForge.SFN_Exp,id:5209,x:31608,y:33946,varname:node_5209,prsc:2,et:1|IN-6682-OUT;n:type:ShaderForge.SFN_Power,id:8064,x:31806,y:33832,varname:node_8064,prsc:2|VAL-4770-OUT,EXP-5209-OUT;n:type:ShaderForge.SFN_Add,id:9241,x:32272,y:33704,cmnt:Combine,varname:node_9241,prsc:2|A-7766-OUT,B-4126-OUT;n:type:ShaderForge.SFN_Multiply,id:9799,x:32517,y:33844,cmnt:Attenuate and Color,varname:node_9799,prsc:2|A-9241-OUT,B-7832-RGB,C-493-OUT;n:type:ShaderForge.SFN_ConstantLerp,id:6682,x:31396,y:33948,varname:node_6682,prsc:2,a:1,b:11|IN-1813-OUT;n:type:ShaderForge.SFN_Color,id:5238,x:31806,y:33987,ptovrint:False,ptlb:Spec Color,ptin:_SpecColor,varname:node_4865,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:6168,x:31486,y:32859,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_6168,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_FragmentPosition,id:6322,x:31789,y:32438,varname:node_6322,prsc:2;n:type:ShaderForge.SFN_DDX,id:5371,x:31990,y:32362,varname:node_5371,prsc:2|IN-6322-XYZ;n:type:ShaderForge.SFN_DDY,id:2546,x:31990,y:32528,varname:node_2546,prsc:2|IN-6322-XYZ;n:type:ShaderForge.SFN_Normalize,id:6803,x:32164,y:32362,varname:node_6803,prsc:2|IN-5371-OUT;n:type:ShaderForge.SFN_Normalize,id:9713,x:32175,y:32528,varname:node_9713,prsc:2|IN-2546-OUT;n:type:ShaderForge.SFN_Cross,id:3480,x:32375,y:32446,varname:node_3480,prsc:2|A-6803-OUT,B-9713-OUT;n:type:ShaderForge.SFN_If,id:8206,x:32701,y:33340,varname:node_8206,prsc:2|A-8123-OUT,B-2323-OUT,GT-936-OUT,EQ-100-OUT,LT-100-OUT;n:type:ShaderForge.SFN_Vector1,id:2323,x:32396,y:33098,varname:node_2323,prsc:2,v1:0.15;n:type:ShaderForge.SFN_Vector1,id:100,x:32227,y:33548,varname:node_100,prsc:2,v1:1;n:type:ShaderForge.SFN_Tex2d,id:502,x:32606,y:32476,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_502,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:4630,x:31959,y:32919,varname:node_4630,prsc:2|A-1-RGB,B-359-RGB;n:type:ShaderForge.SFN_TexCoord,id:2451,x:32577,y:33594,varname:node_2451,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Subtract,id:3862,x:32776,y:33594,varname:node_3862,prsc:2|A-2451-UVOUT,B-1753-OUT;n:type:ShaderForge.SFN_Vector2,id:1753,x:32577,y:33747,varname:node_1753,prsc:2,v1:0.5,v2:0.5;n:type:ShaderForge.SFN_Multiply,id:3379,x:32965,y:33594,varname:node_3379,prsc:2|A-3862-OUT,B-6614-OUT;n:type:ShaderForge.SFN_Vector1,id:6614,x:32776,y:33725,varname:node_6614,prsc:2,v1:2;n:type:ShaderForge.SFN_Sin,id:6732,x:33137,y:33594,varname:node_6732,prsc:2|IN-3379-OUT;n:type:ShaderForge.SFN_Length,id:93,x:33304,y:33594,varname:node_93,prsc:2|IN-6732-OUT;n:type:ShaderForge.SFN_Multiply,id:925,x:33483,y:33594,varname:node_925,prsc:2|A-93-OUT,B-5865-OUT,C-6022-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6022,x:33304,y:33753,ptovrint:False,ptlb:HillScale,ptin:_HillScale,varname:node_6022,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Add,id:6319,x:33700,y:33536,varname:node_6319,prsc:2|A-925-OUT,B-1107-OUT;n:type:ShaderForge.SFN_Vector3,id:5865,x:33289,y:33814,varname:node_5865,prsc:2,v1:0,v2:1,v3:0;proporder:358-1813-4991-6124-936-6438-1587-1-5238-6168-502-6022;pass:END;sub:END;*/

Shader "Shader Forge/S_Background_Terrain" {
    Properties {
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _MainTex ("MainTex", 2D) = "white" {}
        _BlurTex ("BlurTex", 2D) = "white" {}
        _Tessellation ("Tessellation", Range(1, 64)) = 1
        _HeightScale ("HeightScale", Range(0, 5)) = 1
        _Noise ("Noise", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _SpecColor ("Spec Color", Color) = (1,1,1,1)
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Normal ("Normal", 2D) = "white" {}
        _HillScale ("HillScale", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            Blend SrcAlpha OneMinusSrcAlpha
            
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BlurTex; uniform float4 _BlurTex_ST;
            uniform float _Tessellation;
            uniform float _HeightScale;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float4 _Color;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _HillScale;
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
                float2 node_6732 = sin(((o.uv0-float2(0.5,0.5))*2.0));
                float node_93 = length(node_6732);
                float4 _MainTex_var = tex2Dlod(_MainTex,float4(TRANSFORM_TEX(o.uv0, _MainTex),0.0,0));
                float4 _BlurTex_var = tex2Dlod(_BlurTex,float4(TRANSFORM_TEX(o.uv0, _BlurTex),0.0,0));
                float3 node_4948 = (_MainTex_var.rgb-_BlurTex_var.rgb);
                float4 node_359 = tex2Dlod(_Noise,float4(TRANSFORM_TEX(o.uv0, _Noise),0.0,0));
                v.vertex.xyz += ((node_93*float3(0,1,0)*_HillScale)+(node_4948*float3(0,1,0)*_HeightScale*node_359.rgb));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    float4 _MainTex_var = tex2Dlod(_MainTex,float4(TRANSFORM_TEX(v.texcoord0, _MainTex),0.0,0));
                    float4 _BlurTex_var = tex2Dlod(_BlurTex,float4(TRANSFORM_TEX(v.texcoord0, _BlurTex),0.0,0));
                    float3 node_4948 = (_MainTex_var.rgb-_BlurTex_var.rgb);
                    float3 node_9813 = node_4948.rgb;
                    float node_8123 = (node_9813.r*node_9813.g*node_9813.b);
                    float node_8206_if_leA = step(node_8123,0.15);
                    float node_8206_if_leB = step(0.15,node_8123);
                    float node_100 = 1.0;
                    return lerp((node_8206_if_leA*node_100)+(node_8206_if_leB*_Tessellation),node_100,node_8206_if_leA*node_8206_if_leB);
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 _BlurTex_var = tex2D(_BlurTex,TRANSFORM_TEX(i.uv0, _BlurTex));
                float3 node_4948 = (_MainTex_var.rgb-_BlurTex_var.rgb);
                float3 node_9813 = node_4948.rgb;
                float node_8123 = (node_9813.r*node_9813.g*node_9813.b);
                clip(node_8123 - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float4 node_359 = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float3 node_5261 = (node_4948*_Diffuse_var.rgb*(_Color.rgb*node_359.rgb));
                float3 emissive = node_5261;
                float node_2430 = max(0,dot(lightDirection,normalDirection)); // Lambert
                float3 finalColor = emissive + (((node_5261*node_2430)+(node_2430*pow(max(0,dot(normalDirection,halfDirection)),exp2(lerp(1,11,_Gloss)))*_SpecColor.rgb))*_LightColor0.rgb*attenuation);
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
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BlurTex; uniform float4 _BlurTex_ST;
            uniform float _Tessellation;
            uniform float _HeightScale;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float4 _Color;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _HillScale;
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
                float2 node_6732 = sin(((o.uv0-float2(0.5,0.5))*2.0));
                float node_93 = length(node_6732);
                float4 _MainTex_var = tex2Dlod(_MainTex,float4(TRANSFORM_TEX(o.uv0, _MainTex),0.0,0));
                float4 _BlurTex_var = tex2Dlod(_BlurTex,float4(TRANSFORM_TEX(o.uv0, _BlurTex),0.0,0));
                float3 node_4948 = (_MainTex_var.rgb-_BlurTex_var.rgb);
                float4 node_359 = tex2Dlod(_Noise,float4(TRANSFORM_TEX(o.uv0, _Noise),0.0,0));
                v.vertex.xyz += ((node_93*float3(0,1,0)*_HillScale)+(node_4948*float3(0,1,0)*_HeightScale*node_359.rgb));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    float4 _MainTex_var = tex2Dlod(_MainTex,float4(TRANSFORM_TEX(v.texcoord0, _MainTex),0.0,0));
                    float4 _BlurTex_var = tex2Dlod(_BlurTex,float4(TRANSFORM_TEX(v.texcoord0, _BlurTex),0.0,0));
                    float3 node_4948 = (_MainTex_var.rgb-_BlurTex_var.rgb);
                    float3 node_9813 = node_4948.rgb;
                    float node_8123 = (node_9813.r*node_9813.g*node_9813.b);
                    float node_8206_if_leA = step(node_8123,0.15);
                    float node_8206_if_leB = step(0.15,node_8123);
                    float node_100 = 1.0;
                    return lerp((node_8206_if_leA*node_100)+(node_8206_if_leB*_Tessellation),node_100,node_8206_if_leA*node_8206_if_leB);
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 _BlurTex_var = tex2D(_BlurTex,TRANSFORM_TEX(i.uv0, _BlurTex));
                float3 node_4948 = (_MainTex_var.rgb-_BlurTex_var.rgb);
                float3 node_9813 = node_4948.rgb;
                float node_8123 = (node_9813.r*node_9813.g*node_9813.b);
                clip(node_8123 - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float4 node_359 = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float3 node_5261 = (node_4948*_Diffuse_var.rgb*(_Color.rgb*node_359.rgb));
                float node_2430 = max(0,dot(lightDirection,normalDirection)); // Lambert
                float3 finalColor = (((node_5261*node_2430)+(node_2430*pow(max(0,dot(normalDirection,halfDirection)),exp2(lerp(1,11,_Gloss)))*_SpecColor.rgb))*_LightColor0.rgb*attenuation);
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
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BlurTex; uniform float4 _BlurTex_ST;
            uniform float _Tessellation;
            uniform float _HeightScale;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _HillScale;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float2 node_6732 = sin(((o.uv0-float2(0.5,0.5))*2.0));
                float node_93 = length(node_6732);
                float4 _MainTex_var = tex2Dlod(_MainTex,float4(TRANSFORM_TEX(o.uv0, _MainTex),0.0,0));
                float4 _BlurTex_var = tex2Dlod(_BlurTex,float4(TRANSFORM_TEX(o.uv0, _BlurTex),0.0,0));
                float3 node_4948 = (_MainTex_var.rgb-_BlurTex_var.rgb);
                float4 node_359 = tex2Dlod(_Noise,float4(TRANSFORM_TEX(o.uv0, _Noise),0.0,0));
                v.vertex.xyz += ((node_93*float3(0,1,0)*_HillScale)+(node_4948*float3(0,1,0)*_HeightScale*node_359.rgb));
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    float4 _MainTex_var = tex2Dlod(_MainTex,float4(TRANSFORM_TEX(v.texcoord0, _MainTex),0.0,0));
                    float4 _BlurTex_var = tex2Dlod(_BlurTex,float4(TRANSFORM_TEX(v.texcoord0, _BlurTex),0.0,0));
                    float3 node_4948 = (_MainTex_var.rgb-_BlurTex_var.rgb);
                    float3 node_9813 = node_4948.rgb;
                    float node_8123 = (node_9813.r*node_9813.g*node_9813.b);
                    float node_8206_if_leA = step(node_8123,0.15);
                    float node_8206_if_leB = step(0.15,node_8123);
                    float node_100 = 1.0;
                    return lerp((node_8206_if_leA*node_100)+(node_8206_if_leB*_Tessellation),node_100,node_8206_if_leA*node_8206_if_leB);
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 _BlurTex_var = tex2D(_BlurTex,TRANSFORM_TEX(i.uv0, _BlurTex));
                float3 node_4948 = (_MainTex_var.rgb-_BlurTex_var.rgb);
                float3 node_9813 = node_4948.rgb;
                float node_8123 = (node_9813.r*node_9813.g*node_9813.b);
                clip(node_8123 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Tessellation.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform float _Metallic;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BlurTex; uniform float4 _BlurTex_ST;
            uniform float _Tessellation;
            uniform float _HeightScale;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float4 _Color;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _HillScale;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float2 node_6732 = sin(((o.uv0-float2(0.5,0.5))*2.0));
                float node_93 = length(node_6732);
                float4 _MainTex_var = tex2Dlod(_MainTex,float4(TRANSFORM_TEX(o.uv0, _MainTex),0.0,0));
                float4 _BlurTex_var = tex2Dlod(_BlurTex,float4(TRANSFORM_TEX(o.uv0, _BlurTex),0.0,0));
                float3 node_4948 = (_MainTex_var.rgb-_BlurTex_var.rgb);
                float4 node_359 = tex2Dlod(_Noise,float4(TRANSFORM_TEX(o.uv0, _Noise),0.0,0));
                v.vertex.xyz += ((node_93*float3(0,1,0)*_HillScale)+(node_4948*float3(0,1,0)*_HeightScale*node_359.rgb));
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                    float2 texcoord1 : TEXCOORD1;
                    float2 texcoord2 : TEXCOORD2;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    o.texcoord1 = v.texcoord1;
                    o.texcoord2 = v.texcoord2;
                    return o;
                }
                float Tessellation(TessVertex v){
                    float4 _MainTex_var = tex2Dlod(_MainTex,float4(TRANSFORM_TEX(v.texcoord0, _MainTex),0.0,0));
                    float4 _BlurTex_var = tex2Dlod(_BlurTex,float4(TRANSFORM_TEX(v.texcoord0, _BlurTex),0.0,0));
                    float3 node_4948 = (_MainTex_var.rgb-_BlurTex_var.rgb);
                    float3 node_9813 = node_4948.rgb;
                    float node_8123 = (node_9813.r*node_9813.g*node_9813.b);
                    float node_8206_if_leA = step(node_8123,0.15);
                    float node_8206_if_leB = step(0.15,node_8123);
                    float node_100 = 1.0;
                    return lerp((node_8206_if_leA*node_100)+(node_8206_if_leB*_Tessellation),node_100,node_8206_if_leA*node_8206_if_leB);
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    v.texcoord1 = vi[0].texcoord1*bary.x + vi[1].texcoord1*bary.y + vi[2].texcoord1*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : SV_Target {
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 _BlurTex_var = tex2D(_BlurTex,TRANSFORM_TEX(i.uv0, _BlurTex));
                float3 node_4948 = (_MainTex_var.rgb-_BlurTex_var.rgb);
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float4 node_359 = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float3 node_5261 = (node_4948*_Diffuse_var.rgb*(_Color.rgb*node_359.rgb));
                o.Emission = node_5261;
                
                float3 diffColor = float3(0,0,0);
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
