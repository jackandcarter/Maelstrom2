Shader "Custom/CircleStar" {
    Properties {
        _MainTex ("Star Texture", 2D) = "white" {}
        _TintColor ("Star Tint", Color) = (1, 1, 1, 1)
        _StarSize ("Star Size", Range(0.1, 2.0)) = 1.0
    }
 
    SubShader {
        Tags { "Queue" = "Transparent" }
        LOD 100
 
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            struct appdata_t {
                float4 vertex : POSITION;
            };
 
            struct v2f {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };
 
            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _TintColor;
            float _StarSize;
 
            v2f vert (appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.vertex.xy, _MainTex);
                return o;
            }
 
            half4 frag (v2f i) : SV_Target {
                // Calculate the distance from the center of the star
                float2 center = float2(0.5, 0.5);
                float distance = length(i.uv - center);
 
                // Create the circle star with a soft edge
                half4 starColor = distance <= _StarSize * 0.5 ? half4(1, 1, 1, 1) : half4(0, 0, 0, 0);
 
                return starColor * _TintColor;
            }
            ENDCG
        }
    }
}
