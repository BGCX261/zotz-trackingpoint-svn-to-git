Shader "Custom/TronLight" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_SubTex ("Base (SubRGB)", 2D) = "white" {}
		_Sub2Tex ("Base (Sub2RGB)", 2D) = "white" {}
		
		_perc1 ("Percent 1", Range(0,100)) = 100
		
		_MovingLightX ("LightX", Range (0,100)) = 1
		_MovingLightY ("LightY", Range (0,100)) = 1
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _SubTex;
		sampler2D _Sub2Tex;
		float _perc1;
		float _MovingLightX;
		float _MovingLightY;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			float3 worldNormal;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c1;
			half4 c2;
			if(IN.worldNormal.y > 0.1f || IN.worldNormal.y < -0.1f)
			{
				c1 = tex2D (_SubTex, ((IN.worldPos.xz * 0.05f) + float2(_MovingLightX/100, 0)));
				c2 = tex2D (_Sub2Tex, ((IN.worldPos.xz * 0.05f) + float2(0, _MovingLightY/100)));
			}
			else if(IN.worldNormal.x > 0.1f || IN.worldNormal.x < -0.1f)
			{
				c1 = tex2D (_SubTex, ((IN.worldPos.yz * 0.05f) + float2(_MovingLightX/100, 0)));
				c2 = tex2D (_Sub2Tex, ((IN.worldPos.yz * 0.05f) + float2(0, _MovingLightY/100)));
			}
			else
			{
				c1 = tex2D (_SubTex, ((IN.worldPos.xy * 0.05f) + float2(_MovingLightX/100, 0)));
				c2 = tex2D (_Sub2Tex, ((IN.worldPos.xy * 0.05f) + float2(0, _MovingLightY/100)));
			}
			half4 c = c1 + c2;
			half4 Subc = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = (c.rgb * _perc1 + Subc.rgb * (100 - _perc1))/100;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
