Shader "Dimenco/Color"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _TopPad ("Top Padding", float) = 0.1
        _BottomPad ("Bottom Padding", float) = 0.1
        _PadTh ("Padding Threshold", float) = 0.9
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float depth : TEXCOORD1;
                UNITY_FOG_COORDS(1)
            };

            sampler2D _MainTex;
            float _TopPad;
            float _BottomPad;
            float _PadTh;

            v2f vert (appdata v)
            {
                v2f o;

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.depth = COMPUTE_DEPTH_01
                UNITY_TRANSFER_FOG(o,o.vertex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col;
                float checker;

                // checker = (i.uv.y - (1 - _TopPad)) * (i.uv.y - _BottomPad) * (i.depth - _PadTh);
                // clip(checker);

                col = (i.uv.y > (1 - _TopPad) || i.uv.y < _BottomPad) &&
                      i.depth > _PadTh ?
                      tex2D(_MainTex, i.uv) :
                      float4(0, 0, 0, 0);

                // col = tex2D(_MainTex, i.uv);
                UNITY_APPLY_FOG(i.fogCoord, col);

                return col;
            }
            ENDCG
        }
    }
}
