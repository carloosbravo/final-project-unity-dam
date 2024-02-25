Shader "Custom/BlurShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurAmount ("Blur Amount", Range(0, 5)) = 1
    }
 
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100
 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
 
            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };
 
            sampler2D _MainTex;
            float _BlurAmount;
 
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
 
            half4 frag (v2f i) : SV_Target
            {
                half4 color = tex2D(_MainTex, i.uv);
                half4 blurColor = color;
                for (int x = -5; x <= 5; x++) {
                    for (int y = -5; y <= 5; y++) {
                        blurColor += tex2D(_MainTex, i.uv + float2(x, y) * _BlurAmount / _ScreenParams.xy);
                    }
                }
                blurColor /= 121; // Adjust this value according to blur intensity
                return blurColor;
            }
            ENDCG
        }
    }
}
