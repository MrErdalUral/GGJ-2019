Shader "Custom/Perlin Noise" {
	Properties {
		_Blend ("Blend", Range (0, 1) ) = 0.0
		_WaveSpeed ("Wave Speed", Range (0, 1) ) = 0.0
		_WaveAmp ("Wave Amp", Range (0, 1) ) = 0.0

		_Saturation("Saturation", Range (0, 1) ) = 0.0

		_MainTex("Texture", 2D) = "white" {}
		_TargetTex("Texture", 2D) = "white" {}
		_NoiseTex("Noise Texture", 2D) = "white" {}
		_GradientTex("Gradient Texture", 2D) = "white" {}

		_Octaves("Octaves", int) = 6
		_Offset("Offset" , vector) = (0,0,0,0)
		_Size ("Size", vector) = (100,100,0,0)
		_Scale("Scale", float) = 1.0
		_Lacunarity("_Lacunarity",float) = 2.5
		_Persistance("Persistance",float) = 0.6
	}
	SubShader {
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "include.cginc"
			#include "UnityCG.cginc"

            struct vertexInput
            {
                float2 texCoord: TEXCOORD0;
                float4 vertex: POSITION;
            };

			struct v2f {
				float4 pos : SV_POSITION;
//				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			sampler2D _MainTex;
            sampler2D _TargetTex;
            sampler2D _NoiseTex;
            sampler2D _GradientTex;
			float4 _MainTex_ST;
			float _WaveSpeed;
			float _WaveAmp;

//			v2f vert(appdata_base v)
//			{
//				v2f o;
//				o.pos = UnityObjectToClipPos(v.vertex);
//				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
//				return o;
//			}

			v2f vert(vertexInput input) {
					v2f output;
					output.pos = UnityObjectToClipPos(input.vertex);
					output.uv = input.texCoord;

					// apply wave animation
					float noiseSample = tex2Dlod(_NoiseTex, float4(input.texCoord.xy,0,0));
					float gradientSample = tex2Dlod(_GradientTex, float4(input.texCoord.xy, 0, 0));
					output.pos.x += sin(_Time *100 * _WaveSpeed * noiseSample*(1 - gradientSample))*_WaveAmp;

					return output;
				}

			int _Octaves;
			float _Scale;
			float _Freq;
			float _Lacunarity;
			float _Persistance;
			vector _Offset;
			vector _OctaveOffset[10];
			vector _Size;
			float _Blend;
			float _Saturation;

            float PI = 3.1415926;
			float EPSILON = 1e-10;

            float RGBtoHue(float3 RGB)
            {
                float4 P = (RGB.g < RGB.b) ? float4(RGB.bg, -1.0, 2.0/3.0) : float4(RGB.gb, 0.0, -1.0/3.0);
                float4 Q = (RGB.r < P.x) ? float4(P.xyw, RGB.r) : float4(RGB.r, P.yzx);
                float C = Q.x - min(Q.w, Q.y);
                float H = abs((Q.w - Q.y) / (6 * C + EPSILON) + Q.z);
                return H;
            }

            float3 HuetoRGB(float H)
            {
                float R = abs(H * 6 - 3) - 1;
                float G = 2 - abs(H * 6 - 2);
                float B = 2 - abs(H * 6 - 4);
                return saturate(float3(R, G, B));
            }

            float3 RGBtoHCV(in float3 RGB)
            {
                // Based on work by Sam Hocevar and Emil Persson
                float4 P = (RGB.g < RGB.b) ? float4(RGB.bg, -1.0, 2.0/3.0) : float4(RGB.gb, 0.0, -1.0/3.0);
                float4 Q = (RGB.r < P.x) ? float4(P.xyw, RGB.r) : float4(RGB.r, P.yzx);
                float C = Q.x - min(Q.w, Q.y);
                float H = abs((Q.w - Q.y) / (6 * C + EPSILON) + Q.z);
                return float3(H, C, Q.x);
            }

            float3 RGBtoHSV(in float3 RGB)
            {
                float3 HCV = RGBtoHCV(RGB);
                float S = HCV.y / (HCV.z + EPSILON);
                return float3(HCV.x, HCV.y * _Saturation, HCV.z);
            }
            float3 HSVtoRGB(in float3 HSV)
              {
                float3 RGB = HuetoRGB(HSV.x);
                return ((RGB - 1) * HSV.y + 1) * HSV.z;
              }

            float3 mod3(float3 f, float v)
            {
                return float3(fmod(f.r, v), fmod(f.g, v), fmod(f.b, v));
            }

            float random (float2 st) {
                return frac(sin(dot(st.xy, float2(12.9898, 78.233))) * 43758.5453123);
            }

			half4 frag(v2f output) : COLOR{

			    fixed4 col1 = tex2D(_MainTex, output.uv);
                fixed4 col2 = tex2D(_TargetTex, output.uv);

				float x = output.uv.x * _Size.x;
				float y = output.uv.y * _Size.y;
				half4 value = 0;
				float2 p = {(x - _Size.x / 2)  / _Scale + _SinTime[1],
					(y - _Size.y / 2) / _Scale +_Time[1] };

//				float v = Perlin2D(p, _Octaves, _Persistance, _Lacunarity, _OctaveOffset);
//				v = Normalize(v, _Octaves, _Persistance);

                float v = random(output.uv) + (_SinTime[1]);

				fixed4 temp = lerp(col1, col2, v);
				fixed4 result1 = lerp(col1, temp, _Blend);
				fixed4 result2 = lerp(temp, col2, _Blend);
				fixed4 result = lerp(result1, result2, _Blend);

//                float hue = RGBtoHue(result) + _Time[0];
                float3 hsv = RGBtoHSV(result);
                hsv = float3(fmod(hsv.r + _Time[0], 1), _Saturation, hsv.b);

				result = fixed4(HSVtoRGB(sin(hsv * (_SinTime[2]*4 + 20)) / 2 + .5), result.a);
//  			  result = fixed4(HSVtoRGB(fmod(hue, 1)), result.a);

				return result;
			}
			ENDCG
		}
	}
}
