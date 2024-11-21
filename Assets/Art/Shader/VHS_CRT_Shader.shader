Shader "Unlit/VHS_CRT_Shader"
{
	Properties
    {
        _MainTex ("Base Color", 2D) = "white" {}
        _ScanlineTex ("Scanline Texture", 2D) = "white" {}
        _NoiseTex ("Noise Texture", 2D) = "white" {}
        _Distortion ("Distortion Amount", Float) = 0.1
        _ScanlineStrength ("Scanline Strength", Float) = 1.5
        _NoiseStrength ("Noise Strength", Float) = 0.05
        _ScanlineThickness ("Scanline Thickness", Float) = 1.0
        _Opacity ("Opacity", Range(0, 1)) = 1.0
        _ScanlineSpeed ("Scanline Speed", Float) = 0.5 // Control scanline movement speed
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Tags { "LightMode"="Always" }

            ZWrite Off
            ZTest LEqual
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            sampler2D _MainTex;
            sampler2D _ScanlineTex;
            sampler2D _NoiseTex;
            float _Distortion;
            float _ScanlineStrength;
            float _NoiseStrength;
            float _ScanlineThickness;
            float _Opacity;
            float _ScanlineSpeed; // Speed of scanline movement

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // UV distortion
                float2 distortedUV = i.uv;
                distortedUV.x += sin(distortedUV.y * 30.0 + _Time.y) * _Distortion;

                // Sample textures
                fixed4 color = tex2D(_MainTex, distortedUV);
                fixed4 noise = tex2D(_NoiseTex, i.uv + _Time.y * 0.1);

                // Move the scanlines over time
                float scanlineOffset = _Time.y * _ScanlineSpeed;
                fixed4 scanlines = tex2D(_ScanlineTex, float2(i.uv.x, i.uv.y + scanlineOffset) * 10.0 * _ScanlineThickness); // Adjust scanline thickness

                // Combine effects with adjustable strengths
                scanlines = lerp(1.0, scanlines, _ScanlineStrength); // Boost scanlines
                noise *= _NoiseStrength; // Subtle noise

                // Apply opacity to all effects
                color.a = _Opacity;
                scanlines.a = _Opacity;
                noise.a = _Opacity;

                // Return final color with opacity
                return color * scanlines + noise;
            }
            ENDCG
        }
    }
}