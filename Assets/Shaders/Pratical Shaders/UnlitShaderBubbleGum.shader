Shader "Unlit/UnlitShaderBubbleGum"
{
    Properties
    {
        _MainColor("Main Color", Color) = (1, 1, 1, 1)
        [HDR] _FlashColor("Flash Color 1", Color) = (1, 1, 1, 1)
        _FlashFrequency("Flash Franquency", Int) = 1
        _Displacement("Displacement", Int) = 1
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
                half4 color         : COLOR;
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                half4 color         : COLOR;
            };
            
            CBUFFER_START(UnityPerMaterial)
                half4 _MainColor;
                half4 _FlashColor;
                int _FlashFrequency;
                int _Displacement;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz * sin(_Time.y) * _Displacement);
                OUT.color = IN.color * _MainColor;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 Color = _MainColor + (_FlashColor - _MainColor) * sin(_Time.y) * _FlashFrequency;

                return Color;
            }
            ENDHLSL
        }
    }
}