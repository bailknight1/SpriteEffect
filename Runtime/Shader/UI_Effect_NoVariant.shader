Shader "Hidden/UI_Effect" {
    Properties {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        [PerRendererData] _Rect("Rect Display", Vector) = (0,0,1,1)
        [PerRendererData] _AspectRatio("AspectRatio", Vector) = (1,1,1,1)
        _UseUiImage("Is UI Image", Int) = 0
        _SetSpriteTransparent("Set Sprite Transparent", Int) = 0
        _UseUnscaledTime("Use Unscaled Time", Int) = 0

        [Toggle] _Effect1("Effect1", Int) = 0
        _Effect1UniformUV("Effect1 Uniform UV", Int) = 0
        _Effect1MaskMode("Effect1 Mask Mode", Int) = 0
        _Effect1AlphaMode("Effect1 Alpha Mode", Int) = 0
        _Effect1Tex ("Effect1 Texture", 2D) = "black" {}
        _Effect1Mask ("Effect1 Mask", 2D) = "white" {}
        _Effect1Color ("Effect1 Color", Color) = (1,1,1,1)
        _Effect1Brightness("Effect1 Brightness", Float) = 1
        _Effect1ScaleOrigin("Effect1 Scale", Float) = 1
        _Effect1ScaleMultipier("Effect1 Scale Multipier", Float) = 1
        _Effect1ScaleSpeed("Effect1 Scale Speed", Float) = 0
        _Effect1Power ("Effect1 Power", Float ) = 1
        _Effect1RotateAngle("Effect1 Rotate Angle", Float) = 0
        _Effect1RotateSpeed ("Effect1 Rotate Speed", Float ) = 0
        _Effect1VerticalSpeed("Effect1 Vertical Speed", Float) = 0
        _Effect1HorizontalSpeed("Effect1 Horizontal Speed", Float) = 0
        _Effect1GlowSpeed("Effect1 Glow Speed", Float) = 0
        _Effect1TimingOffset("Effect1 Timing Offset", Float) = 0
        _Effect1UseAlpha("Effect1 Use Alpha", Int) = 0
        _Effect1ScalePingPong("Effect1 Use PingPong Scale", Int) = 0
        _Effect1RotateScrollDirection("Effect1 Rotate Scroll Direction", Int) = 0
        _Effect1MaskDistortStrength("Effect1 Mask Distort Strength", Float) = 0

        [Toggle] _Effect2("Effect2", Int) = 0
        _Effect2UniformUV("Effect2 Uniform UV", Int) = 0
        _Effect2MaskMode("Effect2 Mask Mode", Int) = 0
        _Effect2AlphaMode("Effect2 Alpha Mode", Int) = 0
        _Effect2Tex("Effect2 Texture", 2D) = "black" {}
        _Effect2Mask("Effect2 Mask", 2D) = "white" {}
        _Effect2Color("Effect2 Color", Color) = (1,1,1,1)
        _Effect2Brightness("Effect2 Brightness", Float) = 1
        _Effect2ScaleOrigin("Effect2 Scale", Float) = 1
        _Effect2ScaleMultipier("Effect2 Scale Multipier", Float) = 1
        _Effect2ScaleSpeed("Effect2 Scale Speed", Float) = 0
        _Effect2Power("Effect2 Power", Float) = 1
        _Effect2RotateAngle("Effect2 Rotate Angle", Float) = 0
        _Effect2RotateSpeed("Effect2 Rotate Speed", Float) = 0
        _Effect2VerticalSpeed("Effect2 Vertical Speed", Float) = 0
        _Effect2HorizontalSpeed("Effect2 Horizontal Speed", Float) = 0
        _Effect2GlowSpeed("Effect2 Glow Speed", Float) = 0
        _Effect2TimingOffset("Effect2 Timing Offset", Float) = 0
        _Effect2UseAlpha("Effect2 Use Alpha", Int) = 0
        _Effect2ScalePingPong("Effect2 Use PingPong Scale", Int) = 0
        _Effect2RotateScrollDirection("Effect2 Rotate Scroll Direction", Int) = 0
        _Effect2MaskDistortStrength("Effect2 Mask Distort Strength", Float) = 0

        [Toggle] _Effect3("Effect3", Int) = 0
        _Effect3UniformUV("Effect3 Uniform UV", Int) = 0
        _Effect3MaskMode("Effect3 Mask Mode", Int) = 0
        _Effect3AlphaMode("Effect3 Alpha Mode", Int) = 0
        _Effect3Tex("Effect3 Texture", 2D) = "black" {}
        _Effect3Mask("Effect3 Mask", 2D) = "white" {}
        _Effect3Color("Effect3 Color", Color) = (1,1,1,1)
        _Effect3Brightness("Effect3 Brightness", Float) = 1
        _Effect3ScaleOrigin("Effect3 Scale", Float) = 1
        _Effect3ScaleMultipier("Effect3 Scale Multipier", Float) = 1
        _Effect3ScaleSpeed("Effect3 Scale Speed", Float) = 0
        _Effect3Power("Effect3 Power", Float) = 1
        _Effect3RotateAngle("Effect3 Rotate Angle", Float) = 0
        _Effect3RotateSpeed("Effect3 Rotate Speed", Float) = 0
        _Effect3VerticalSpeed("Effect3 Vertical Speed", Float) = 0
        _Effect3HorizontalSpeed("Effect3 Horizontal Speed", Float) = 0
        _Effect3GlowSpeed("Effect3 Glow Speed", Float) = 0
        _Effect3TimingOffset("Effect3 Timing Offset", Float) = 0
        _Effect3UseAlpha("Effect3 Use Alpha", Int) = 0
        _Effect3ScalePingPong("Effect3 Use PingPong Scale", Int) = 0
        _Effect3RotateScrollDirection("Effect3 Rotate Scroll Direction", Int) = 0
        _Effect3MaskDistortStrength("Effect3 Mask Distort Strength", Float) = 0

        [Toggle] _Effect4("Effect4", Int) = 0
        _Effect4UniformUV("Effect4 Uniform UV", Int) = 0
        _Effect4MaskMode("Effect4 Mask Mode", Int) = 0
        _Effect4AlphaMode("Effect4 Alpha Mode", Int) = 0
        _Effect4Tex("Effect4 Texture", 2D) = "black" {}
        _Effect4Mask("Effect4 Mask", 2D) = "white" {}
        _Effect4Color("Effect4 Color", Color) = (1,1,1,1)
        _Effect4Brightness("Effect4 Brightness", Float) = 1
        _Effect4ScaleOrigin("Effect4 Scale", Float) = 1
        _Effect4ScaleMultipier("Effect4 Scale Multipier", Float) = 1
        _Effect4ScaleSpeed("Effect4 Scale Speed", Float) = 0
        _Effect4Power("Effect4 Power", Float) = 1
        _Effect4RotateAngle("Effect4 Rotate Angle", Float) = 0
        _Effect4RotateSpeed("Effect4 Rotate Speed", Float) = 0
        _Effect4VerticalSpeed("Effect4 Vertical Speed", Float) = 0
        _Effect4HorizontalSpeed("Effect4 Horizontal Speed", Float) = 0
        _Effect4GlowSpeed("Effect4 Glow Speed", Float) = 0
        _Effect4TimingOffset("Effect4 Timing Offset", Float) = 0
        _Effect4UseAlpha("Effect4 Use Alpha", Int) = 0
        _Effect4ScalePingPong("Effect4 Use PingPong Scale", Int) = 0
        _Effect4RotateScrollDirection("Effect4 Rotate Scroll Direction", Int) = 0
        _Effect4MaskDistortStrength("Effect4 Mask Distort Strength", Float) = 0
		
        [Toggle] _Effect5("Effect5", Int) = 0
        _Effect5UniformUV("Effect5 Uniform UV", Int) = 0
        _Effect5MaskMode("Effect5 Mask Mode", Int) = 0
        _Effect5AlphaMode("Effect5 Alpha Mode", Int) = 0
        _Effect5Tex("Effect5 Texture", 2D) = "black" {}
        _Effect5Mask("Effect5 Mask", 2D) = "white" {}
        _Effect5Color("Effect5 Color", Color) = (1,1,1,1)
        _Effect5Brightness("Effect5 Brightness", Float) = 1
        _Effect5ScaleOrigin("Effect5 Scale", Float) = 1
        _Effect5ScaleMultipier("Effect5 Scale Multipier", Float) = 1
        _Effect5ScaleSpeed("Effect5 Scale Speed", Float) = 0
        _Effect5Power("Effect5 Power", Float) = 1
        _Effect5RotateAngle("Effect5 Rotate Angle", Float) = 0
        _Effect5RotateSpeed("Effect5 Rotate Speed", Float) = 0
        _Effect5VerticalSpeed("Effect5 Vertical Speed", Float) = 0
        _Effect5HorizontalSpeed("Effect5 Horizontal Speed", Float) = 0
        _Effect5GlowSpeed("Effect5 Glow Speed", Float) = 0
        _Effect5TimingOffset("Effect5 Timing Offset", Float) = 0
        _Effect5UseAlpha("Effect5 Use Alpha", Int) = 0
        _Effect5ScalePingPong("Effect5 Use PingPong Scale", Int) = 0
        _Effect5RotateScrollDirection("Effect5 Rotate Scroll Direction", Int) = 0
        _Effect5MaskDistortStrength("Effect5 Mask Distort Strength", Float) = 0

        [Toggle] _Effect6("Effect6", Int) = 0
        _Effect6UniformUV("Effect6 Uniform UV", Int) = 0
        _Effect6MaskMode("Effect6 Mask Mode", Int) = 0
        _Effect6AlphaMode("Effect6 Alpha Mode", Int) = 0
        _Effect6Tex("Effect6 Texture", 2D) = "black" {}
        _Effect6Mask("Effect6 Mask", 2D) = "white" {}
        _Effect6Color("Effect6 Color", Color) = (1,1,1,1)
        _Effect6Brightness("Effect6 Brightness", Float) = 1
        _Effect6ScaleOrigin("Effect6 Scale", Float) = 1
        _Effect6ScaleMultipier("Effect6 Scale Multipier", Float) = 1
        _Effect6ScaleSpeed("Effect6 Scale Speed", Float) = 0
        _Effect6Power("Effect6 Power", Float) = 1
        _Effect6RotateAngle("Effect6 Rotate Angle", Float) = 0
        _Effect6RotateSpeed("Effect6 Rotate Speed", Float) = 0
        _Effect6VerticalSpeed("Effect6 Vertical Speed", Float) = 0
        _Effect6HorizontalSpeed("Effect6 Horizontal Speed", Float) = 0
        _Effect6GlowSpeed("Effect6 Glow Speed", Float) = 0
        _Effect6TimingOffset("Effect6 Timing Offset", Float) = 0
        _Effect6UseAlpha("Effect6 Use Alpha", Int) = 0
        _Effect6ScalePingPong("Effect6 Use PingPong Scale", Int) = 0
        _Effect6RotateScrollDirection("Effect6 Rotate Scroll Direction", Int) = 0
        _Effect6MaskDistortStrength("Effect6 Mask Distort Strength", Float) = 0

		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255
		_ColorMask ("Color Mask", Float) = 15

        [Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip("Use Alpha Clip", Float) = 0
    }
    SubShader {
        Tags {
            "Queue"="Transparent"
            "IgnoreProjector" = "True"
            "RenderType"="Transparent"
			"PreviewType"="Plane"
            "CanUseSpriteAtlas" = "True"
        }

        Stencil
		{
			Ref [_Stencil]
			Comp [_StencilComp]
			Pass [_StencilOp]
			ReadMask [_StencilReadMask]
			WriteMask [_StencilWriteMask]
		}

        Cull Off
        Lighting Off
        ZWrite Off
        ZTest[unity_GUIZTestMode]
        Blend One OneMinusSrcAlpha
        ColorMask[_ColorMask]

        Pass 
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "UnityUI.cginc"

            #pragma multi_compile_local _ UNITY_UI_CLIP_RECT
            #pragma multi_compile_local _ UNITY_UI_ALPHACLIP

            #pragma shader_feature _EFFECT1_ON
            #pragma shader_feature _EFFECT2_ON
            #pragma shader_feature _EFFECT3_ON
            #pragma shader_feature _EFFECT4_ON
            #pragma shader_feature _EFFECT5_ON
            #pragma shader_feature _EFFECT6_ON

            struct VertexInput {
				half4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 texcoord1 : TEXCOORD1;
                fixed4 vertexColor : COLOR;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct VertexOutput {
				half4 pos : SV_POSITION;
				fixed4 uv0 : TEXCOORD0;
                fixed4 vertexColor : COLOR;

                #if _EFFECT2_ON || _EFFECT3_ON
				fixed4 uv1 : TEXCOORD1;
                #endif

                #if _EFFECT4_ON || _EFFECT5_ON
                fixed4 uv2 : TEXCOORD2;
                #endif

                #if _EFFECT6_ON
                fixed4 uv3 : TEXCOORD3;
                #else
                fixed2 uv3 : TEXCOORD3;
                #endif

                fixed4 Glowcolor1 : COLOR1;
                fixed2 Glowcolor2 : COLOR2;

                float4 worldPosition : TEXCOORD4;
                float4  mask : TEXCOORD5;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform fixed4 _Rect;
            uniform float2 _AspectRatio;
            float _ShaderUnscaledTime;
            uniform fixed _UseUiImage;
            uniform fixed _UseUnscaledTime;
            uniform fixed _SetSpriteTransparent;

            float4 _ClipRect;
            float _UIMaskSoftnessX;
            float _UIMaskSoftnessY;
            int _UIVertexColorAlwaysGammaSpace;

            #if _EFFECT1_ON
                uniform sampler2D _Effect1Tex; uniform float4 _Effect1Tex_ST;
                uniform sampler2D _Effect1Mask; uniform float4 _Effect1Mask_ST;
                uniform fixed _Effect1Power;
                uniform fixed _Effect1ScaleOrigin;
                uniform fixed _Effect1ScaleMultipier;
                uniform fixed _Effect1ScaleSpeed;
                uniform fixed4 _Effect1Color;
                uniform fixed _Effect1Brightness;
                uniform float _Effect1RotateAngle;
                uniform fixed _Effect1RotateSpeed;
                uniform fixed _Effect1VerticalSpeed;
                uniform fixed _Effect1HorizontalSpeed;
                uniform fixed _Effect1GlowSpeed;
                uniform fixed _Effect1MaskMode;
                uniform fixed _Effect1AlphaMode;
                uniform fixed _Effect1UniformUV;
                uniform fixed _Effect1TimingOffset;
                uniform fixed _Effect1UseAlpha;
                uniform fixed _Effect1ScalePingPong;
                uniform fixed _Effect1RotateScrollDirection;
                uniform fixed _Effect1MaskDistortStrength;
            #endif

            #if _EFFECT2_ON
                uniform sampler2D _Effect2Tex; uniform float4 _Effect2Tex_ST;
                uniform sampler2D _Effect2Mask; uniform float4 _Effect2Mask_ST;
                uniform fixed _Effect2Power;
                uniform fixed _Effect2ScaleOrigin;
                uniform fixed _Effect2ScaleMultipier;
                uniform fixed _Effect2ScaleSpeed;
                uniform fixed4 _Effect2Color;
                uniform fixed _Effect2Brightness;
                uniform float _Effect2RotateAngle;
                uniform fixed _Effect2RotateSpeed;
                uniform fixed _Effect2VerticalSpeed;
                uniform fixed _Effect2HorizontalSpeed;
                uniform fixed _Effect2GlowSpeed;
                uniform fixed _Effect2MaskMode;
                uniform fixed _Effect2AlphaMode;
                uniform fixed _Effect2UniformUV;
                uniform fixed _Effect2TimingOffset;
                uniform fixed _Effect2UseAlpha;
                uniform fixed _Effect2ScalePingPong;
                uniform fixed _Effect2RotateScrollDirection;
                uniform fixed _Effect2MaskDistortStrength;
            #endif

            #if _EFFECT3_ON
                uniform sampler2D _Effect3Tex; uniform float4 _Effect3Tex_ST;
                uniform sampler2D _Effect3Mask; uniform float4 _Effect3Mask_ST;
                uniform fixed _Effect3Power;
                uniform fixed _Effect3ScaleOrigin;
                uniform fixed _Effect3ScaleMultipier;
                uniform fixed _Effect3ScaleSpeed;
                uniform fixed4 _Effect3Color;
                uniform fixed _Effect3Brightness;
                uniform float _Effect3RotateAngle;
                uniform fixed _Effect3RotateSpeed;
                uniform fixed _Effect3VerticalSpeed;
                uniform fixed _Effect3HorizontalSpeed;
                uniform fixed _Effect3GlowSpeed;
                uniform fixed _Effect3MaskMode;
                uniform fixed _Effect3AlphaMode;
                uniform fixed _Effect3UniformUV;
                uniform fixed _Effect3TimingOffset;
                uniform fixed _Effect3UseAlpha;
                uniform fixed _Effect3ScalePingPong;
                uniform fixed _Effect3RotateScrollDirection;
                uniform fixed _Effect3MaskDistortStrength;
            #endif

            #if _EFFECT4_ON
                uniform sampler2D _Effect4Tex; uniform float4 _Effect4Tex_ST;
                uniform sampler2D _Effect4Mask; uniform float4 _Effect4Mask_ST;
                uniform fixed _Effect4Power;
                uniform fixed _Effect4ScaleOrigin;
                uniform fixed _Effect4ScaleMultipier;
                uniform fixed _Effect4ScaleSpeed;
                uniform fixed4 _Effect4Color;
                uniform fixed _Effect4Brightness;
                uniform float _Effect4RotateAngle;
                uniform fixed _Effect4RotateSpeed;
                uniform fixed _Effect4VerticalSpeed;
                uniform fixed _Effect4HorizontalSpeed;
                uniform fixed _Effect4GlowSpeed;
                uniform fixed _Effect4MaskMode;
                uniform fixed _Effect4AlphaMode;
                uniform fixed _Effect4UniformUV;
                uniform fixed _Effect4TimingOffset;
                uniform fixed _Effect4UseAlpha;
                uniform fixed _Effect4ScalePingPong;
                uniform fixed _Effect4RotateScrollDirection;
                uniform fixed _Effect4MaskDistortStrength;
            #endif

            #if _EFFECT5_ON
                uniform sampler2D _Effect5Tex; uniform float4 _Effect5Tex_ST;
                uniform sampler2D _Effect5Mask; uniform float4 _Effect5Mask_ST;
                uniform fixed _Effect5Power;
                uniform fixed _Effect5ScaleOrigin;
                uniform fixed _Effect5ScaleMultipier;
                uniform fixed _Effect5ScaleSpeed;
                uniform fixed4 _Effect5Color;
                uniform fixed _Effect5Brightness;
                uniform float _Effect5RotateAngle;
                uniform fixed _Effect5RotateSpeed;
                uniform fixed _Effect5VerticalSpeed;
                uniform fixed _Effect5HorizontalSpeed;
                uniform fixed _Effect5GlowSpeed;
                uniform fixed _Effect5MaskMode;
                uniform fixed _Effect5AlphaMode;
                uniform fixed _Effect5UniformUV;
                uniform fixed _Effect5TimingOffset;
                uniform fixed _Effect5UseAlpha;
                uniform fixed _Effect5ScalePingPong;
                uniform fixed _Effect5RotateScrollDirection;
                uniform fixed _Effect5MaskDistortStrength;
            #endif

            #if _EFFECT6_ON
                uniform sampler2D _Effect6Tex; uniform float4 _Effect6Tex_ST;
                uniform sampler2D _Effect6Mask; uniform float4 _Effect6Mask_ST;
                uniform fixed _Effect6Power;
                uniform fixed _Effect6ScaleOrigin;
                uniform fixed _Effect6ScaleMultipier;
                uniform fixed _Effect6ScaleSpeed;
                uniform fixed4 _Effect6Color;
                uniform fixed _Effect6Brightness;
                uniform float _Effect6RotateAngle;
                uniform fixed _Effect6RotateSpeed;
                uniform fixed _Effect6VerticalSpeed;
                uniform fixed _Effect6HorizontalSpeed;
                uniform fixed _Effect6GlowSpeed;
                uniform fixed _Effect6MaskMode;
                uniform fixed _Effect6AlphaMode;
                uniform fixed _Effect6UniformUV;
                uniform fixed _Effect6TimingOffset;
                uniform fixed _Effect6UseAlpha;
                uniform fixed _Effect6ScalePingPong;
                uniform fixed _Effect6RotateScrollDirection;
                uniform fixed _Effect6MaskDistortStrength;
            #endif

            float2 ScaleUV(float2 uv, float scale, float2 rectAspect) {
                scale = max(0.001, scale);
                //return (uv - 0.5) * float2(1/scale,1/(scale* rectAspect)) + 0.5;
                return (uv - 0.5) * float2(1 / (scale * rectAspect.x), 1 / (scale * rectAspect.y)) + 0.5;
            }

            float2 ScaleUV(float2 uv, float scale) {
                scale = max(0.001, scale);
                return (uv - 0.5) * (1 / scale) + 0.5;
            }

            float2 ComputeScrollUV(float2 uv, float verticalScroll, float horizontalScroll, float maxScale, float effectTime) {
                //float triangleWave = abs(2 * (rotateAngle / 1.5708 - floor(0.5 + rotateAngle / 1.5708)));   
                //float rotationalFix = lerp(1.0, 1.414213562, abs(sin(rotateAngle * 2))); //UV 회전에 의한 비틀림으로 UV루프가 끊어지는 문제 보정 -> 이 방식으론 불가능
                float2 offset = frac(fixed2(horizontalScroll, verticalScroll) * effectTime);
                uv += (offset - floor(0.5 + offset)) * maxScale* ((ceil(1 / maxScale))+ 1);
                return uv;
            }

            float2 ComputeRotateUV(sampler2D tex, float4 tex_ST, float2 uv, float rotateSpeed, float rotateAngle, float effectTime) {
                fixed rotate_cos = cos(rotateSpeed * effectTime + rotateAngle);
                fixed rotate_sin = sin(rotateSpeed * effectTime + rotateAngle);
                fixed2 rotate_piv = fixed2(0.5 - tex_ST.z, 0.5 - tex_ST.w);
                return TRANSFORM_TEX(mul(uv - fixed2(0.5, 0.5), fixed2x2(rotate_cos, -rotate_sin, rotate_sin, rotate_cos)) + rotate_piv, tex);
            }

            float2 ComputeEffectUV(sampler2D tex, float4 tex_ST, float2 uv, float maxScale, float verticalScroll, float horizontalScroll, float rotateSpeed, float rotateAngle, float effectTime, float scrollDirection) {
                float2 scrollUV = uv;
                scrollUV = ComputeScrollUV(scrollUV, verticalScroll, horizontalScroll, maxScale, effectTime);
                scrollUV = ComputeRotateUV(tex, tex_ST, scrollUV, rotateSpeed, rotateAngle, effectTime);
                float2 directionalScrollUV = uv;
                directionalScrollUV = ComputeRotateUV(tex, tex_ST, directionalScrollUV, rotateSpeed, rotateAngle, effectTime);
                directionalScrollUV = ComputeScrollUV(directionalScrollUV, verticalScroll, horizontalScroll, maxScale, effectTime);
                return lerp(scrollUV, directionalScrollUV, scrollDirection);
            }

            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                o.worldPosition = v.vertex;
                float4 vPosition = UnityObjectToClipPos(v.vertex);
                o.pos = vPosition;

                float2 pixelSize = vPosition.w;
                pixelSize /= float2(1, 1) * abs(mul((float2x2)UNITY_MATRIX_P, _ScreenParams.xy));

                float4 clampedRect = clamp(_ClipRect, -2e10, 2e10);
                float2 maskUV = (v.vertex.xy - clampedRect.xy) / (clampedRect.zw - clampedRect.xy);
                //OUT.texcoord = TRANSFORM_TEX(v.texcoord.xy, _MainTex);
                o.mask = float4(v.vertex.xy * 2 - clampedRect.xy - clampedRect.zw, 0.25 / (0.25 * half2(_UIMaskSoftnessX, _UIMaskSoftnessY) + abs(pixelSize.xy)));

                if (_UIVertexColorAlwaysGammaSpace)
                {
                    if (!IsGammaSpace())
                    {
                        v.vertexColor.rgb = UIGammaToLinear(v.vertexColor.rgb);
                    }
                }

                o.uv0.xy = v.texcoord0;
                v.texcoord0 = TRANSFORM_TEX(half2((v.texcoord0.r - _Rect.x) / (_Rect.z - _Rect.x), (v.texcoord0.g - _Rect.y) / (_Rect.w - _Rect.y)), _MainTex);
                o.uv3.xy = v.texcoord0;

                v.texcoord0 = lerp(v.texcoord0, v.texcoord1.xy, _UseUiImage);

                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.Glowcolor1 = fixed4(1, 1, 1,1);
                o.Glowcolor2 = 1;

                float2 rectAspect = lerp(_AspectRatio, v.texcoord1.zw, _UseUiImage);

                #ifdef UNITY_HALF_TEXEL_OFFSET
                    o.pos.xy += (_ScreenParams.zw - 1.0) * float2(-1, 1);
                #endif
                
                _Time.g = lerp(_Time.g, _ShaderUnscaledTime, _UseUnscaledTime);
                
                //Effect 1
                #if _EFFECT1_ON
                    float effectTime1 = _Time.g + _Effect1TimingOffset;
                    effectTime1 *= -1;

                    float2 uniformUV1 = ScaleUV(TRANSFORM_TEX(v.texcoord0, _Effect1Tex), 1, rectAspect);
                    o.uv0.zw = ScaleUV(TRANSFORM_TEX(v.texcoord0, _Effect1Tex), 1);
                    o.uv0.zw = lerp(o.uv0.zw, uniformUV1, _Effect1UniformUV);
                    o.uv0.zw = ComputeEffectUV(_Effect1Tex, _Effect1Tex_ST, o.uv0.zw, _Effect1ScaleOrigin, _Effect1VerticalSpeed, _Effect1HorizontalSpeed,
                        _Effect1RotateSpeed, _Effect1RotateAngle, effectTime1, _Effect1RotateScrollDirection);
                    o.Glowcolor1.x = cos((effectTime1 *_Effect1GlowSpeed))*0.5 + 0.5;
                #endif
                //

                //Effect 2
                #if _EFFECT2_ON
                    float effectTime2 = _Time.g + _Effect2TimingOffset;
                    effectTime2 *= -1;

                    float2 uniformUV2 = ScaleUV(TRANSFORM_TEX(v.texcoord0, _Effect2Tex), 1, rectAspect);
                    o.uv1.xy = ScaleUV(TRANSFORM_TEX(v.texcoord0, _Effect2Tex), 1);
                    o.uv1.xy = lerp(o.uv1.xy, uniformUV2, _Effect2UniformUV);
                    o.uv1.xy = ComputeEffectUV(_Effect2Tex, _Effect2Tex_ST, o.uv1.xy, _Effect2ScaleOrigin, _Effect2VerticalSpeed, _Effect2HorizontalSpeed,
                        _Effect2RotateSpeed, _Effect2RotateAngle, effectTime2, _Effect2RotateScrollDirection);
                    o.Glowcolor1.y = cos((effectTime2 *_Effect2GlowSpeed))*0.5 + 0.5;
                #endif
                //

                //Effect 3
                #if _EFFECT3_ON
                    float effectTime3 = _Time.g + _Effect3TimingOffset;
                    effectTime3 *= -1;

                    float2 uniformUV3 = ScaleUV(TRANSFORM_TEX(v.texcoord0, _Effect3Tex), 1, rectAspect);
                    o.uv1.zw = ScaleUV(TRANSFORM_TEX(v.texcoord0, _Effect3Tex), 1);
                    o.uv1.zw = lerp(o.uv1.zw, uniformUV3, _Effect3UniformUV);
                    o.uv1.zw = ComputeEffectUV(_Effect3Tex, _Effect3Tex_ST, o.uv1.zw, _Effect3ScaleOrigin, _Effect3VerticalSpeed, _Effect3HorizontalSpeed,
                        _Effect3RotateSpeed, _Effect3RotateAngle, effectTime3, _Effect3RotateScrollDirection);
				    o.Glowcolor1.z = cos((effectTime3 *_Effect3GlowSpeed))*0.5 + 0.5;
                #endif
                //

                //Effect 4
                #if _EFFECT4_ON
                    float effectTime4 = _Time.g + _Effect4TimingOffset;
                    effectTime4 *= -1;

                    float2 uniformUV4 = ScaleUV(TRANSFORM_TEX(v.texcoord0, _Effect4Tex), 1, rectAspect);
                    o.uv2.xy = ScaleUV(TRANSFORM_TEX(v.texcoord0, _Effect4Tex), 1);
                    o.uv2.xy = lerp(o.uv2.xy, uniformUV4, _Effect4UniformUV);
                    o.uv2.xy = ComputeEffectUV(_Effect4Tex, _Effect4Tex_ST, o.uv2.xy, _Effect4ScaleOrigin, _Effect4VerticalSpeed, _Effect4HorizontalSpeed,
                        _Effect4RotateSpeed, _Effect4RotateAngle, effectTime4, _Effect4RotateScrollDirection);
				    o.Glowcolor1.w = cos((effectTime4 *_Effect4GlowSpeed))*0.5 + 0.5;
                #endif
                //

                //Effect 5
                #if _EFFECT5_ON
                    float effectTime5 = _Time.g + _Effect5TimingOffset;
                    effectTime5 *= -1;

                    float2 uniformUV5 = ScaleUV(TRANSFORM_TEX(v.texcoord0, _Effect5Tex), 1, rectAspect);
                    o.uv2.zw = ScaleUV(TRANSFORM_TEX(v.texcoord0, _Effect5Tex), 1);
                    o.uv2.zw = lerp(o.uv2.zw, uniformUV5, _Effect5UniformUV);
                    o.uv2.zw = ComputeEffectUV(_Effect5Tex, _Effect5Tex_ST, o.uv2.zw, _Effect5ScaleOrigin, _Effect5VerticalSpeed, _Effect5HorizontalSpeed,
                        _Effect5RotateSpeed, _Effect5RotateAngle, effectTime5, _Effect5RotateScrollDirection);
				    o.Glowcolor2.x = cos((effectTime5 *_Effect5GlowSpeed))*0.5 + 0.5;
                #endif
                //

                //Effect 6
                #if _EFFECT6_ON
                    float effectTime6 = _Time.g + _Effect6TimingOffset;
                    effectTime6 *= -1;

                    float2 uniformUV6 = ScaleUV(TRANSFORM_TEX(v.texcoord0, _Effect6Tex), 1, rectAspect);
                    o.uv3.zw = ScaleUV(TRANSFORM_TEX(v.texcoord0, _Effect6Tex), 1);
                    o.uv3.zw = lerp(o.uv3.zw, uniformUV6, _Effect6UniformUV);
                    o.uv3.zw = ComputeEffectUV(_Effect6Tex, _Effect6Tex_ST, o.uv3.zw, _Effect6ScaleOrigin, _Effect6VerticalSpeed, _Effect6HorizontalSpeed,
                        _Effect6RotateSpeed, _Effect6RotateAngle, effectTime6, _Effect6RotateScrollDirection);
				    o.Glowcolor2.y = cos((effectTime6 *_Effect6GlowSpeed))*0.5 + 0.5;
                #endif
                //
                return o;
            }

            fixed4 ScaleFlowTex(sampler2D tex, float2 uv, float scaleMultipier, float scaleOrigin, float scaleSpeed, float timingOffset) {
                float effectTime = _Time.g + timingOffset;
                scaleMultipier = scaleOrigin * scaleMultipier;
                float effect1Scale1 = lerp(scaleOrigin, scaleMultipier, frac(effectTime * scaleSpeed));
                float effect1Scale2 = lerp(scaleOrigin, scaleMultipier, frac((effectTime - min(100,0.5 / scaleSpeed)) * scaleSpeed));  //scaleSpeed가 0일때 0으로 나누기 대책
                float2 flowUV1 = ScaleUV(uv, effect1Scale1);
                float2 flowUV2 = ScaleUV(uv, effect1Scale2);
                fixed4 texflow1 = tex2D(tex, flowUV1);
                fixed4 texflow2 = tex2D(tex, flowUV2);
                texflow1.rgb *= texflow1.a;
                texflow2.rgb *= texflow2.a;
                float lerpVal = abs(frac(effectTime * scaleSpeed) * 2 - 1);
                return lerp(texflow1, texflow2, lerpVal);
            }

            fixed4 ScalePIngPongTex(sampler2D tex, float2 uv, float scaleMultipier, float scaleOrigin, float scaleSpeed, float timingOffset) {
                float effectTime = (cos(_Time.g * scaleSpeed + timingOffset) + 1) / 2;
                scaleMultipier = scaleOrigin * scaleMultipier;
                float effect1Scale = lerp(scaleOrigin, scaleMultipier, effectTime);
                uv = ScaleUV(uv, effect1Scale);
                fixed4 texVal = tex2D(tex, uv);
                texVal.rgb *= texVal.a;
                return texVal;
            }

            fixed4 ScaleTex(sampler2D tex, float2 uv, float scaleMultipier, float scaleOrigin, float scaleSpeed, float timingOffset, float scaleMode) {
                fixed4 flow_tex = ScaleFlowTex(tex, uv, scaleMultipier, scaleOrigin, scaleSpeed, timingOffset);
                fixed4 pingpong_tex = ScalePIngPongTex(tex, uv, scaleMultipier, scaleOrigin, scaleSpeed, timingOffset);
                fixed4 scaleTex = lerp(flow_tex, pingpong_tex, scaleMode);
                return scaleTex;
            }

            fixed4 frag(VertexOutput i) : COLOR {
                _Time.g = lerp(_Time.g, _ShaderUnscaledTime, _UseUnscaledTime);
                #if defined(UNITY_UI_CLIP_RECT) || defined(UNITY_UI_ALPHACLIP)
                const half alphaPrecision = half(0xff);
                const half invAlphaPrecision = half(1.0 / alphaPrecision);
                half clipRect = round(i.vertexColor.a * alphaPrecision) * invAlphaPrecision;
                #endif

                #ifdef UNITY_UI_CLIP_RECT
                half2 m = saturate((_ClipRect.zw - _ClipRect.xy - abs(i.mask.xy)) * i.mask.zw);
                clipRect *= m.x * m.y;
                #endif

                #if defined(UNITY_UI_CLIP_RECT) || defined(UNITY_UI_ALPHACLIP)
                clip(clipRect - 0.001);
                #endif

                fixed4 _Mask_var = tex2D(_MainTex, i.uv0.xy); // Effects Main Mask
                _Mask_var.rgb *= i.vertexColor.rgb;
                fixed alphaBlendAlpha = 0;

                _Mask_var.rgb = lerp(_Mask_var.rgb,fixed3(0, 0, 0), _SetSpriteTransparent);

                fixed finalAlpha = 0;
                fixed addAlpha = 0;
                fixed blendAlpha = 0;

                fixed effectMask = _Mask_var.a * i.vertexColor.a;
                //#ifdef UNITY_UI_ALPHACLIP
                //    clip(effectMask - 0.001);
                //#endif
                fixed3 finalColor = _Mask_var;// float3(0, 0, 0);
                fixed3 baseColor = finalColor;
                fixed3 finalColorAdditive = fixed3(0,0,0);
                fixed3 finalColorAlphaBlend = fixed3(0, 0, 0);

                fixed3 effect1Color;
                fixed3 effect2Color;
                fixed3 effect3Color;
                fixed3 effect4Color;
                fixed3 effect5Color;
                fixed3 effect6Color;

                fixed effect2Mask = 1;
                fixed effect3Mask = 1;
                fixed effect4Mask = 1;
                fixed effect5Mask = 1; 
                fixed effect6Mask = 1;

                #if _EFFECT1_ON
                fixed2 _Effect1_mask = tex2D(_Effect1Mask, i.uv3.xy).rg;
                i.uv0.zw += ((_Effect1_mask.g - 0.5) * 2) * _Effect1MaskDistortStrength;
                fixed4 _Effect1_var = ScaleTex(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultipier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset, _Effect1ScalePingPong);
                alphaBlendAlpha = lerp(saturate(Luminance(_Effect1_var) * 4), _Effect1_var.a, _Effect1UseAlpha) * i.Glowcolor1.x * _Effect1Color.a;
                _Effect1_var *= _Effect1_var.a;
                effect1Color = pow(_Effect1_var.rgb, _Effect1Power) * _Effect1Color.rgb * _Effect1Color.a * _Effect1Brightness;

                effect1Color *= _Effect1_mask.r;

                effect2Mask = lerp(1,effect1Color.r, _Effect1MaskMode);
                effect2Mask = saturate(effect2Mask);

                baseColor = finalColor;
                finalColorAdditive = finalColor + effect1Color * i.Glowcolor1.x;
                finalColorAlphaBlend = lerp(finalColor,effect1Color, alphaBlendAlpha);
                finalColor = lerp(finalColorAdditive, finalColorAlphaBlend, _Effect1AlphaMode);
                finalColor = lerp(finalColor, baseColor, _Effect1MaskMode);

                addAlpha = finalAlpha + effect1Color;
                blendAlpha = max(finalAlpha, alphaBlendAlpha);
                finalAlpha = lerp(addAlpha, blendAlpha, _Effect1AlphaMode);

                finalColor = saturate(finalColor);
                #endif

                #if _EFFECT2_ON
                fixed2 _Effect2_mask = tex2D(_Effect2Mask, i.uv3.xy).rg;
                i.uv1.xy += ((_Effect2_mask.g - 0.5) * 2) * _Effect2MaskDistortStrength;
                fixed4 _Effect2_var = ScaleTex(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultipier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset, _Effect2ScalePingPong);
                _Effect2_var *= _Effect2_var.a;
                effect2Color = pow(_Effect2_var.rgb, _Effect2Power) * _Effect2Color.rgb * _Effect2Color.a * _Effect2Brightness* effect2Mask;

                effect2Color *= _Effect2_mask.r;

                effect3Mask = lerp(1, effect2Color.r, _Effect2MaskMode);
                effect3Mask = saturate(effect3Mask);

                baseColor = finalColor;
                finalColorAdditive = finalColor + effect2Color * i.Glowcolor1.y;
                alphaBlendAlpha = lerp(saturate(Luminance(_Effect2_var) * 4), _Effect2_var.a, _Effect2UseAlpha) * effect2Mask * i.Glowcolor1.y * _Effect2Color.a;
                finalColorAlphaBlend = lerp(finalColor, effect2Color, alphaBlendAlpha);
                finalColor = lerp(finalColorAdditive, finalColorAlphaBlend, _Effect2AlphaMode);
                finalColor = lerp(finalColor, baseColor, _Effect2MaskMode);

                addAlpha = finalAlpha + effect2Color;
                blendAlpha = max(finalAlpha, alphaBlendAlpha);
                finalAlpha = lerp(addAlpha, blendAlpha, _Effect2AlphaMode);

                finalColor = saturate(finalColor);
                #endif

                #if _EFFECT3_ON
                fixed2 _Effect3_mask = tex2D(_Effect3Mask, i.uv3.xy).rg;
                i.uv1.zw += ((_Effect3_mask.g - 0.5) * 2) * _Effect3MaskDistortStrength;
                fixed4 _Effect3_var = ScaleTex(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultipier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset, _Effect3ScalePingPong);
                _Effect3_var *= _Effect3_var.a;
                effect3Color = pow(_Effect3_var.rgb, _Effect3Power) * _Effect3Color.rgb * _Effect3Color.a * _Effect3Brightness* effect3Mask;

                effect3Color *= _Effect3_mask.r;

                effect4Mask = lerp(1, effect3Color.r, _Effect3MaskMode);
                effect4Mask = saturate(effect4Mask);

                baseColor = finalColor;
                finalColorAdditive = finalColor + effect3Color * i.Glowcolor1.z;
                alphaBlendAlpha = lerp(saturate(Luminance(_Effect3_var) * 4), _Effect3_var.a, _Effect3UseAlpha) * effect3Mask * i.Glowcolor1.z * _Effect3Color.a;;
                finalColorAlphaBlend = lerp(finalColor, effect3Color, alphaBlendAlpha);
                finalColor = lerp(finalColorAdditive, finalColorAlphaBlend, _Effect3AlphaMode);
                finalColor = lerp(finalColor, baseColor, _Effect3MaskMode);

                addAlpha = finalAlpha + effect3Color;
                blendAlpha = max(finalAlpha, alphaBlendAlpha);
                finalAlpha = lerp(addAlpha, blendAlpha, _Effect3AlphaMode);

                finalColor = saturate(finalColor);
                #endif

                #if _EFFECT4_ON
                fixed2 _Effect4_mask = tex2D(_Effect4Mask, i.uv3.xy).rg;
                i.uv2.xy += ((_Effect4_mask.g - 0.5) * 2) * _Effect4MaskDistortStrength;
                fixed4 _Effect4_var = ScaleTex(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultipier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset, _Effect4ScalePingPong);
                _Effect4_var *= _Effect4_var.a;
                effect4Color = pow(_Effect4_var.rgb, _Effect4Power) * _Effect4Color.rgb * _Effect4Color.a * _Effect4Brightness* effect4Mask;

                effect4Color *= _Effect4_mask.r;

                effect5Mask = lerp(1, effect4Color.r, _Effect4MaskMode);
                effect5Mask = saturate(effect5Mask);

                baseColor = finalColor;
                finalColorAdditive = finalColor + effect4Color * i.Glowcolor1.w;
                alphaBlendAlpha = lerp(saturate(Luminance(_Effect4_var) * 4), _Effect4_var.a, _Effect4UseAlpha) * effect4Mask * i.Glowcolor1.w * _Effect4Color.a;;
                finalColorAlphaBlend = lerp(finalColor, effect4Color, alphaBlendAlpha);
                finalColor = lerp(finalColorAdditive, finalColorAlphaBlend, _Effect4AlphaMode);
                finalColor = lerp(finalColor, baseColor, _Effect4MaskMode);

                addAlpha = finalAlpha + effect4Color;
                blendAlpha = max(finalAlpha, alphaBlendAlpha);
                finalAlpha = lerp(addAlpha, blendAlpha, _Effect4AlphaMode);

                finalColor = saturate(finalColor);
                #endif

                #if _EFFECT5_ON
                fixed2 _Effect5_mask = tex2D(_Effect5Mask, i.uv3.xy).rg;
                i.uv2.zw += ((_Effect5_mask.g - 0.5) * 2) * _Effect5MaskDistortStrength;
                fixed4 _Effect5_var = ScaleTex(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultipier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset, _Effect5ScalePingPong);
                _Effect5_var *= _Effect5_var.a;
                effect5Color = pow(_Effect5_var.rgb, _Effect5Power) * _Effect5Color.rgb * _Effect5Color.a * _Effect5Brightness* effect5Mask;

                effect5Color *= _Effect5_mask.r;

                effect6Mask = lerp(1, effect5Color.r, _Effect5MaskMode);
                effect6Mask = saturate(effect6Mask);

                baseColor = finalColor;
                finalColorAdditive = finalColor + effect5Color * i.Glowcolor2.x;
                alphaBlendAlpha = lerp(saturate(Luminance(_Effect5_var) * 4), _Effect5_var.a, _Effect5UseAlpha) * effect5Mask * i.Glowcolor2.x * _Effect5Color.a;;
                finalColorAlphaBlend = lerp(finalColor, effect5Color, alphaBlendAlpha);
                finalColor = lerp(finalColorAdditive, finalColorAlphaBlend, _Effect5AlphaMode);
                finalColor = lerp(finalColor, baseColor, _Effect5MaskMode);

                addAlpha = finalAlpha + effect5Color;
                blendAlpha = max(finalAlpha, alphaBlendAlpha);
                finalAlpha = lerp(addAlpha, blendAlpha, _Effect5AlphaMode);

                finalColor = saturate(finalColor);
                #endif

                #if _EFFECT6_ON
                fixed2 _Effect6_mask = tex2D(_Effect6Mask, i.uv3.xy).rg;
                i.uv3.zw += ((_Effect6_mask.g - 0.5) * 2) * _Effect6MaskDistortStrength;
                fixed4 _Effect6_var = ScaleTex(_Effect6Tex, i.uv3.zw, _Effect6ScaleMultipier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset, _Effect6ScalePingPong);
                _Effect6_var *= _Effect6_var.a;
                effect6Color = pow(_Effect6_var.rgb, _Effect6Power) * _Effect6Color.rgb * _Effect6Color.a * _Effect6Brightness* effect6Mask;
           
                effect6Color *= _Effect6_mask.r;

                finalColorAdditive = finalColor + effect6Color * i.Glowcolor2.y;
                alphaBlendAlpha = lerp(saturate(Luminance(_Effect6_var) * 4), _Effect6_var.a, _Effect6UseAlpha) * effect6Mask * i.Glowcolor2.y * _Effect6Color.a;;
                finalColorAlphaBlend = lerp(finalColor, effect6Color, alphaBlendAlpha);
                finalColor = lerp(finalColorAdditive, finalColorAlphaBlend, _Effect6AlphaMode);

                addAlpha = finalAlpha + effect6Color;
                blendAlpha = max(finalAlpha, alphaBlendAlpha);
                finalAlpha = lerp(addAlpha, blendAlpha, _Effect6AlphaMode);

                finalColor = saturate(finalColor);
                #endif

                finalColor = saturate(finalColor)* effectMask;
                finalAlpha = lerp(_Mask_var.a, saturate(finalAlpha),_SetSpriteTransparent);
                return fixed4(finalColor, finalAlpha);
            }
            ENDCG
        }
    }
    //CustomEditor "UIEffectShaderGUI"
    FallBack "Mobile/Particles/Additive"

}
