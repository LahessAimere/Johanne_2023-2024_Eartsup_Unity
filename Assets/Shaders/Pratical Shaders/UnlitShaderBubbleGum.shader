Shader "Unlit/UnlitShaderBubbleGum"
{
    Properties
    {
        _MainColor("Main Color", Color) = (1, 1, 1, 1)
        [HDR] _FlashColor("Flash Color 1", Color) = (1, 1, 1, 1)
        _FlashFrenquency("Flash Franquency", Int) = 1
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
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
            };
            
            CBUFFER_START(UnityPerMaterial)
                half4 _MainColor;
                half4 _FlashColor;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                return OUT;
            }

            half4 frag() : SV_Target
            {
                return _MainColor;
            }
            ENDHLSL
        }
    }
}