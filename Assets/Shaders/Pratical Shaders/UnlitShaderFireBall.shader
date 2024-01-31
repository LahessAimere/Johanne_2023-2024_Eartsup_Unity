Shader "UnlitShaderTexture"
{
    Properties
    { 
        _BaseMap("Fire Ball Map", 2D) = "white" {}
        [HDR] _FireColor1("Fire Color 1", Color) = (1, 1, 1, 1)
        [HDR] _FireColor2("Fire Color 2", Color) = (1, 1, 1, 1)
        [HDR] _FresnelColor("Fresnel Color", Color) = (1, 1, 1, 1)
        _FresnelPower ("Fresnel Power", Range(0.0, 1.0)) = 0.5
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
            
            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);
            CBUFFER_START(UnityPerMaterial)
            float4 _BaseMap_ST;
            float _FresnelPower;
            half4 _FireColor1;
            half4 _FireColor2;
            half4 _FresnelColor;
            CBUFFER_END

            
            struct Attributes
            {
                float4 positionOS   : POSITION;
                half3 normal        : NORMAL;
                float2 uvBaseColor  : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float3 positionWS   : WS_POSITION;
                half3 normal        : TEXCOORD0;
                float2 uv           : TEXCOORD1;
            };            
            
            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.positionWS = TransformObjectToWorld(IN.positionOS);
                OUT.uv = TRANSFORM_TEX(IN.uvBaseColor, _BaseMap);
                OUT.normal = TransformObjectToWorldNormal(IN.normal);                
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                float3 viewDirection = GetCameraPositionWS() - IN.positionWS;
                float2 UvCalcul = float2(0,1);
                half4 color = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv + (UvCalcul * _Time.x));
                float fresnel = pow(1.0 - saturate(dot(normalize(IN.normal), normalize(viewDirection))), _FresnelPower);
                color = lerp(_FireColor1, _FresnelColor, color);
                return color + fresnel * _FireColor2;
            }
            ENDHLSL
      }  
    }
}