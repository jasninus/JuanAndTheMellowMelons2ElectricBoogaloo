Shader "SupGames/Mobile/PixellateURP"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
	}

		HLSLINCLUDE

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

	TEXTURE2D(_MainTex);
	SAMPLER(sampler_MainTex);

	half2 _Dencity;

	struct AttributesDefault
	{
		half4 pos : POSITION;
		half2 uv : TEXCOORD0;
		UNITY_VERTEX_INPUT_INSTANCE_ID
	};

	struct v2f
	{
		half4 pos : POSITION;
		half2 uv  : TEXCOORD0;
		UNITY_VERTEX_OUTPUT_STEREO
	};

	v2f vert(AttributesDefault i)
	{
		v2f o = (v2f)0;
		UNITY_SETUP_INSTANCE_ID(i);
		UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
		o.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, half4(i.pos.xyz, 1.0h)));
		o.uv = i.uv;
		return o;
	}

	half4 frag(v2f i) : SV_Target
	{
	UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);
		return SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, round(UnityStereoTransformScreenSpaceTex(i.uv)*_Dencity) / _Dencity);
	}

		ENDHLSL

		Subshader
	{
		Pass
		{
		  ZTest Always Cull Off ZWrite Off
		  Fog { Mode off }
		  HLSLPROGRAM
		  #pragma vertex vert
		  #pragma fragment frag
		  #pragma fragmentoption ARB_precision_hint_fastest
		  ENDHLSL
		}
	}
}