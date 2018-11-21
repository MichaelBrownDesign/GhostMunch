// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33560,y:32717,varname:node_9361,prsc:2|emission-2460-OUT,custl-5085-OUT,alpha-8522-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:8068,x:32734,y:33086,varname:node_8068,prsc:2;n:type:ShaderForge.SFN_LightColor,id:3406,x:32734,y:32952,varname:node_3406,prsc:2;n:type:ShaderForge.SFN_LightVector,id:6869,x:31858,y:32654,varname:node_6869,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9684,x:31858,y:32782,prsc:2,pt:True;n:type:ShaderForge.SFN_HalfVector,id:9471,x:31858,y:32933,varname:node_9471,prsc:2;n:type:ShaderForge.SFN_Dot,id:7782,x:32070,y:32697,cmnt:Lambert,varname:node_7782,prsc:2,dt:1|A-6869-OUT,B-9684-OUT;n:type:ShaderForge.SFN_Dot,id:3269,x:32070,y:32871,cmnt:Blinn-Phong,varname:node_3269,prsc:2,dt:1|A-9684-OUT,B-9471-OUT;n:type:ShaderForge.SFN_Multiply,id:2746,x:32465,y:32866,cmnt:Specular Contribution,varname:node_2746,prsc:2|A-7782-OUT,B-5267-OUT,C-4865-RGB;n:type:ShaderForge.SFN_Tex2d,id:851,x:32115,y:32369,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_851,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1941,x:32465,y:32693,cmnt:Diffuse Contribution,varname:node_1941,prsc:2|A-851-RGB,B-7782-OUT;n:type:ShaderForge.SFN_Exp,id:1700,x:32070,y:33054,varname:node_1700,prsc:2,et:1|IN-9978-OUT;n:type:ShaderForge.SFN_Slider,id:5328,x:31529,y:33056,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_5328,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Power,id:5267,x:32268,y:32940,varname:node_5267,prsc:2|VAL-3269-OUT,EXP-1700-OUT;n:type:ShaderForge.SFN_Add,id:2159,x:32734,y:32812,cmnt:Combine,varname:node_2159,prsc:2|A-1941-OUT,B-2746-OUT;n:type:ShaderForge.SFN_Multiply,id:5085,x:32979,y:32952,cmnt:Attenuate and Color,varname:node_5085,prsc:2|A-2159-OUT,B-3406-RGB,C-8068-OUT;n:type:ShaderForge.SFN_ConstantLerp,id:9978,x:31858,y:33056,varname:node_9978,prsc:2,a:1,b:11|IN-5328-OUT;n:type:ShaderForge.SFN_Color,id:4865,x:32268,y:33095,ptovrint:False,ptlb:Spec Color,ptin:_SpecColor,varname:node_4865,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_AmbientLight,id:7528,x:32734,y:32515,varname:node_7528,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2460,x:32980,y:32432,cmnt:Ambient Light,varname:node_2460,prsc:2|A-851-RGB,B-7528-RGB;n:type:ShaderForge.SFN_Subtract,id:6129,x:31985,y:33383,varname:node_6129,prsc:2|A-5104-OUT,B-7382-OUT;n:type:ShaderForge.SFN_Length,id:7545,x:32566,y:33356,varname:node_7545,prsc:2|IN-3071-OUT;n:type:ShaderForge.SFN_Power,id:9754,x:32759,y:33356,varname:node_9754,prsc:2|VAL-7545-OUT,EXP-8032-OUT;n:type:ShaderForge.SFN_Divide,id:4962,x:32960,y:33390,varname:node_4962,prsc:2|A-9754-OUT,B-1011-OUT;n:type:ShaderForge.SFN_Multiply,id:7382,x:31906,y:33629,varname:node_7382,prsc:2|A-30-XYZ,B-865-OUT;n:type:ShaderForge.SFN_Vector3,id:865,x:31609,y:33557,varname:node_865,prsc:2,v1:1,v2:0,v3:1;n:type:ShaderForge.SFN_Multiply,id:5104,x:31773,y:33410,varname:node_5104,prsc:2|A-6587-OUT,B-865-OUT;n:type:ShaderForge.SFN_Slider,id:8032,x:32409,y:33607,ptovrint:False,ptlb:FadeFallOff,ptin:_FadeFallOff,varname:node_8032,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3,max:10;n:type:ShaderForge.SFN_Slider,id:1011,x:32820,y:33618,ptovrint:False,ptlb:FadeLevel,ptin:_FadeLevel,varname:node_1011,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2000,max:10000;n:type:ShaderForge.SFN_ViewVector,id:5210,x:32108,y:33233,varname:node_5210,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3071,x:32342,y:33418,varname:node_3071,prsc:2|A-6129-OUT,B-4161-XYZ;n:type:ShaderForge.SFN_Vector4Property,id:4161,x:32152,y:33541,ptovrint:False,ptlb:FadeAxisBias,ptin:_FadeAxisBias,varname:node_4161,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2,v2:0,v3:1,v4:1;n:type:ShaderForge.SFN_Vector4Property,id:8716,x:30199,y:33097,ptovrint:False,ptlb:Player1Pos,ptin:_Player1Pos,varname:node_8716,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Vector4Property,id:8904,x:30199,y:33293,ptovrint:False,ptlb:Player2Pos,ptin:_Player2Pos,varname:node_8904,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Vector4Property,id:9902,x:30199,y:33485,ptovrint:False,ptlb:Player3Pos,ptin:_Player3Pos,varname:node_9902,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Vector4Property,id:7617,x:30199,y:33702,ptovrint:False,ptlb:Player4Pos,ptin:_Player4Pos,varname:node_7617,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_FragmentPosition,id:30,x:30201,y:34002,varname:node_30,prsc:2;n:type:ShaderForge.SFN_Subtract,id:2999,x:30489,y:33127,varname:node_2999,prsc:2|A-8716-XYZ,B-30-XYZ;n:type:ShaderForge.SFN_Subtract,id:791,x:30489,y:33313,varname:node_791,prsc:2|A-8904-XYZ,B-30-XYZ;n:type:ShaderForge.SFN_Subtract,id:3827,x:30492,y:33494,varname:node_3827,prsc:2|A-9902-XYZ,B-30-XYZ;n:type:ShaderForge.SFN_Subtract,id:7278,x:30492,y:33663,varname:node_7278,prsc:2|A-7617-XYZ,B-30-XYZ;n:type:ShaderForge.SFN_Add,id:6587,x:31381,y:33432,varname:node_6587,prsc:2|A-9186-OUT,B-30-XYZ;n:type:ShaderForge.SFN_Code,id:9186,x:30818,y:33150,varname:node_9186,prsc:2,code:ZgBsAG8AYQB0ADMAIABhAGwAbABQAG8AcwBbADQAXQAgAD0AIAB7ACAAZABpAHMAdAAxACwAIABkAGkAcwB0ADIALAAgAGQAaQBzAHQAMwAsACAAZABpAHMAdAA0ACAAfQA7AAoACgBmAGwAbwBhAHQAMwAgAG8AdQB0AFAAbwBzACAAPQAgAGYAbABvAGEAdAAzACgAMAAuADAAZgAsACAAMAAuADAAZgAsACAAMAAuADAAZgApADsACgBmAGwAbwBhAHQAIABtAGkAbgBMAGUAbgBnAHQAaAAgAD0AIAA5ADkAOQA5ADkAOQAuADAAZgA7AAoACgBmAG8AcgAoAGkAbgB0ACAAaQAgAD0AIAAwADsAIABpACAAPAAgADQAOwAgACsAKwBpACkAIAAKAHsACgAgACAAIAAgAGYAbABvAGEAdAAgAGwAZQBuACAAPQAgAGwAZQBuAGcAdABoACgAYQBsAGwAUABvAHMAWwBpAF0AKQA7AAoAIAAKACAAIAAgACAAaQBmACgAbABlAG4AIAA8ACAAbQBpAG4ATABlAG4AZwB0AGgAKQAKACAAIAAgACAAewAKACAAIAAgACAAIAAgACAAIABtAGkAbgBMAGUAbgBnAHQAaAAgAD0AIABsAGUAbgA7AAoAIAAgACAAIAAgACAAIAAgAG8AdQB0AFAAbwBzACAAPQAgAGEAbABsAFAAbwBzAFsAaQBdADsACgAgACAAIAAgAH0ACgB9AAoACgByAGUAdAB1AHIAbgAgAG8AdQB0AFAAbwBzADsA,output:2,fname:Function_node_9186,width:463,height:298,input:2,input:2,input:2,input:2,input_1_label:dist1,input_2_label:dist2,input_3_label:dist3,input_4_label:dist4|A-2999-OUT,B-791-OUT,C-3827-OUT,D-7278-OUT;n:type:ShaderForge.SFN_Clamp,id:8522,x:33294,y:33118,varname:node_8522,prsc:2|IN-4962-OUT,MIN-609-OUT,MAX-5927-OUT;n:type:ShaderForge.SFN_Vector1,id:5927,x:33193,y:33406,varname:node_5927,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:609,x:32923,y:33217,ptovrint:False,ptlb:MinAlpha,ptin:_MinAlpha,varname:node_609,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2,max:1;proporder:851-5328-4865-8032-1011-4161-8716-8904-9902-7617-609;pass:END;sub:END;*/

