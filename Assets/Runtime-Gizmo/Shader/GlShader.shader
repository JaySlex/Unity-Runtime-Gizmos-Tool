Shader "Custom/GLShader" {
	SubShader{
		BindChannels {
			Bind "vertex", vertex
			Bind "color", color
		}
		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			Cull Off
			Fog { Mode Off }
		}
		Pass
		{
			Blend SrcAlpha One
			ZTest Greater
			ZWrite Off
			Cull Off
			Fog { Mode Off }
		}
	}
		Fallback "Diffuse"
}