Shader "Custom/TargetLight" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_SubTex ("Base (SubRGB)", 2D) = "white" {}
		
		_perc1 ("Percent 1", Range(0,100)) = 100
	}
	SubShader {
		Tags { "RenderType"="Transparent" "QUEUE"="Transparent" "IGNOREPROJECTOR"="true"}
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _SubTex;
		float _perc1;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			half4 Subc = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = ((c.rgb * _perc1/100 + Subc.rgb * (100 - _perc1))/100) * 5;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
