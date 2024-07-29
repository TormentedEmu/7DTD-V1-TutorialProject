Shader "Game/Entity Tint Mask" {
	Properties {
		_Color ("Color", Vector) = (1,1,1,1)
		_EmissionColor ("Emissive Color", Vector) = (0,0,0,1)
		_MainTex ("Albedo", 2D) = "white" {}
		[NoScaleOffset] [Normal] _Normal ("Normal", 2D) = "white" {}
		[NoScaleOffset] _Emissive ("Emissive", 2D) = "black" {}
		[NoScaleOffset] _RMOM ("RMOM", 2D) = "white" {}
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard alpha
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
}