Shader "Shader Forge/S_Wall_Master" {
	Properties{
		_Diffuse("Diffuse", 2D) = "white" {}
	_Gloss("Gloss", Range(0, 1)) = 0.5
		_SpecColor("Spec Color", Color) = (1,1,1,1)
		_FadeFallOff("FadeFallOff", Range(0, 10)) = 3
		_FadeLevel("FadeLevel", Range(0, 10000)) = 2000
		_FadeAxisBias("FadeAxisBias", Vector) = (2,0,1,1)
		_Player1Pos("Player1Pos", Vector) = (0,0,0,0)
		_Player2Pos("Player2Pos", Vector) = (0,0,0,0)
		_Player3Pos("Player3Pos", Vector) = (0,0,0,0)
		_Player4Pos("Player4Pos", Vector) = (0,0,0,0)
		_MinAlpha("MinAlpha", Range(0, 1)) = 0.2
		[HideInInspector]_Cutoff("Alpha cutoff", Range(0,1)) = 0.5
	}
		SubShader{
		Tags{
		"IgnoreProjector" = "True"
		"Queue" = "Transparent"
		"RenderType" = "Transparent"
	}
		Pass{
		Name "FORWARD"
		Tags{
		"LightMode" = "ForwardBase"
	}
		Blend SrcAlpha OneMinusSrcAlpha
		ZWrite Off

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#define UNITY_PASS_FORWARDBASE
#include "UnityCG.cginc"
#include "Lighting.cginc"
#pragma multi_compile_fwdbase
#pragma multi_compile_fog
#pragma only_renderers d3d9 d3d11 glcore gles 
#pragma target 3.0
		uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
	uniform float _Gloss;
	uniform float _FadeFallOff;
	uniform float _FadeLevel;
	uniform float4 _FadeAxisBias;
	uniform float4 _Player1Pos;
	uniform float4 _Player2Pos;
	uniform float4 _Player3Pos;
	uniform float4 _Player4Pos;
	float3 Function_node_9186(float3 dist1 , float3 dist2 , float3 dist3 , float3 dist4) {
		float3 allPos[4] = { dist1, dist2, dist3, dist4 };

		float3 outPos = float3(0.0f, 0.0f, 0.0f);
		float minLength = 999999.0f;

		for (int i = 0; i < 4; ++i)
		{
			float len = length(allPos[i]);

			if (len < minLength)
			{
				minLength = len;
				outPos = allPos[i];
			}
		}

		return outPos;
	}

	uniform float _MinAlpha;
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

		float3 chosenPos : COLOR;

		UNITY_FOG_COORDS(3)
	};
	VertexOutput vert(VertexInput v) {
		VertexOutput o = (VertexOutput)0;
		o.uv0 = v.texcoord0;
		o.normalDir = UnityObjectToWorldNormal(v.normal);
		o.posWorld = mul(unity_ObjectToWorld, v.vertex);
		float3 lightColor = _LightColor0.rgb;
		o.pos = UnityObjectToClipPos(v.vertex);

		float3 player1Dist = _Player1Pos.rgb - o.posWorld.rgb;
		float3 player2Dist = _Player2Pos.rgb - o.posWorld.rgb;
		float3 player3Dist = _Player3Pos.rgb - o.posWorld.rgb;
		float3 player4Dist = _Player4Pos.rgb - o.posWorld.rgb;

		o.chosenPos = Function_node_9186(player1Dist, player2Dist, player3Dist, player4Dist) + o.posWorld.rgb;

		UNITY_TRANSFER_FOG(o,o.pos);
		return o;
	}
	float4 frag(VertexOutput i) : COLOR{
		i.normalDir = normalize(i.normalDir);
	float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
	float3 normalDirection = i.normalDir;
	float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
	float3 lightColor = _LightColor0.rgb;
	float3 halfDirection = normalize(viewDirection + lightDirection);
	////// Lighting:
	float attenuation = 1;
	////// Emissive:
	float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
	float3 emissive = (_Diffuse_var.rgb*UNITY_LIGHTMODEL_AMBIENT.rgb);
	float node_7782 = max(0,dot(lightDirection,normalDirection)); // Lambert
	float3 finalColor = emissive + (((_Diffuse_var.rgb*node_7782) + (node_7782*pow(max(0,dot(normalDirection,halfDirection)),exp2(lerp(1,11,_Gloss)))*_SpecColor.rgb))*_LightColor0.rgb*attenuation);
	float3 node_865 = float3(1,0,1);
	fixed4 finalRGBA = fixed4(finalColor,clamp((pow(length(((((i.chosenPos)*node_865) - (i.posWorld.rgb*node_865))*_FadeAxisBias.rgb)),_FadeFallOff) / _FadeLevel),_MinAlpha,1.0));
	UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
	return finalRGBA;
	}
		ENDCG
	}
		Pass{
		Name "FORWARD_DELTA"
		Tags{
		"LightMode" = "ForwardAdd"
	}
		Blend One One
		ZWrite Off

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#define UNITY_PASS_FORWARDADD
#include "UnityCG.cginc"
#include "AutoLight.cginc"
#include "Lighting.cginc"
#pragma multi_compile_fwdadd
#pragma multi_compile_fog
#pragma only_renderers d3d9 d3d11 glcore gles 
#pragma target 3.0
		uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
	uniform float _Gloss;
	uniform float _FadeFallOff;
	uniform float _FadeLevel;
	uniform float4 _FadeAxisBias;
	uniform float4 _Player1Pos;
	uniform float4 _Player2Pos;
	uniform float4 _Player3Pos;
	uniform float4 _Player4Pos;
	float3 Function_node_9186(float3 dist1 , float3 dist2 , float3 dist3 , float3 dist4) {
		float3 allPos[4] = { dist1, dist2, dist3, dist4 };

		float3 outPos = float3(0.0f, 0.0f, 0.0f);
		float minLength = 999999.0f;

		for (int i = 0; i < 4; ++i)
		{
			float len = length(allPos[i]);

			if (len < minLength)
			{
				minLength = len;
				outPos = allPos[i];
			}
		}

		return outPos;
	}

	uniform float _MinAlpha;
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

		float3 chosenPos : COLOR;

		LIGHTING_COORDS(3,4)
			UNITY_FOG_COORDS(5)
	};
	VertexOutput vert(VertexInput v) {
		VertexOutput o = (VertexOutput)0;
		o.uv0 = v.texcoord0;
		o.normalDir = UnityObjectToWorldNormal(v.normal);
		o.posWorld = mul(unity_ObjectToWorld, v.vertex);
		float3 lightColor = _LightColor0.rgb;
		o.pos = UnityObjectToClipPos(v.vertex);

		float3 player1Dist = _Player1Pos.rgb - o.posWorld.rgb;
		float3 player2Dist = _Player2Pos.rgb - o.posWorld.rgb;
		float3 player3Dist = _Player3Pos.rgb - o.posWorld.rgb;
		float3 player4Dist = _Player4Pos.rgb - o.posWorld.rgb;

		o.chosenPos = Function_node_9186(player1Dist, player2Dist, player3Dist, player4Dist) + o.posWorld.rgb;

		UNITY_TRANSFER_FOG(o,o.pos);
		TRANSFER_VERTEX_TO_FRAGMENT(o)
			return o;
	}
	float4 frag(VertexOutput i) : COLOR{
		i.normalDir = normalize(i.normalDir);
	float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
	float3 normalDirection = i.normalDir;
	float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
	float3 lightColor = _LightColor0.rgb;
	float3 halfDirection = normalize(viewDirection + lightDirection);
	////// Lighting:
	float attenuation = LIGHT_ATTENUATION(i);
	float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
	float node_7782 = max(0,dot(lightDirection,normalDirection)); // Lambert
	float3 finalColor = (((_Diffuse_var.rgb*node_7782) + (node_7782*pow(max(0,dot(normalDirection,halfDirection)),exp2(lerp(1,11,_Gloss)))*_SpecColor.rgb))*_LightColor0.rgb*attenuation);
	float3 node_865 = float3(1,0,1);

	fixed4 finalRGBA = fixed4(finalColor * clamp((pow(length(((((i.chosenPos)*node_865) - (i.posWorld.rgb*node_865))*_FadeAxisBias.rgb)),_FadeFallOff) / _FadeLevel),_MinAlpha,1.0),0);

	UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
	return finalRGBA;
	}
		ENDCG
	}
	}
		FallBack "Diffuse"
		CustomEditor "ShaderForgeMaterialInspector"
}
