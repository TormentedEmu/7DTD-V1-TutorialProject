Shader "Game/Glass Reflex" {
	Properties {
		_GlassSurface ("Glass Surface", 2D) = "white" {}
		_Specular ("Specular", Range(0, 1)) = 0.7649578
		_Gloss ("Gloss", Range(0, 1)) = 0.7564113
		_GlassIntensity ("Glass Intensity", Range(0, 12)) = 4
		_DotSize ("Dot Size", Range(0, 1)) = 0.4401709
		[HideInInspector] _Cutoff ("Alpha cutoff", Range(0, 1)) = 0.5
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
	Fallback "Diffuse"
	//CustomEditor "ShaderForgeMaterialInspector"
}