// Upgrade NOTE: upgraded instancing buffer 'MyProperties' to new syntax.

Shader "Hidden/UI_Effect_Optimized" {
    Properties {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        [PerRendererData] _SpriteEffectMask("SpriteEffect Mask (Secondary)", 2D) = "white" {}
        [PerRendererData] _Rect("Rect Display", Vector) = (0,0,1,1)
        [PerRendererData] _AspectRatio("AspectRatio", Vector) = (1,1,1,1)
        [PerRendererData] _SpriteData("Sprite Data", Vector) = (1,1,0,0)    // <- zw는 실제로 쉐이더에서 사용하지않음. 프로퍼티블럭을 분할하기위해사용
        [PerRendererData] _MaskData("Mask Data", Vector) = (1,1,0,0)

        _BaseCutOutTex("Base CutOut Texture", 2D) = "white" {}
        _BaseCutOutVal("Base CutOut Value", Vector) = (0.5,1,0,1)  //(Cutoff,Contrast,RemapMin,RemapMax)
        _BaseCutOutEdgeColor("Base CutOut Edge Color", Color) = (1,1,1,1)
        _BaseCutOutEdgeColorBrightness("Base CutOut Edge Brightness", Float) = 1
        _BaseCutOutFillColor("Base CutOut Fill Color", Color) = (1,1,1,1)
        _BaseCutOutFillColorBrightness("Base CutOut Fill Brightness", Float) = 1
        _BaseCutOutProgress("Base CutOut Progress", Float) = 0
        _BaseGrayscaleValue("Base Grayscale Value", Float) = 0
        _BaseBrightnessValue("Base Brightness Value", Float) = 1
        _BaseTintColor("Base Tint Color", Color) = (1,1,1,1)
        _BaseVertexAnimVal("Base Vertex Animation Value", Vector) = (0,0,0,0)
        _BaseSpriteGrayscale("Base Sprite Grayscale", Int) = 0
        _BaseSpriteBrightness("Base Sprite Brightness", Int) = 0
        _BaseBrightnessUseLuminanceMask("Base Brightness Use Luminance Mask", Int) = 0
        _BaseSpriteTintColor("Base Sprite TintColor", Int) = 0
        _BaseTintColorUseLuminanceMask("Base Tint Color Use Luminance Mask", Int) = 0

        _BaseGrayscaleUseCurve("Base Grayscale Use Curve", Int) = 0
        _BaseBrightnessUseCurve("Base Brightness Use Curve", Int) = 0
        _BaseTintColorUseCurve("Base Tint Color Use Curve", Int) = 0
        _BaseCutOutUseCurve("Base CutOut Use Curve", Int) = 0

        _Effect1Tex ("Effect1 Texture", 2D) = "black" {}
        _Effect1Mask ("Effect1 Mask", 2D) = "white" {}
        _Effect1SpriteMaskValue("Effect1 SpriteMask Value", Vector) = (0,0,0,0)
        _Effect1Color("Effect1 Color", Color) = (1,1,1,1)
        _Effect1Brightness("Effect1 Brightness", Float) = 1
        _Effect1ScaleOrigin("Effect1 Scale", Float) = 1
        _Effect1ScaleMultiplier("Effect1 Scale Multiplier", Float) = 1
        _Effect1ScaleSpeed("Effect1 Scale Speed", Float) = 0
        _Effect1Power("Effect1 Power", Float) = 1
        _Effect1RotateAngle("Effect1 Rotate Angle", Float) = 0
        _Effect1RotateSpeed("Effect1 Rotate Speed", Float) = 0
        _Effect1VerticalSpeed("Effect1 Vertical Speed", Float) = 0
        _Effect1HorizontalSpeed("Effect1 Horizontal Speed", Float) = 0
        _Effect1GlowSpeed("Effect1 Glow Speed", Float) = 0
        _Effect1TimingOffset("Effect1 Timing Offset", Float) = 0
        _Effect1MaskDistortStrength("Effect1 Mask Distort Strength", Float) = 0
        _Effect1FlipbookValue ("Effect1 Flipbook Value", Vector) = (1,1,0,0)
        _Effect1TimerMaskVal("Effect1 Timer Mask Val", Vector) = (0.3,0.7,0.1,0.1)  // 최소,최대,페더값,시간배속
        _Effect1UseLuminanceMask("Effect1 Use Luminance Mask", Int) = 0
        _Effect1AlphaBlend("Effect1 Alpha Blend", Int) = 0
        _Effect1WorldUV("Effect1 World UV", Int) = 0
        _Effect1UniformUV("Effect1 Uniform UV", Int) = 0
        _Effect1UseAlpha("Effect1 Use Alpha", Int) = 0
        _Effect1UseDistortMask("Effect1 Use Distort Mask", Int) = 0
        _Effect1UseMaskUV("Effect1 Use Mask UV", Int) = 0
        _Effect1UseTimerMaskBaseUV("Effect1 Use Timer Mask Base UV", Int) = 0
        _Effect1BlendMask("Effect1 Blend Mask", Int) = 0
        _Effect1UseGlow("Effect1 Use Glow", Int) = 0
        _Effect1UseSpriteMask("Effect1 Use SpriteMask", Int) = 0
        _Effect1UseColorCurve("Effect1 Use Color Curve", Int) = 0
        _Effect1UseFlipBookCurve("Effect1 Use FlipBook Curve", Int) = 0

        _Effect2Tex("Effect2 Texture", 2D) = "black" {}
        _Effect2Mask("Effect2 Mask", 2D) = "white" {}
        _Effect2SpriteMaskValue("Effect2 SpriteMask Value", Vector) = (0,0,0,0)
        _Effect2Color("Effect2 Color", Color) = (1,1,1,1)
        _Effect2Brightness("Effect2 Brightness", Float) = 1
        _Effect2ScaleOrigin("Effect2 Scale", Float) = 1
        _Effect2ScaleMultiplier("Effect2 Scale Multiplier", Float) = 1
        _Effect2ScaleSpeed("Effect2 Scale Speed", Float) = 0
        _Effect2Power("Effect2 Power", Float) = 1
        _Effect2RotateAngle("Effect2 Rotate Angle", Float) = 0
        _Effect2RotateSpeed("Effect2 Rotate Speed", Float) = 0
        _Effect2VerticalSpeed("Effect2 Vertical Speed", Float) = 0
        _Effect2HorizontalSpeed("Effect2 Horizontal Speed", Float) = 0
        _Effect2GlowSpeed("Effect2 Glow Speed", Float) = 0
        _Effect2TimingOffset("Effect2 Timing Offset", Float) = 0
        _Effect2MaskDistortStrength("Effect2 Mask Distort Strength", Float) = 0
        _Effect2FlipbookValue("Effect2 Flipbook Value", Vector) = (1,1,0,0)
        _Effect2TimerMaskVal("Effect2 Timer Mask Val", Vector) = (0.3,0.7,0.1,0.1)  // 최소,최대,페더값,시간배속
        _Effect2UseLuminanceMask("Effect2 Use Luminance Mask", Int) = 0
        _Effect2AlphaBlend("Effect2 Alpha Blend", Int) = 0
        _Effect2WorldUV("Effect2 World UV", Int) = 0
        _Effect2UniformUV("Effect2 Uniform UV", Int) = 0
        _Effect2UseAlpha("Effect2 Use Alpha", Int) = 0
        _Effect2UseDistortMask("Effect2 Use Distort Mask", Int) = 0
        _Effect2UseMaskUV("Effect2 Use Mask UV", Int) = 0
        _Effect2UseTimerMaskBaseUV("Effect2 Use Timer Mask Base UV", Int) = 0
        _Effect2BlendMask("Effect2 Blend Mask", Int) = 0
        _Effect2UseGlow("Effect2 Use Glow", Int) = 0
        _Effect2UseSpriteMask("Effect2 Use SpriteMask", Int) = 0
        _Effect2UseColorCurve("Effect2 Use Color Curve", Int) = 0
        _Effect2UseFlipBookCurve("Effect2 Use FlipBook Curve", Int) = 0

        _Effect3Tex("Effect3 Texture", 2D) = "black" {}
        _Effect3Mask("Effect3 Mask", 2D) = "white" {}
        _Effect3SpriteMaskValue("Effect3 SpriteMask Value", Vector) = (0,0,0,0)
        _Effect3Color("Effect3 Color", Color) = (1,1,1,1)
        _Effect3Brightness("Effect3 Brightness", Float) = 1
        _Effect3ScaleOrigin("Effect3 Scale", Float) = 1
        _Effect3ScaleMultiplier("Effect3 Scale Multiplier", Float) = 1
        _Effect3ScaleSpeed("Effect3 Scale Speed", Float) = 0
        _Effect3Power("Effect3 Power", Float) = 1
        _Effect3RotateAngle("Effect3 Rotate Angle", Float) = 0
        _Effect3RotateSpeed("Effect3 Rotate Speed", Float) = 0
        _Effect3VerticalSpeed("Effect3 Vertical Speed", Float) = 0
        _Effect3HorizontalSpeed("Effect3 Horizontal Speed", Float) = 0
        _Effect3GlowSpeed("Effect3 Glow Speed", Float) = 0
        _Effect3TimingOffset("Effect3 Timing Offset", Float) = 0
        _Effect3MaskDistortStrength("Effect3 Mask Distort Strength", Float) = 0
        _Effect3FlipbookValue("Effect3 Flipbook Value", Vector) = (1,1,0,0)
        _Effect3TimerMaskVal("Effect3 Timer Mask Val", Vector) = (0.3,0.7,0.1,0.1)  // 최소,최대,페더값,시간배속
        _Effect3UseLuminanceMask("Effect3 Use Luminance Mask", Int) = 0
        _Effect3AlphaBlend("Effect3 Alpha Blend", Int) = 0
        _Effect3WorldUV("Effect3 World UV", Int) = 0
        _Effect3UniformUV("Effect3 Uniform UV", Int) = 0
        _Effect3UseAlpha("Effect3 Use Alpha", Int) = 0
        _Effect3UseDistortMask("Effect3 Use Distort Mask", Int) = 0
        _Effect3UseMaskUV("Effect3 Use Mask UV", Int) = 0
        _Effect3UseTimerMaskBaseUV("Effect3 Use Timer Mask Base UV", Int) = 0
        _Effect3BlendMask("Effect3 Blend Mask", Int) = 0
        _Effect3UseGlow("Effect3 Use Glow", Int) = 0
        _Effect3UseSpriteMask("Effect3 Use SpriteMask", Int) = 0
        _Effect3UseColorCurve("Effect3 Use Color Curve", Int) = 0
        _Effect3UseFlipBookCurve("Effect3 Use FlipBook Curve", Int) = 0

        _Effect4Tex("Effect4 Texture", 2D) = "black" {}
        _Effect4Mask("Effect4 Mask", 2D) = "white" {}
        _Effect4SpriteMaskValue("Effect4 SpriteMask Value", Vector) = (0, 0, 0, 0)
        _Effect4Color("Effect4 Color", Color) = (1,1,1,1)
        _Effect4Brightness("Effect4 Brightness", Float) = 1
        _Effect4ScaleOrigin("Effect4 Scale", Float) = 1
        _Effect4ScaleMultiplier("Effect4 Scale Multiplier", Float) = 1
        _Effect4ScaleSpeed("Effect4 Scale Speed", Float) = 0
        _Effect4Power("Effect4 Power", Float) = 1
        _Effect4RotateAngle("Effect4 Rotate Angle", Float) = 0
        _Effect4RotateSpeed("Effect4 Rotate Speed", Float) = 0
        _Effect4VerticalSpeed("Effect4 Vertical Speed", Float) = 0
        _Effect4HorizontalSpeed("Effect4 Horizontal Speed", Float) = 0
        _Effect4GlowSpeed("Effect4 Glow Speed", Float) = 0
        _Effect4TimingOffset("Effect4 Timing Offset", Float) = 0
        _Effect4MaskDistortStrength("Effect4 Mask Distort Strength", Float) = 0
        _Effect4FlipbookValue("Effect4 Flipbook Value", Vector) = (1,1,0,0)
        _Effect4TimerMaskVal("Effect4 Timer Mask Val", Vector) = (0.3,0.7,0.1,0.1)  // 최소,최대,페더값,시간배속
        _Effect4UseLuminanceMask("Effect4 Use Luminance Mask", Int) = 0
        _Effect4AlphaBlend("Effect4 Alpha Blend", Int) = 0
        _Effect4WorldUV("Effect4 World UV", Int) = 0
        _Effect4UniformUV("Effect4 Uniform UV", Int) = 0
        _Effect4UseAlpha("Effect4 Use Alpha", Int) = 0
        _Effect4UseDistortMask("Effect4 Use Distort Mask", Int) = 0
        _Effect4UseMaskUV("Effect4 Use Mask UV", Int) = 0
        _Effect4UseTimerMaskBaseUV("Effect4 Use Timer Mask Base UV", Int) = 0
        _Effect4BlendMask("Effect4 Blend Mask", Int) = 0
        _Effect4UseGlow("Effect4 Use Glow", Int) = 0
        _Effect4UseSpriteMask("Effect4 Use SpriteMask", Int) = 0
        _Effect4UseColorCurve("Effect4 Use Color Curve", Int) = 0
        _Effect4UseFlipBookCurve("Effect4 Use FlipBook Curve", Int) = 0

        _Effect5Tex("Effect5 Texture", 2D) = "black" {}
        _Effect5Mask("Effect5 Mask", 2D) = "white" {}
        _Effect5SpriteMaskValue("Effect5 SpriteMask Value", Vector) = (0, 0, 0, 0)
        _Effect5Color("Effect5 Color", Color) = (1,1,1,1)
        _Effect5Brightness("Effect5 Brightness", Float) = 1
        _Effect5ScaleOrigin("Effect5 Scale", Float) = 1
        _Effect5ScaleMultiplier("Effect5 Scale Multiplier", Float) = 1
        _Effect5ScaleSpeed("Effect5 Scale Speed", Float) = 0
        _Effect5Power("Effect5 Power", Float) = 1
        _Effect5RotateAngle("Effect5 Rotate Angle", Float) = 0
        _Effect5RotateSpeed("Effect5 Rotate Speed", Float) = 0
        _Effect5VerticalSpeed("Effect5 Vertical Speed", Float) = 0
        _Effect5HorizontalSpeed("Effect5 Horizontal Speed", Float) = 0
        _Effect5GlowSpeed("Effect5 Glow Speed", Float) = 0
        _Effect5TimingOffset("Effect5 Timing Offset", Float) = 0
        _Effect5MaskDistortStrength("Effect5 Mask Distort Strength", Float) = 0
        _Effect5FlipbookValue("Effect5 Flipbook Value", Vector) = (1, 1, 0, 0)
        _Effect5TimerMaskVal("Effect5 Timer Mask Val", Vector) = (0.3, 0.7, 0.1, 0.1)  // 최소,최대,페더값,시간배속
        _Effect5UseLuminanceMask("Effect5 Use Luminance Mask", Int) = 0
        _Effect5AlphaBlend("Effect5 Alpha Blend", Int) = 0
        _Effect5WorldUV("Effect5 World UV", Int) = 0
        _Effect5UniformUV("Effect5 Uniform UV", Int) = 0
        _Effect5UseAlpha("Effect5 Use Alpha", Int) = 0
        _Effect5UseDistortMask("Effect5 Use Distort Mask", Int) = 0
        _Effect5UseMaskUV("Effect5 Use Mask UV", Int) = 0
        _Effect5UseTimerMaskBaseUV("Effect5 Use Timer Mask Base UV", Int) = 0
        _Effect5BlendMask("Effect5 Blend Mask", Int) = 0
        _Effect5UseGlow("Effect5 Use Glow", Int) = 0
        _Effect5UseSpriteMask("Effect5 Use SpriteMask", Int) = 0
        _Effect5UseColorCurve("Effect5 Use Color Curve", Int) = 0
        _Effect5UseFlipBookCurve("Effect5 Use FlipBook Curve", Int) = 0

        _Effect6Tex("Effect6 Texture", 2D) = "black" {}
        _Effect6Mask("Effect6 Mask", 2D) = "white" {}
        _Effect6SpriteMaskValue("Effect6 SpriteMask Value", Vector) = (0, 0, 0, 0)
        _Effect6Color("Effect6 Color", Color) = (1,1,1,1)
        _Effect6Brightness("Effect6 Brightness", Float) = 1
        _Effect6ScaleOrigin("Effect6 Scale", Float) = 1
        _Effect6ScaleMultiplier("Effect6 Scale Multiplier", Float) = 1
        _Effect6ScaleSpeed("Effect6 Scale Speed", Float) = 0
        _Effect6Power("Effect6 Power", Float) = 1
        _Effect6RotateAngle("Effect6 Rotate Angle", Float) = 0
        _Effect6RotateSpeed("Effect6 Rotate Speed", Float) = 0
        _Effect6VerticalSpeed("Effect6 Vertical Speed", Float) = 0
        _Effect6HorizontalSpeed("Effect6 Horizontal Speed", Float) = 0
        _Effect6GlowSpeed("Effect6 Glow Speed", Float) = 0
        _Effect6TimingOffset("Effect6 Timing Offset", Float) = 0
        _Effect6MaskDistortStrength("Effect6 Mask Distort Strength", Float) = 0
        _Effect6FlipbookValue("Effect6 Flipbook Value", Vector) = (1, 1, 0, 0)
        _Effect6TimerMaskVal("Effect6 Timer Mask Val", Vector) = (0.3, 0.7, 0.1, 0.1)  // 최소,최대,페더값,시간배속
        _Effect6UseLuminanceMask("Effect6 Use Luminance Mask", Int) = 0
        _Effect6AlphaBlend("Effect6 Alpha Blend", Int) = 0
        _Effect6WorldUV("Effect6 World UV", Int) = 0
        _Effect6UniformUV("Effect6 Uniform UV", Int) = 0
        _Effect6UseAlpha("Effect6 Use Alpha", Int) = 0
        _Effect6UseDistortMask("Effect6 Use Distort Mask", Int) = 0
        _Effect6UseMaskUV("Effect6 Use Mask UV", Int) = 0
        _Effect6UseTimerMaskBaseUV("Effect6 Use Timer Mask Base UV", Int) = 0
        _Effect6BlendMask("Effect6 Blend Mask", Int) = 0
        _Effect6UseGlow("Effect6 Use Glow", Int) = 0
        _Effect6UseSpriteMask("Effect6 Use SpriteMask", Int) = 0
        _Effect6UseColorCurve("Effect6 Use Color Curve", Int) = 0
        _Effect6UseFlipBookCurve("Effect6 Use FlipBook Curve", Int) = 0

        _LuminanceMaskThresholdMin("Luminance Mask Threshold Min", Float) = 0.01
        _LuminanceMaskThresholdMax("Luminance Mask Threshold Max", Float) = 0.1

		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255

		_ColorMask ("Color Mask", Float) = 15

		[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
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
        ZTest [unity_GUIZTestMode] //LEqual
        Blend One OneMinusSrcAlpha
        ColorMask [_ColorMask]

        Offset -1, -1

        Pass 
        {
            Name "Default"
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #pragma shader_feature_local _UIIMAGE_ON
            #pragma shader_feature_local _SPRITESLICED_ON
            #pragma shader_feature_local _REMOVEBASESPRITE_ON
            #pragma shader_feature_local _USEUNSCALEDTIME_ON
            #pragma shader_feature_local _BASESPRITEGRAYSCALE_ON
            #pragma shader_feature_local _BASECUTOUT_ON
            #pragma shader_feature_local _BASECUTOUTEDGECOLOR_ON
            #pragma shader_feature_local _BASECUTOUTFILLCOLOR_ON
            #pragma shader_feature_local _BASECUTOUTUSESLICEUV_ON
            #pragma shader_feature_local _BASECUTOUTUNIFORMUV_ON
            #pragma shader_feature_local _BASECUTOUTDONOTUSEALPHA_ON
            #pragma shader_feature_local _BASEVERTEXANIM_ON

            #pragma shader_feature_local _EFFECT1_ON
            #if _EFFECT1_ON
            #pragma shader_feature_local _EFFECT1USEMASK_ON
            #pragma shader_feature_local _EFFECT1USEROTATE_ON
            #pragma shader_feature_local _EFFECT1RANDOMROTATE_ON
            #pragma shader_feature_local _EFFECT1USESCROLL_ON
            #pragma shader_feature_local _ _EFFECT1USESCALE_ON _EFFECT1USESCALEPINGPONG_ON
            #pragma shader_feature_local _EFFECT1USEDIRECTIONALSCROLL_ON
            #pragma shader_feature_local _EFFECT1USEFLIPBOOK_ON
            #if _EFFECT1USEFLIPBOOK_ON
            #pragma shader_feature_local _EFFECT1USEFLIPBOOKBLEND_ON
            #endif
            #if _EFFECT1USEMASK_ON
            #pragma shader_feature_local _EFFECT1USETIMERMASK_ON
            #pragma shader_feature_local _EFFECT1USETIMEROFFSETMASK_ON
            #endif
            #pragma shader_feature_local _EFFECT1USESCROLLCURVE_ON
            #pragma shader_feature_local _EFFECT1USEROTATECURVE_ON
            #pragma shader_feature_local _EFFECT1USESCALECURVE_ON
            #endif

            #pragma shader_feature_local _EFFECT2_ON
            #if _EFFECT2_ON
            #pragma shader_feature_local _EFFECT2USEMASK_ON
            #pragma shader_feature_local _EFFECT2USEROTATE_ON
            #pragma shader_feature_local _EFFECT2RANDOMROTATE_ON
            #pragma shader_feature_local _EFFECT2USESCROLL_ON
            #pragma shader_feature_local _ _EFFECT2USESCALE_ON _EFFECT2USESCALEPINGPONG_ON
            #pragma shader_feature_local _EFFECT2USEDIRECTIONALSCROLL_ON
            #pragma shader_feature_local _EFFECT2USEFLIPBOOK_ON
            #if _EFFECT2USEFLIPBOOK_ON
            #pragma shader_feature_local _EFFECT2USEFLIPBOOKBLEND_ON
            #endif
            #if _EFFECT2USEMASK_ON
            #pragma shader_feature_local _EFFECT2USETIMERMASK_ON
            #pragma shader_feature_local _EFFECT2USETIMEROFFSETMASK_ON
            #endif
            #pragma shader_feature_local _EFFECT2USESCROLLCURVE_ON
            #pragma shader_feature_local _EFFECT2USEROTATECURVE_ON
            #pragma shader_feature_local _EFFECT2USESCALECURVE_ON
            #endif

            #pragma shader_feature_local _EFFECT3_ON
            #if _EFFECT3_ON
            #pragma shader_feature_local _EFFECT3USEMASK_ON
            #pragma shader_feature_local _EFFECT3USEROTATE_ON
            #pragma shader_feature_local _EFFECT3RANDOMROTATE_ON
            #pragma shader_feature_local _EFFECT3USESCROLL_ON
            #pragma shader_feature_local _ _EFFECT3USESCALE_ON _EFFECT3USESCALEPINGPONG_ON
            #pragma shader_feature_local _EFFECT3USEDIRECTIONALSCROLL_ON
            #pragma shader_feature_local _EFFECT3USEFLIPBOOK_ON
            #if _EFFECT3USEFLIPBOOK_ON
            #pragma shader_feature_local _EFFECT3USEFLIPBOOKBLEND_ON
            #endif
            #if _EFFECT3USEMASK_ON
            #pragma shader_feature_local _EFFECT3USETIMERMASK_ON
            #pragma shader_feature_local _EFFECT3USETIMEROFFSETMASK_ON
            #endif
            #pragma shader_feature_local _EFFECT3USESCROLLCURVE_ON
            #pragma shader_feature_local _EFFECT3USEROTATECURVE_ON
            #pragma shader_feature_local _EFFECT3USESCALECURVE_ON
            #endif

            #pragma shader_feature_local _EFFECT4_ON
            #if _EFFECT4_ON
            #pragma shader_feature_local _EFFECT4USEMASK_ON
            #pragma shader_feature_local _EFFECT4USEROTATE_ON
            #pragma shader_feature_local _EFFECT4RANDOMROTATE_ON
            #pragma shader_feature_local _EFFECT4USESCROLL_ON
            #pragma shader_feature_local _ _EFFECT4USESCALE_ON _EFFECT4USESCALEPINGPONG_ON
            #pragma shader_feature_local _EFFECT4USEDIRECTIONALSCROLL_ON
            #pragma shader_feature_local _EFFECT4USEFLIPBOOK_ON
            #if _EFFECT4USEFLIPBOOK_ON
            #pragma shader_feature_local _EFFECT4USEFLIPBOOKBLEND_ON
            #endif
            #if _EFFECT4USEMASK_ON

            #pragma shader_feature_local _EFFECT4USETIMERMASK_ON
            #pragma shader_feature_local _EFFECT4USETIMEROFFSETMASK_ON
            #endif
            #pragma shader_feature_local _EFFECT4USESCROLLCURVE_ON
            #pragma shader_feature_local _EFFECT4USEROTATECURVE_ON
            #pragma shader_feature_local _EFFECT4USESCALECURVE_ON
            #endif

            #pragma shader_feature_local _EFFECT5_ON
            #if _EFFECT5_ON
            #pragma shader_feature_local _EFFECT5USEMASK_ON
            #pragma shader_feature_local _EFFECT5USEROTATE_ON
            #pragma shader_feature_local _EFFECT5RANDOMROTATE_ON
            #pragma shader_feature_local _EFFECT5USESCROLL_ON
            #pragma shader_feature_local _ _EFFECT5USESCALE_ON _EFFECT5USESCALEPINGPONG_ON
            #pragma shader_feature_local _EFFECT5USEDIRECTIONALSCROLL_ON
            #pragma shader_feature_local _EFFECT5USEFLIPBOOK_ON
            #if _EFFECT5USEFLIPBOOK_ON
            #pragma shader_feature_local _EFFECT5USEFLIPBOOKBLEND_ON
            #endif
            #if _EFFECT5USEMASK_ON
            #pragma shader_feature_local _EFFECT5USETIMERMASK_ON
            #pragma shader_feature_local _EFFECT5USETIMEROFFSETMASK_ON
            #endif
            #pragma shader_feature_local _EFFECT5USESCROLLCURVE_ON
            #pragma shader_feature_local _EFFECT5USEROTATECURVE_ON
            #pragma shader_feature_local _EFFECT5USESCALECURVE_ON
            #endif

            #pragma shader_feature_local _EFFECT6_ON
            #if _EFFECT6_ON
            #pragma shader_feature_local _EFFECT6USEMASK_ON
            #pragma shader_feature_local _EFFECT6USEROTATE_ON
            #pragma shader_feature_local _EFFECT6RANDOMROTATE_ON
            #pragma shader_feature_local _EFFECT6USESCROLL_ON
            #pragma shader_feature_local _ _EFFECT6USESCALE_ON _EFFECT6USESCALEPINGPONG_ON
            #pragma shader_feature_local _EFFECT6USEDIRECTIONALSCROLL_ON
            #pragma shader_feature_local _EFFECT6USEFLIPBOOK_ON
            #if _EFFECT6USEFLIPBOOK_ON
            #pragma shader_feature_local _EFFECT6USEFLIPBOOKBLEND_ON
            #endif
            #if _EFFECT6USEMASK_ON
             #pragma shader_feature_local _EFFECT6USETIMERMASK_ON
            #pragma shader_feature_local _EFFECT6USETIMEROFFSETMASK_ON
            #endif
            #pragma shader_feature_local _EFFECT6USESCROLLCURVE_ON
            #pragma shader_feature_local _EFFECT6USEROTATECURVE_ON
            #pragma shader_feature_local _EFFECT6USESCALECURVE_ON
            #endif

            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "UnityUI.cginc"

			#pragma multi_compile_local _ UNITY_UI_CLIP_RECT
			#pragma multi_compile_local _ UNITY_UI_ALPHACLIP


            struct VertexInput {
				half4 vertex : POSITION;
                float4 texcoord0 : TEXCOORD0;  //zw: rectUV   <-UI이미지일 경우만 헬퍼에서 셋팅
                float4 texcoord1 : TEXCOORD1;   //xy: 정규화UV, zw: 화면비  <-UI이미지일 경우만헬퍼에서 셋팅
                fixed4 vertexColor : COLOR;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct VertexOutput {
				half4 pos : SV_POSITION;

                fixed4 vertexColor : COLOR;

				fixed4 uv0 : TEXCOORD0; //uv0 xy 렌더러UV, zw 이펙트1UV

                #if _EFFECT2_ON || _EFFECT3_ON  //uv1 xy 이펙트2UV, zw 이펙트3UV
				fixed4 uv1 : TEXCOORD1;
                #endif

                #if _EFFECT4_ON || _EFFECT5_ON  //uv2 xy 이펙트4UV ,zw 이펙트5UV
                fixed4 uv2 : TEXCOORD2;
                #endif

                #if _EFFECT6_ON || _BASECUTOUT_ON //uv3 xy 이펙트6UV  ,zw 컷아웃마스크UV
                fixed4 uv3 : TEXCOORD3;
                #endif

                fixed4 uv4 : TEXCOORD4; //uv4 xy 마스크UV ,zw 마스크UV(슬라이스X)

                fixed4 Glowcolor1 : COLOR1;
                fixed2 Glowcolor2 : COLOR2;

                float2 worldPosition : TEXCOORD5;
                float4  mask : TEXCOORD6;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _SpriteEffectMask; uniform float4 _SpriteEffectMask_ST;

            UNITY_INSTANCING_BUFFER_START(Props)
                UNITY_DEFINE_INSTANCED_PROP(fixed4, _Rect)
                UNITY_DEFINE_INSTANCED_PROP(float2, _AspectRatio)
                UNITY_DEFINE_INSTANCED_PROP(float4, _MaskData)
                //#if !defined(_UIIMAGE_ON) && defined(_SPRITESLICED_ON)
                UNITY_DEFINE_INSTANCED_PROP(float4, _SpriteData)
                //#endif
            UNITY_INSTANCING_BUFFER_END(Props)


            UNITY_INSTANCING_BUFFER_START(PerDrawSprite)
            // SpriteRenderer.Color while Non-Batched/Instanced.
            UNITY_DEFINE_INSTANCED_PROP(fixed4, unity_SpriteRendererColorArray)
            // this could be smaller but that's how bit each entry is regardless of type
            UNITY_DEFINE_INSTANCED_PROP(fixed2, unity_SpriteFlipArray)
            //UNITY_DEFINE_INSTANCED_PROP(fixed4, spriteTintColor)
            UNITY_INSTANCING_BUFFER_END(PerDrawSprite)
            #ifdef UNITY_INSTANCING_ENABLED
            #define _RendererColor  UNITY_ACCESS_INSTANCED_PROP(PerDrawSprite, unity_SpriteRendererColorArray)
            #define _Flip           UNITY_ACCESS_INSTANCED_PROP(PerDrawSprite, unity_SpriteFlipArray)
            //#define _Color          UNITY_ACCESS_INSTANCED_PROP(PerDrawSprite, spriteTintColor)
            #endif // instancing

            CBUFFER_START(UnityPerDrawSprite)
            #ifndef UNITY_INSTANCING_ENABLED
            fixed4 _RendererColor;
            fixed2 _Flip;
            //fixed4 _Color;
            #endif
            //float _EnableExternalAlpha;
            CBUFFER_END

            //uniform fixed4 _Rect;
            //uniform float2 _AspectRatio;  //xy 종횡비 
            //uniform float4 _MaskData;   //xy 스프라이트 원본 텍스쳐와 스프라이트 픽셀 크기의 비율, zw 스프라이트 정규화 피봇
            float _ShaderUnscaledTime;

            float4 _ClipRect;
            float _UIMaskSoftnessX;
            float _UIMaskSoftnessY;
            int _UIVertexColorAlwaysGammaSpace;

            static const float PI = 3.14159265f * 2;

            float _LuminanceMaskThresholdMin;
            float _LuminanceMaskThresholdMax;

            uniform int _BaseSpriteGrayscale;
            float _BaseGrayscaleValue;

            uniform int _BaseSpriteBrightness;
            uniform int _BaseBrightnessUseLuminanceMask;
            float _BaseBrightnessValue;

            uniform int _BaseSpriteTintColor;
            uniform int _BaseTintColorUseLuminanceMask;
            fixed4 _BaseTintColor;

            #if _BASECUTOUT_ON
            fixed4 _BaseCutOutVal;
            uniform sampler2D _BaseCutOutTex; uniform float4 _BaseCutOutTex_ST;
                #if _BASECUTOUTEDGECOLOR_ON
                uniform fixed4 _BaseCutOutEdgeColor;
                float _BaseCutOutEdgeColorBrightness;
                #endif // _BASECUTOUTEDGECOLOR_ON
                #if _BASECUTOUTFILLCOLOR_ON
                uniform fixed4 _BaseCutOutFillColor;
                float _BaseCutOutFillColorBrightness;
                #endif // _BASECUTOUTFILLCOLOR_ON
                #if _BASECUTOUTDONOTUSEALPHA_ON
                half _BaseCutOutProgress;
                #endif // _BASECUTOUTDONOTUSEALPHA_ON
            #endif

            #ifdef _BASEVERTEXANIM_ON
            uniform fixed4 _BaseVertexAnimVal; // vector.w for speed
            sampler2D _MaskMap;
            #endif

            //#if !defined(_UIIMAGE_ON) && defined(_SPRITESLICED_ON)
            //half2 _SpriteData;
            //#endif

            #if _EFFECT1_ON
                uniform sampler2D _Effect1Tex; uniform float4 _Effect1Tex_ST;
                #if defined(_EFFECT1USEMASK_ON)
                    #if defined(_EFFECT1USEMASK_ON)
                    uniform sampler2D _Effect1Mask; uniform float4 _Effect1Mask_ST;
                    #endif
                    #if defined(_EFFECT1USETIMERMASK_ON) || defined(_EFFECT1USETIMEROFFSETMASK_ON)
                    uniform fixed4 _Effect1TimerMaskVal;
                    #endif
                #endif
                uniform half4 _Effect1SpriteMaskValue;
                uniform fixed _Effect1MaskDistortStrength;
                uniform fixed _Effect1Power;
                uniform fixed _Effect1ScaleOrigin;
                uniform fixed4 _Effect1Color;
                uniform fixed _Effect1Brightness;
                #if _EFFECT1USEROTATE_ON
                uniform fixed _Effect1RotateAngle;
                uniform fixed _Effect1RotateSpeed;
                #endif
                #if _EFFECT1USESCROLL_ON
                uniform fixed _Effect1VerticalSpeed;
                uniform fixed _Effect1HorizontalSpeed;
                #endif
                uniform fixed _Effect1GlowSpeed;
                #if _EFFECT1USESCALE_ON || _EFFECT1USESCALEPINGPONG_ON
                uniform fixed _Effect1ScaleSpeed;
                uniform fixed _Effect1ScaleMultiplier;
                #endif
                uniform fixed _Effect1TimingOffset;

                #if _EFFECT1USESCROLLCURVE_ON
                float2 _Effect1ScrollCurve;
                #endif
                #if _EFFECT1USEROTATECURVE_ON
                float _Effect1RotateCurve;
                #endif
                #if _EFFECT1USESCALECURVE_ON
                float _Effect1ScaleCurve;
                #endif

                #if _EFFECT1USEFLIPBOOK_ON
                float4 _Effect1FlipbookValue;
                #endif

                uniform int _Effect1UseGlow;
                uniform int _Effect1UseLuminanceMask;
                uniform int _Effect1AlphaBlend;
                uniform int _Effect1WorldUV;
                uniform int _Effect1UniformUV;
                uniform int _Effect1UseAlpha;
                uniform int _Effect1UseDistortMask;
                uniform int _Effect1UseMaskUV;
                uniform int _Effect1UseTimerMaskBaseUV;
                uniform int _Effect1BlendMask;
                uniform int _Effect1UseSpriteMask;
            #endif

            #if _EFFECT2_ON
                uniform sampler2D _Effect2Tex; uniform float4 _Effect2Tex_ST;
                #if defined(_EFFECT2USEMASK_ON)
                    #if defined(_EFFECT2USEMASK_ON)
                    uniform sampler2D _Effect2Mask; uniform float4 _Effect2Mask_ST;
                    #endif
                    #if defined(_EFFECT2USETIMERMASK_ON) || defined(_EFFECT2USETIMEROFFSETMASK_ON)
                    uniform fixed4 _Effect2TimerMaskVal;
                    #endif
                #endif
                uniform half4 _Effect2SpriteMaskValue;
                uniform fixed _Effect2MaskDistortStrength;
                uniform fixed _Effect2Power;
                uniform fixed _Effect2ScaleOrigin;
                uniform fixed4 _Effect2Color;
                uniform fixed _Effect2Brightness;
                #if _EFFECT2USEROTATE_ON
                uniform fixed _Effect2RotateAngle;
                uniform fixed _Effect2RotateSpeed;
                #endif
                #if _EFFECT2USESCROLL_ON
                uniform fixed _Effect2VerticalSpeed;
                uniform fixed _Effect2HorizontalSpeed;
                #endif
                uniform fixed _Effect2GlowSpeed;
                #if _EFFECT2USESCALE_ON || _EFFECT2USESCALEPINGPONG_ON
                uniform fixed _Effect2ScaleSpeed;
                uniform fixed _Effect2ScaleMultiplier;
                #endif
                uniform fixed _Effect2TimingOffset;

                #if _EFFECT2USESCROLLCURVE_ON
                float2 _Effect2ScrollCurve;
                #endif
                #if _EFFECT2USEROTATECURVE_ON
                float _Effect2RotateCurve;
                #endif
                #if _EFFECT2USESCALECURVE_ON
                float _Effect2ScaleCurve;
                #endif

                #if _EFFECT2USEFLIPBOOK_ON
                float4 _Effect2FlipbookValue;
                #endif

                uniform int _Effect2UseGlow;
                uniform int _Effect2UseLuminanceMask;
                uniform int _Effect2AlphaBlend;
                uniform int _Effect2WorldUV;
                uniform int _Effect2UniformUV;
                uniform int _Effect2UseAlpha;
                uniform int _Effect2UseDistortMask;
                uniform int _Effect2UseMaskUV;
                uniform int _Effect2UseTimerMaskBaseUV;
                uniform int _Effect2BlendMask;
                uniform int _Effect2UseSpriteMask;
            #endif

            #if _EFFECT3_ON
                uniform sampler2D _Effect3Tex; uniform float4 _Effect3Tex_ST;
                #if defined(_EFFECT3USEMASK_ON)
                    #if defined(_EFFECT3USEMASK_ON)
                    uniform sampler2D _Effect3Mask; uniform float4 _Effect3Mask_ST;
                    #endif
                    #if defined(_EFFECT3USETIMERMASK_ON) || defined(_EFFECT3USETIMEROFFSETMASK_ON)
                    uniform fixed4 _Effect3TimerMaskVal;
                    #endif
                #endif
                uniform half4 _Effect3SpriteMaskValue;
                uniform fixed _Effect3MaskDistortStrength;
                uniform fixed _Effect3Power;
                uniform fixed _Effect3ScaleOrigin;
                uniform fixed4 _Effect3Color;
                uniform fixed _Effect3Brightness;
                #if _EFFECT3USEROTATE_ON
                uniform fixed _Effect3RotateAngle;
                uniform fixed _Effect3RotateSpeed;
                #endif
                #if _EFFECT3USESCROLL_ON
                uniform fixed _Effect3VerticalSpeed;
                uniform fixed _Effect3HorizontalSpeed;
                #endif
                uniform fixed _Effect3GlowSpeed;
                #if _EFFECT3USESCALE_ON || _EFFECT3USESCALEPINGPONG_ON
                uniform fixed _Effect3ScaleSpeed;
                uniform fixed _Effect3ScaleMultiplier;
                #endif
                uniform fixed _Effect3TimingOffset;

                #if _EFFECT3USESCROLLCURVE_ON
                float2 _Effect3ScrollCurve;
                #endif
                #if _EFFECT3USEROTATECURVE_ON
                float _Effect3RotateCurve;
                #endif
                #if _EFFECT3USESCALECURVE_ON
                float _Effect3ScaleCurve;
                #endif

                #if _EFFECT3USEFLIPBOOK_ON
                float4 _Effect3FlipbookValue;
                #endif

                uniform int _Effect3UseGlow;
                uniform int _Effect3UseLuminanceMask;
                uniform int _Effect3AlphaBlend;
                uniform int _Effect3WorldUV;
                uniform int _Effect3UniformUV;
                uniform int _Effect3UseAlpha;
                uniform int _Effect3UseDistortMask;
                uniform int _Effect3UseMaskUV;
                uniform int _Effect3UseTimerMaskBaseUV;
                uniform int _Effect3BlendMask;
                uniform int _Effect3UseSpriteMask;
            #endif

            #if _EFFECT4_ON
                uniform sampler2D _Effect4Tex; uniform float4 _Effect4Tex_ST;
                #if defined(_EFFECT4USEMASK_ON)
                    #if defined(_EFFECT4USEMASK_ON)
                    uniform sampler2D _Effect4Mask; uniform float4 _Effect4Mask_ST;
                    #endif
                    #if defined(_EFFECT4USETIMERMASK_ON) || defined(_EFFECT4USETIMEROFFSETMASK_ON)
                    uniform fixed4 _Effect4TimerMaskVal;
                    #endif
                #endif
                uniform half4 _Effect4SpriteMaskValue;
                uniform fixed _Effect4MaskDistortStrength;
                uniform fixed _Effect4Power;
                uniform fixed _Effect4ScaleOrigin;
                uniform fixed4 _Effect4Color;
                uniform fixed _Effect4Brightness;
                #if _EFFECT4USEROTATE_ON
                uniform fixed _Effect4RotateAngle;
                uniform fixed _Effect4RotateSpeed;
                #endif
                #if _EFFECT4USESCROLL_ON
                uniform fixed _Effect4VerticalSpeed;
                uniform fixed _Effect4HorizontalSpeed;
                #endif
                uniform fixed _Effect4GlowSpeed;
                #if _EFFECT4USESCALE_ON || _EFFECT4USESCALEPINGPONG_ON
                uniform fixed _Effect4ScaleSpeed;
                uniform fixed _Effect4ScaleMultiplier;
                #endif
                uniform fixed _Effect4TimingOffset;

                #if _EFFECT4USESCROLLCURVE_ON
                float2 _Effect4ScrollCurve;
                #endif
                #if _EFFECT4USEROTATECURVE_ON
                float _Effect4RotateCurve;
                #endif
                #if _EFFECT4USESCALECURVE_ON
                float _Effect4ScaleCurve;
                #endif

                #if _EFFECT4USEFLIPBOOK_ON
                float4 _Effect4FlipbookValue;
                #endif

                uniform int _Effect4UseGlow;
                uniform int _Effect4UseLuminanceMask;
                uniform int _Effect4AlphaBlend;
                uniform int _Effect4WorldUV;
                uniform int _Effect4UniformUV;
                uniform int _Effect4UseAlpha;
                uniform int _Effect4UseDistortMask;
                uniform int _Effect4UseMaskUV;
                uniform int _Effect4UseTimerMaskBaseUV;
                uniform int _Effect4BlendMask;
                uniform int _Effect4UseSpriteMask;
            #endif

            #if _EFFECT5_ON
                uniform sampler2D _Effect5Tex; uniform float4 _Effect5Tex_ST;
                #if defined(_EFFECT5USEMASK_ON)
                    #if defined(_EFFECT5USEMASK_ON)
                    uniform sampler2D _Effect5Mask; uniform float4 _Effect5Mask_ST;
                    #endif
                    #if defined(_EFFECT5USETIMERMASK_ON) || defined(_EFFECT5USETIMEROFFSETMASK_ON)
                    uniform fixed4 _Effect5TimerMaskVal;
                    #endif
                #endif
                uniform half4 _Effect5SpriteMaskValue;
                uniform fixed _Effect5MaskDistortStrength;
                uniform fixed _Effect5Power;
                uniform fixed _Effect5ScaleOrigin;
                uniform fixed4 _Effect5Color;
                uniform fixed _Effect5Brightness;
                #if _EFFECT5USEROTATE_ON
                uniform fixed _Effect5RotateAngle;
                uniform fixed _Effect5RotateSpeed;
                #endif
                #if _EFFECT5USESCROLL_ON
                uniform fixed _Effect5VerticalSpeed;
                uniform fixed _Effect5HorizontalSpeed;
                #endif
                uniform fixed _Effect5GlowSpeed;
                #if _EFFECT5USESCALE_ON || _EFFECT5USESCALEPINGPONG_ON
                uniform fixed _Effect5ScaleSpeed;
                uniform fixed _Effect5ScaleMultiplier;
                #endif
                uniform fixed _Effect5TimingOffset;

                #if _EFFECT5USESCROLLCURVE_ON
                float2 _Effect5ScrollCurve;
                #endif
                #if _EFFECT5USEROTATECURVE_ON
                float _Effect5RotateCurve;
                #endif
                #if _EFFECT5USESCALECURVE_ON
                float _Effect5ScaleCurve;
                #endif

                #if _EFFECT5USEFLIPBOOK_ON
                float4 _Effect5FlipbookValue;
                #endif

                uniform int _Effect5UseGlow;
                uniform int _Effect5UseLuminanceMask;
                uniform int _Effect5AlphaBlend;
                uniform int _Effect5WorldUV;
                uniform int _Effect5UniformUV;
                uniform int _Effect5UseAlpha;
                uniform int _Effect5UseDistortMask;
                uniform int _Effect5UseMaskUV;
                uniform int _Effect5UseTimerMaskBaseUV;
                uniform int _Effect5BlendMask;
                uniform int _Effect5UseSpriteMask;
            #endif

            #if _EFFECT6_ON
                uniform sampler2D _Effect6Tex; uniform float4 _Effect6Tex_ST;
                #if defined(_EFFECT6USEMASK_ON)
                    #if defined(_EFFECT6USEMASK_ON)
                    uniform sampler2D _Effect6Mask; uniform float4 _Effect6Mask_ST;
                    #endif
                    #if defined(_EFFECT6USETIMERMASK_ON) || defined(_EFFECT6USETIMEROFFSETMASK_ON)
                    uniform fixed4 _Effect6TimerMaskVal;
                    #endif
                #endif
                uniform half4 _Effect6SpriteMaskValue;
                uniform fixed _Effect6MaskDistortStrength;
                uniform fixed _Effect6Power;
                uniform fixed _Effect6ScaleOrigin;
                uniform fixed4 _Effect6Color;
                uniform fixed _Effect6Brightness;
                #if _EFFECT6USEROTATE_ON
                uniform fixed _Effect6RotateAngle;
                uniform fixed _Effect6RotateSpeed;
                #endif
                #if _EFFECT6USESCROLL_ON
                uniform fixed _Effect6VerticalSpeed;
                uniform fixed _Effect6HorizontalSpeed;
                #endif
                uniform fixed _Effect6GlowSpeed;
                #if _EFFECT6USESCALE_ON || _EFFECT6USESCALEPINGPONG_ON
                uniform fixed _Effect6ScaleSpeed;
                uniform fixed _Effect6ScaleMultiplier;
                #endif
                uniform fixed _Effect6TimingOffset;

                #if _EFFECT6USESCROLLCURVE_ON
                float2 _Effect6ScrollCurve;
                #endif
                #if _EFFECT6USEROTATECURVE_ON
                float _Effect6RotateCurve;
                #endif
                #if _EFFECT6USESCALECURVE_ON
                float _Effect6ScaleCurve;
                #endif

                #if _EFFECT6USEFLIPBOOK_ON
                float4 _Effect6FlipbookValue;
                #endif

                uniform int _Effect6UseGlow;
                uniform int _Effect6UseLuminanceMask;
                uniform int _Effect6AlphaBlend;
                uniform int _Effect6WorldUV;
                uniform int _Effect6UniformUV;
                uniform int _Effect6UseAlpha;
                uniform int _Effect6UseDistortMask;
                uniform int _Effect6UseMaskUV;
                uniform int _Effect6UseTimerMaskBaseUV;
                uniform int _Effect6BlendMask;
                uniform int _Effect6UseSpriteMask;
            #endif

            float2 ScaleUV(float2 uv,float scale, float2 rectAspect) {
                scale = max(0.001, scale);
                float2 pivotOffset = 0.5;
                return (uv - pivotOffset) * float2(1 / (scale * rectAspect.x), 1 / (scale * rectAspect.y)) + pivotOffset;
            }

            float2 ScaleUV(float2 uv, float scale) {
                scale = max(0.001, scale);
                float2 pivotOffset = 0.5;
                return (uv - pivotOffset) * (1 / scale) + pivotOffset;
            }

            float2 CustomTransformTex(float2 uv, float4 tex_ST) {
                float2 scale = max(0.001, tex_ST.xy);
                float2 pivotOffset = 0.5;
                return (uv - pivotOffset) * (1 / scale) + pivotOffset + tex_ST.zw;
            }

            float2 ComputeScrollUV(float2 uv, float verticalScroll, float horizontalScroll, float maxScale, float effectTime) {
                float2 offset = frac(fixed2(horizontalScroll, verticalScroll) * effectTime);
                uv += (offset - floor(0.5 + offset))* maxScale* ((ceil(1 / maxScale))+1);
                return uv;
            }

            float2 ComputeRotateUV(sampler2D tex, float4 tex_ST, float2 uv, float rotateSpeed, float rotateAngle, float effectTime) {
                fixed rotate_cos = cos(rotateSpeed * effectTime + rotateAngle);
                fixed rotate_sin = sin(rotateSpeed * effectTime + rotateAngle);
                fixed2 rotate_piv = fixed2(0.5 - tex_ST.z, 0.5 - tex_ST.w);
                return mul(uv - rotate_piv, fixed2x2(rotate_cos, -rotate_sin, rotate_sin, rotate_cos)) + rotate_piv;
            }

            float2 ComputeRotateCurveUV(sampler2D tex, float4 tex_ST, float2 uv, float rotateCurve) {
                fixed rotate_cos = cos(rotateCurve);
                fixed rotate_sin = sin(rotateCurve);
                fixed2 rotate_piv = fixed2(0.5 - tex_ST.z, 0.5 - tex_ST.w);
                return mul(uv - rotate_piv, fixed2x2(rotate_cos, -rotate_sin, rotate_sin, rotate_cos)) + rotate_piv;
            }

            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                #ifdef _BASEVERTEXANIM_ON
                    #ifdef _USEUNSCALEDTIME_ON
                    _Time.g = _ShaderUnscaledTime;
                    #endif
                fixed mask = tex2Dlod(_MaskMap, float4(v.texcoord0.xy, 0.0, 1)).b;
                float4 posWorld = mul(unity_ObjectToWorld, v.vertex);
                float aspect = _ScreenParams.x / _ScreenParams.y;
                _BaseVertexAnimVal.x /= aspect;
                v.vertex.xy += mask * sin(((_Time.g + ((posWorld.r + posWorld.g + posWorld.b)* _BaseVertexAnimVal.z * 0.5)) * _BaseVertexAnimVal.w)) * _BaseVertexAnimVal.xy * 0.01;
                #endif

                #if !defined(_UIIMAGE_ON)
                float2 worldPos = v.vertex.xy;
                #endif

                float4 spriteDataVal = UNITY_ACCESS_INSTANCED_PROP(Props, _SpriteData);
                o.worldPosition = (mul(unity_ObjectToWorld, v.vertex).xy - spriteDataVal.zw) * 0.1;
                float4 vPosition = UnityObjectToClipPos(v.vertex);
                o.pos = vPosition;

                float2 pixelSize = vPosition.w;
                pixelSize /= float2(1, 1) * abs(mul((float2x2)UNITY_MATRIX_P, _ScreenParams.xy));

                float4 clampedRect = clamp(_ClipRect, -2e10, 2e10);
                float2 maskUV = (v.vertex.xy - clampedRect.xy) / (clampedRect.zw - clampedRect.xy);

                o.mask = float4(v.vertex.xy * 2 - clampedRect.xy - clampedRect.zw, 0.25 / (0.25 * half2(_UIMaskSoftnessX, _UIMaskSoftnessY) + abs(pixelSize.xy)));

                #if !defined(_UIIMAGE_ON)
                v.vertexColor *= _RendererColor;
                #endif

                if (_UIVertexColorAlwaysGammaSpace)
                {
                    if (!IsGammaSpace())
                    {
                        v.vertexColor.rgb = UIGammaToLinear(v.vertexColor.rgb);
                    }
                }

                //렌더러 스프라이트 UV
                o.uv0.xy = v.texcoord0.xy;

                #if _UIIMAGE_ON
                    //마스크UV
                    o.uv4.xy = v.texcoord0.zw;  //이미지렌더러의 UV에 rect만 적용(슬라이스된 UV 적용시 사용)
                    o.uv4.zw = v.texcoord1.xy;  //일반 정규화 rectUV (이팩트와 동일)
                #else
                    //렌더러가 UI이미지가 아닐경우 여기서 아틀라스UV처리
                    fixed4 rectVal = UNITY_ACCESS_INSTANCED_PROP(Props, _Rect);
                    v.texcoord1.xy = half2((v.texcoord0.r - rectVal.x) / (rectVal.z - rectVal.x), (v.texcoord0.g - rectVal.y) / (rectVal.w - rectVal.y));
                    //v.texcoord1.xy = (o.worldPosition - spriteDataVal.zw) * 0.1;
                    o.uv4.xy = v.texcoord1.xy;  //스프라이트 렌더러의 UV에 rect만 적용(슬라이스된 UV 적용시 사용)
                    float2 pivot = UNITY_ACCESS_INSTANCED_PROP(Props, _MaskData).zw;
                    o.uv4.xy = o.uv4.xy * UNITY_ACCESS_INSTANCED_PROP(Props, _MaskData).xy + pivot;  // 스프라이트 원본텍스쳐의 종횡비에 맞춰서 제작한 마스크의 uv가 어긋나지 않게 보정
                    #if _SPRITESLICED_ON   //스프라이트렌더러에서 드로우모드가 simple이 아닐경우
                    //float4 spriteDataVal = UNITY_ACCESS_INSTANCED_PROP(Props, _SpriteData);
                    v.texcoord1.xy = half2(worldPos.x / spriteDataVal.x, worldPos.y / spriteDataVal.y)+0.5;
                    o.uv4.zw = v.texcoord1.xy;   //일반 정규화 rectUV (이팩트와 동일)
                    #else
                    o.uv4.zw = v.texcoord1.xy;
                    #endif
                #endif

                o.vertexColor = v.vertexColor;

                o.Glowcolor1 = fixed4(1, 1, 1, 1);
                o.Glowcolor2 = fixed2(1,1);

                #if _UIIMAGE_ON
                    float2 rectAspect = v.texcoord1.zw;
                #else
                    float2 rectAspect = UNITY_ACCESS_INSTANCED_PROP(Props, _AspectRatio);
                #endif

                #ifdef UNITY_HALF_TEXEL_OFFSET
                    o.pos.xy += (_ScreenParams.zw - 1.0) * float2(-1, 1);
                #endif
                
                #if _USEUNSCALEDTIME_ON
                _Time.g = _ShaderUnscaledTime;
                #endif

                #if _BASECUTOUT_ON
                    #if _BASECUTOUTUSESLICEUV_ON
                        float2 cutOutMaskUV = o.uv4.xy;
                    #else
                        #if _BASECUTOUTUNIFORMUV_ON
                        float2 cutOutMaskUV = ScaleUV(o.uv4.zw, 1, rectAspect);
                        #else
                        float2 cutOutMaskUV = o.uv4.zw;
                        #endif
                    #endif
                    o.uv3.zw = CustomTransformTex(cutOutMaskUV, _BaseCutOutTex_ST);
                #endif

                //Effect 1
                #if _EFFECT1_ON
                    float effectTime1 = _Time.g + _Effect1TimingOffset;
                    effectTime1 *= -1;
                    
                    o.uv0.zw = _Effect1WorldUV ? o.worldPosition : v.texcoord1.xy;
                    o.uv0.zw = _Effect1UniformUV ? ScaleUV(o.uv0.zw, 1, rectAspect) : ScaleUV(o.uv0.zw, 1);
              
                    #if defined(_EFFECT1USEMASK_ON) && defined(_EFFECT1USETIMEROFFSETMASK_ON)
                    //////
                    #else
                        #if _EFFECT1USEDIRECTIONALSCROLL_ON
                            #if _EFFECT1USEROTATE_ON
                                #if _EFFECT1USEROTATECURVE_ON
                                o.uv0.zw = ComputeRotateCurveUV(_Effect1Tex, _Effect1Tex_ST, o.uv0.zw, _Effect1RotateCurve);
                                #else
                                o.uv0.zw = ComputeRotateUV(_Effect1Tex, _Effect1Tex_ST, o.uv0.zw, _Effect1RotateSpeed, _Effect1RotateAngle, effectTime1);
                                #endif
                            #endif
                            #if _EFFECT1USESCROLL_ON
                                #if _EFFECT1USESCROLLCURVE_ON
                                o.uv0.zw = o.uv0.zw - (_Effect1ScrollCurve * (0.5 + _Effect1ScaleOrigin));
                                #else
                                o.uv0.zw = ComputeScrollUV(o.uv0.zw, _Effect1VerticalSpeed, _Effect1HorizontalSpeed, _Effect1ScaleOrigin, effectTime1);
                                #endif
                            #endif
                        #else
                            #if _EFFECT1USESCROLL_ON
                                #if _EFFECT1USESCROLLCURVE_ON
                                o.uv0.zw = o.uv0.zw - (_Effect1ScrollCurve * (0.5 + _Effect1ScaleOrigin));
                                #else
                                o.uv0.zw = ComputeScrollUV(o.uv0.zw, _Effect1VerticalSpeed, _Effect1HorizontalSpeed, _Effect1ScaleOrigin, effectTime1);
                                #endif
                            #endif
                            #if _EFFECT1USEROTATE_ON
                                #if _EFFECT1USEROTATECURVE_ON
                                o.uv0.zw = ComputeRotateCurveUV(_Effect1Tex, _Effect1Tex_ST, o.uv0.zw, _Effect1RotateCurve);
                                #else
                                o.uv0.zw = ComputeRotateUV(_Effect1Tex, _Effect1Tex_ST, o.uv0.zw, _Effect1RotateSpeed, _Effect1RotateAngle, effectTime1);
                                #endif
                            #endif
                        #endif

                        o.uv0.zw = CustomTransformTex(o.uv0.zw, _Effect1Tex_ST);
                        o.Glowcolor1.x = _Effect1UseGlow ? cos((effectTime1 * _Effect1GlowSpeed)) * 0.5 + 0.5 : 1;
                    #endif
                #endif
                //

                //Effect 2
                #if _EFFECT2_ON
                    float effectTime2 = _Time.g + _Effect2TimingOffset;
                    effectTime2 *= -1;

                    o.uv1.xy = _Effect2WorldUV ? o.worldPosition : v.texcoord1.xy;
                    o.uv1.xy = _Effect2UniformUV ? ScaleUV(o.uv1.xy, 1, rectAspect) : ScaleUV(o.uv1.xy, 1);

                    #if defined(_EFFECT2USEMASK_ON) && defined(_EFFECT2USETIMEROFFSETMASK_ON)
                    //////
                    #else
                        #if _EFFECT2USEDIRECTIONALSCROLL_ON
                            #if _EFFECT2USEROTATE_ON
                                #if _EFFECT2USEROTATECURVE_ON
                                o.uv1.xy = ComputeRotateCurveUV(_Effect2Tex, _Effect2Tex_ST, o.uv1.xy, _Effect2RotateCurve);
                                #else
                                o.uv1.xy = ComputeRotateUV(_Effect2Tex, _Effect2Tex_ST, o.uv1.xy, _Effect2RotateSpeed, _Effect2RotateAngle, effectTime2);
                                #endif
                            #endif
                            #if _EFFECT2USESCROLL_ON
                                #if _EFFECT2USESCROLLCURVE_ON
                                o.uv1.xy = o.uv1.xy - (_Effect2ScrollCurve * (0.5 + _Effect2ScaleOrigin));
                                #else
                                o.uv1.xy = ComputeScrollUV(o.uv1.xy, _Effect2VerticalSpeed, _Effect2HorizontalSpeed, _Effect2ScaleOrigin, effectTime2);
                                #endif
                            #endif
                        #else
                            #if _EFFECT2USESCROLL_ON
                                #if _EFFECT2USESCROLLCURVE_ON
                                o.uv1.xy = o.uv1.xy - (_Effect2ScrollCurve * (0.5 + _Effect2ScaleOrigin));
                                #else
                                o.uv1.xy = ComputeScrollUV(o.uv1.xy, _Effect2VerticalSpeed, _Effect2HorizontalSpeed, _Effect2ScaleOrigin, effectTime2);
                                #endif
                            #endif
                            #if _EFFECT2USEROTATE_ON
                                #if _EFFECT2USEROTATECURVE_ON
                                o.uv1.xy = ComputeRotateCurveUV(_Effect2Tex, _Effect2Tex_ST, o.uv1.xy, _Effect2RotateCurve);
                                #else
                                o.uv1.xy = ComputeRotateUV(_Effect2Tex, _Effect2Tex_ST, o.uv1.xy, _Effect2RotateSpeed, _Effect2RotateAngle, effectTime2);
                                #endif
                            #endif
                        #endif

                        o.uv1.xy = CustomTransformTex(o.uv1.xy, _Effect2Tex_ST);
                        o.Glowcolor1.y = _Effect2UseGlow ? cos((effectTime2 * _Effect2GlowSpeed)) * 0.5 + 0.5 : 1;
                    #endif
                #endif
                //

                //Effect 3
                #if _EFFECT3_ON
                    float effectTime3 = _Time.g + _Effect3TimingOffset;
                    effectTime3 *= -1;

                    o.uv1.zw = _Effect3WorldUV ? o.worldPosition : v.texcoord1.xy;
                    o.uv1.zw = _Effect3UniformUV ? ScaleUV(o.uv1.zw, 1, rectAspect) : ScaleUV(o.uv1.zw, 1);

                    #if defined(_EFFECT3USEMASK_ON) && defined(_EFFECT3USETIMEROFFSETMASK_ON)
                    //////
                    #else
                        #if _EFFECT3USEDIRECTIONALSCROLL_ON
                            #if _EFFECT3USEROTATE_ON
                                #if _EFFECT3USEROTATECURVE_ON
                                o.uv1.zw = ComputeRotateCurveUV(_Effect3Tex, _Effect3Tex_ST, o.uv1.zw, _Effect3RotateCurve);
                                #else
                                o.uv1.zw = ComputeRotateUV(_Effect3Tex, _Effect3Tex_ST, o.uv1.zw, _Effect3RotateSpeed, _Effect3RotateAngle, effectTime3);
                                #endif
                            #endif
                            #if _EFFECT3USESCROLL_ON
                                #if _EFFECT3USESCROLLCURVE_ON
                                o.uv1.zw = o.uv1.zw - (_Effect3ScrollCurve * (0.5 + _Effect3ScaleOrigin));
                                #else
                                o.uv1.zw = ComputeScrollUV(o.uv1.zw, _Effect3VerticalSpeed, _Effect3HorizontalSpeed, _Effect3ScaleOrigin, effectTime3);
                                #endif
                            #endif
                        #else
                            #if _EFFECT3USESCROLL_ON
                                #if _EFFECT3USESCROLLCURVE_ON
                                o.uv1.zw = o.uv1.zw - (_Effect3ScrollCurve * (0.5 + _Effect3ScaleOrigin));
                                #else
                                o.uv1.zw = ComputeScrollUV(o.uv1.zw, _Effect3VerticalSpeed, _Effect3HorizontalSpeed, _Effect3ScaleOrigin, effectTime3);
                                #endif
                            #endif
                            #if _EFFECT3USEROTATE_ON
                                #if _EFFECT3USEROTATECURVE_ON
                                o.uv1.zw = ComputeRotateCurveUV(_Effect3Tex, _Effect3Tex_ST, o.uv1.zw, _Effect3RotateCurve);
                                #else
                                o.uv1.zw = ComputeRotateUV(_Effect3Tex, _Effect3Tex_ST, o.uv1.zw, _Effect3RotateSpeed, _Effect3RotateAngle, effectTime3);
                                #endif
                            #endif
                        #endif

                        o.uv1.zw = CustomTransformTex(o.uv1.zw, _Effect3Tex_ST);
                        o.Glowcolor1.z = _Effect3UseGlow ? cos((effectTime3 * _Effect3GlowSpeed)) * 0.5 + 0.5 : 1;
                    #endif
                #endif
                //

                //Effect 4
                #if _EFFECT4_ON
                    float effectTime4 = _Time.g + _Effect4TimingOffset;
                    effectTime4 *= -1;

                    o.uv2.xy = _Effect4WorldUV ? o.worldPosition : v.texcoord1.xy;
                    o.uv2.xy = _Effect4UniformUV ? ScaleUV(o.uv2.xy, 1, rectAspect) : ScaleUV(o.uv2.xy, 1);

                    #if defined(_EFFECT4USEMASK_ON) && defined(_EFFECT4USETIMEROFFSETMASK_ON)
                    //////
                    #else
                        #if _EFFECT4USEDIRECTIONALSCROLL_ON
                            #if _EFFECT4USEROTATE_ON
                                #if _EFFECT4USEROTATECURVE_ON
                                o.uv2.xy = ComputeRotateCurveUV(_Effect4Tex, _Effect4Tex_ST, o.uv2.xy, _Effect4RotateCurve);
                                #else
                                o.uv2.xy = ComputeRotateUV(_Effect4Tex, _Effect4Tex_ST, o.uv2.xy, _Effect4RotateSpeed, _Effect4RotateAngle, effectTime4);
                                #endif
                            #endif
                            #if _EFFECT4USESCROLL_ON
                                #if _EFFECT4USESCROLLCURVE_ON
                                o.uv2.xy = o.uv2.xy - (_Effect4ScrollCurve * (0.5 + _Effect4ScaleOrigin));
                                #else
                                o.uv2.xy = ComputeScrollUV(o.uv2.xy, _Effect4VerticalSpeed, _Effect4HorizontalSpeed, _Effect4ScaleOrigin, effectTime4);
                                #endif
                            #endif
                        #else
                            #if _EFFECT4USESCROLL_ON
                                #if _EFFECT4USESCROLLCURVE_ON
                                 o.uv2.xy = o.uv2.xy - (_Effect4ScrollCurve * (0.5+_Effect4ScaleOrigin));
                                #else
                                o.uv2.xy = ComputeScrollUV(o.uv2.xy, _Effect4VerticalSpeed, _Effect4HorizontalSpeed, _Effect4ScaleOrigin, effectTime4);
                                #endif
                            #endif
                            #if _EFFECT4USEROTATE_ON
                                #if _EFFECT4USEROTATECURVE_ON
                                o.uv2.xy = ComputeRotateCurveUV(_Effect4Tex, _Effect4Tex_ST, o.uv2.xy, _Effect4RotateCurve);
                                #else
                                o.uv2.xy = ComputeRotateUV(_Effect4Tex, _Effect4Tex_ST, o.uv2.xy, _Effect4RotateSpeed, _Effect4RotateAngle, effectTime4);
                                #endif
                            #endif
                        #endif

                        o.uv2.xy = CustomTransformTex(o.uv2.xy, _Effect4Tex_ST);
                        o.Glowcolor1.w = _Effect4UseGlow ? cos((effectTime4 * _Effect4GlowSpeed)) * 0.5 + 0.5 : 1;
                    #endif
                #endif
                //

                //Effect 5
                #if _EFFECT5_ON
                    float effectTime5 = _Time.g + _Effect5TimingOffset;
                    effectTime5 *= -1;

                    o.uv2.zw = _Effect5WorldUV ? o.worldPosition : v.texcoord1.xy;
                    o.uv2.zw = _Effect5UniformUV ? ScaleUV(o.uv2.zw, 1, rectAspect) : ScaleUV(o.uv2.zw, 1);

                    #if defined(_EFFECT5USEMASK_ON) && defined(_EFFECT5USETIMEROFFSETMASK_ON)
                    //////
                    #else
                        #if _EFFECT5USEDIRECTIONALSCROLL_ON
                            #if _EFFECT5USEROTATE_ON
                                #if _EFFECT5USEROTATECURVE_ON
                                o.uv2.zw = ComputeRotateCurveUV(_Effect5Tex, _Effect5Tex_ST, o.uv2.zw, _Effect5RotateCurve);
                                #else
                                o.uv2.zw = ComputeRotateUV(_Effect5Tex, _Effect5Tex_ST, o.uv2.zw, _Effect5RotateSpeed, _Effect5RotateAngle, effectTime5);
                                #endif
                            #endif
                            #if _EFFECT5USESCROLL_ON
                                #if _EFFECT5USESCROLLCURVE_ON
                                o.uv2.zw = o.uv2.zw - (_Effect5ScrollCurve * (0.5 + _Effect5ScaleOrigin));
                                #else
                                o.uv2.zw = ComputeScrollUV(o.uv2.zw, _Effect5VerticalSpeed, _Effect5HorizontalSpeed, _Effect5ScaleOrigin, effectTime5);
                                #endif
                            #endif
                        #else
                            #if _EFFECT5USESCROLL_ON
                                #if _EFFECT5USESCROLLCURVE_ON
                                o.uv2.zw = o.uv2.zw - (_Effect5ScrollCurve * (0.5 + _Effect5ScaleOrigin));
                                #else
                                o.uv2.zw = ComputeScrollUV(o.uv2.zw, _Effect5VerticalSpeed, _Effect5HorizontalSpeed, _Effect5ScaleOrigin, effectTime5);
                                #endif
                            #endif
                            #if _EFFECT5USEROTATE_ON
                                #if _EFFECT5USEROTATECURVE_ON
                                o.uv2.zw = ComputeRotateCurveUV(_Effect5Tex, _Effect5Tex_ST, o.uv2.zw, _Effect5RotateCurve);
                                #else
                                o.uv2.zw = ComputeRotateUV(_Effect5Tex, _Effect5Tex_ST, o.uv2.zw, _Effect5RotateSpeed, _Effect5RotateAngle, effectTime5);
                                #endif
                            #endif
                        #endif

                        o.uv2.zw = CustomTransformTex(o.uv2.zw, _Effect5Tex_ST);
                        o.Glowcolor2.x = _Effect5UseGlow ? cos((effectTime5 * _Effect5GlowSpeed)) * 0.5 + 0.5 : 1;
                    #endif
                #endif
                //

                //Effect 6
                #if _EFFECT6_ON
                    float effectTime6 = _Time.g + _Effect6TimingOffset;
                    effectTime6 *= -1;

                    o.uv3.xy = _Effect6WorldUV ? o.worldPosition : v.texcoord1.xy;
                    o.uv3.xy = _Effect6UniformUV ? ScaleUV(o.uv3.xy, 1, rectAspect): ScaleUV(o.uv3.xy, 1);

                    #if defined(_EFFECT6USEMASK_ON) && defined(_EFFECT6USETIMEROFFSETMASK_ON)
                    //////
                    #else
                        #if _EFFECT6USEDIRECTIONALSCROLL_ON
                            #if _EFFECT6USEROTATE_ON
                                #if _EFFECT6USEROTATECURVE_ON
                                o.uv3.xy = ComputeRotateCurveUV(_Effect6Tex, _Effect6Tex_ST, o.uv3.xy, _Effect6RotateCurve);
                                #else
                                o.uv3.xy = ComputeRotateUV(_Effect6Tex, _Effect6Tex_ST, o.uv3.xy, _Effect6RotateSpeed, _Effect6RotateAngle, effectTime6);
                                #endif
                            #endif
                            #if _EFFECT6USESCROLL_ON
                                #if _EFFECT6USESCROLLCURVE_ON
                                o.uv3.xy = o.uv3.xy - (_Effect6ScrollCurve * (0.5 + _Effect6ScaleOrigin));
                                #else
                                o.uv3.xy = ComputeScrollUV(o.uv3.xy, _Effect6VerticalSpeed, _Effect6HorizontalSpeed, _Effect6ScaleOrigin, effectTime6);
                                #endif
                            #endif
                        #else
                            #if _EFFECT6USESCROLL_ON
                                #if _EFFECT6USESCROLLCURVE_ON
                                o.uv3.xy = o.uv3.xy - (_Effect6ScrollCurve * (0.5 + _Effect6ScaleOrigin));
                                #else
                                o.uv3.xy = ComputeScrollUV(o.uv3.xy, _Effect6VerticalSpeed, _Effect6HorizontalSpeed, _Effect6ScaleOrigin, effectTime6);
                                #endif
                            #endif
                            #if _EFFECT6USEROTATE_ON
                                #if _EFFECT6USEROTATECURVE_ON
                                o.uv3.xy = ComputeRotateCurveUV(_Effect6Tex, _Effect6Tex_ST, o.uv3.xy, _Effect6RotateCurve);
                                #else
                                o.uv3.xy = ComputeRotateUV(_Effect6Tex, _Effect6Tex_ST, o.uv3.xy, _Effect6RotateSpeed, _Effect6RotateAngle, effectTime6);
                                #endif
                            #endif
                        #endif

                        o.uv3.xy = CustomTransformTex(o.uv3.xy, _Effect6Tex_ST);
                        o.Glowcolor2.y = _Effect6UseGlow ? cos((effectTime6 * _Effect6GlowSpeed)) * 0.5 + 0.5 : 1;
                    #endif
                #endif
                //
                return o;
            }


            float RandomRange_float(float Seed, float Min, float Max)
            {
                float randomno = frac(sin(dot(Seed, 12.9898)) * 43758.5453);
                return lerp(Min, Max, randomno);
            }

            float2 RandomRotateInterval(float2 uv, float randomseed, float interval, float timeOffset, float angleOffset)
            {
                float seed = floor(fmod((randomseed - timeOffset / interval) * interval, 360));
                float rotateAngle = RandomRange_float(seed, 0, 360) + angleOffset;
                fixed rotate_cos = cos(rotateAngle);
                fixed rotate_sin = sin(rotateAngle);
                fixed2 rotate_piv = fixed2(0.5, 0.5);
                return mul(uv - rotate_piv, fixed2x2(rotate_cos, -rotate_sin, rotate_sin, rotate_cos)) + rotate_piv;
            }

            //ScaleFlowTex
            fixed4 ScaleFlowTex(sampler2D tex, inout float2 uv, float scaleMultiplier, float scaleOrigin, float scaleSpeed, float timingOffset) {
                float effectTime = _Time.g + timingOffset;
                scaleMultiplier = scaleOrigin * scaleMultiplier;
                float effect1Scale1 = lerp(scaleOrigin, scaleMultiplier, frac(effectTime * scaleSpeed));
                float effect1Scale2 = lerp(scaleOrigin, scaleMultiplier, frac((effectTime - min(100, 0.5 / scaleSpeed)) * scaleSpeed));  //scaleSpeed가 0일때 0으로 나누기 대책
                float2 flowUV1 = ScaleUV(uv, max(0.05, effect1Scale1));
                float2 flowUV2 = ScaleUV(uv, max(0.05, effect1Scale2));
                fixed4 texflow1 = tex2D(tex, flowUV1);
                fixed4 texflow2 = tex2D(tex, flowUV2);
                texflow1.rgb *= texflow1.a;
                texflow2.rgb *= texflow2.a;
                float lerpVal = abs(frac(effectTime * scaleSpeed) * 2 - 1);
                return lerp(texflow1, texflow2, lerpVal);
            }

            //ScaleFlowTex RandomRotate 
            fixed4 ScaleFlowTexRandomRotate(sampler2D tex, inout float2 uv, float scaleMultiplier, float scaleOrigin, float scaleSpeed, float timingOffset) {
                float effectTime = _Time.g + timingOffset;
                scaleMultiplier = scaleOrigin * scaleMultiplier;
                float effect1Scale1 = lerp(scaleOrigin, scaleMultiplier, frac(effectTime * scaleSpeed));
                float effect1Scale2 = lerp(scaleOrigin, scaleMultiplier, frac((effectTime - min(100, 0.5 / scaleSpeed)) * scaleSpeed));  //scaleSpeed가 0일때 0으로 나누기 대책
                float2 flowUV1 = ScaleUV(uv, max(0.05, effect1Scale1));
                float2 flowUV2 = ScaleUV(uv, max(0.05, effect1Scale2));
                flowUV1 = RandomRotateInterval(flowUV1, effectTime, scaleSpeed, 0, 0);
                flowUV2 = RandomRotateInterval(flowUV2, effectTime, scaleSpeed, 0.5, 180);
                fixed4 texflow1 = tex2D(tex, flowUV1);
                fixed4 texflow2 = tex2D(tex, flowUV2);
                texflow1.rgb *= texflow1.a;
                texflow2.rgb *= texflow2.a;
                float lerpVal = abs(frac(effectTime * scaleSpeed) * 2 - 1);
                return lerp(texflow1, texflow2, lerpVal);
            }

            //ScaleFlowTex Timing Mask 
            fixed4 ScaleFlowTex(sampler2D tex, float2 uv, float scaleMultiplier, float scaleOrigin, float scaleSpeed, float timingOffset, sampler2D MaskTex, float4 timerMaskVal) {
                float effectTime = _Time.g + timingOffset;
                scaleMultiplier = scaleOrigin * scaleMultiplier;
                float effect1Scale1 = lerp(scaleOrigin, scaleMultiplier, frac(effectTime * scaleSpeed));
                float effect1Scale2 = lerp(scaleOrigin, scaleMultiplier, frac((effectTime - min(100, 0.5 / scaleSpeed)) * scaleSpeed));  //scaleSpeed가 0일때 0으로 나누기 대책
                float2 flowUV1 = ScaleUV(uv, max(0.05, effect1Scale1));
                float2 flowUV2 = ScaleUV(uv, max(0.05, effect1Scale2));
                fixed4 texflow1 = tex2D(tex, flowUV1);
                fixed4 texflow2 = tex2D(tex, flowUV2);
                texflow1.rgb *= texflow1.a;
                texflow2.rgb *= texflow2.a;
                float lerpVal = abs(frac(effectTime * scaleSpeed) * 2 - 1);

                fixed2 MaskTexFlow1 = tex2D(MaskTex, flowUV1).ba;
                fixed2 MaskTexFlow2 = tex2D(MaskTex, flowUV2).ba;
                MaskTexFlow1.g *= 0.7777777;
                MaskTexFlow2.g *= 0.7777777;
                float time1 = frac(MaskTexFlow1.g * (timerMaskVal.a) * effectTime + MaskTexFlow1.r);
                float time2 = frac(MaskTexFlow2.g * (timerMaskVal.a) * (effectTime + timerMaskVal.a * 0.5) + MaskTexFlow2.r);
                fixed timingMask1 = smoothstep(timerMaskVal.r, timerMaskVal.r + timerMaskVal.b, time1)
                    * smoothstep(timerMaskVal.g, timerMaskVal.g - timerMaskVal.b, time1);
                fixed timingMask2 = smoothstep(timerMaskVal.r, timerMaskVal.r + timerMaskVal.b, time2)
                    * smoothstep(timerMaskVal.g, timerMaskVal.g - timerMaskVal.b, time2);
                texflow1 *= timingMask1;
                texflow2 *= timingMask2;

                return lerp(texflow1, texflow2, lerpVal);
            }

            //ScaleFlowTex RandomRotate Timing Mask 
            fixed4 ScaleFlowTexRandomRotate(sampler2D tex, float2 uv, float scaleMultiplier, float scaleOrigin, float scaleSpeed, float timingOffset, sampler2D MaskTex, float4 timerMaskVal) {
                float effectTime = _Time.g + timingOffset;
                scaleMultiplier = scaleOrigin * scaleMultiplier;
                float effect1Scale1 = lerp(scaleOrigin, scaleMultiplier, frac(effectTime * scaleSpeed));
                float effect1Scale2 = lerp(scaleOrigin, scaleMultiplier, frac((effectTime - min(100, 0.5 / scaleSpeed)) * scaleSpeed));  //scaleSpeed가 0일때 0으로 나누기 대책
                float2 flowUV1 = ScaleUV(uv, max(0.05, effect1Scale1));
                float2 flowUV2 = ScaleUV(uv, max(0.05, effect1Scale2));
                flowUV1 = RandomRotateInterval(flowUV1, effectTime, scaleSpeed,0, 0);
                flowUV2 = RandomRotateInterval(flowUV2, effectTime, scaleSpeed,0.5, 180);
                fixed4 texflow1 = tex2D(tex, flowUV1);
                fixed4 texflow2 = tex2D(tex, flowUV2);
                texflow1.rgb *= texflow1.a;
                texflow2.rgb *= texflow2.a;
                float lerpVal = abs(frac(effectTime * scaleSpeed) * 2 - 1);

                fixed2 MaskTexFlow1 = tex2D(MaskTex, flowUV1).ba;
                fixed2 MaskTexFlow2 = tex2D(MaskTex, flowUV2).ba;
                MaskTexFlow1.g *= 0.7777777;
                MaskTexFlow2.g *= 0.7777777;
                float time1 = frac(MaskTexFlow1.g * (timerMaskVal.a) * effectTime + MaskTexFlow1.r);
                float time2 = frac(MaskTexFlow2.g * (timerMaskVal.a) * (effectTime + timerMaskVal.a * 0.5) + MaskTexFlow2.r);
                fixed timingMask1 = smoothstep(timerMaskVal.r, timerMaskVal.r + timerMaskVal.b, time1)
                    * smoothstep(timerMaskVal.g, timerMaskVal.g - timerMaskVal.b, time1);
                fixed timingMask2 = smoothstep(timerMaskVal.r, timerMaskVal.r + timerMaskVal.b, time2)
                    * smoothstep(timerMaskVal.g, timerMaskVal.g - timerMaskVal.b, time2);
                texflow1 *= timingMask1;
                texflow2 *= timingMask2;

                return lerp(texflow1, texflow2, lerpVal);
            }

            fixed4 ScalePIngPongTex(sampler2D tex, inout float2 uv, float scaleMultiplier, float scaleOrigin, float scaleSpeed, float timingOffset) {
                float effectTime = (cos(_Time.g * scaleSpeed + timingOffset)+1)/2;
                scaleMultiplier = scaleOrigin * scaleMultiplier;
                float effect1Scale = lerp(scaleOrigin, scaleMultiplier, effectTime);
                uv = ScaleUV(uv, max(0.05, effect1Scale));
                fixed4 texVal = tex2D(tex, uv);
                texVal.rgb *= texVal.a;
                return texVal;
            }

            fixed4 ScaleCurveTex(sampler2D tex, inout float2 uv, float scaleOrigin, float scaleSpeed, float animCurveVal) {
                uv = ScaleUV(uv, max(0.05,animCurveVal* scaleOrigin)* scaleSpeed);
                fixed4 texVal = tex2D(tex, uv);
                texVal.rgb *= texVal.a;
                return texVal;
            }

            /////////------------------FlipBook Variation------------------/////////
            float2 FlipBookUV(inout float2 UV, float4 FlipbookValue, bool UseFlipbook = true)//float Width, float Height, float Tile)
            {
                float Width = FlipbookValue.x;
                float Height = FlipbookValue.y;
                float Tile = FlipbookValue.z;
                Tile += floor(_Time.g * FlipbookValue.w);
                Tile = floor(fmod(Tile + float(0.00001), Width * Height));
                float2 tileCount = float2(1.0, 1.0) / float2(Width, Height);
                float base = floor((Tile + float(0.5)) * tileCount.x);
                float tileX = (Tile - Width * base);
                float tileY = (Height - (base + 1));
                return lerp(UV, (UV + float2(tileX, tileY)) * tileCount, UseFlipbook);
            }

            fixed4 FlipBookBlending(inout fixed4 targetColor, sampler2D tex, float2 uv, float4 flipBookValue, fixed blendVal) {
                flipBookValue.z += 1;
                uv = FlipBookUV(uv, flipBookValue);
                fixed4 blendColor = tex2D(tex, uv);
                blendColor.rgb *= blendColor.a;
                return targetColor = lerp(targetColor, blendColor, blendVal);
            }

            //ScaleFlow
            fixed4 ScaleFlowTex(sampler2D tex, inout float2 uv, float scaleMultiplier, float scaleOrigin, float scaleSpeed, float timingOffset, float4 flipBookValue) {
                float effectTime = _Time.g + timingOffset;
                scaleMultiplier = scaleOrigin * scaleMultiplier;
                float effect1Scale1 = lerp(scaleOrigin, scaleMultiplier, frac(effectTime * scaleSpeed));
                float effect1Scale2 = lerp(scaleOrigin, scaleMultiplier, frac((effectTime - min(100, 0.5 / scaleSpeed)) * scaleSpeed));  //scaleSpeed가 0일때 0으로 나누기 대책
                float2 flowUV1 = ScaleUV(uv, max(0.05, effect1Scale1));
                float2 flowUV2 = ScaleUV(uv, max(0.05, effect1Scale2));
                float2 flowUVFlip1 = FlipBookUV(flowUV1, flipBookValue);
                float2 flowUVFlip2 = FlipBookUV(flowUV2, flipBookValue);
                fixed4 texflow1 = tex2D(tex, flowUVFlip1);
                fixed4 texflow2 = tex2D(tex, flowUVFlip2);
                texflow1.rgb *= texflow1.a;
                texflow2.rgb *= texflow2.a;
                float lerpVal = abs(frac(effectTime * scaleSpeed) * 2 - 1);
                return lerp(texflow1, texflow2, lerpVal);
            }

            //ScaleFlow Blend
            fixed4 ScaleFlowTexBlend(sampler2D tex, inout float2 uv, float scaleMultiplier, float scaleOrigin, float scaleSpeed, float timingOffset, float4 flipBookValue) {
                float effectTime = _Time.g + timingOffset;
                scaleMultiplier = scaleOrigin * scaleMultiplier;
                float effect1Scale1 = lerp(scaleOrigin, scaleMultiplier, frac(effectTime * scaleSpeed));
                float effect1Scale2 = lerp(scaleOrigin, scaleMultiplier, frac((effectTime - min(100, 0.5 / scaleSpeed)) * scaleSpeed));  //scaleSpeed가 0일때 0으로 나누기 대책
                float2 flowUV1 = ScaleUV(uv, max(0.05, effect1Scale1));
                float2 flowUV2 = ScaleUV(uv, max(0.05, effect1Scale2));
                float2 flowUVFlip1 = FlipBookUV(flowUV1, flipBookValue);
                float2 flowUVFlip2 = FlipBookUV(flowUV2, flipBookValue);
                fixed4 texflow1 = tex2D(tex, flowUVFlip1);
                fixed4 texflow2 = tex2D(tex, flowUVFlip2);
                texflow1.rgb *= texflow1.a;
                texflow2.rgb *= texflow2.a;
                fixed blendVal = frac(fmod((_Time.g * flipBookValue.w) + float(0.00001), flipBookValue.x * flipBookValue.y));
                texflow1 = FlipBookBlending(texflow1, tex, flowUV1, flipBookValue, blendVal);
                texflow2 = FlipBookBlending(texflow2, tex, flowUV2, flipBookValue, blendVal);
                float lerpVal = abs(frac(effectTime * scaleSpeed) * 2 - 1);
                return lerp(texflow1, texflow2, lerpVal);
            }

            //ScaleFlow Random Rotate
            fixed4 ScaleFlowTexRandomRotate(sampler2D tex, inout float2 uv, float scaleMultiplier, float scaleOrigin, float scaleSpeed, float timingOffset, float4 flipBookValue) {
                float effectTime = _Time.g + timingOffset;
                scaleMultiplier = scaleOrigin * scaleMultiplier;
                float effect1Scale1 = lerp(scaleOrigin, scaleMultiplier, frac(effectTime * scaleSpeed));
                float effect1Scale2 = lerp(scaleOrigin, scaleMultiplier, frac((effectTime - min(100, 0.5 / scaleSpeed)) * scaleSpeed));  //scaleSpeed가 0일때 0으로 나누기 대책
                float2 flowUV1 = ScaleUV(uv, max(0.05, effect1Scale1));
                float2 flowUV2 = ScaleUV(uv, max(0.05, effect1Scale2));
                flowUV1 = RandomRotateInterval(flowUV1, effectTime, scaleSpeed, 0, 0);
                flowUV2 = RandomRotateInterval(flowUV2, effectTime, scaleSpeed, 0.5, 180);
                flowUV1 = FlipBookUV(flowUV1, flipBookValue);
                flowUV2 = FlipBookUV(flowUV2, flipBookValue);
                fixed4 texflow1 = tex2D(tex, flowUV1);
                fixed4 texflow2 = tex2D(tex, flowUV2);
                texflow1.rgb *= texflow1.a;
                texflow2.rgb *= texflow2.a;
                float lerpVal = abs(frac(effectTime * scaleSpeed) * 2 - 1);
                return lerp(texflow1, texflow2, lerpVal);
            }

            //ScaleFlow Random Rotate Blend
            fixed4 ScaleFlowTexRandomRotateBlend(sampler2D tex, inout float2 uv, float scaleMultiplier, float scaleOrigin, float scaleSpeed, float timingOffset, float4 flipBookValue) {
                float effectTime = _Time.g + timingOffset;
                scaleMultiplier = scaleOrigin * scaleMultiplier;
                float effect1Scale1 = lerp(scaleOrigin, scaleMultiplier, frac(effectTime * scaleSpeed));
                float effect1Scale2 = lerp(scaleOrigin, scaleMultiplier, frac((effectTime - min(100, 0.5 / scaleSpeed)) * scaleSpeed));  //scaleSpeed가 0일때 0으로 나누기 대책
                float2 flowUV1 = ScaleUV(uv, max(0.05, effect1Scale1));
                float2 flowUV2 = ScaleUV(uv, max(0.05, effect1Scale2));
                flowUV1 = RandomRotateInterval(flowUV1, effectTime, scaleSpeed, 0, 0);
                flowUV2 = RandomRotateInterval(flowUV2, effectTime, scaleSpeed, 0.5, 180);
                float2 flowUVFlip1 = FlipBookUV(flowUV1, flipBookValue);
                float2 flowUVFlip2 = FlipBookUV(flowUV2, flipBookValue);
                fixed4 texflow1 = tex2D(tex, flowUVFlip1);
                fixed4 texflow2 = tex2D(tex, flowUVFlip2);
                texflow1.rgb *= texflow1.a;
                texflow2.rgb *= texflow2.a;
                fixed blendVal = frac(fmod((_Time.g * flipBookValue.w) + float(0.00001), flipBookValue.x * flipBookValue.y));
                texflow1 = FlipBookBlending(texflow1, tex, flowUV1, flipBookValue, blendVal);
                texflow2 = FlipBookBlending(texflow2, tex, flowUV2, flipBookValue, blendVal);
                float lerpVal = abs(frac(effectTime * scaleSpeed) * 2 - 1);
                return lerp(texflow1, texflow2, lerpVal);
            }

            //ScaleFlow Timing Mask
            fixed4 ScaleFlowTex(sampler2D tex, inout float2 uv, float scaleMultiplier, float scaleOrigin, float scaleSpeed, float timingOffset, sampler2D MaskTex, float4 timerMaskVal, float4 flipBookValue) {
                float effectTime = _Time.g + timingOffset;
                scaleMultiplier = scaleOrigin * scaleMultiplier;
                float effect1Scale1 = lerp(scaleOrigin, scaleMultiplier, frac(effectTime * scaleSpeed));
                float effect1Scale2 = lerp(scaleOrigin, scaleMultiplier, frac((effectTime - min(100, 0.5 / scaleSpeed)) * scaleSpeed));  //scaleSpeed가 0일때 0으로 나누기 대책
                float2 flowUV1 = ScaleUV(uv, max(0.05, effect1Scale1));
                float2 flowUV2 = ScaleUV(uv, max(0.05, effect1Scale2));

                flowUV1 = FlipBookUV(flowUV1, flipBookValue);
                flowUV2 = FlipBookUV(flowUV2, flipBookValue);

                fixed4 texflow1 = tex2D(tex, flowUV1);
                fixed4 texflow2 = tex2D(tex, flowUV2);
                texflow1.rgb *= texflow1.a;
                texflow2.rgb *= texflow2.a;
                float lerpVal = abs(frac(effectTime * scaleSpeed) * 2 - 1);

                fixed2 MaskTexFlow1 = tex2D(MaskTex, flowUV1).ba;
                fixed2 MaskTexFlow2 = tex2D(MaskTex, flowUV2).ba;
                MaskTexFlow1.g *= 0.7777777;
                MaskTexFlow2.g *= 0.7777777;
                float time1 = frac(MaskTexFlow1.g * (timerMaskVal.a) * effectTime + MaskTexFlow1.r);
                float time2 = frac(MaskTexFlow2.g * (timerMaskVal.a) * (effectTime + timerMaskVal.a * 0.5) + MaskTexFlow2.r);
                fixed timingMask1 = smoothstep(timerMaskVal.r, timerMaskVal.r + timerMaskVal.b, time1)
                    * smoothstep(timerMaskVal.g, timerMaskVal.g - timerMaskVal.b, time1);
                fixed timingMask2 = smoothstep(timerMaskVal.r, timerMaskVal.r + timerMaskVal.b, time2)
                    * smoothstep(timerMaskVal.g, timerMaskVal.g - timerMaskVal.b, time2);
                texflow1 *= timingMask1;
                texflow2 *= timingMask2;
                return lerp(texflow1, texflow2, lerpVal);
            }

            //ScaleFlow Timing Mask Blend
            fixed4 ScaleFlowTexBlend(sampler2D tex, inout float2 uv, float scaleMultiplier, float scaleOrigin, float scaleSpeed, float timingOffset, sampler2D MaskTex, float4 timerMaskVal, float4 flipBookValue) {
                float effectTime = _Time.g + timingOffset;
                scaleMultiplier = scaleOrigin * scaleMultiplier;
                float effect1Scale1 = lerp(scaleOrigin, scaleMultiplier, frac(effectTime * scaleSpeed));
                float effect1Scale2 = lerp(scaleOrigin, scaleMultiplier, frac((effectTime - min(100, 0.5 / scaleSpeed)) * scaleSpeed));  //scaleSpeed가 0일때 0으로 나누기 대책
                float2 flowUV1 = ScaleUV(uv, max(0.05, effect1Scale1));
                float2 flowUV2 = ScaleUV(uv, max(0.05, effect1Scale2));
                float2 flowUVFlip1 = FlipBookUV(flowUV1, flipBookValue);
                float2 flowUVFlip2 = FlipBookUV(flowUV2, flipBookValue);
                fixed4 texflow1 = tex2D(tex, flowUVFlip1);
                fixed4 texflow2 = tex2D(tex, flowUVFlip2);
                texflow1.rgb *= texflow1.a;
                texflow2.rgb *= texflow2.a;
                fixed blendVal = frac(fmod((_Time.g * flipBookValue.w) + float(0.00001), flipBookValue.x * flipBookValue.y));
                texflow1 = FlipBookBlending(texflow1, tex, flowUV1, flipBookValue, blendVal);
                texflow2 = FlipBookBlending(texflow2, tex, flowUV2, flipBookValue, blendVal);
                float lerpVal = abs(frac(effectTime * scaleSpeed) * 2 - 1);

                fixed2 MaskTexFlow1 = tex2D(MaskTex, flowUV1).ba;
                fixed2 MaskTexFlow2 = tex2D(MaskTex, flowUV2).ba;
                MaskTexFlow1.g *= 0.7777777;
                MaskTexFlow2.g *= 0.7777777;
                float time1 = frac(MaskTexFlow1.g * (timerMaskVal.a) * effectTime + MaskTexFlow1.r);
                float time2 = frac(MaskTexFlow2.g * (timerMaskVal.a) * (effectTime + timerMaskVal.a * 0.5) + MaskTexFlow2.r);
                fixed timingMask1 = smoothstep(timerMaskVal.r, timerMaskVal.r + timerMaskVal.b, time1)
                    * smoothstep(timerMaskVal.g, timerMaskVal.g - timerMaskVal.b, time1);
                fixed timingMask2 = smoothstep(timerMaskVal.r, timerMaskVal.r + timerMaskVal.b, time2)
                    * smoothstep(timerMaskVal.g, timerMaskVal.g - timerMaskVal.b, time2);
                texflow1 *= timingMask1;
                texflow2 *= timingMask2;
                return lerp(texflow1, texflow2, lerpVal);
            }

            //ScaleFlow Random Rotate Timing Mask
            fixed4 ScaleFlowTexRandomRotate(sampler2D tex, inout float2 uv, float scaleMultiplier, float scaleOrigin, float scaleSpeed, float timingOffset, sampler2D MaskTex, float4 timerMaskVal, float4 flipBookValue) {
                float effectTime = _Time.g + timingOffset;
                scaleMultiplier = scaleOrigin * scaleMultiplier;
                float effect1Scale1 = lerp(scaleOrigin, scaleMultiplier, frac(effectTime * scaleSpeed));
                float effect1Scale2 = lerp(scaleOrigin, scaleMultiplier, frac((effectTime - min(100, 0.5 / scaleSpeed)) * scaleSpeed));  //scaleSpeed가 0일때 0으로 나누기 대책
                float2 flowUV1 = ScaleUV(uv, max(0.05, effect1Scale1));
                float2 flowUV2 = ScaleUV(uv, max(0.05, effect1Scale2));

                flowUV1 = RandomRotateInterval(flowUV1, effectTime, scaleSpeed, 0, 0);
                flowUV2 = RandomRotateInterval(flowUV2, effectTime, scaleSpeed, 0.5, 180);

                flowUV1 = FlipBookUV(flowUV1, flipBookValue);
                flowUV2 = FlipBookUV(flowUV2, flipBookValue);

                fixed4 texflow1 = tex2D(tex, flowUV1);
                fixed4 texflow2 = tex2D(tex, flowUV2);
                texflow1.rgb *= texflow1.a;
                texflow2.rgb *= texflow2.a;
                float lerpVal = abs(frac(effectTime * scaleSpeed) * 2 - 1);

                fixed2 MaskTexFlow1 = tex2D(MaskTex, flowUV1).ba;
                fixed2 MaskTexFlow2 = tex2D(MaskTex, flowUV2).ba;
                MaskTexFlow1.g *= 0.7777777;
                MaskTexFlow2.g *= 0.7777777;
                float time1 = frac(MaskTexFlow1.g * (timerMaskVal.a) * effectTime + MaskTexFlow1.r);
                float time2 = frac(MaskTexFlow2.g * (timerMaskVal.a) * (effectTime + timerMaskVal.a * 0.5) + MaskTexFlow2.r);
                fixed timingMask1 = smoothstep(timerMaskVal.r, timerMaskVal.r + timerMaskVal.b, time1)
                    * smoothstep(timerMaskVal.g, timerMaskVal.g - timerMaskVal.b, time1);
                fixed timingMask2 = smoothstep(timerMaskVal.r, timerMaskVal.r + timerMaskVal.b, time2)
                    * smoothstep(timerMaskVal.g, timerMaskVal.g - timerMaskVal.b, time2);
                texflow1 *= timingMask1;
                texflow2 *= timingMask2;
                return lerp(texflow1, texflow2, lerpVal);
            }

            //ScaleFlow Random Rotate Timing Mask Blend
            fixed4 ScaleFlowTexRandomRotateBlend(sampler2D tex, inout float2 uv, float scaleMultiplier, float scaleOrigin, float scaleSpeed, float timingOffset, sampler2D MaskTex, float4 timerMaskVal, float4 flipBookValue) {
                float effectTime = _Time.g + timingOffset;
                scaleMultiplier = scaleOrigin * scaleMultiplier;
                float effect1Scale1 = lerp(scaleOrigin, scaleMultiplier, frac(effectTime * scaleSpeed));
                float effect1Scale2 = lerp(scaleOrigin, scaleMultiplier, frac((effectTime - min(100, 0.5 / scaleSpeed)) * scaleSpeed));  //scaleSpeed가 0일때 0으로 나누기 대책
                float2 flowUV1 = ScaleUV(uv, max(0.05, effect1Scale1));
                float2 flowUV2 = ScaleUV(uv, max(0.05, effect1Scale2));

                flowUV1 = RandomRotateInterval(flowUV1, effectTime, scaleSpeed, 0, 0);
                flowUV2 = RandomRotateInterval(flowUV2, effectTime, scaleSpeed, 0.5, 180);
                float2 flowUVFlip1 = FlipBookUV(flowUV1, flipBookValue);
                float2 flowUVFlip2 = FlipBookUV(flowUV2, flipBookValue);
                fixed4 texflow1 = tex2D(tex, flowUVFlip1);
                fixed4 texflow2 = tex2D(tex, flowUVFlip2);
                texflow1.rgb *= texflow1.a;
                texflow2.rgb *= texflow2.a;
                fixed blendVal = frac(fmod((_Time.g * flipBookValue.w) + float(0.00001), flipBookValue.x * flipBookValue.y));
                texflow1 = FlipBookBlending(texflow1, tex, flowUV1, flipBookValue, blendVal);
                texflow2 = FlipBookBlending(texflow2, tex, flowUV2, flipBookValue, blendVal);
                float lerpVal = abs(frac(effectTime * scaleSpeed) * 2 - 1);

                fixed2 MaskTexFlow1 = tex2D(MaskTex, flowUV1).ba;
                fixed2 MaskTexFlow2 = tex2D(MaskTex, flowUV2).ba;
                MaskTexFlow1.g *= 0.7777777;
                MaskTexFlow2.g *= 0.7777777;
                float time1 = frac(MaskTexFlow1.g * (timerMaskVal.a) * effectTime + MaskTexFlow1.r);
                float time2 = frac(MaskTexFlow2.g * (timerMaskVal.a) * (effectTime + timerMaskVal.a * 0.5) + MaskTexFlow2.r);
                fixed timingMask1 = smoothstep(timerMaskVal.r, timerMaskVal.r + timerMaskVal.b, time1)
                    * smoothstep(timerMaskVal.g, timerMaskVal.g - timerMaskVal.b, time1);
                fixed timingMask2 = smoothstep(timerMaskVal.r, timerMaskVal.r + timerMaskVal.b, time2)
                    * smoothstep(timerMaskVal.g, timerMaskVal.g - timerMaskVal.b, time2);
                texflow1 *= timingMask1;
                texflow2 *= timingMask2;
                return lerp(texflow1, texflow2, lerpVal);
            }

            fixed4 ScalePIngPongTex(sampler2D tex, inout float2 uv, float scaleMultiplier, float scaleOrigin, float scaleSpeed, float timingOffset, float4 flipBookValue) {
                float effectTime = (cos(_Time.g * scaleSpeed + timingOffset) + 1) / 2;
                scaleMultiplier = scaleOrigin * scaleMultiplier;
                float effect1Scale = lerp(scaleOrigin, scaleMultiplier, effectTime);
                uv = ScaleUV(uv, max(0.05, effect1Scale));

                uv = FlipBookUV(uv, flipBookValue);

                fixed4 texVal = tex2D(tex, uv);
                texVal.rgb *= texVal.a;
                return texVal;
            }

            fixed4 ScalePIngPongTexBlend(sampler2D tex, inout float2 uv, float scaleMultiplier, float scaleOrigin, float scaleSpeed, float timingOffset, float4 flipBookValue) {
                float effectTime = (cos(_Time.g * scaleSpeed + timingOffset) + 1) / 2;
                scaleMultiplier = scaleOrigin * scaleMultiplier;
                float effect1Scale = lerp(scaleOrigin, scaleMultiplier, effectTime);
                uv = ScaleUV(uv, max(0.05, effect1Scale));
                float2 uvFlip = FlipBookUV(uv, flipBookValue);
                fixed4 texVal = tex2D(tex, uvFlip);
                texVal.rgb *= texVal.a;
                fixed blendVal = frac(fmod((_Time.g * flipBookValue.w) + float(0.00001), flipBookValue.x * flipBookValue.y));
                texVal = FlipBookBlending(texVal, tex, uv, flipBookValue, blendVal);
                return texVal;
            }

            fixed4 ScaleCurveTex(sampler2D tex, inout float2 uv, float scaleOrigin, float scaleSpeed, float animCurveVal, float4 flipBookValue) {
                uv = ScaleUV(uv, max(0.05, animCurveVal * scaleOrigin) * scaleSpeed);
                uv = FlipBookUV(uv, flipBookValue);
                fixed4 texVal = tex2D(tex, uv);
                texVal.rgb *= texVal.a;
                return texVal;
            }

            fixed4 ScaleCurveTexBlend(sampler2D tex, inout float2 uv, float scaleOrigin, float scaleSpeed, float animCurveVal, float4 flipBookValue) {
                uv = ScaleUV(uv, max(0.05, animCurveVal * scaleOrigin) * scaleSpeed);
                float2 uvFlip = FlipBookUV(uv, flipBookValue);
                fixed4 texVal = tex2D(tex, uvFlip);
                texVal.rgb *= texVal.a;
                fixed blendVal = frac(fmod((_Time.g * flipBookValue.w) + float(0.00001), flipBookValue.x * flipBookValue.y));
                texVal = FlipBookBlending(texVal, tex, uv, flipBookValue, blendVal);
                return texVal;
            }

            float InverseLerp_float(float A, float B, float T)
            {
                return (T - A) / (B - A);
            }

            float remap(float val, float in1, float in2, float out1, float out2)
            {
                return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
            }

            fixed4 frag(VertexOutput i) : COLOR{
                fixed4 debug = fixed4(1,1,1,1);

                #if _USEUNSCALEDTIME_ON
                _Time.g = _ShaderUnscaledTime;
                #endif

                const half alphaPrecision = half(0xff);
                const half invAlphaPrecision = half(1.0 / alphaPrecision);
                i.vertexColor.a = round(i.vertexColor.a * alphaPrecision) * invAlphaPrecision;

                #if _BASECUTOUT_ON
                    #if _BASECUTOUTDONOTUSEALPHA_ON
                    fixed cutOutVal = 1-_BaseCutOutProgress;
                    #else
                    fixed cutOutVal = i.vertexColor.a;
                    i.vertexColor.a = 1;
                    #endif // _BASECUTOUTDONOTUSEALPHA_ON
                #endif

                fixed4 _Mask_var = tex2D(_MainTex, i.uv0.xy); // Effects Main Mask
                fixed4 _SpriteEffectMask_var = tex2D(_SpriteEffectMask, i.uv0.xy); // Secondary _SpriteEffectsMask

                #if defined(UNITY_UI_CLIP_RECT) || defined(UNITY_UI_ALPHACLIP)
                half clipRect = i.vertexColor.a * _Mask_var.a;
                #endif

                #ifdef UNITY_UI_CLIP_RECT
                half2 m = saturate((_ClipRect.zw - _ClipRect.xy - abs(i.mask.xy)) * i.mask.zw);
                clipRect *= m.x * m.y;
                #endif

                #ifdef UNITY_UI_ALPHACLIP
                clip(clipRect - 0.001);
                #endif

                fixed _SpriteLuminanceMask = smoothstep(_LuminanceMaskThresholdMin, _LuminanceMaskThresholdMax, (_Mask_var.r+ _Mask_var.g+ _Mask_var.b)/3);
                _Mask_var *= i.vertexColor;

                #if _REMOVEBASESPRITE_ON
                _Mask_var.rgb = fixed3(0, 0, 0);
                fixed finalAlpha = 0;
                #else
                    _Mask_var.rgb = _BaseSpriteGrayscale ? lerp(_Mask_var.rgb, dot(_Mask_var.rgb, float3(0.299, 0.587, 0.114)), _BaseGrayscaleValue) : _Mask_var.rgb;
                    _Mask_var.rgb = _BaseSpriteBrightness ? lerp(_Mask_var.rgb, saturate(_Mask_var.rgb * _BaseBrightnessValue), _BaseBrightnessUseLuminanceMask ? _SpriteLuminanceMask : 1) : _Mask_var.rgb;
                    _Mask_var.rgb = _BaseSpriteTintColor ? lerp(_Mask_var.rgb, _Mask_var.rgb * _BaseTintColor.rgb, (_BaseTintColorUseLuminanceMask ? _SpriteLuminanceMask : 1)) : _Mask_var.rgb;
                #endif

                fixed3 finalColor = _Mask_var;// float3(0, 0, 0);

                #if _EFFECT1_ON || _EFFECT2_ON
                    fixed2 effect2Mask = fixed2(1,1);
                #endif
                #if _EFFECT2_ON || _EFFECT3_ON
                    fixed2 effect3Mask = fixed2(1, 1);
                #endif
                #if _EFFECT3_ON || _EFFECT4_ON
                    fixed2 effect4Mask = fixed2(1, 1);
                #endif
                #if _EFFECT4_ON || _EFFECT5_ON
                    fixed2 effect5Mask = fixed2(1, 1);
                #endif
                #if _EFFECT5_ON || _EFFECT6_ON
                    fixed2 effect6Mask = fixed2(1, 1);
                #endif

                #if _EFFECT1_ON
                    fixed3 effect1Color;
                    half2 effect1MaskUV;
                    effect1MaskUV = _Effect1UseMaskUV ? i.uv4.zw : i.uv4.xy;

                    #if defined(_EFFECT1USEMASK_ON) && defined(_EFFECT1USETIMEROFFSETMASK_ON)
                        fixed2 _Effect1_TimerPreMask = tex2D(_Effect1Mask, i.uv0.zw).ba;
                        float effectTime1 = (_Time.g + _Effect1TimingOffset + _Effect1_TimerPreMask.r* _Effect1TimerMaskVal.a) *_Effect1_TimerPreMask.g;
                        effectTime1 *= -1;
                        #if _EFFECT1USEDIRECTIONALSCROLL_ON
                            #if _EFFECT1USEROTATE_ON
                                #if _EFFECT1USEROTATECURVE_ON
                                i.uv0.zw = ComputeRotateCurveUV(_Effect1Tex, _Effect1Tex_ST, i.uv0.zw, _Effect1RotateCurve);
                                #else
                                i.uv0.zw = ComputeRotateUV(_Effect1Tex, _Effect1Tex_ST, i.uv0.zw, _Effect1RotateSpeed, _Effect1RotateAngle, effectTime1);
                                #endif
                            #endif
                            #if _EFFECT1USESCROLL_ON
                                #if _EFFECT1USESCROLLCURVE_ON
                                i.uv0.zw = i.uv0.zw - (_Effect1ScrollCurve * (0.5 + _Effect1ScaleOrigin));
                                #else
                                i.uv0.zw = ComputeScrollUV(i.uv0.zw, _Effect1VerticalSpeed, _Effect1HorizontalSpeed, _Effect1ScaleOrigin, effectTime1);
                                #endif
                            #endif
                        #else
                            #if _EFFECT1USESCROLL_ON
                                #if _EFFECT1USESCROLLCURVE_ON
                                i.uv0.zw = i.uv0.zw - (_Effect1ScrollCurve * (0.5 + _Effect1ScaleOrigin));
                                #else
                                i.uv0.zw = ComputeScrollUV(i.uv0.zw, _Effect1VerticalSpeed, _Effect1HorizontalSpeed, _Effect1ScaleOrigin, effectTime1);
                                #endif
                            #endif
                            #if _EFFECT1USEROTATE_ON
                                #if _EFFECT1USEROTATECURVE_ON
                                i.uv0.zw = ComputeRotateCurveUV(_Effect1Tex, _Effect1Tex_ST, i.uv0.zw, _Effect1RotateCurve);
                                #else
                                i.uv0.zw = ComputeRotateUV(_Effect1Tex, _Effect1Tex_ST, i.uv0.zw, _Effect1RotateSpeed, _Effect1RotateAngle, effectTime1);
                                #endif
                            #endif
                        #endif

                        i.uv0.zw = CustomTransformTex(i.uv0.zw, _Effect1Tex_ST);
                        i.Glowcolor1.x = _Effect1UseGlow ? cos((effectTime1 * _Effect1GlowSpeed)) * 0.5 + 0.5 : 1;
                    #endif

                        fixed _Effect1_mask = _Effect1UseSpriteMask ? saturate(dot(_Effect1SpriteMaskValue, _SpriteEffectMask_var)) : 1;

                    #if _EFFECT1USEMASK_ON
                        fixed2 effect1MaskTex = tex2D(_Effect1Mask, effect1MaskUV).rg;
                        i.uv0.zw += _Effect1UseDistortMask ? ((effect1MaskTex.g - 0.5) * 2) * _Effect1MaskDistortStrength : 0;
                        _Effect1_mask *= effect1MaskTex.r;
                    #endif

                    #if _EFFECT1USEFLIPBOOK_ON
                        #if _EFFECT1USEFLIPBOOKBLEND_ON
                            #if _EFFECT1USESCALE_ON && _EFFECT1USESCALECURVE_ON || _EFFECT1USESCALEPINGPONG_ON && _EFFECT1USESCALECURVE_ON
                                fixed4 _Effect1_var = ScaleCurveTexBlend(_Effect1Tex, i.uv0.zw, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1ScaleCurve, _Effect1FlipbookValue);
                                #if defined(_EFFECT1USETIMERMASK_ON) && defined(_EFFECT1USEMASK_ON)	
                                    half2 effect1TimerMaskUV;
                                    effect1TimerMaskUV = _Effect1UseTimerMaskBaseUV ? effect1MaskUV : i.uv0.zw;
                              	    fixed2 _Effect1_TimerMask = tex2D(_Effect1Mask, effect1TimerMaskUV).ba;
                                #endif
                            #elif _EFFECT1USESCALE_ON
                                #if defined(_EFFECT1USETIMERMASK_ON) && defined(_EFFECT1USEMASK_ON)
                                    #if _EFFECT1RANDOMROTATE_ON
                                    fixed4 _Effect1_var = ScaleFlowTexRandomRotateBlend(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultiplier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset, _Effect1Mask, _Effect1TimerMaskVal, _Effect1FlipbookValue);
                                    #else
                                    fixed4 _Effect1_var = ScaleFlowTexBlend(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultiplier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset, _Effect1Mask, _Effect1TimerMaskVal, _Effect1FlipbookValue);
                                    #endif
                                #else
                                    #if _EFFECT1RANDOMROTATE_ON
                                    fixed4 _Effect1_var = ScaleFlowTexRandomRotateBlend(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultiplier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset, _Effect1FlipbookValue);
                                    #else
                                    fixed4 _Effect1_var = ScaleFlowTexBlend(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultiplier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset, _Effect1FlipbookValue);
                                    #endif
                                #endif
                            #elif _EFFECT1USESCALEPINGPONG_ON
                                fixed4 _Effect1_var = ScalePIngPongTexBlend(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultiplier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset, _Effect1FlipbookValue);
                                #if defined(_EFFECT1USETIMERMASK_ON) && defined(_EFFECT1USEMASK_ON)	
                                    half2 effect1TimerMaskUV;
                                    effect1TimerMaskUV = _Effect1UseTimerMaskBaseUV ? effect1MaskUV : i.uv0.zw;
                            	    fixed2 _Effect1_TimerMask = tex2D(_Effect1Mask, effect1TimerMaskUV).ba;
                                #endif
                            #else
                                i.uv0.zw = ScaleUV(i.uv0.zw, _Effect1ScaleOrigin);
                                float2 _Effect1FlipbookBlendUV = i.uv0.zw;
                                i.uv0.zw = FlipBookUV(i.uv0.zw, _Effect1FlipbookValue);
                                fixed4 _Effect1_var = tex2D(_Effect1Tex, i.uv0.zw);

                                fixed blendVal1 = frac(fmod((_Time.g * _Effect1FlipbookValue.w) + float(0.00001), _Effect1FlipbookValue.x * _Effect1FlipbookValue.y));
                                _Effect1FlipbookValue.z += 1;
                                _Effect1FlipbookBlendUV = FlipBookUV(_Effect1FlipbookBlendUV, _Effect1FlipbookValue);
                                fixed4 _Effect1_var2 = tex2D(_Effect1Tex, _Effect1FlipbookBlendUV);
                                _Effect1_var = lerp(_Effect1_var, _Effect1_var2, blendVal1);

                                #if defined(_EFFECT1USETIMERMASK_ON) && defined(_EFFECT1USEMASK_ON)	
                                    half2 effect1TimerMaskUV;
                                    effect1TimerMaskUV = _Effect1UseTimerMaskBaseUV ? effect1MaskUV : i.uv0.zw;
                            	    fixed2 _Effect1_TimerMask = tex2D(_Effect1Mask, effect1TimerMaskUV).ba;
                                #endif
                            #endif
                        #else
                            #if _EFFECT1USESCALE_ON && _EFFECT1USESCALECURVE_ON || _EFFECT1USESCALEPINGPONG_ON && _EFFECT1USESCALECURVE_ON
                                fixed4 _Effect1_var = ScaleCurveTex(_Effect1Tex, i.uv0.zw, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1ScaleCurve, _Effect1FlipbookValue);
                                #if defined(_EFFECT1USETIMERMASK_ON) && defined(_EFFECT1USEMASK_ON)	
                                    half2 effect1TimerMaskUV;
                                    effect1TimerMaskUV = _Effect1UseTimerMaskBaseUV ? effect1MaskUV : i.uv0.zw;
                            	    fixed2 _Effect1_TimerMask = tex2D(_Effect1Mask, effect1TimerMaskUV).ba;
                                #endif
                            #elif _EFFECT1USESCALE_ON
                                #if defined(_EFFECT1USETIMERMASK_ON) && defined(_EFFECT1USEMASK_ON)
                                    #if _EFFECT1RANDOMROTATE_ON
                                    fixed4 _Effect1_var = ScaleFlowTexRandomRotate(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultiplier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset, _Effect1Mask, _Effect1TimerMaskVal, _Effect1FlipbookValue);
                                    #else
                                    fixed4 _Effect1_var = ScaleFlowTex(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultiplier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset, _Effect1Mask, _Effect1TimerMaskVal, _Effect1FlipbookValue);
                                    #endif
                                #else
                                    #if _EFFECT1RANDOMROTATE_ON
                                    fixed4 _Effect1_var = ScaleFlowTexRandomRotate(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultiplier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset, _Effect1FlipbookValue);
                                    #else
                                    fixed4 _Effect1_var = ScaleFlowTex(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultiplier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset, _Effect1FlipbookValue);
                                    #endif
                                #endif
                            #elif _EFFECT1USESCALEPINGPONG_ON
                                fixed4 _Effect1_var = ScalePIngPongTex(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultiplier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset, _Effect1FlipbookValue);
                                #if defined(_EFFECT1USETIMERMASK_ON) && defined(_EFFECT1USEMASK_ON)	
                                    half2 effect1TimerMaskUV;
                                    effect1TimerMaskUV = _Effect1UseTimerMaskBaseUV ? effect1MaskUV : i.uv0.zw;
                              	    fixed2 _Effect1_TimerMask = tex2D(_Effect1Mask, effect1TimerMaskUV).ba;
                                #endif
                            #else
                                i.uv0.zw = ScaleUV(i.uv0.zw, _Effect1ScaleOrigin);
                                i.uv0.zw = FlipBookUV(i.uv0.zw, _Effect1FlipbookValue);
                                fixed4 _Effect1_var = tex2D(_Effect1Tex, i.uv0.zw);
                                #if defined(_EFFECT1USETIMERMASK_ON) && defined(_EFFECT1USEMASK_ON)	
                                    half2 effect1TimerMaskUV;
                                    effect1TimerMaskUV = _Effect1UseTimerMaskBaseUV ? effect1MaskUV : i.uv0.zw;
                            	    fixed2 _Effect1_TimerMask = tex2D(_Effect1Mask, effect1TimerMaskUV).ba;
                                #endif
                            #endif
                        #endif
                    #else
                        #if _EFFECT1USESCALE_ON && _EFFECT1USESCALECURVE_ON || _EFFECT1USESCALEPINGPONG_ON && _EFFECT1USESCALECURVE_ON
                            fixed4 _Effect1_var = ScaleCurveTex(_Effect1Tex, i.uv0.zw, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1ScaleCurve);
                            #if defined(_EFFECT1USETIMERMASK_ON) && defined(_EFFECT1USEMASK_ON)	
                                half2 effect1TimerMaskUV;
                                effect1TimerMaskUV = _Effect1UseTimerMaskBaseUV ? effect1MaskUV : i.uv0.zw;
                            	fixed2 _Effect1_TimerMask = tex2D(_Effect1Mask, effect1TimerMaskUV).ba;
                            #endif
                        #elif _EFFECT1USESCALE_ON
                            #if defined(_EFFECT1USETIMERMASK_ON) && defined(_EFFECT1USEMASK_ON)
                                #if _EFFECT1RANDOMROTATE_ON
                                fixed4 _Effect1_var = ScaleFlowTexRandomRotate(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultiplier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset, _Effect1Mask, _Effect1TimerMaskVal);
                                #else
                                fixed4 _Effect1_var = ScaleFlowTex(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultiplier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset, _Effect1Mask, _Effect1TimerMaskVal);
                                #endif
                            #else
                                #if _EFFECT1RANDOMROTATE_ON
                                fixed4 _Effect1_var = ScaleFlowTexRandomRotate(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultiplier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset);
                                #else
                                fixed4 _Effect1_var = ScaleFlowTex(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultiplier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset);
                                #endif
                            #endif
                        #elif _EFFECT1USESCALEPINGPONG_ON
                            fixed4 _Effect1_var = ScalePIngPongTex(_Effect1Tex, i.uv0.zw, _Effect1ScaleMultiplier, _Effect1ScaleOrigin, _Effect1ScaleSpeed, _Effect1TimingOffset);
                            #if defined(_EFFECT1USETIMERMASK_ON) && defined(_EFFECT1USEMASK_ON)	
                                half2 effect1TimerMaskUV;
                                effect1TimerMaskUV = _Effect1UseTimerMaskBaseUV ? effect1MaskUV : i.uv0.zw;
                            	fixed2 _Effect1_TimerMask = tex2D(_Effect1Mask, effect1TimerMaskUV).ba;
                            #endif
                        #else
                            i.uv0.zw = ScaleUV(i.uv0.zw, _Effect1ScaleOrigin);
                            fixed4 _Effect1_var = tex2D(_Effect1Tex, i.uv0.zw);
                            #if defined(_EFFECT1USETIMERMASK_ON) && defined(_EFFECT1USEMASK_ON)	
                                half2 effect1TimerMaskUV;
                                effect1TimerMaskUV = _Effect1UseTimerMaskBaseUV ? effect1MaskUV : i.uv0.zw;
                            	fixed2 _Effect1_TimerMask = tex2D(_Effect1Mask, effect1TimerMaskUV).ba;
                            #endif
                        #endif
                    #endif

                    #if defined(_EFFECT1USETIMERMASK_ON) && defined(_EFFECT1USEMASK_ON) && !defined(_EFFECT1USESCALE_ON)
                                _Effect1_TimerMask.g *= 0.7777777;
                                fixed effect1TimerMaskInput = frac(_Effect1_TimerMask.g * _Effect1TimerMaskVal.a * _Time.g + _Effect1TimingOffset + _Effect1_TimerMask.r);
                                _Effect1_mask *= smoothstep(_Effect1TimerMaskVal.r, _Effect1TimerMaskVal.r + _Effect1TimerMaskVal.b, effect1TimerMaskInput)
                                                * smoothstep(_Effect1TimerMaskVal.g, _Effect1TimerMaskVal.g - _Effect1TimerMaskVal.b, effect1TimerMaskInput);
                    #endif

                    _Effect1_var.rgb *= _Effect1_var.a;
                    effect1Color = pow(_Effect1_var.rgb, _Effect1Power) * _Effect1Color.rgb * _Effect1Color.a * _Effect1Brightness;
                    effect1Color *= _Effect1UseLuminanceMask ? _SpriteLuminanceMask : 1;
                    effect1Color *= _Effect1UseGlow ? i.Glowcolor1.x : 1;

                    effect2Mask = _Effect1BlendMask ? saturate(effect1Color) : effect2Mask;
                    //#if _EFFECT1USEMASK_ON
                    effect1Color *= _Effect1_mask.r;
                    //#endif

                    fixed effect1Alpha = _Effect1UseAlpha ? _Effect1_var.a : saturate(Luminance(_Effect1_var) * 4);
                    effect1Alpha *= _Effect1UseGlow ? i.Glowcolor1.x : 1;
                    effect1Alpha *= _Effect1Color.a;

                    //#if _EFFECT1USEMASK_ON
                    effect1Alpha *= _Effect1_mask.r;
                    //#endif

                    #if _REMOVEBASESPRITE_ON
                        finalAlpha = max(finalAlpha,effect1Alpha);
                    #endif

                    finalColor = _Effect1BlendMask ? finalColor : (_Effect1AlphaBlend ? lerp(finalColor, effect1Color, effect1Alpha) : finalColor + effect1Color);

                    #if _REMOVEBASESPRITE_ON
                        finalAlpha += effect1Color;
                    #endif

                    finalColor = saturate(finalColor);
                #endif

                #if _EFFECT2_ON
                    fixed3 effect2Color;
                    half2 effect2MaskUV;
                    effect2MaskUV = _Effect2UseMaskUV ? i.uv4.zw : i.uv4.xy;

                    #if defined(_EFFECT2USEMASK_ON) && defined(_EFFECT2USETIMEROFFSETMASK_ON)
                        fixed2 _Effect2_TimerPreMask = tex2D(_Effect2Mask, i.uv1.xy).ba;
                        float effectTime2 = (_Time.g + _Effect2TimingOffset + _Effect2_TimerPreMask.r * _Effect2TimerMaskVal.a) * _Effect2_TimerPreMask.g;
                        effectTime2 *= -1;
                        #if _EFFECT2USEDIRECTIONALSCROLL_ON
                            #if _EFFECT2USEROTATE_ON
                                #if _EFFECT2USEROTATECURVE_ON
                                i.uv1.xy = ComputeRotateCurveUV(_Effect2Tex, _Effect2Tex_ST, i.uv1.xy, _Effect2RotateCurve);
                                #else
                                i.uv1.xy = ComputeRotateUV(_Effect2Tex, _Effect2Tex_ST, i.uv1.xy, _Effect2RotateSpeed, _Effect2RotateAngle, effectTime2);
                                #endif
                            #endif
                            #if _EFFECT2USESCROLL_ON
                                #if _EFFECT2USESCROLLCURVE_ON
                                i.uv1.xy = i.uv1.xy - (_Effect2ScrollCurve * (0.5 + _Effect2ScaleOrigin));
                                #else
                                i.uv1.xy = ComputeScrollUV(i.uv1.xy, _Effect2VerticalSpeed, _Effect2HorizontalSpeed, _Effect2ScaleOrigin, effectTime2);
                                #endif
                            #endif
                        #else
                            #if _EFFECT2USESCROLL_ON
                                #if _EFFECT2USESCROLLCURVE_ON
                                i.uv1.xy = i.uv1.xy - (_Effect2ScrollCurve * (0.5 + _Effect2ScaleOrigin));
                                #else
                                i.uv1.xy = ComputeScrollUV(i.uv1.xy, _Effect2VerticalSpeed, _Effect2HorizontalSpeed, _Effect2ScaleOrigin, effectTime2);
                                #endif
                            #endif
                            #if _EFFECT2USEROTATE_ON
                                #if _EFFECT2USEROTATECURVE_ON
                                i.uv1.xy = ComputeRotateCurveUV(_Effect2Tex, _Effect2Tex_ST, i.uv1.xy, _Effect2RotateCurve);
                                #else
                                i.uv1.xy = ComputeRotateUV(_Effect2Tex, _Effect2Tex_ST, i.uv1.xy, _Effect2RotateSpeed, _Effect2RotateAngle, effectTime2);
                                #endif
                            #endif
                        #endif

                        i.uv1.xy = CustomTransformTex(i.uv1.xy, _Effect2Tex_ST);
                        i.Glowcolor1.y = _Effect2UseGlow ? cos((effectTime2 * _Effect2GlowSpeed)) * 0.5 + 0.5 : 1;
                    #endif

                    fixed _Effect2_mask = _Effect2UseSpriteMask ? saturate(dot(_Effect2SpriteMaskValue, _SpriteEffectMask_var)) : 1;

                    #if _EFFECT2USEMASK_ON
                        fixed2 effect2MaskTex = tex2D(_Effect2Mask, effect2MaskUV).rg;
                        i.uv1.xy += _Effect2UseDistortMask ? (((effect2MaskTex.g * effect2Mask.g) - 0.5) * 2) * _Effect2MaskDistortStrength : 0;
                        _Effect2_mask *= effect2MaskTex.r;
                    #else
                        i.uv1.xy += _Effect2UseDistortMask ? ((effect2Mask.g - 0.5) * 2) * _Effect2MaskDistortStrength : 0;
                    #endif

                    #if _EFFECT2USEFLIPBOOK_ON
                        #if _EFFECT2USEFLIPBOOKBLEND_ON
                            #if _EFFECT2USESCALE_ON && _EFFECT2USESCALECURVE_ON || _EFFECT2USESCALEPINGPONG_ON && _EFFECT2USESCALECURVE_ON
                                fixed4 _Effect2_var = ScaleCurveTexBlend(_Effect2Tex, i.uv1.xy, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2ScaleCurve, _Effect2FlipbookValue);
                        	    #if defined(_EFFECT2USETIMERMASK_ON) && defined(_EFFECT2USEMASK_ON)	
                                    half2 effect2TimerMaskUV;
                                    effect2TimerMaskUV = _Effect2UseTimerMaskBaseUV ? effect2MaskUV : i.uv1.xy;
		                            fixed2 _Effect2_TimerMask = tex2D(_Effect2Mask, effect2TimerMaskUV).ba;
	                            #endif
                            #elif _EFFECT2USESCALE_ON
                                #if defined(_EFFECT2USETIMERMASK_ON) && defined(_EFFECT2USEMASK_ON)	
                                    #if _EFFECT2RANDOMROTATE_ON
                                    fixed4 _Effect2_var = ScaleFlowTexRandomRotateBlend(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultiplier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset, _Effect2Mask, _Effect2TimerMaskVal, _Effect2FlipbookValue);
                                    #else
                                    fixed4 _Effect2_var = ScaleFlowTexBlend(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultiplier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset, _Effect2Mask, _Effect2TimerMaskVal, _Effect2FlipbookValue);
                                    #endif
                                #else
                                    #if _EFFECT2RANDOMROTATE_ON
                                    fixed4 _Effect2_var = ScaleFlowTexRandomRotateBlend(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultiplier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset, _Effect2FlipbookValue);
                                    #else
                                    fixed4 _Effect2_var = ScaleFlowTexBlend(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultiplier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset, _Effect2FlipbookValue);
                                    #endif
                                #endif
                            #elif _EFFECT2USESCALEPINGPONG_ON
                                fixed4 _Effect2_var = ScalePIngPongTexBlend(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultiplier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset, _Effect2FlipbookValue);
                        	    #if defined(_EFFECT2USETIMERMASK_ON) && defined(_EFFECT2USEMASK_ON)	
                                    half2 effect2TimerMaskUV;
                                    effect2TimerMaskUV = _Effect2UseTimerMaskBaseUV ? effect2MaskUV : i.uv1.xy;
		                            fixed2 _Effect2_TimerMask = tex2D(_Effect2Mask, effect2TimerMaskUV).ba;
	                            #endif
                            #else
                                i.uv1.xy = ScaleUV(i.uv1.xy, _Effect2ScaleOrigin);
                                float2 _Effect2FlipbookBlendUV = i.uv1.xy;
                                i.uv1.xy = FlipBookUV(i.uv1.xy, _Effect2FlipbookValue);
                                fixed4 _Effect2_var = tex2D(_Effect2Tex, i.uv1.xy);

                                fixed blendVal2 = frac(fmod((_Time.g * _Effect2FlipbookValue.w) + float(0.00001), _Effect2FlipbookValue.x * _Effect2FlipbookValue.y));
                                _Effect2FlipbookValue.z += 1;
                                _Effect2FlipbookBlendUV = FlipBookUV(_Effect2FlipbookBlendUV, _Effect2FlipbookValue);
                                fixed4 _Effect2_var2 = tex2D(_Effect2Tex, _Effect2FlipbookBlendUV);
                                _Effect2_var = lerp(_Effect2_var, _Effect2_var2, blendVal2);
                        	    #if defined(_EFFECT2USETIMERMASK_ON) && defined(_EFFECT2USEMASK_ON)	
                                    half2 effect2TimerMaskUV;
                                    effect2TimerMaskUV = _Effect2UseTimerMaskBaseUV ? effect2MaskUV : i.uv1.xy;
		                            fixed2 _Effect2_TimerMask = tex2D(_Effect2Mask, effect2TimerMaskUV).ba;
	                            #endif
                            #endif
                        #else
                            #if _EFFECT2USESCALE_ON && _EFFECT2USESCALECURVE_ON || _EFFECT2USESCALEPINGPONG_ON && _EFFECT2USESCALECURVE_ON
                                fixed4 _Effect2_var = ScaleCurveTex(_Effect2Tex, i.uv1.xy, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2ScaleCurve, _Effect2FlipbookValue);
                        	    #if defined(_EFFECT2USETIMERMASK_ON) && defined(_EFFECT2USEMASK_ON)	
                                    half2 effect2TimerMaskUV;
                                    effect2TimerMaskUV = _Effect2UseTimerMaskBaseUV ? effect2MaskUV : i.uv1.xy;
		                            fixed2 _Effect2_TimerMask = tex2D(_Effect2Mask, effect2TimerMaskUV).ba;
	                            #endif
                            #elif _EFFECT2USESCALE_ON
                                #if defined(_EFFECT2USETIMERMASK_ON) && defined(_EFFECT2USEMASK_ON)	
                                    #if _EFFECT2RANDOMROTATE_ON
                                    fixed4 _Effect2_var = ScaleFlowTexRandomRotate(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultiplier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset, _Effect2Mask, _Effect2TimerMaskVal, _Effect2FlipbookValue);
                                    #else
                                    fixed4 _Effect2_var = ScaleFlowTex(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultiplier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset, _Effect2Mask, _Effect2TimerMaskVal, _Effect2FlipbookValue);
                                    #endif
                                #else
                                    #if _EFFECT2RANDOMROTATE_ON
                                    fixed4 _Effect2_var = ScaleFlowTexRandomRotate(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultiplier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset, _Effect2FlipbookValue);
                                    #else
                                    fixed4 _Effect2_var = ScaleFlowTex(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultiplier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset, _Effect2FlipbookValue);
                                    #endif
                                #endif
                            #elif _EFFECT2USESCALEPINGPONG_ON
                                fixed4 _Effect2_var = ScalePIngPongTex(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultiplier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset, _Effect2FlipbookValue);
                        	    #if defined(_EFFECT2USETIMERMASK_ON) && defined(_EFFECT2USEMASK_ON)	
                                    half2 effect2TimerMaskUV;
                                    effect2TimerMaskUV = _Effect2UseTimerMaskBaseUV ? effect2MaskUV : i.uv1.xy;
		                            fixed2 _Effect2_TimerMask = tex2D(_Effect2Mask, effect2TimerMaskUV).ba;
	                            #endif
                            #else
                                i.uv1.xy = ScaleUV(i.uv1.xy, _Effect2ScaleOrigin);
                                i.uv1.xy = FlipBookUV(i.uv1.xy, _Effect2FlipbookValue);
                                fixed4 _Effect2_var = tex2D(_Effect2Tex, i.uv1.xy);
                        	    #if defined(_EFFECT2USETIMERMASK_ON) && defined(_EFFECT2USEMASK_ON)	
                                    half2 effect2TimerMaskUV;
                                    effect2TimerMaskUV = _Effect2UseTimerMaskBaseUV ? effect2MaskUV : i.uv1.xy;
		                            fixed2 _Effect2_TimerMask = tex2D(_Effect2Mask, effect2TimerMaskUV).ba;
	                            #endif
                            #endif
                        #endif
                    #else
                        #if _EFFECT2USESCALE_ON && _EFFECT2USESCALECURVE_ON || _EFFECT2USESCALEPINGPONG_ON && _EFFECT2USESCALECURVE_ON
                            fixed4 _Effect2_var = ScaleCurveTex(_Effect2Tex, i.uv1.xy, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2ScaleCurve);
                        	#if defined(_EFFECT2USETIMERMASK_ON) && defined(_EFFECT2USEMASK_ON)	
                                    half2 effect2TimerMaskUV;
                                    effect2TimerMaskUV = _Effect2UseTimerMaskBaseUV ? effect2MaskUV : i.uv1.xy;
		                        fixed2 _Effect2_TimerMask = tex2D(_Effect2Mask, effect2TimerMaskUV).ba;
	                        #endif
                        #elif _EFFECT2USESCALE_ON
                            #if defined(_EFFECT2USETIMERMASK_ON) && defined(_EFFECT2USEMASK_ON)	
                                #if _EFFECT2RANDOMROTATE_ON
                                fixed4 _Effect2_var = ScaleFlowTexRandomRotate(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultiplier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset, _Effect2Mask, _Effect2TimerMaskVal);
                                #else
                                fixed4 _Effect2_var = ScaleFlowTex(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultiplier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset, _Effect2Mask, _Effect2TimerMaskVal);
                                #endif
                            #else
                                #if _EFFECT2RANDOMROTATE_ON
                                fixed4 _Effect2_var = ScaleFlowTexRandomRotate(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultiplier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset);
                                #else
                                fixed4 _Effect2_var = ScaleFlowTex(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultiplier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset);
                                #endif
                            #endif
                        #elif _EFFECT2USESCALEPINGPONG_ON
                            fixed4 _Effect2_var = ScalePIngPongTex(_Effect2Tex, i.uv1.xy, _Effect2ScaleMultiplier, _Effect2ScaleOrigin, _Effect2ScaleSpeed, _Effect2TimingOffset);
                        	#if defined(_EFFECT2USETIMERMASK_ON) && defined(_EFFECT2USEMASK_ON)	
                                    half2 effect2TimerMaskUV;
                                    effect2TimerMaskUV = _Effect2UseTimerMaskBaseUV ? effect2MaskUV : i.uv1.xy;
		                        fixed2 _Effect2_TimerMask = tex2D(_Effect2Mask, effect2TimerMaskUV).ba;
	                        #endif
                        #else
                            i.uv1.xy = ScaleUV(i.uv1.xy, _Effect2ScaleOrigin);
                            fixed4 _Effect2_var = tex2D(_Effect2Tex, i.uv1.xy);
                        	#if defined(_EFFECT2USETIMERMASK_ON) && defined(_EFFECT2USEMASK_ON)	
                                    half2 effect2TimerMaskUV;
                                    effect2TimerMaskUV = _Effect2UseTimerMaskBaseUV ? effect2MaskUV : i.uv1.xy;
		                        fixed2 _Effect2_TimerMask = tex2D(_Effect2Mask, effect2TimerMaskUV).ba;
	                        #endif
                        #endif
                    #endif

                    #if defined(_EFFECT2USETIMERMASK_ON) && defined(_EFFECT2USEMASK_ON) && !defined(_EFFECT2USESCALE_ON)
                                _Effect2_TimerMask.g *= 0.7777777;
                                fixed effect2TimerMaskInput = frac(_Effect2_TimerMask.g * _Effect2TimerMaskVal.a * _Time.g + _Effect2TimingOffset + _Effect2_TimerMask.r);
                                _Effect2_mask *= smoothstep(_Effect2TimerMaskVal.r, _Effect2TimerMaskVal.r + _Effect2TimerMaskVal.b, effect2TimerMaskInput)
                                                * smoothstep(_Effect2TimerMaskVal.g, _Effect2TimerMaskVal.g - _Effect2TimerMaskVal.b, effect2TimerMaskInput);
                    #endif

                    _Effect2_var *= _Effect2_var.a;
                    effect2Color = pow(_Effect2_var.rgb, _Effect2Power) * _Effect2Color.rgb * _Effect2Color.a * _Effect2Brightness* effect2Mask.r;
                    effect2Color *= _Effect2UseLuminanceMask ? _SpriteLuminanceMask : 1;
                    effect2Color *= _Effect2UseGlow ? i.Glowcolor1.y : 1;

                    effect3Mask.r *= _Effect2BlendMask ? saturate(effect2Color.r) : 1;
                    effect3Mask.g *= _Effect2BlendMask ? saturate(saturate(effect2Color.g) * effect2Mask.g) : 1;
                    //#if _EFFECT2USEMASK_ON                    
                    effect2Color *= _Effect2_mask.r;
                    //#endif

                    fixed effect2Alpha = _Effect2UseAlpha ? _Effect2_var.a : saturate(Luminance(_Effect2_var) * 4);
                    effect2Alpha *= _Effect2UseGlow ? i.Glowcolor1.y : 1;
                    effect2Alpha *= _Effect2Color.a;

                    //#if _EFFECT2USEMASK_ON
                    effect2Alpha *= _Effect2_mask.r;
                    //#endif

                    #if _REMOVEBASESPRITE_ON
                        finalAlpha = max(finalAlpha,effect2Alpha * effect2Mask.r);
                    #endif

                    finalColor = _Effect2BlendMask ? finalColor : (_Effect2AlphaBlend ? lerp(finalColor, effect2Color, effect2Alpha * effect2Mask.r) : finalColor + effect2Color);

                    #if _REMOVEBASESPRITE_ON
                        finalAlpha += effect2Color;
                    #endif
                    
                    finalColor = saturate(finalColor);
                #endif

                #if _EFFECT3_ON
                    fixed3 effect3Color;
                    half2 effect3MaskUV;
                    effect3MaskUV = _Effect3UseMaskUV ? i.uv4.zw : i.uv4.xy;

                    #if defined(_EFFECT3USEMASK_ON) && defined(_EFFECT3USETIMEROFFSETMASK_ON)
                        fixed2 _Effect3_TimerPreMask = tex2D(_Effect3Mask, i.uv1.zw).ba;
                        float effectTime3 = (_Time.g + _Effect3TimingOffset + _Effect3_TimerPreMask.r * _Effect3TimerMaskVal.a) * _Effect3_TimerPreMask.g;
                        effectTime3 *= -1;
                        #if _EFFECT3USEDIRECTIONALSCROLL_ON
                            #if _EFFECT3USEROTATE_ON
                                #if _EFFECT3USEROTATECURVE_ON
                                i.uv1.zw = ComputeRotateCurveUV(_Effect3Tex, _Effect3Tex_ST, i.uv1.zw, _Effect3RotateCurve);
                                #else
                                i.uv1.zw = ComputeRotateUV(_Effect3Tex, _Effect3Tex_ST, i.uv1.zw, _Effect3RotateSpeed, _Effect3RotateAngle, effectTime3);
                                #endif
                            #endif
                            #if _EFFECT3USESCROLL_ON
                                #if _EFFECT3USESCROLLCURVE_ON
                                i.uv1.zw = i.uv1.zw - (_Effect3ScrollCurve * (0.5 + _Effect3ScaleOrigin));
                                #else
                                i.uv1.zw = ComputeScrollUV(i.uv1.zw, _Effect3VerticalSpeed, _Effect3HorizontalSpeed, _Effect3ScaleOrigin, effectTime3);
                                #endif
                            #endif
                        #else
                            #if _EFFECT3USESCROLL_ON
                                #if _EFFECT3USESCROLLCURVE_ON_Effect3_TimerMask = tex2D(_Effect3Mask, effect3MaskUV).ba
                                i.uv1.zw = i.uv1.zw - (_Effect3ScrollCurve * (0.5 + _Effect3ScaleOrigin));
                                #else
                                i.uv1.zw = ComputeScrollUV(i.uv1.zw, _Effect3VerticalSpeed, _Effect3HorizontalSpeed, _Effect3ScaleOrigin, effectTime3);
                                #endif
                            #endif
                            #if _EFFECT3USEROTATE_ON
                                #if _EFFECT3USEROTATECURVE_ON
                                i.uv1.zw = ComputeRotateCurveUV(_Effect3Tex, _Effect3Tex_ST, i.uv1.zw, _Effect3RotateCurve);
                                #else
                                i.uv1.zw = ComputeRotateUV(_Effect3Tex, _Effect3Tex_ST, i.uv1.zw, _Effect3RotateSpeed, _Effect3RotateAngle, effectTime3);
                                #endif
                            #endif
                        #endif

                        i.uv1.zw = CustomTransformTex(i.uv1.zw, _Effect3Tex_ST);
                        i.Glowcolor1.z = _Effect3UseGlow ? cos((effectTime3 * _Effect3GlowSpeed)) * 0.5 + 0.5 : 1;
                    #endif

                    fixed _Effect3_mask = _Effect3UseSpriteMask ? saturate(dot(_Effect3SpriteMaskValue, _SpriteEffectMask_var)) : 1;

                    #if _EFFECT3USEMASK_ON
                        fixed2 effect3MaskTex = tex2D(_Effect3Mask, effect3MaskUV).rg;
                        i.uv1.zw += _Effect3UseDistortMask ? (((effect3MaskTex.g * effect3Mask.g) - 0.5) * 2) * _Effect3MaskDistortStrength : 0;
                        _Effect3_mask *= effect3MaskTex.r;
                    #else
                        i.uv1.zw += _Effect3UseDistortMask ? ((effect3Mask.g - 0.5) * 2) * _Effect3MaskDistortStrength : 0;
                    #endif

                    #if _EFFECT3USEFLIPBOOK_ON
                        #if _EFFECT3USEFLIPBOOKBLEND_ON
                            #if _EFFECT3USESCALE_ON && _EFFECT3USESCALECURVE_ON || _EFFECT3USESCALEPINGPONG_ON && _EFFECT3USESCALECURVE_ON
                                fixed4 _Effect3_var = ScaleCurveTexBlend(_Effect3Tex, i.uv1.zw, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3ScaleCurve, _Effect3FlipbookValue);
                                #if defined(_EFFECT3USETIMERMASK_ON) && defined(_EFFECT3USEMASK_ON) 
                                    half2 effect3TimerMaskUV;
                                    effect3TimerMaskUV = _Effect3UseTimerMaskBaseUV ? effect3MaskUV : i.uv1.zw;
                                fixed2 _Effect3_TimerMask = tex2D(_Effect3Mask, effect3TimerMaskUV).ba;
                                #endif
                            #elif _EFFECT3USESCALE_ON
                                #if defined(_EFFECT3USETIMERMASK_ON) && defined(_EFFECT3USEMASK_ON)
                                    #if _EFFECT3RANDOMROTATE_ON
                                    fixed4 _Effect3_var = ScaleFlowTexRandomRotateBlend(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultiplier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset, _Effect3Mask, _Effect3TimerMaskVal, _Effect3FlipbookValue);
                                    #else
                                    fixed4 _Effect3_var = ScaleFlowTexBlend(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultiplier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset, _Effect3Mask, _Effect3TimerMaskVal, _Effect3FlipbookValue);
                                    #endif
                                #else
                                    #if _EFFECT3RANDOMROTATE_ON
                                    fixed4 _Effect3_var = ScaleFlowTexRandomRotateBlend(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultiplier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset, _Effect3FlipbookValue);
                                    #else
                                    fixed4 _Effect3_var = ScaleFlowTexBlend(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultiplier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset, _Effect3FlipbookValue);
                                    #endif
                                #endif
                            #elif _EFFECT3USESCALEPINGPONG_ON 
                                fixed4 _Effect3_var = ScalePIngPongTexBlend(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultiplier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset, _Effect3FlipbookValue);
                                #if defined(_EFFECT3USETIMERMASK_ON) && defined(_EFFECT3USEMASK_ON)
                                    half2 effect3TimerMaskUV;
                                    effect3TimerMaskUV = _Effect3UseTimerMaskBaseUV ? effect3MaskUV : i.uv1.zw;
                                fixed2 _Effect3_TimerMask = tex2D(_Effect3Mask, effect3TimerMaskUV).ba;
                                #endif
                            #else
                                i.uv1.zw = ScaleUV(i.uv1.zw, _Effect3ScaleOrigin);
                                float2 _Effect3FlipbookBlendUV = i.uv1.zw;
                                i.uv1.zw = FlipBookUV(i.uv1.zw, _Effect3FlipbookValue);
                                fixed4 _Effect3_var = tex2D(_Effect3Tex, i.uv1.zw);

                                fixed blendVal3 = frac(fmod((_Time.g * _Effect3FlipbookValue.w) + float(0.00001), _Effect3FlipbookValue.x * _Effect3FlipbookValue.y));
                                _Effect3FlipbookValue.z += 1;
                                _Effect3FlipbookBlendUV = FlipBookUV(_Effect3FlipbookBlendUV, _Effect3FlipbookValue);
                                fixed4 _Effect3_var2 = tex2D(_Effect3Tex, _Effect3FlipbookBlendUV);
                                _Effect3_var = lerp(_Effect3_var, _Effect3_var2, blendVal3);
                                #if defined(_EFFECT3USETIMERMASK_ON) && defined(_EFFECT3USEMASK_ON)
                                    half2 effect3TimerMaskUV;
                                    effect3TimerMaskUV = _Effect3UseTimerMaskBaseUV ? effect3MaskUV : i.uv1.zw;
                                fixed2 _Effect3_TimerMask = tex2D(_Effect3Mask, effect3TimerMaskUV).ba;
                                #endif
                            #endif
                        #else
                            #if _EFFECT3USESCALE_ON && _EFFECT3USESCALECURVE_ON || _EFFECT3USESCALEPINGPONG_ON && _EFFECT3USESCALECURVE_ON
                                fixed4 _Effect3_var = ScaleCurveTex(_Effect3Tex, i.uv1.zw, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3ScaleCurve, _Effect3FlipbookValue);
                                #if defined(_EFFECT3USETIMERMASK_ON) && defined(_EFFECT3USEMASK_ON)  
                                    half2 effect3TimerMaskUV;
                                    effect3TimerMaskUV = _Effect3UseTimerMaskBaseUV ? effect3MaskUV : i.uv1.zw;
                                fixed2 _Effect3_TimerMask = tex2D(_Effect3Mask, effect3TimerMaskUV).ba;
                                #endif

                            #elif _EFFECT3USESCALE_ON
                                #if defined(_EFFECT3USETIMERMASK_ON) && defined(_EFFECT3USEMASK_ON)
                                    #if _EFFECT3RANDOMROTATE_ON
                                    fixed4 _Effect3_var = ScaleFlowTexRandomRotate(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultiplier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset, _Effect3Mask, _Effect3TimerMaskVal, _Effect3FlipbookValue);
                                    #else
                                    fixed4 _Effect3_var = ScaleFlowTex(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultiplier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset, _Effect3Mask, _Effect3TimerMaskVal, _Effect3FlipbookValue);
                                    #endif
                                #else
                                    #if _EFFECT3RANDOMROTATE_ON
                                    fixed4 _Effect3_var = ScaleFlowTexRandomRotate(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultiplier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset, _Effect3FlipbookValue);
                                    #else
                                    fixed4 _Effect3_var = ScaleFlowTex(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultiplier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset, _Effect3FlipbookValue);
                                    #endif
                                #endif

                            #elif _EFFECT3USESCALEPINGPONG_ON 
                                fixed4 _Effect3_var = ScalePIngPongTex(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultiplier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset, _Effect3FlipbookValue);
                                #if defined(_EFFECT3USETIMERMASK_ON) && defined(_EFFECT3USEMASK_ON)
                                    half2 effect3TimerMaskUV;
                                    effect3TimerMaskUV = _Effect3UseTimerMaskBaseUV ? effect3MaskUV : i.uv1.zw;
                                fixed2 _Effect3_TimerMask = tex2D(_Effect3Mask, effect3TimerMaskUV).ba;
                                #endif

                            #else
                                i.uv1.zw = ScaleUV(i.uv1.zw, _Effect3ScaleOrigin);
                                i.uv1.zw = FlipBookUV(i.uv1.zw, _Effect3FlipbookValue);
                                fixed4 _Effect3_var = tex2D(_Effect3Tex, i.uv1.zw);
                                #if _EFFECT3FLIPBOOKBLEND_ON

                                #endif
                                #if defined(_EFFECT3USETIMERMASK_ON) && defined(_EFFECT3USEMASK_ON)
                                    half2 effect3TimerMaskUV;
                                    effect3TimerMaskUV = _Effect3UseTimerMaskBaseUV ? effect3MaskUV : i.uv1.zw;
                                fixed2 _Effect3_TimerMask = tex2D(_Effect3Mask, effect3TimerMaskUV).ba;
                                #endif
                            #endif
                        #endif
                    #else
                        #if _EFFECT3USESCALE_ON && _EFFECT3USESCALECURVE_ON || _EFFECT3USESCALEPINGPONG_ON && _EFFECT3USESCALECURVE_ON
                            fixed4 _Effect3_var = ScaleCurveTex(_Effect3Tex, i.uv1.zw, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3ScaleCurve);
                            #if defined(_EFFECT3USETIMERMASK_ON) && defined(_EFFECT3USEMASK_ON)
                                    half2 effect3TimerMaskUV;
                                    effect3TimerMaskUV = _Effect3UseTimerMaskBaseUV ? effect3MaskUV : i.uv1.zw;
                            fixed2 _Effect3_TimerMask = tex2D(_Effect3Mask, effect3TimerMaskUV).ba;
                            #endif

                        #elif _EFFECT3USESCALE_ON
                            #if defined(_EFFECT3USETIMERMASK_ON) && defined(_EFFECT3USEMASK_ON)
                                #if _EFFECT3RANDOMROTATE_ON
                                fixed4 _Effect3_var = ScaleFlowTexRandomRotate(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultiplier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset, _Effect3Mask, _Effect3TimerMaskVal);
                                #else
                                fixed4 _Effect3_var = ScaleFlowTex(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultiplier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset, _Effect3Mask, _Effect3TimerMaskVal);
                                #endif
                            #else
                                #if _EFFECT3RANDOMROTATE_ON
                                fixed4 _Effect3_var = ScaleFlowTexRandomRotate(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultiplier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset);
                                #else
                                fixed4 _Effect3_var = ScaleFlowTex(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultiplier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset);
                                #endif
                            #endif

                        #elif _EFFECT3USESCALEPINGPONG_ON 
                            fixed4 _Effect3_var = ScalePIngPongTex(_Effect3Tex, i.uv1.zw, _Effect3ScaleMultiplier, _Effect3ScaleOrigin, _Effect3ScaleSpeed, _Effect3TimingOffset);
                            #if defined(_EFFECT3USETIMERMASK_ON) && defined(_EFFECT3USEMASK_ON)
                                    half2 effect3TimerMaskUV;
                                    effect3TimerMaskUV = _Effect3UseTimerMaskBaseUV ? effect3MaskUV : i.uv1.zw;
                            fixed2 _Effect3_TimerMask = tex2D(_Effect3Mask, effect3TimerMaskUV).ba;
                            #endif

                        #else
                            i.uv1.zw = ScaleUV(i.uv1.zw, _Effect3ScaleOrigin);
                            fixed4 _Effect3_var = tex2D(_Effect3Tex, i.uv1.zw);
                            #if defined(_EFFECT3USETIMERMASK_ON) && defined(_EFFECT3USEMASK_ON)
                                    half2 effect3TimerMaskUV;
                                    effect3TimerMaskUV = _Effect3UseTimerMaskBaseUV ? effect3MaskUV : i.uv1.zw;
                            fixed2 _Effect3_TimerMask = tex2D(_Effect3Mask, effect3TimerMaskUV).ba;
                            #endif

                        #endif
                    #endif

                    #if defined(_EFFECT3USETIMERMASK_ON) && defined(_EFFECT3USEMASK_ON) && !defined(_EFFECT3USESCALE_ON)
                                _Effect3_TimerMask.g *= 0.7777777;
                                fixed effect3TimerMaskInput = frac(_Effect3_TimerMask.g * _Effect3TimerMaskVal.a * _Time.g + _Effect3TimingOffset + _Effect3_TimerMask.r);
                                _Effect3_mask *= smoothstep(_Effect3TimerMaskVal.r, _Effect3TimerMaskVal.r + _Effect3TimerMaskVal.b, effect3TimerMaskInput)
                                                * smoothstep(_Effect3TimerMaskVal.g, _Effect3TimerMaskVal.g - _Effect3TimerMaskVal.b, effect3TimerMaskInput);
                    #endif

                    _Effect3_var *= _Effect3_var.a;
                    effect3Color = pow(_Effect3_var.rgb, _Effect3Power) * _Effect3Color.rgb * _Effect3Color.a * _Effect3Brightness* effect3Mask.r;
                    effect3Color *= _Effect3UseLuminanceMask ? _SpriteLuminanceMask : 1;
                    effect3Color *= _Effect3UseGlow ? i.Glowcolor1.z : 1;

                    effect4Mask.r *= _Effect3BlendMask ? saturate(effect3Color.r) : 1;
                    effect4Mask.g *= _Effect3BlendMask ? saturate(saturate(effect3Color.g) * effect3Mask.g) : 1;
                    //#if _EFFECT3USEMASK_ON
                    effect3Color *= _Effect3_mask.r;
                    //#endif

                    fixed effect3Alpha = _Effect3UseAlpha ? _Effect3_var.a : saturate(Luminance(_Effect3_var) * 4);
                    effect3Alpha *= _Effect3UseGlow ? i.Glowcolor1.z : 1;
                    effect3Alpha *= _Effect3Color.a;

                    //#if _EFFECT3USEMASK_ON
                    effect3Alpha *= _Effect3_mask.r;
                    //#endif

                    #if _REMOVEBASESPRITE_ONt
                        finalAlpha = max(finalAlpha,effect3Alpha * effect3Mask.r);
                    #endif

                    finalColor = _Effect3BlendMask ? finalColor : (_Effect3AlphaBlend ? lerp(finalColor, effect3Color, effect3Alpha * effect3Mask.r) : finalColor + effect3Color);

                    #if _REMOVEBASESPRITE_ON
                        finalAlpha += effect3Color;
                    #endif

                    finalColor = saturate(finalColor);
                #endif

                #if _EFFECT4_ON
                    fixed3 effect4Color;
                    half2 effect4MaskUV;
                    effect4MaskUV = _Effect4UseMaskUV ? i.uv4.zw : i.uv4.xy;

                    #if defined(_EFFECT4USEMASK_ON) && defined(_EFFECT4USETIMEROFFSETMASK_ON)
                        fixed2 _Effect4_TimerPreMask = tex2D(_Effect4Mask, i.uv2.xy).ba;
                        float effectTime4 = (_Time.g + _Effect4TimingOffset + _Effect4_TimerPreMask.r * _Effect4TimerMaskVal.a) * _Effect4_TimerPreMask.g;
                        effectTime4 *= -1;
                        #if _EFFECT4USEDIRECTIONALSCROLL_ON
                            #if _EFFECT4USEROTATE_ON
                                #if _EFFECT4USEROTATECURVE_ON
                                i.uv2.xy = ComputeRotateCurveUV(_Effect4Tex, _Effect4Tex_ST, i.uv2.xy, _Effect4RotateCurve);
                                #else
                                i.uv2.xy = ComputeRotateUV(_Effect4Tex, _Effect4Tex_ST, i.uv2.xy, _Effect4RotateSpeed, _Effect4RotateAngle, effectTime4);
                                #endif
                            #endif
                            #if _EFFECT4USESCROLL_ON
                                #if _EFFECT4USESCROLLCURVE_ON
                                i.uv2.xy = i.uv2.xy - (_Effect4ScrollCurve * (0.5 + _Effect4ScaleOrigin));
                                #else
                                i.uv2.xy = ComputeScrollUV(i.uv2.xy, _Effect4VerticalSpeed, _Effect4HorizontalSpeed, _Effect4ScaleOrigin, effectTime4);
                                #endif
                            #endif
                        #else
                            #if _EFFECT4USESCROLL_ON
                                #if _EFFECT4USESCROLLCURVE_ON
                                 i.uv2.xy = i.uv2.xy - (_Effect4ScrollCurve * (0.5+_Effect4ScaleOrigin));
                                #else
                                i.uv2.xy = ComputeScrollUV(i.uv2.xy, _Effect4VerticalSpeed, _Effect4HorizontalSpeed, _Effect4ScaleOrigin, effectTime4);
                                #endif
                            #endif
                            #if _EFFECT4USEROTATE_ON
                                #if _EFFECT4USEROTATECURVE_ON
                                i.uv2.xy = ComputeRotateCurveUV(_Effect4Tex, _Effect4Tex_ST, i.uv2.xy, _Effect4RotateCurve);
                                #else
                                i.uv2.xy = ComputeRotateUV(_Effect4Tex, _Effect4Tex_ST, i.uv2.xy, _Effect4RotateSpeed, _Effect4RotateAngle, effectTime4);
                                #endif
                            #endif
                        #endif

                        i.uv2.xy = CustomTransformTex(i.uv2.xy, _Effect4Tex_ST);
                        i.Glowcolor1.w = _Effect4UseGlow ? cos((effectTime4 * _Effect4GlowSpeed)) * 0.5 + 0.5 : 1;
                    #endif

                    fixed _Effect4_mask = _Effect4UseSpriteMask ? saturate(dot(_Effect4SpriteMaskValue, _SpriteEffectMask_var)) : 1;

                    #if _EFFECT4USEMASK_ON
                        fixed2 effect4MaskTex = tex2D(_Effect4Mask, effect4MaskUV).rg;
                        i.uv2.zw += _Effect4UseDistortMask ? (((effect4MaskTex.g * effect4Mask.g) - 0.5) * 2) * _Effect4MaskDistortStrength : 0;
                        _Effect4_mask *= effect4MaskTex.r;
                    #else
                        i.uv2.zw += _Effect4UseDistortMask ? ((effect4Mask.g - 0.5) * 2) * _Effect4MaskDistortStrength : 0;
                    #endif

                    #if _EFFECT4USEFLIPBOOK_ON
                        #if _EFFECT4USEFLIPBOOKBLEND_ON
                           #if _EFFECT4USESCALE_ON && _EFFECT4USESCALECURVE_ON || _EFFECT4USESCALEPINGPONG_ON && _EFFECT4USESCALECURVE_ON
                                 fixed4 _Effect4_var = ScaleCurveTexBlend(_Effect4Tex, i.uv2.xy, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4ScaleCurve, _Effect4FlipbookValue);
                                 #if defined(_EFFECT4USETIMERMASK_ON) && defined(_EFFECT4USEMASK_ON)
                                    half2 effect4TimerMaskUV;
                                    effect4TimerMaskUV = _Effect4UseTimerMaskBaseUV ? effect4MaskUV : i.uv2.xy;
                                    fixed2 _Effect4_TimerMask = tex2D(_Effect4Mask, effect4TimerMaskUV).ba;
                                 #endif
                           #elif _EFFECT4USESCALE_ON
                                 #if defined(_EFFECT4USETIMERMASK_ON) && defined(_EFFECT4USEMASK_ON)
                                     #if _EFFECT4RANDOMROTATE_ON
                                     fixed4 _Effect4_var = ScaleFlowTexRandomRotateBlend(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultiplier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset, _Effect4Mask, _Effect4TimerMaskVal, _Effect4FlipbookValue);
                                     #else
                                     fixed4 _Effect4_var = ScaleFlowTexBlend(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultiplier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset, _Effect4Mask, _Effect4TimerMaskVal, _Effect4FlipbookValue);
                                     #endif
                                 #else
                                     #if _EFFECT4RANDOMROTATE_ON
                                     fixed4 _Effect4_var = ScaleFlowTexRandomRotateBlend(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultiplier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset, _Effect4FlipbookValue);
                                     #else
                                     fixed4 _Effect4_var = ScaleFlowTexBlend(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultiplier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset, _Effect4FlipbookValue);
                                     #endif                              
                                 #endif
                           #elif _EFFECT4USESCALEPINGPONG_ON
                                 fixed4 _Effect4_var = ScalePIngPongTexBlend(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultiplier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset, _Effect4FlipbookValue);
                                 #if defined(_EFFECT4USETIMERMASK_ON) && defined(_EFFECT4USEMASK_ON)
                                    half2 effect4TimerMaskUV;
                                    effect4TimerMaskUV = _Effect4UseTimerMaskBaseUV ? effect4MaskUV : i.uv2.xy;
                                    fixed2 _Effect4_TimerMask = tex2D(_Effect4Mask, effect4TimerMaskUV).ba;
                                 #endif
                           #else
                                 i.uv2.xy = ScaleUV(i.uv2.xy, _Effect4ScaleOrigin);
                                 float2 _Effect4FlipbookBlendUV = i.uv2.xy;
                                 i.uv2.xy = FlipBookUV(i.uv2.xy, _Effect4FlipbookValue);
                                 fixed4 _Effect4_var = tex2D(_Effect4Tex, i.uv2.xy);

                                 fixed blendVal4 = frac(fmod((_Time.g * _Effect4FlipbookValue.w) + float(0.00001), _Effect4FlipbookValue.x * _Effect4FlipbookValue.y));
                                 _Effect4FlipbookValue.z += 1;
                                 _Effect4FlipbookBlendUV = FlipBookUV(_Effect4FlipbookBlendUV, _Effect4FlipbookValue);
                                 fixed4 _Effect4_var2 = tex2D(_Effect4Tex, _Effect4FlipbookBlendUV);
                                 _Effect4_var = lerp(_Effect4_var, _Effect4_var2, blendVal4);
                                 #if defined(_EFFECT4USETIMERMASK_ON) && defined(_EFFECT4USEMASK_ON)
                                    half2 effect4TimerMaskUV;
                                    effect4TimerMaskUV = _Effect4UseTimerMaskBaseUV ? effect4MaskUV : i.uv2.xy;
                                    fixed2 _Effect4_TimerMask = tex2D(_Effect4Mask, effect4TimerMaskUV).ba;
                                 #endif
                           #endif
                        #else
                            #if _EFFECT4USESCALE_ON && _EFFECT4USESCALECURVE_ON || _EFFECT4USESCALEPINGPONG_ON && _EFFECT4USESCALECURVE_ON
                                fixed4 _Effect4_var = ScaleCurveTex(_Effect4Tex, i.uv2.xy, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4ScaleCurve, _Effect4FlipbookValue);
                                #if defined(_EFFECT4USETIMERMASK_ON) && defined(_EFFECT4USEMASK_ON)
                                    half2 effect4TimerMaskUV;
                                    effect4TimerMaskUV = _Effect4UseTimerMaskBaseUV ? effect4MaskUV : i.uv2.xy;
                                    fixed2 _Effect4_TimerMask = tex2D(_Effect4Mask, effect4TimerMaskUV).ba;
                                #endif
                            #elif _EFFECT4USESCALE_ON
                                #if defined(_EFFECT4USETIMERMASK_ON) && defined(_EFFECT4USEMASK_ON)
                                    #if _EFFECT4RANDOMROTATE_ON
                                    fixed4 _Effect4_var = ScaleFlowTexRandomRotate(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultiplier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset, _Effect4Mask, _Effect4TimerMaskVal, _Effect4FlipbookValue);
                                    #else
                                    fixed4 _Effect4_var = ScaleFlowTex(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultiplier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset, _Effect4Mask, _Effect4TimerMaskVal, _Effect4FlipbookValue);
                                    #endif
                                #else
                                    #if _EFFECT4RANDOMROTATE_ON
                                    fixed4 _Effect4_var = ScaleFlowTexRandomRotate(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultiplier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset, _Effect4FlipbookValue);
                                    #else
                                    fixed4 _Effect4_var = ScaleFlowTex(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultiplier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset, _Effect4FlipbookValue);
                                    #endif                              
                                #endif
                            #elif _EFFECT4USESCALEPINGPONG_ON
                                fixed4 _Effect4_var = ScalePIngPongTex(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultiplier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset, _Effect4FlipbookValue);
                                #if defined(_EFFECT4USETIMERMASK_ON) && defined(_EFFECT4USEMASK_ON)
                                half2 effect4TimerMaskUV;
                                effect4TimerMaskUV = _Effect4UseTimerMaskBaseUV ? effect4MaskUV : i.uv2.xy;
                                fixed2 _Effect4_TimerMask = tex2D(_Effect4Mask, effect4TimerMaskUV).ba;
                                #endif
                            #else
                                i.uv2.xy = ScaleUV(i.uv2.xy, _Effect4ScaleOrigin);
                                i.uv2.xy = FlipBookUV(i.uv2.xy, _Effect4FlipbookValue);
                                fixed4 _Effect4_var = tex2D(_Effect4Tex, i.uv2.xy);
                                #if defined(_EFFECT4USETIMERMASK_ON) && defined(_EFFECT4USEMASK_ON)
                                    half2 effect4TimerMaskUV;
                                    effect4TimerMaskUV = _Effect4UseTimerMaskBaseUV ? effect4MaskUV : i.uv2.xy;
                                    fixed2 _Effect4_TimerMask = tex2D(_Effect4Mask, effect4TimerMaskUV).ba;
                                #endif
                            #endif
                        #endif
                    #else
                        #if _EFFECT4USESCALE_ON && _EFFECT4USESCALECURVE_ON || _EFFECT4USESCALEPINGPONG_ON && _EFFECT4USESCALECURVE_ON
                            fixed4 _Effect4_var = ScaleCurveTex(_Effect4Tex, i.uv2.xy, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4ScaleCurve);
                            #if defined(_EFFECT4USETIMERMASK_ON) && defined(_EFFECT4USEMASK_ON)
                                half2 effect4TimerMaskUV;
                                effect4TimerMaskUV = _Effect4UseTimerMaskBaseUV ? effect4MaskUV : i.uv2.xy;
                                fixed2 _Effect4_TimerMask = tex2D(_Effect4Mask, effect4TimerMaskUV).ba;
                            #endif
                      #elif _EFFECT4USESCALE_ON
                            #if defined(_EFFECT4USETIMERMASK_ON) && defined(_EFFECT4USEMASK_ON)	
                                #if _EFFECT4RANDOMROTATE_ON
                                fixed4 _Effect4_var = ScaleFlowTexRandomRotate(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultiplier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset, _Effect4Mask, _Effect4TimerMaskVal);
                                #else
                                fixed4 _Effect4_var = ScaleFlowTex(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultiplier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset, _Effect4Mask, _Effect4TimerMaskVal);
                                #endif
                            #else
                                #if _EFFECT4RANDOMROTATE_ON
                                fixed4 _Effect4_var = ScaleFlowTexRandomRotate(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultiplier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset);
                                #else
                                fixed4 _Effect4_var = ScaleFlowTex(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultiplier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset);
                                #endif
                            #endif
                      #elif _EFFECT4USESCALEPINGPONG_ON
                            fixed4 _Effect4_var = ScalePIngPongTex(_Effect4Tex, i.uv2.xy, _Effect4ScaleMultiplier, _Effect4ScaleOrigin, _Effect4ScaleSpeed, _Effect4TimingOffset);
                            #if defined(_EFFECT4USETIMERMASK_ON) && defined(_EFFECT4USEMASK_ON)
                                half2 effect4TimerMaskUV;
                                effect4TimerMaskUV = _Effect4UseTimerMaskBaseUV ? effect4MaskUV : i.uv2.xy;
                                fixed2 _Effect4_TimerMask = tex2D(_Effect4Mask, effect4TimerMaskUV).ba;
                            #endif
                      #else
                            i.uv2.xy = ScaleUV(i.uv2.xy, _Effect4ScaleOrigin);
                            fixed4 _Effect4_var = tex2D(_Effect4Tex, i.uv2.xy);
                            #if defined(_EFFECT4USETIMERMASK_ON) && defined(_EFFECT4USEMASK_ON)
                                half2 effect4TimerMaskUV;
                                effect4TimerMaskUV = _Effect4UseTimerMaskBaseUV ? effect4MaskUV : i.uv2.xy;
                                fixed2 _Effect4_TimerMask = tex2D(_Effect4Mask, effect4TimerMaskUV).ba;
                            #endif
                      #endif
                    #endif

                    #if defined(_EFFECT4USETIMERMASK_ON) && defined(_EFFECT4USEMASK_ON) && !defined(_EFFECT4USESCALE_ON)
                                _Effect4_TimerMask.g *= 0.7777777;
                                fixed effect4TimerMaskInput = frac(_Effect4_TimerMask.g * _Effect4TimerMaskVal.a * _Time.g + _Effect4TimingOffset + _Effect4_TimerMask.r);
                                _Effect4_mask *= smoothstep(_Effect4TimerMaskVal.r, _Effect4TimerMaskVal.r + _Effect4TimerMaskVal.b, effect4TimerMaskInput)
                                                * smoothstep(_Effect4TimerMaskVal.g, _Effect4TimerMaskVal.g - _Effect4TimerMaskVal.b, effect4TimerMaskInput);
                    #endif

                    _Effect4_var *= _Effect4_var.a;
                    effect4Color = pow(_Effect4_var.rgb, _Effect4Power) * _Effect4Color.rgb * _Effect4Color.a * _Effect4Brightness* effect4Mask.r;
                    effect4Color *= _Effect4UseLuminanceMask ? _SpriteLuminanceMask : 1;
                    effect4Color *= _Effect4UseGlow ? i.Glowcolor1.w : 1;

                    effect5Mask.r *= _Effect4BlendMask ? saturate(effect4Color.r) : 1;
                    effect5Mask.g *= _Effect4BlendMask ? saturate(saturate(effect4Color.g) * effect4Mask.g) : 1;
                    //#if _EFFECT4USEMASK_ON
                    effect4Color *= _Effect4_mask.r;
                    //#endif

                    fixed effect4Alpha = _Effect4UseAlpha ? _Effect4_var.a : saturate(Luminance(_Effect4_var) * 4);
                    effect4Alpha *= _Effect4UseGlow ? i.Glowcolor1.w : 1;
                    effect4Alpha *= _Effect4Color.a;

                    //#if _EFFECT4USEMASK_ON
                    effect4Alpha *= _Effect4_mask.r;
                    //#endif

                    #if _REMOVEBASESPRITE_ON
                        finalAlpha = max(finalAlpha,effect4Alpha * effect4Mask.r);
                    #endif

                    finalColor = _Effect4BlendMask ? finalColor : (_Effect4AlphaBlend ? lerp(finalColor, effect4Color, effect4Alpha * effect4Mask.r) : finalColor + effect4Color);

                    #if _REMOVEBASESPRITE_ON
                        finalAlpha += effect4Color;
                    #endif

                    finalColor = saturate(finalColor);
                #endif

                #if _EFFECT5_ON
                    fixed3 effect5Color;
                    half2 effect5MaskUV;
                    effect5MaskUV = _Effect5UseMaskUV ? i.uv4.zw : i.uv4.xy;

                    #if defined(_EFFECT5USEMASK_ON) && defined(_EFFECT5USETIMEROFFSETMASK_ON)
                        fixed2 _Effect5_TimerPreMask = tex2D(_Effect5Mask, i.uv2.zw).ba;
                        float effectTime5 = (_Time.g + _Effect5TimingOffset + _Effect5_TimerPreMask.r * _Effect5TimerMaskVal.a) * _Effect5_TimerPreMask.g;
                        effectTime5 *= -1;
                        #if _EFFECT5USEDIRECTIONALSCROLL_ON
                            #if _EFFECT5USEROTATE_ON
                                #if _EFFECT5USEROTATECURVE_ON
                                i.uv2.zw = ComputeRotateCurveUV(_Effect5Tex, _Effect5Tex_ST, i.uv2.zw, _Effect5RotateCurve);
                                #else
                                i.uv2.zw = ComputeRotateUV(_Effect5Tex, _Effect5Tex_ST, i.uv2.zw, _Effect5RotateSpeed, _Effect5RotateAngle, effectTime5);
                                #endif
                            #endif
                            #if _EFFECT5USESCROLL_ON
                                #if _EFFECT5USESCROLLCURVE_ON
                                i.uv2.zw = i.uv2.zw - (_Effect5ScrollCurve * (0.5 + _Effect5ScaleOrigin));
                                #else
                                i.uv2.zw = ComputeScrollUV(i.uv2.zw, _Effect5VerticalSpeed, _Effect5HorizontalSpeed, _Effect5ScaleOrigin, effectTime5);
                                #endif
                            #endif
                        #else
                            #if _EFFECT5USESCROLL_ON
                                #if _EFFECT5USESCROLLCURVE_ON
                                i.uv2.zw = i.uv2.zw - (_Effect5ScrollCurve * (0.5 + _Effect5ScaleOrigin));
                                #else
                                i.uv2.zw = ComputeScrollUV(i.uv2.zw, _Effect5VerticalSpeed, _Effect5HorizontalSpeed, _Effect5ScaleOrigin, effectTime5);
                                #endif
                            #endif
                            #if _EFFECT5USEROTATE_ON
                                #if _EFFECT5USEROTATECURVE_ON
                                i.uv2.zw = ComputeRotateCurveUV(_Effect5Tex, _Effect5Tex_ST, i.uv2.zw, _Effect5RotateCurve);
                                #else
                                i.uv2.zw = ComputeRotateUV(_Effect5Tex, _Effect5Tex_ST, i.uv2.zw, _Effect5RotateSpeed, _Effect5RotateAngle, effectTime5);
                                #endif
                            #endif
                        #endif

                        i.uv2.zw = CustomTransformTex(i.uv2.zw, _Effect5Tex_ST);
                        i.Glowcolor2.x = _Effect5UseGlow ? cos((effectTime5 * _Effect5GlowSpeed)) * 0.5 + 0.5 : 1;
                    #endif

                    fixed _Effect5_mask = _Effect5UseSpriteMask ? saturate(dot(_Effect5SpriteMaskValue, _SpriteEffectMask_var)) : 1;

                    #if _EFFECT5USEMASK_ON
                        fixed2 effect5MaskTex = tex2D(_Effect5Mask, effect5MaskUV).rg;
                        i.uv2.zw += _Effect5UseDistortMask ? (((effect5MaskTex.g * effect5Mask.g) - 0.5) * 2) * _Effect5MaskDistortStrength : 0;
                        _Effect5_mask *= effect5MaskTex.r;
                    #else
                        i.uv2.zw += _Effect5UseDistortMask ? ((effect5Mask.g - 0.5) * 2) * _Effect5MaskDistortStrength : 0;
                    #endif

                    #if _EFFECT5USEFLIPBOOK_ON
                        #if _EFFECT5USEFLIPBOOKBLEND_ON
                            #if _EFFECT5USESCALE_ON && _EFFECT5USESCALECURVE_ON || _EFFECT5USESCALEPINGPONG_ON && _EFFECT5USESCALECURVE_ON
                                fixed4 _Effect5_var = ScaleCurveTexBlend(_Effect5Tex, i.uv2.zw, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5ScaleCurve, _Effect5FlipbookValue);
                                #if defined(_EFFECT5USETIMERMASK_ON) && defined(_EFFECT5USEMASK_ON)
                                    half2 effect5TimerMaskUV;
                                    effect5TimerMaskUV = _Effect5UseTimerMaskBaseUV ? effect5MaskUV : i.uv2.zw;
                                    fixed2 _Effect5_TimerMask = tex2D(_Effect5Mask, effect5TimerMaskUV).ba;
                                #endif
                            #elif _EFFECT5USESCALE_ON
                                #if defined(_EFFECT5USETIMERMASK_ON) && defined(_EFFECT5USEMASK_ON)	
                                    #if _EFFECT5RANDOMROTATE_ON
		                            fixed4 _Effect5_var = ScaleFlowTexRandomRotateBlend(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultiplier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset, _Effect5Mask, _Effect5TimerMaskVal, _Effect5FlipbookValue);
                                    #else
		                            fixed4 _Effect5_var = ScaleFlowTexBlend(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultiplier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset, _Effect5Mask, _Effect5TimerMaskVal, _Effect5FlipbookValue);
                                    #endif
                                #else
                                    #if _EFFECT5RANDOMROTATE_ON
                                    fixed4 _Effect5_var = ScaleFlowTexRandomRotateBlend(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultiplier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset, _Effect5FlipbookValue);
                                    #else
                                    fixed4 _Effect5_var = ScaleFlowTexBlend(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultiplier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset, _Effect5FlipbookValue);
                                    #endif
                                #endif
                            #elif _EFFECT5USESCALEPINGPONG_ON
                                fixed4 _Effect5_var = ScalePIngPongTexBlend(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultiplier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset, _Effect5FlipbookValue);
                                #if defined(_EFFECT5USETIMERMASK_ON) && defined(_EFFECT5USEMASK_ON)
                                    half2 effect5TimerMaskUV;
                                    effect5TimerMaskUV = _Effect5UseTimerMaskBaseUV ? effect5MaskUV : i.uv2.zw;
                                    fixed2 _Effect5_TimerMask = tex2D(_Effect5Mask, effect5TimerMaskUV).ba;
                                #endif
                            #else
                                i.uv2.zw = ScaleUV(i.uv2.zw, _Effect5ScaleOrigin);
                                float2 _Effect5FlipbookBlendUV = i.uv2.zw;
                                i.uv2.zw = FlipBookUV(i.uv2.zw, _Effect5FlipbookValue);
                                fixed4 _Effect5_var = tex2D(_Effect5Tex, i.uv2.zw);

                                fixed blendVal5 = frac(fmod((_Time.g * _Effect5FlipbookValue.w) + float(0.00001), _Effect5FlipbookValue.x * _Effect5FlipbookValue.y));
                                _Effect5FlipbookValue.z += 1;
                                _Effect5FlipbookBlendUV = FlipBookUV(_Effect5FlipbookBlendUV, _Effect5FlipbookValue);
                                fixed4 _Effect5_var2 = tex2D(_Effect5Tex, _Effect5FlipbookBlendUV);
                                _Effect5_var = lerp(_Effect5_var, _Effect5_var2, blendVal5);
                                #if defined(_EFFECT5USETIMERMASK_ON) && defined(_EFFECT5USEMASK_ON)
                                    half2 effect5TimerMaskUV;
                                    effect5TimerMaskUV = _Effect5UseTimerMaskBaseUV ? effect5MaskUV : i.uv2.zw;
                                    fixed2 _Effect5_TimerMask = tex2D(_Effect5Mask, effect5TimerMaskUV).ba;
                                #endif
                            #endif
                        #else
                            #if _EFFECT5USESCALE_ON && _EFFECT5USESCALECURVE_ON || _EFFECT5USESCALEPINGPONG_ON && _EFFECT5USESCALECURVE_ON
                                fixed4 _Effect5_var = ScaleCurveTex(_Effect5Tex, i.uv2.zw, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5ScaleCurve, _Effect5FlipbookValue);
                                #if defined(_EFFECT5USETIMERMASK_ON) && defined(_EFFECT5USEMASK_ON)
                                    half2 effect5TimerMaskUV;
                                    effect5TimerMaskUV = _Effect5UseTimerMaskBaseUV ? effect5MaskUV : i.uv2.zw;
                                    fixed2 _Effect5_TimerMask = tex2D(_Effect5Mask, effect5TimerMaskUV).ba;
                                #endif
                            #elif _EFFECT5USESCALE_ON
                                #if defined(_EFFECT5USETIMERMASK_ON) && defined(_EFFECT5USEMASK_ON)	
                                    #if _EFFECT5RANDOMROTATE_ON
		                            fixed4 _Effect5_var = ScaleFlowTexRandomRotate(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultiplier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset, _Effect5Mask, _Effect5TimerMaskVal, _Effect5FlipbookValue);
                                    #else
		                            fixed4 _Effect5_var = ScaleFlowTex(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultiplier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset, _Effect5Mask, _Effect5TimerMaskVal, _Effect5FlipbookValue);
                                    #endif
                                #else
                                    #if _EFFECT5RANDOMROTATE_ON
                                    fixed4 _Effect5_var = ScaleFlowTexRandomRotate(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultiplier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset, _Effect5FlipbookValue);
                                    #else
                                    fixed4 _Effect5_var = ScaleFlowTex(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultiplier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset, _Effect5FlipbookValue);
                                    #endif
                                #endif
                            #elif _EFFECT5USESCALEPINGPONG_ON
                                fixed4 _Effect5_var = ScalePIngPongTex(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultiplier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset, _Effect5FlipbookValue);
                                #if defined(_EFFECT5USETIMERMASK_ON) && defined(_EFFECT5USEMASK_ON)
                                    half2 effect5TimerMaskUV;
                                    effect5TimerMaskUV = _Effect5UseTimerMaskBaseUV ? effect5MaskUV : i.uv2.zw;
                                    fixed2 _Effect5_TimerMask = tex2D(_Effect5Mask, effect5TimerMaskUV).ba;
                                #endif
                            #else
                                i.uv2.zw = ScaleUV(i.uv2.zw, _Effect5ScaleOrigin);
                                i.uv2.zw = FlipBookUV(i.uv2.zw, _Effect5FlipbookValue);
                                fixed4 _Effect5_var = tex2D(_Effect5Tex, i.uv2.zw);
                                #if defined(_EFFECT5USETIMERMASK_ON) && defined(_EFFECT5USEMASK_ON)
                                    half2 effect5TimerMaskUV;
                                    effect5TimerMaskUV = _Effect5UseTimerMaskBaseUV ? effect5MaskUV : i.uv2.zw;
                                    fixed2 _Effect5_TimerMask = tex2D(_Effect5Mask, effect5TimerMaskUV).ba;
                                #endif
                            #endif
                        #endif
                    #else
                        #if _EFFECT5USESCALE_ON && _EFFECT5USESCALECURVE_ON || _EFFECT5USESCALEPINGPONG_ON && _EFFECT5USESCALECURVE_ON
                            fixed4 _Effect5_var = ScaleCurveTex(_Effect5Tex, i.uv2.zw, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5ScaleCurve);
                            #if defined(_EFFECT5USETIMERMASK_ON) && defined(_EFFECT5USEMASK_ON)
                                half2 effect5TimerMaskUV;
                                effect5TimerMaskUV = _Effect5UseTimerMaskBaseUV ? effect5MaskUV : i.uv2.zw;
                                fixed2 _Effect5_TimerMask = tex2D(_Effect5Mask, effect5TimerMaskUV).ba;
                            #endif
                        #elif _EFFECT5USESCALE_ON
                            #if defined(_EFFECT5USETIMERMASK_ON) && defined(_EFFECT5USEMASK_ON)
                                #if _EFFECT5RANDOMROTATE_ON
		                        fixed4 _Effect5_var = ScaleFlowTexRandomRotate(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultiplier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset, _Effect5Mask, _Effect5TimerMaskVal);
                                #else
		                        fixed4 _Effect5_var = ScaleFlowTex(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultiplier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset, _Effect5Mask, _Effect5TimerMaskVal);
                                #endif
                            #else
                                #if _EFFECT5RANDOMROTATE_ON
                                fixed4 _Effect5_var = ScaleFlowTexRandomRotate(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultiplier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset);
                                #else
                                fixed4 _Effect5_var = ScaleFlowTex(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultiplier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset);
                                #endif
                            #endif
                        #elif _EFFECT5USESCALEPINGPONG_ON
                            fixed4 _Effect5_var = ScalePIngPongTex(_Effect5Tex, i.uv2.zw, _Effect5ScaleMultiplier, _Effect5ScaleOrigin, _Effect5ScaleSpeed, _Effect5TimingOffset);
                            #if defined(_EFFECT5USETIMERMASK_ON) && defined(_EFFECT5USEMASK_ON)
                                half2 effect5TimerMaskUV;
                                effect5TimerMaskUV = _Effect5UseTimerMaskBaseUV ? effect5MaskUV : i.uv2.zw;
                                fixed2 _Effect5_TimerMask = tex2D(_Effect5Mask, effect5TimerMaskUV).ba;
                            #endif
                        #else
                            i.uv2.zw = ScaleUV(i.uv2.zw, _Effect5ScaleOrigin);
                            fixed4 _Effect5_var = tex2D(_Effect5Tex, i.uv2.zw);
                            #if defined(_EFFECT5USETIMERMASK_ON) && defined(_EFFECT5USEMASK_ON)
                                half2 effect5TimerMaskUV;
                                effect5TimerMaskUV = _Effect5UseTimerMaskBaseUV ? effect5MaskUV : i.uv2.zw;
                                fixed2 _Effect5_TimerMask = tex2D(_Effect5Mask, effect5TimerMaskUV).ba;
                            #endif
                        #endif
                    #endif

                    #if defined(_EFFECT5USETIMERMASK_ON) && defined(_EFFECT5USEMASK_ON) && !defined(_EFFECT5USESCALE_ON)
                                _Effect5_TimerMask.g *= 0.7777777;
                                fixed effect5TimerMaskInput = frac(_Effect5_TimerMask.g * _Effect5TimerMaskVal.a * _Time.g+ _Effect5TimingOffset + _Effect5_TimerMask.r);
                                _Effect5_mask *= smoothstep(_Effect5TimerMaskVal.r, _Effect5TimerMaskVal.r + _Effect5TimerMaskVal.b, effect5TimerMaskInput)
                                                * smoothstep(_Effect5TimerMaskVal.g, _Effect5TimerMaskVal.g - _Effect5TimerMaskVal.b, effect5TimerMaskInput);
                    #endif

                    _Effect5_var *= _Effect5_var.a;
                    effect5Color = pow(_Effect5_var.rgb, _Effect5Power) * _Effect5Color.rgb * _Effect5Color.a * _Effect5Brightness* effect5Mask.r;
                    effect5Color *= _Effect5UseLuminanceMask ? _SpriteLuminanceMask : 1;
                    effect5Color *= _Effect5UseGlow ? i.Glowcolor2.x : 1;

                    effect6Mask.r *= _Effect5BlendMask ? saturate(effect5Color.r) : 1;
                    effect6Mask.g *= _Effect5BlendMask ? saturate(saturate(effect5Color.g) * effect5Mask.g) : 1;

                    //#if _EFFECT5USEMASK_ON                        
                    effect5Color *= _Effect5_mask.r;
                    //#endif

                    fixed effect5Alpha = _Effect5UseAlpha ? _Effect5_var.a : saturate(Luminance(_Effect5_var) * 4);
                    effect5Alpha *= _Effect5UseGlow ? i.Glowcolor2.x : 1;
                    effect5Alpha *= _Effect5Color.a;

                    //#if _EFFECT5USEMASK_ON
                    effect5Alpha *= _Effect5_mask.r;
                    //#endif

                    #if _REMOVEBASESPRITE_ON
                        finalAlpha = max(finalAlpha,effect5Alpha * effect5Mask.r);
                    #endif

                    finalColor = _Effect5BlendMask ? finalColor : (_Effect5AlphaBlend ? lerp(finalColor, effect5Color, effect5Alpha * effect5Mask.r) : finalColor + effect5Color);

                    #if _REMOVEBASESPRITE_ON
                        finalAlpha += effect5Color;
                    #endif

                    finalColor = saturate(finalColor);
                #endif

                #if _EFFECT6_ON
                    fixed3 effect6Color;
                    half2 effect6MaskUV;
                    effect6MaskUV = _Effect6UseMaskUV ? i.uv4.zw : i.uv4.xy;

                    #if defined(_EFFECT6USEMASK_ON) && defined(_EFFECT6USETIMEROFFSETMASK_ON)
                        fixed2 _Effect6_TimerPreMask = tex2D(_Effect6Mask, i.uv3.xy).ba;
                        float effectTime6 = (_Time.g + _Effect6TimingOffset + _Effect6_TimerPreMask.r * _Effect6TimerMaskVal.a) * _Effect6_TimerPreMask.g;
                        effectTime6 *= -1;
                        #if _EFFECT6USEDIRECTIONALSCROLL_ON
                            #if _EFFECT6USEROTATE_ON
                                #if _EFFECT6USEROTATECURVE_ON
                                i.uv3.xy = ComputeRotateCurveUV(_Effect6Tex, _Effect6Tex_ST, i.uv3.xy, _Effect6RotateCurve);
                                #else
                                i.uv3.xy = ComputeRotateUV(_Effect6Tex, _Effect6Tex_ST, i.uv3.xy, _Effect6RotateSpeed, _Effect6RotateAngle, effectTime6);
                                #endif
                            #endif
                            #if _EFFECT6USESCROLL_ON
                                #if _EFFECT6USESCROLLCURVE_ON
                                i.uv3.xy = i.uv3.xy - (_Effect6ScrollCurve * (0.5 + _Effect6ScaleOrigin));
                                #else
                                i.uv3.xy = ComputeScrollUV(i.uv3.xy, _Effect6VerticalSpeed, _Effect6HorizontalSpeed, _Effect6ScaleOrigin, effectTime6);
                                #endif
                            #endif
                        #else
                            #if _EFFECT6USESCROLL_ON
                                #if _EFFECT6USESCROLLCURVE_ON
                                i.uv3.xy = i.uv3.xy - (_Effect6ScrollCurve * (0.5 + _Effect6ScaleOrigin));
                                #else
                                i.uv3.xy = ComputeScrollUV(i.uv3.xy, _Effect6VerticalSpeed, _Effect6HorizontalSpeed, _Effect6ScaleOrigin, effectTime6);
                                #endif
                            #endif
                            #if _EFFECT6USEROTATE_ON
                                #if _EFFECT6USEROTATECURVE_ON
                                i.uv3.xy = ComputeRotateCurveUV(_Effect6Tex, _Effect6Tex_ST, i.uv3.xy, _Effect6RotateCurve);
                                #else
                                i.uv3.xy = ComputeRotateUV(_Effect6Tex, _Effect6Tex_ST, i.uv3.xy, _Effect6RotateSpeed, _Effect6RotateAngle, effectTime6);
                                #endif
                            #endif
                        #endif

                        i.uv3.xy = CustomTransformTex(i.uv3.xy, _Effect6Tex_ST);
                        i.Glowcolor2.y = _Effect6UseGlow ? cos((effectTime6 * _Effect6GlowSpeed)) * 0.5 + 0.5 : 1;
                    #endif

                    fixed _Effect6_mask = _Effect6UseSpriteMask ? saturate(dot(_Effect6SpriteMaskValue, _SpriteEffectMask_var)) : 1;

                    #if _EFFECT6USEMASK_ON
                        fixed2 effect6MaskTex = tex2D(_Effect6Mask, effect6MaskUV).rg;
                        i.uv3.xy += _Effect6UseDistortMask ? (((effect6MaskTex.g * effect6Mask.g) - 0.5) * 2) * _Effect6MaskDistortStrength : 0;
                        _Effect6_mask *= effect6MaskTex.r;
                    #else
                        i.uv3.xy += _Effect6UseDistortMask ? ((effect6Mask.g - 0.5) * 2) * _Effect6MaskDistortStrength * 0.2 : 0;
                    #endif

                    #if _EFFECT6USEFLIPBOOK_ON
                        #if _EFFECT6USEFLIPBOOKBLEND_ON
                            #if _EFFECT6USESCALE_ON && _EFFECT6USESCALECURVE_ON || _EFFECT6USESCALEPINGPONG_ON && _EFFECT6USESCALECURVE_ON
                                fixed4 _Effect6_var = ScaleCurveTexBlend(_Effect6Tex, i.uv3.xy, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6ScaleCurve, _Effect6FlipbookValue);
                                #if defined(_EFFECT6USETIMERMASK_ON) && defined(_EFFECT6USEMASK_ON)	
                                    half2 effect6TimerMaskUV;
                                    effect6TimerMaskUV = _Effect6UseTimerMaskBaseUV ? effect6MaskUV : i.uv3.xy;
                                    fixed2 _Effect6_TimerMask = tex2D(_Effect6Mask, effect6TimerMaskUV).ba;
                                #endif
                            #elif _EFFECT6USESCALE_ON
                                #if defined(_EFFECT6USETIMERMASK_ON) && defined(_EFFECT6USEMASK_ON)
                                    #if _EFFECT6RANDOMROTATE_ON
		                            fixed4 _Effect6_var = ScaleFlowTexRandomRotateBlend(_Effect6Tex, i.uv3.xy, _Effect6ScaleMultiplier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset, _Effect6Mask, _Effect6TimerMaskVal, _Effect6FlipbookValue);
                                    #else
		                            fixed4 _Effect6_var = ScaleFlowTexBlend(_Effect6Tex, i.uv3.xy, _Effect6ScaleMultiplier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset, _Effect6Mask, _Effect6TimerMaskVal, _Effect6FlipbookValue);
                                    #endif
                                #else
                                    #if _EFFECT6RANDOMROTATE_ON
                                    fixed4 _Effect6_var = ScaleFlowTexRandomRotateBlend(_Effect6Tex, i.uv3.xy, _Effect6ScaleMultiplier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset, _Effect6FlipbookValue);
                                    #else
                                    fixed4 _Effect6_var = ScaleFlowTexBlend(_Effect6Tex, i.uv3.xy, _Effect6ScaleMultiplier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset, _Effect6FlipbookValue);
                                    #endif
                                #endif
                            #elif _EFFECT6USESCALEPINGPONG_ON
                                fixed4 _Effect6_var = ScalePIngPongTexBlend(_Effect6Tex, i.uv3.xy, _Effect6ScaleMultiplier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset, _Effect6FlipbookValue);
                                #if defined(_EFFECT6USETIMERMASK_ON) && defined(_EFFECT6USEMASK_ON)
                                    half2 effect6TimerMaskUV;
                                    effect6TimerMaskUV = _Effect6UseTimerMaskBaseUV ? effect6MaskUV : i.uv3.xy;
                                    fixed2 _Effect6_TimerMask = tex2D(_Effect6Mask, effect6TimerMaskUV).ba;
                                #endif
                            #else
                                i.uv3.xy = ScaleUV(i.uv3.xy, _Effect6ScaleOrigin);
                                float2 _Effect6FlipbookBlendUV = i.uv3.xy;
                                i.uv3.xy = FlipBookUV(i.uv3.xy, _Effect6FlipbookValue);
                                fixed4 _Effect6_var = tex2D(_Effect6Tex, i.uv3.xy);
                                fixed blendVal6 = frac(fmod((_Time.g * _Effect6FlipbookValue.w) + float(0.00001), _Effect6FlipbookValue.x * _Effect6FlipbookValue.y));
                                _Effect6FlipbookValue.z += 1;
                                _Effect6FlipbookBlendUV = FlipBookUV(_Effect6FlipbookBlendUV, _Effect6FlipbookValue);
                                fixed4 _Effect6_var2 = tex2D(_Effect6Tex, _Effect6FlipbookBlendUV);
                                _Effect6_var = lerp(_Effect6_var, _Effect6_var2, blendVal6);
                                #if defined(_EFFECT6USETIMERMASK_ON) && defined(_EFFECT6USEMASK_ON)
                                    half2 effect6TimerMaskUV;
                                    effect6TimerMaskUV = _Effect6UseTimerMaskBaseUV ? effect6MaskUV : i.uv3.xy;
                                    fixed2 _Effect6_TimerMask = tex2D(_Effect6Mask, effect6TimerMaskUV).ba;
                                #endif
                            #endif
                        #else
                            #if _EFFECT6USESCALE_ON && _EFFECT6USESCALECURVE_ON || _EFFECT6USESCALEPINGPONG_ON && _EFFECT6USESCALECURVE_ON
                                fixed4 _Effect6_var = ScaleCurveTex(_Effect6Tex, i.uv3.xy, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6ScaleCurve, _Effect6FlipbookValue);
                                #if defined(_EFFECT6USETIMERMASK_ON) && defined(_EFFECT6USEMASK_ON)
                                    half2 effect6TimerMaskUV;
                                    effect6TimerMaskUV = _Effect6UseTimerMaskBaseUV ? effect6MaskUV : i.uv3.xy;
                                    fixed2 _Effect6_TimerMask = tex2D(_Effect6Mask, effect6TimerMaskUV).ba;
                                #endif
                            #elif _EFFECT6USESCALE_ON
                                #if defined(_EFFECT6USETIMERMASK_ON) && defined(_EFFECT6USEMASK_ON)
                                    #if _EFFECT6RANDOMROTATE_ON
		                            fixed4 _Effect6_var = ScaleFlowTexRandomRotate(_Effect6Tex, i.uv3.xy, _Effect6ScaleMultiplier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset, _Effect6Mask, _Effect6TimerMaskVal, _Effect6FlipbookValue);
                                    #else
		                            fixed4 _Effect6_var = ScaleFlowTex(_Effect6Tex, i.uv3.xy, _Effect6ScaleMultiplier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset, _Effect6Mask, _Effect6TimerMaskVal, _Effect6FlipbookValue);
                                    #endif
                                #else
                                    #if _EFFECT6RANDOMROTATE_ON
                                    fixed4 _Effect6_var = ScaleFlowTexRandomRotate(_Effect6Tex, i.uv3.xy, _Effect6ScaleMultiplier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset, _Effect6FlipbookValue);
                                    #else
                                    fixed4 _Effect6_var = ScaleFlowTex(_Effect6Tex, i.uv3.xy, _Effect6ScaleMultiplier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset, _Effect6FlipbookValue);
                                    #endif
                                #endif
                            #elif _EFFECT6USESCALEPINGPONG_ON
                                fixed4 _Effect6_var = ScalePIngPongTex(_Effect6Tex, i.uv3.xy, _Effect6ScaleMultiplier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset, _Effect6FlipbookValue);
                                #if defined(_EFFECT6USETIMERMASK_ON) && defined(_EFFECT6USEMASK_ON)
                                    half2 effect6TimerMaskUV;
                                    effect6TimerMaskUV = _Effect6UseTimerMaskBaseUV ? effect6MaskUV : i.uv3.xy;
                                    fixed2 _Effect6_TimerMask = tex2D(_Effect6Mask, effect6TimerMaskUV).ba;
                                #endif
                            #else
                                i.uv3.xy = ScaleUV(i.uv3.xy, _Effect6ScaleOrigin);
                                i.uv3.xy = FlipBookUV(i.uv3.xy, _Effect6FlipbookValue);
                                fixed4 _Effect6_var = tex2D(_Effect6Tex, i.uv3.xy);
                                #if defined(_EFFECT6USETIMERMASK_ON) && defined(_EFFECT6USEMASK_ON)
                                    half2 effect6TimerMaskUV;
                                    effect6TimerMaskUV = _Effect6UseTimerMaskBaseUV ? effect6MaskUV : i.uv3.xy;
                                    fixed2 _Effect6_TimerMask = tex2D(_Effect6Mask, effect6TimerMaskUV).ba;
                                #endif
                            #endif
                        #endif
                    #else
                        #if _EFFECT6USESCALE_ON && _EFFECT6USESCALECURVE_ON || _EFFECT6USESCALEPINGPONG_ON && _EFFECT6USESCALECURVE_ON
                            fixed4 _Effect6_var = ScaleCurveTex(_Effect6Tex, i.uv3.xy, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6ScaleCurve);
                            #if defined(_EFFECT6USETIMERMASK_ON) && defined(_EFFECT6USEMASK_ON)
                                half2 effect6TimerMaskUV;
                                effect6TimerMaskUV = _Effect6UseTimerMaskBaseUV ? effect6MaskUV : i.uv3.xy;
                                fixed2 _Effect6_TimerMask = tex2D(_Effect6Mask, effect6TimerMaskUV).ba;
                            #endif
                        #elif _EFFECT6USESCALE_ON
                            #if defined(_EFFECT6USETIMERMASK_ON) && defined(_EFFECT6USEMASK_ON)
                                #if _EFFECT6RANDOMROTATE_ON
		                        fixed4 _Effect6_var = ScaleFlowTexRandomRotate(_Effect6Tex, i.uv3.xy, _Effect6ScaleMultiplier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset, _Effect6Mask, _Effect6TimerMaskVal);
                                #else
		                        fixed4 _Effect6_var = ScaleFlowTex(_Effect6Tex, i.uv3.xy, _Effect6ScaleMultiplier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset, _Effect6Mask, _Effect6TimerMaskVal);
                                #endif
                            #else
                                #if _EFFECT6RANDOMROTATE_ON
                                fixed4 _Effect6_var = ScaleFlowTexRandomRotate(_Effect6Tex, i.uv3.xy, _Effect6ScaleMultiplier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset);
                                #else
                                fixed4 _Effect6_var = ScaleFlowTex(_Effect6Tex, i.uv3.xy, _Effect6ScaleMultiplier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset);
                                #endif
                            #endif
                        #elif _EFFECT6USESCALEPINGPONG_ON
                            fixed4 _Effect6_var = ScalePIngPongTex(_Effect6Tex, i.uv3.xy, _Effect6ScaleMultiplier, _Effect6ScaleOrigin, _Effect6ScaleSpeed, _Effect6TimingOffset);
                            #if defined(_EFFECT6USETIMERMASK_ON) && defined(_EFFECT6USEMASK_ON)
                                half2 effect6TimerMaskUV;
                                effect6TimerMaskUV = _Effect6UseTimerMaskBaseUV ? effect6MaskUV : i.uv3.xy;
                                fixed2 _Effect6_TimerMask = tex2D(_Effect6Mask, effect6TimerMaskUV).ba;
                            #endif
                        #else
                            i.uv3.xy = ScaleUV(i.uv3.xy, _Effect6ScaleOrigin);
                            fixed4 _Effect6_var = tex2D(_Effect6Tex, i.uv3.xy);
                            #if defined(_EFFECT6USETIMERMASK_ON) && defined(_EFFECT6USEMASK_ON)
                                half2 effect6TimerMaskUV;
                                effect6TimerMaskUV = _Effect6UseTimerMaskBaseUV ? effect6MaskUV : i.uv3.xy;
                                fixed2 _Effect6_TimerMask = tex2D(_Effect6Mask, effect6TimerMaskUV).ba;
                            #endif
                        #endif
                    #endif

                    #if defined(_EFFECT6USETIMERMASK_ON) && defined(_EFFECT6USEMASK_ON) && !defined(_EFFECT6USESCALE_ON)
                                _Effect6_TimerMask.g *= 0.7777777;
                                fixed effect6TimerMaskInput = frac(_Effect6_TimerMask.g * _Effect6TimerMaskVal.a * _Time.g + _Effect6TimingOffset + _Effect6_TimerMask.r);
                                _Effect6_mask *= smoothstep(_Effect6TimerMaskVal.r, _Effect6TimerMaskVal.r + _Effect6TimerMaskVal.b, effect6TimerMaskInput)
                                                * smoothstep(_Effect6TimerMaskVal.g, _Effect6TimerMaskVal.g - _Effect6TimerMaskVal.b, effect6TimerMaskInput);
                    #endif

                    _Effect6_var *= _Effect6_var.a.r;
                    effect6Color = pow(_Effect6_var.rgb, _Effect6Power) * _Effect6Color.rgb * _Effect6Color.a * _Effect6Brightness* effect6Mask.r;
                    effect6Color *= _Effect6UseLuminanceMask?_SpriteLuminanceMask:1;
                    effect6Color *= _Effect6UseGlow ? i.Glowcolor2.y : 1;

                    //#if _EFFECT6USEMASK_ON                     
                    effect6Color *= _Effect6_mask.r;
                    //#endif

                    fixed effect6Alpha = _Effect6UseAlpha ? _Effect6_var.a : saturate(Luminance(_Effect6_var) * 4);
                    effect6Alpha *= _Effect6UseGlow ? i.Glowcolor2.y : 1;
                    effect6Alpha *= _Effect6Color.a;

                    //#if _EFFECT6USEMASK_ON
                    effect6Alpha *= _Effect6_mask.r;
                    //#endif

                    #if _REMOVEBASESPRITE_ON
                    finalAlpha = max(finalAlpha,effect6Alpha * effect6Mask.r);
                    #endif

                    finalColor = _Effect6AlphaBlend ? lerp(finalColor, effect6Color, effect6Alpha * effect6Mask.r) : finalColor + effect6Color;

                    #if _REMOVEBASESPRITE_ON
                    finalAlpha += effect6Color;
                    #endif

                    finalColor = saturate(finalColor);
                #endif

                #if _BASECUTOUT_ON
                    fixed cutOutMask = tex2D(_BaseCutOutTex, i.uv3.zw).r;
                    fixed cutOff = max(0.01, _BaseCutOutVal.x);
                    cutOutMask = remap(cutOutMask, 0, 1, _BaseCutOutVal.z, _BaseCutOutVal.w);
                    cutOutMask = pow(cutOutMask, _BaseCutOutVal.y);
                    fixed cutOutMask1 = saturate(InverseLerp_float(0, cutOff, cutOutMask + cutOff - (1 - cutOutVal)) * 1.5);

                    #if _BASECUTOUTEDGECOLOR_ON
                    fixed cutoutEdgeFeather = 0.05;
                    fixed3 cutoutEdgeColor = _BaseCutOutEdgeColor.rgb * _BaseCutOutEdgeColorBrightness;
                    fixed cutOutMask2 = saturate(InverseLerp_float(0, cutoutEdgeFeather, cutOutMask + cutoutEdgeFeather - (1 - cutOutVal)));
                    #endif

                    #if _BASECUTOUTFILLCOLOR_ON
                    finalColor.rgb = lerp(_BaseCutOutFillColor.rgb * _BaseCutOutFillColorBrightness, finalColor.rgb, pow(cutOutVal,2.2) * _BaseCutOutFillColor.a);
                    #endif

                    #if _BASECUTOUTEDGECOLOR_ON
                    finalColor.rgb = lerp(cutOutMask1 * lerp(finalColor.rgb, cutoutEdgeColor, _BaseCutOutEdgeColor.a* saturate(_BaseCutOutEdgeColorBrightness)), finalColor.rgb, cutOutMask2);
                    #endif
                    _Mask_var.a *= cutOutMask1;
                #endif

                finalColor = saturate(finalColor* _Mask_var.a);

                //return debug;
                #if _REMOVEBASESPRITE_ON
                return fixed4(finalColor, saturate(finalAlpha * _Mask_var.a));
                #else
                return fixed4(finalColor, _Mask_var.a);
                #endif
            }
            ENDCG
        }
    }
    //CustomEditor "UIEffectShaderGUI"
    FallBack "Mobile/Particles/Additive"
}
