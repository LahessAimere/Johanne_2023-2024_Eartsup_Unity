Shader "Unlit/UnlitShaderChecker"
{
    Properties
    {
        _FirstGrayScale ("First Grayscale", Range(0.0, 1.0)) = 0.118
        _SecondGrayScale ("Second Grayscale", Range(0.0, 1.0)) = 0.316
        _RepeatValue ("Repeat Value", Int) = 5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            CBUFFER_START(UnityPerMaterial)
            float _RepeatValue;
            float _FirstGrayScale;
            float _SecondGrayScale;
            CBUFFER_END

            struct Attributes
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.vertex = TransformObjectToHClip(IN.vertex.xyz);
                OUT.uv = IN.uv;
                return OUT;
            }

            half4 frag (Varyings IN) : SV_Target
            {
                float x = round(frac(IN.uv.x * _RepeatValue));
                float y = round(frac(IN.uv.y * _RepeatValue));

                int checker = (x + y) % 2;
    
                half4 col = _FirstGrayScale;
                if (checker != 0)
                {
                    col = _SecondGrayScale;
                }
                
                return col;
            }
            ENDHLSL
        }
    }
}