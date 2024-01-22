Shader "UnlitShaderTexture"
{
    // The properties block of the Unity shader. In this example this block is empty
    // because the output color is predefined in the fragment shader code.
    Properties
    { 
        _BaseMap("Fire Ball Map", 2D) = "white" {}
        [HDR] _FireColor1("Fire Color 1", Color) = (1, 1, 1, 1)
        [HDR] _FireColor2("Fire Color 2", Color) = (1, 1, 1, 1)
        [HDR] _FresnelColor("Fresnel Color", Color) = (1, 1, 1, 1)
        _FresnelPower ("Fresnel Power", Range(0.0, 1.0)) = 0.5
    }

    // The SubShader block containing the Shader code. 
    SubShader
    {
        // SubShader Tags define when and under which conditions a SubShader block or
        // a pass is executed.
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalRenderPipeline" }

        Pass
        {
            // The HLSL code block. Unity SRP uses the HLSL language.
            HLSLPROGRAM
            // This line defines the name of the vertex shader. 
            #pragma vertex vert
            // This line defines the name of the fragment shader. 
            #pragma fragment frag

            // The Core.hlsl file contains definitions of frequently used HLSL
            // macros and functions, and also contains #include references to other
            // HLSL files (for example, Common.hlsl, SpaceTransforms.hlsl, etc.).
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);
            CBUFFER_START(UnityPerMaterial)
            float4 _BaseMap_ST;
            float _FresnelPower;
            half4 _FireColor1;
            half4 _FresnelColor;
            CBUFFER_END

            // The structure definition defines which variables it contains.
            // This example uses the Attributes structure as an input structure in
            // the vertex shader.
            struct Attributes
            {
                float4 positionOS   : POSITION;
                // Declaring the variable containing the normal vector for each
                // vertex.
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

            // The vertex shader definition with properties defined in the Varyings 
            // structure. The type of the vert function must match the type (struct)
            // that it returns.
            Varyings vert(Attributes IN)
            {
                 Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.positionWS = TransformObjectToWorld(IN.positionOS);
                OUT.uv = TRANSFORM_TEX(IN.uvBaseColor, _BaseMap);
                // Use the TransformObjectToWorldNormal function to transform the
                // normals from object to world space. This function is from the 
                // SpaceTransforms.hlsl file, which is referenced in Core.hlsl.
                OUT.normal = TransformObjectToWorldNormal(IN.normal);                
                return OUT;
            }

            // The fragment shader definition.            
            half4 frag(Varyings IN) : SV_Target
            {
                float3 viewDirection = GetCameraPositionWS() - IN.positionWS;
                float2 UvCalcul = float2(0,1);
                // IN.normal is a 3D vector. Each vector component has the range
                // -1..1. To show all vector elements as color, including the
                // negative values, compress each value into the range 0..1.
                half4 color = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv + (UvCalcul * _Time.x));
                float fresnel = pow(1.0 - saturate(dot(normalize(IN.normal), normalize(viewDirection))), _FresnelPower);
                color = lerp(_FireColor1, _FresnelColor, color);
                return color + fresnel * _FresnelColor;
            }
            ENDHLSL
      }  
    }
}