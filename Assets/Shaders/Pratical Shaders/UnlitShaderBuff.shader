
Shader "Unlit/UnlitShaderBuff"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BuffColor("Buff Color", Color) = (1, 1, 1, 1)
        _BuffPower ("Buff Power", Range(0.0, 1.0)) = 1
    }
    SubShader
    {        
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalRenderPipeline" }

        Pass
        {            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"            

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float2 uv           : TEXCOORD0;
                half4 color         : COLOR;
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD0;
                half4 color         : COLOR;

            };
            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            CBUFFER_START(UnityPerMaterial)
            float4 _MainTex_ST;
            half4 _BuffColor;
            float _BuffPower;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = TRANSFORM_TEX(IN.uv, _MainTex);
                OUT.color = IN.color;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 TextureColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv);
                half4 InvertTextureColor = 1 - TextureColor;
                half4 color = IN.color + (_BuffColor - IN.color) * _BuffPower;
                TextureColor = lerp(TextureColor, InvertTextureColor, _BuffPower) + color;
                return TextureColor;
            }
            ENDHLSL
        }
    }
}
