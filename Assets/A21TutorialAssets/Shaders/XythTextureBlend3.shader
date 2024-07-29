Shader "Custom/XythTextureBlend3" {
 Properties {
	 _Color ("Color", Color) = (1,1,1,1)
	 _Blend ("TextureBlend", Range(0,1)) = 0.0
	 _MainTex ("Albedo (RGB)", 2D) = "white" {}
	 _MainTex2 ("Albedo 2 (RGB)", 2D) = "white" {}
	_BumpScale2 ("Beneath Normal Scale", Float) = 1.0
	_BumpMap2 ("Beneath Normal Map", 2D) = "bump" {} 
    _Cutoff("Alpha Cutoff", Range(0.0, 1.0)) = 0.5

	_Glossiness("Smoothness", Range(0.0, 1.0)) = 0.5
	_GlossMapScale("Smoothness Scale", Range(0.0, 1.0)) = 1.0
	[Enum(Metallic Alpha,0,Albedo Alpha,1)] _SmoothnessTextureChannel ("Smoothness texture channel", Float) = 0

	[Gamma] _Metallic("Metallic", Range(0.0, 1.0)) = 0.0
	_MetallicGlossMap("Metallic", 2D) = "white" {}

	[ToggleOff] _SpecularHighlights("Specular Highlights", Float) = 1.0
	[ToggleOff] _GlossyReflections("Glossy Reflections", Float) = 1.0


	_BumpScale("Scale", Float) = 1.0
	_BumpMap("Normal Map", 2D) = "bump" {}

	_Parallax ("Height Scale", Range (0.005, 0.08)) = 0.02
	_ParallaxMap ("Height Map", 2D) = "black" {}

	_OcclusionStrength("Strength", Range(0.0, 1.0)) = 1.0
	_OcclusionMap("Occlusion", 2D) = "white" {}

	_EmissionColor("Color", Color) = (0,0,0)
	_EmissionMap("Emission", 2D) = "white" {}

	_DetailMask("Detail Mask", 2D) = "white" {}

	_DetailAlbedoMap("Detail Albedo x2", 2D) = "grey" {}
	_DetailNormalMapScale("Scale", Float) = 1.0
	_DetailNormalMap("Normal Map", 2D) = "bump" {}

	[Enum(UV0,0,UV1,1)] _UVSec ("UV Set for secondary textures", Float) = 0
 }
 
//	CGINCLUDE
//		#define UNITY_SETUP_BRDF_INPUT MetallicSetup
//	ENDCG
 
 
 SubShader {
	 Tags { "RenderType"="Opaque" }
	 LOD 200
	 
	 CGPROGRAM
	 // Physically based Standard lighting model, and enable shadows on all light types
	 #pragma surface surf Standard fullforwardshadows

	 // Use shader model 3.0 target, to get nicer looking lighting
	 #pragma target 3.0
	 #pragma shader_feature _NORMALMAP
	 sampler2D _MainTex;
	 sampler2D _MainTex2;
	 sampler2D _BumpMap;
	 sampler2D _BumpMap2;
	 struct Input {
		 float2 uv_MainTex;
		 float2 uv_MainTex2;
		 float2 uv_BumpMap;
		 float2 uv_BumpMap2;
	 };

	 half _Blend;
	 half _Glossiness;
	 half _Metallic;
	 fixed4 _Color;

	 void surf (Input IN, inout SurfaceOutputStandard o) {
		 // Albedo comes from a texture tinted by color
		 fixed4 c = lerp (tex2D (_MainTex, IN.uv_MainTex), tex2D (_MainTex2, IN.uv_MainTex), _Blend) * _Color;
		 o.Albedo = c.rgb;
		 // Metallic and smoothness come from slider variables
		 o.Metallic = _Metallic;
		 o.Smoothness = _Glossiness;
		 o.Alpha = c.a;
		 o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
	 }
	 ENDCG
 }
 FallBack "Diffuse"
}