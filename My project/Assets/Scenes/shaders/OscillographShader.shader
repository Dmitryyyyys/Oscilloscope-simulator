Shader "Custom/OscilloscopeShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _WaveType ("Wave Type", Range(0, 2)) = 0
        _Frequency ("Frequency", Range(0.1, 100)) = 1
        _Amplitude ("Amplitude", Range(0.1, 1)) = 0.5
        _Speed ("Speed", Range(0.1, 10)) = 1
        _Color ("Line Color", Color) = (1,1,1,1)
        _BackgroundColor ("Background Color", Color) = (0,0,0,1)
    }
    SubShader
    {
        Tags { "Queue"="Background" "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            uniform float _WaveType;
            uniform float _Frequency;
            uniform float _Amplitude;
            uniform float _Speed;
            uniform float4 _Color;
            uniform float4 _BackgroundColor;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float wave(float x, float waveType)
            {
                if (waveType == 0)
                    return sin(x); 
                else if (waveType == 1)
                    return cos(x); 
                else
                    return step(0.5, frac(x));
            }

            half4 frag(v2f i) : SV_Target
            {
                float x = i.uv.x * _Frequency + _Speed * _Time.y; 
                float y = wave(x, _WaveType) * _Amplitude + 0.5; 

                float2 screenPos = i.uv * float2(1, 1);
                float dist = abs(screenPos.y - y);

                half4 color = _BackgroundColor;

                if (dist < 0.02)
                    color = _Color;

                return color;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
