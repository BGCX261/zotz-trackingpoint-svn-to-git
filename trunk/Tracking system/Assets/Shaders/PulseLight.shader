Shader "Custom/PulseLight" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_SubTex ("Base (SubRGB)", 2D) = "white" {}
		
		_perc1 ("Percent 1", Range(0,100)) = 100
		
		_MovingLightX ("LightX", Range (0,100)) = 1
		_MovingLightY ("LightY", Range (0,100)) = 1
		
		_LightScale ("LightScale", Range (0,100)) = 1
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert
		
		float _perc1;
		float _MovingLightX;
		float _MovingLightY;
		float _LightScale;
		sampler2D _MainTex;
		sampler2D _SubTex;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c1 = tex2D (_MainTex, IN.uv_MainTex);
			half4 c2 = tex2D (_MainTex, (IN.uv_MainTex + float2(_MovingLightX/100, _MovingLightY/100)));//* _LightScale/100);
			half4 c = c1 + c2;
			half4 Subc = tex2D (_SubTex, IN.uv_MainTex);
			o.Albedo = (c.rgb * _perc1 + Subc.rgb * (100 - _perc1))/100;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
