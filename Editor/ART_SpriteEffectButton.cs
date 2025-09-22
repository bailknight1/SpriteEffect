using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Text.RegularExpressions;

[CustomEditor(typeof(ART_SpriteEffect)), CanEditMultipleObjects]

public class ART_SpriteEffectButton : Editor
{

    private static class MyEditorStyles    //https://discussions.unity.com/t/editorstyles-null-reference/238470/3
    {
        public static GUIStyle customStyle;
        static MyEditorStyles()
        {
            customStyle = new GUIStyle(EditorStyles.boldLabel);
            customStyle.normal.textColor = Color.white;
            customStyle.focused.textColor = Color.white;
            customStyle.fontSize = 20;
        }
    }
    ART_SpriteEffect spriteEffect;

    const int _numOfLayer = 6;

    public SerializedProperty[] effect_Texture = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_TextureTileOffset = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseFlipBook = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseFlipBookBlend = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_FlipBookValue = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseSpriteMask = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_SpriteMaskValue = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_Mask = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseMaskUV = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UniformUV = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseTimerMask = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_TimerMaskValue = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_TimerMaskBaseUV = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_Color = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_Gradient = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_Brightness = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScaleOrigin = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScaleMultiplier = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScaleSpeed = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScalePingPong = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_RandomRotate = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_Power = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_RotateAngle = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_RotateSpeed = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_VerticalSpeed = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_HorizontalSpeed = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScrollDirection = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_GlowSpeed = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_TimingOffset = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_BlendMode = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseAlpha = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_DistortStrength = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseScrollCurve = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseRotateCurve = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseScaleCurve = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseColorCurve = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseFlipBookCurve = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScrollCurveX = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScrollCurveY = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_RotateCurve = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScaleCurve = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ColorCurve = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_FlipBookCurve = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_Active = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseLuminanceMask = new SerializedProperty[_numOfLayer];
    //public SerializedProperty[] effect_ValueFolderOpen = new SerializedProperty[_numOfLayer];

    public SerializedProperty[] effect_Texture_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_TextureTileOffset_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseFlipBook_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseFlipBookBlend_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_FlipBookValue_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseSpriteMask_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_SpriteMaskValue_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_Mask_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseMaskUV_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UniformUV_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseTimerMask_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_TimerMaskValue_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_TimerMaskBaseUV_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_Color_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_Gradient_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_Brightness_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScaleOrigin_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScaleMultiplier_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScaleSpeed_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScalePingPong_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_RandomRotate_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_Power_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_RotateAngle_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_RotateSpeed_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_VerticalSpeed_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_HorizontalSpeed_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScrollDirection_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_GlowSpeed_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_TimingOffset_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_BlendMode_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseAlpha_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_DistortStrength_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseScrollCurve_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseRotateCurve_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseScaleCurve_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseColorCurve_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseFlipBookCurve_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScrollCurveX_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScrollCurveY_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_RotateCurve_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ScaleCurve_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_ColorCurve_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_FlipBookCurve_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_Active_override = new SerializedProperty[_numOfLayer];
    public SerializedProperty[] effect_UseLuminanceMask_override = new SerializedProperty[_numOfLayer];

    private bool[] _isEffectActive = new bool[_numOfLayer];
    private bool[] _isEffectValueOpen = new bool[_numOfLayer];

    private bool _isEffectEnabled;

    private int _layerToRemove = -1;

    private GUIStyle guiTextStyle;

    SerializedProperty effectMaterial;
    SerializedProperty effects;
    SerializedProperty effect_Name;

    private bool _isSpriteValueOpen;
    SerializedProperty effect_SpriteGrayScaleMode;
    SerializedProperty effect_SpriteGrayScaleValue;
    SerializedProperty effect_SpriteGrayScaleUseCurve;
    SerializedProperty effect_SpriteGrayScaleCurve;

    SerializedProperty effect_SpriteBrightnessMode;
    SerializedProperty effect_SpriteBrightnessValue;
    SerializedProperty effect_SpriteBrightnessUseCurve;
    SerializedProperty effect_SpriteBrightnessCurve;
    SerializedProperty effect_SpriteBrightnessUseLuminanceMask;

    SerializedProperty effect_SpriteTintColorMode;
    SerializedProperty effect_SpriteTintColorValue;
    SerializedProperty effect_SpriteTintColorUseCurve;
    SerializedProperty effect_SpriteTintColorCurve;
    SerializedProperty effect_SpriteTintColorGradient;
    SerializedProperty effect_SpriteTintColorUseLuminanceMask;

    SerializedProperty effect_SpriteCutOutMode;
    SerializedProperty effect_SpriteCutOutValue;
    SerializedProperty effect_SpriteCutOutTexture;
    SerializedProperty effect_SpriteCutOutEdgeColor;
    SerializedProperty effect_SpriteCutOutEdgeBrightness;
    SerializedProperty effect_SpriteCutOutFillColor;
    SerializedProperty effect_SpriteCutOutFillBrightness;
    SerializedProperty effect_SpriteCutOutTextureTileOffset;
    SerializedProperty effect_SpriteCutOutUseSliceUV;
    SerializedProperty effect_SpriteCutOutUniformUV;
    SerializedProperty effect_SpriteCutOutDoNotUseAlpha;
    SerializedProperty effect_SpriteCutOutProgress;
    SerializedProperty effect_SpriteCutOutUseCurve;
    SerializedProperty effect_SpriteCutOutCurve;

    SerializedProperty effect_SpriteVertexAnimMode;
    SerializedProperty effect_SpriteVertexAnimValue;

    SerializedProperty effect_SpriteTransparentMode;
    SerializedProperty effect_UseUnscaledTime;
    SerializedProperty effect_LuminanceMaskThresholdMin;
    SerializedProperty effect_LuminanceMaskThresholdMax;

    SerializedProperty effect_SpriteGrayScaleMode_override;
    SerializedProperty effect_SpriteGrayScaleValue_override;
    SerializedProperty effect_SpriteGrayScaleUseCurve_override;
    SerializedProperty effect_SpriteGrayScaleCurve_override;

    SerializedProperty effect_SpriteBrightnessMode_override;
    SerializedProperty effect_SpriteBrightnessValue_override;
    SerializedProperty effect_SpriteBrightnessUseCurve_override;
    SerializedProperty effect_SpriteBrightnessCurve_override;
    SerializedProperty effect_SpriteBrightnessUseLuminanceMask_override;

    SerializedProperty effect_SpriteTintColorMode_override;
    SerializedProperty effect_SpriteTintColorValue_override;
    SerializedProperty effect_SpriteTintColorUseCurve_override;
    SerializedProperty effect_SpriteTintColorCurve_override;
    SerializedProperty effect_SpriteTintColorGradient_override;
    SerializedProperty effect_SpriteTintColorUseLuminanceMask_override;

    SerializedProperty effect_SpriteCutOutMode_override;
    SerializedProperty effect_SpriteCutOutValue_override;
    SerializedProperty effect_SpriteCutOutTexture_override;
    SerializedProperty effect_SpriteCutOutEdgeColor_override;
    SerializedProperty effect_SpriteCutOutEdgeBrightness_override;
    SerializedProperty effect_SpriteCutOutFillColor_override;
    SerializedProperty effect_SpriteCutOutFillBrightness_override;
    SerializedProperty effect_SpriteCutOutTextureTileOffset_override;
    SerializedProperty effect_SpriteCutOutUseSliceUV_override;
    SerializedProperty effect_SpriteCutOutUniformUV_override;
    SerializedProperty effect_SpriteCutOutDoNotUseAlpha_override;
    SerializedProperty effect_SpriteCutOutProgress_override;
    SerializedProperty effect_SpriteCutOutUseCurve_override;
    SerializedProperty effect_SpriteCutOutCurve_override;

    SerializedProperty effect_SpriteVertexAnimMode_override;
    SerializedProperty effect_SpriteVertexAnimValue_override;

    SerializedProperty effect_SpriteTransparentMode_override;
    SerializedProperty effect_UseUnscaledTime_override;
    SerializedProperty effect_LuminanceMaskThresholdMin_override;
    SerializedProperty effect_LuminanceMaskThresholdMax_override;


    private string effectName;
    private const string resourcesPath = "Assets/Resources";
    private const string materialAssetFolderName = "SpriteEffectMaterial";
    private string assetPath;

    private bool holdCtrlKey = false;
    private bool holdAltKey = false;
    private Color darkRedColor = new Color(0.7f, 0.0f, 0.0f);

    private bool confirmRemove = false;  //인스팩터창이 하나 이상일 경우 버튼의 마우스위치 판정 문제처리용
    private Color removeButtonColor = new Color(0.3f, 0.0f, 0.0f);

    private bool overrideCheckBool = true;  //에디터창이 인스팩터에 활성화될때 한번만 체크하기 위해...

    private void OnSceneGUI(SceneView sceneView)
    {
        if (Event.current.modifiers == EventModifiers.Control)
        {
            if (!holdCtrlKey)
            {
                 EditorUtility.SetDirty(this);
                this.Repaint();
                holdCtrlKey = true;
            }
        }
        else if (holdCtrlKey)
        {
            holdCtrlKey = false;
            EditorUtility.SetDirty(this);
            this.Repaint();
        }

        if (Event.current.modifiers == EventModifiers.Alt)
        {
            if (!holdAltKey)
            {
                EditorUtility.SetDirty(this);
                this.Repaint();
                holdAltKey = true;
            }
        }
        else if (holdAltKey)
        {
            holdAltKey = false;
            EditorUtility.SetDirty(this);
            this.Repaint();
        }
    }

    void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
        Initialize();
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    void Initialize()
    {
         spriteEffect = (ART_SpriteEffect)target;
        effectMaterial = serializedObject.FindProperty("createdMaterial");
        effects = serializedObject.FindProperty("spriteEffectLayers");
        effect_Name = serializedObject.FindProperty("name");
        effectName = effect_Name.stringValue;
        effect_SpriteTransparentMode = serializedObject.FindProperty("setSpriteTransparent").FindPropertyRelative("boolValue");
        effect_SpriteGrayScaleMode = serializedObject.FindProperty("setSpriteGrayScale").FindPropertyRelative("boolValue");
        effect_SpriteGrayScaleValue = serializedObject.FindProperty("spriteGrayScaleValue").FindPropertyRelative("floatValue");
        effect_SpriteGrayScaleUseCurve = serializedObject.FindProperty("spriteGrayScaleUseCurve").FindPropertyRelative("boolValue");
        effect_SpriteGrayScaleCurve = serializedObject.FindProperty("spriteGrayScaleCurve");

        effect_SpriteBrightnessMode = serializedObject.FindProperty("setSpriteBrightness").FindPropertyRelative("boolValue");
        effect_SpriteBrightnessValue = serializedObject.FindProperty("spriteBrightnessValue").FindPropertyRelative("floatValue");
        effect_SpriteBrightnessUseCurve = serializedObject.FindProperty("spriteBrightnessUseCurve").FindPropertyRelative("boolValue");
        effect_SpriteBrightnessCurve = serializedObject.FindProperty("spriteBrightnessCurve");
        effect_SpriteBrightnessUseLuminanceMask = serializedObject.FindProperty("spriteBrightnessUseLuminanceMask").FindPropertyRelative("boolValue");

        effect_SpriteTintColorMode = serializedObject.FindProperty("setSpriteTintColor").FindPropertyRelative("boolValue");
        effect_SpriteTintColorValue = serializedObject.FindProperty("spriteTintColorValue").FindPropertyRelative("colorValue");
        effect_SpriteTintColorUseCurve = serializedObject.FindProperty("spriteTintColorUseCurve").FindPropertyRelative("boolValue");
        effect_SpriteTintColorCurve = serializedObject.FindProperty("spriteTintColorCurve");
        effect_SpriteTintColorGradient = serializedObject.FindProperty("spriteTintColorGradient").FindPropertyRelative("gradientValue");
        effect_SpriteTintColorUseLuminanceMask = serializedObject.FindProperty("spriteTintColorUseLuminanceMask").FindPropertyRelative("boolValue");

        effect_SpriteCutOutMode = serializedObject.FindProperty("setSpriteCutOut").FindPropertyRelative("boolValue");
        effect_SpriteCutOutValue = serializedObject.FindProperty("spriteCutOutValue").FindPropertyRelative("vector4Value");
        effect_SpriteCutOutTexture = serializedObject.FindProperty("spriteCutOutTexture").FindPropertyRelative("textureValue");
        effect_SpriteCutOutTextureTileOffset = serializedObject.FindProperty("spriteCutOutTextureTileOffset").FindPropertyRelative("vector4Value");
        effect_SpriteCutOutEdgeColor = serializedObject.FindProperty("spriteCutOutEdgeColor").FindPropertyRelative("colorValue");
        effect_SpriteCutOutEdgeBrightness = serializedObject.FindProperty("spriteCutOutEdgeBrightness").FindPropertyRelative("floatValue");
        effect_SpriteCutOutFillColor = serializedObject.FindProperty("spriteCutOutFillColor").FindPropertyRelative("colorValue");
        effect_SpriteCutOutFillBrightness = serializedObject.FindProperty("spriteCutOutFillBrightness").FindPropertyRelative("floatValue");
        effect_SpriteCutOutUseSliceUV = serializedObject.FindProperty("spriteCutOutUseSliceUV").FindPropertyRelative("boolValue");
        effect_SpriteCutOutUniformUV = serializedObject.FindProperty("spriteCutOutUniformUV").FindPropertyRelative("boolValue");
        effect_SpriteCutOutDoNotUseAlpha = serializedObject.FindProperty("spriteCutOutDoNotUseAlpha").FindPropertyRelative("boolValue");
        effect_SpriteCutOutProgress = serializedObject.FindProperty("spriteCutOutProgress").FindPropertyRelative("floatValue");
        effect_SpriteCutOutUseCurve = serializedObject.FindProperty("spriteCutOutUseCurve").FindPropertyRelative("boolValue");
        effect_SpriteCutOutCurve = serializedObject.FindProperty("spriteCutOutCurve");

        effect_SpriteVertexAnimMode = serializedObject.FindProperty("setSpriteVertexAnim").FindPropertyRelative("boolValue");
        effect_SpriteVertexAnimValue = serializedObject.FindProperty("spriteVertexAnimValue").FindPropertyRelative("vector4Value");

        effect_UseUnscaledTime = serializedObject.FindProperty("useUnscaledTime").FindPropertyRelative("boolValue");
        effect_LuminanceMaskThresholdMin = serializedObject.FindProperty("luminanceMaskThresholdMin").FindPropertyRelative("floatValue");
        effect_LuminanceMaskThresholdMax = serializedObject.FindProperty("luminanceMaskThresholdMax").FindPropertyRelative("floatValue");

        spriteEffect.SetHelper();

        effect_SpriteTransparentMode_override = serializedObject.FindProperty("setSpriteTransparent").FindPropertyRelative("overrideValue");
        effect_SpriteGrayScaleMode_override = serializedObject.FindProperty("setSpriteGrayScale").FindPropertyRelative("overrideValue");
        effect_SpriteGrayScaleValue_override = serializedObject.FindProperty("spriteGrayScaleValue").FindPropertyRelative("overrideValue");
        effect_SpriteGrayScaleUseCurve_override = serializedObject.FindProperty("spriteGrayScaleUseCurve").FindPropertyRelative("overrideValue");

        effect_SpriteBrightnessMode_override = serializedObject.FindProperty("setSpriteBrightness").FindPropertyRelative("overrideValue");
        effect_SpriteBrightnessValue_override = serializedObject.FindProperty("spriteBrightnessValue").FindPropertyRelative("overrideValue");
        effect_SpriteBrightnessUseCurve_override = serializedObject.FindProperty("spriteBrightnessUseCurve").FindPropertyRelative("overrideValue");
        effect_SpriteBrightnessUseLuminanceMask_override = serializedObject.FindProperty("spriteBrightnessUseLuminanceMask").FindPropertyRelative("overrideValue");

        effect_SpriteTintColorMode_override = serializedObject.FindProperty("setSpriteTintColor").FindPropertyRelative("overrideValue");
        effect_SpriteTintColorValue_override = serializedObject.FindProperty("spriteTintColorValue").FindPropertyRelative("overrideValue");
        effect_SpriteTintColorUseCurve_override = serializedObject.FindProperty("spriteTintColorUseCurve").FindPropertyRelative("overrideValue");
        effect_SpriteTintColorGradient_override = serializedObject.FindProperty("spriteTintColorGradient").FindPropertyRelative("overrideValue");

        effect_SpriteCutOutMode_override = serializedObject.FindProperty("setSpriteCutOut").FindPropertyRelative("overrideValue");
        effect_SpriteCutOutValue_override = serializedObject.FindProperty("spriteCutOutValue").FindPropertyRelative("overrideValue");
        effect_SpriteCutOutTexture_override = serializedObject.FindProperty("spriteCutOutTexture").FindPropertyRelative("overrideValue");
        effect_SpriteCutOutTextureTileOffset_override = serializedObject.FindProperty("spriteCutOutTextureTileOffset").FindPropertyRelative("overrideValue");
        effect_SpriteCutOutEdgeColor_override = serializedObject.FindProperty("spriteCutOutEdgeColor").FindPropertyRelative("overrideValue");
        effect_SpriteCutOutEdgeBrightness_override = serializedObject.FindProperty("spriteCutOutEdgeBrightness").FindPropertyRelative("overrideValue");
        effect_SpriteCutOutFillColor_override = serializedObject.FindProperty("spriteCutOutFillColor").FindPropertyRelative("overrideValue");
        effect_SpriteCutOutFillBrightness_override = serializedObject.FindProperty("spriteCutOutFillBrightness").FindPropertyRelative("overrideValue");
        effect_SpriteCutOutUseSliceUV_override = serializedObject.FindProperty("spriteCutOutUseSliceUV").FindPropertyRelative("overrideValue");
        effect_SpriteCutOutUniformUV_override = serializedObject.FindProperty("spriteCutOutUniformUV").FindPropertyRelative("overrideValue");
        effect_SpriteCutOutDoNotUseAlpha_override = serializedObject.FindProperty("spriteCutOutDoNotUseAlpha").FindPropertyRelative("overrideValue");
        effect_SpriteCutOutUseCurve_override = serializedObject.FindProperty("spriteCutOutUseCurve").FindPropertyRelative("overrideValue");
        effect_SpriteCutOutProgress_override = serializedObject.FindProperty("spriteCutOutProgress").FindPropertyRelative("overrideValue");

        effect_SpriteVertexAnimMode_override = serializedObject.FindProperty("setSpriteVertexAnim").FindPropertyRelative("overrideValue");
        effect_SpriteVertexAnimValue_override = serializedObject.FindProperty("spriteVertexAnimValue").FindPropertyRelative("overrideValue");

        effect_UseUnscaledTime_override = serializedObject.FindProperty("useUnscaledTime").FindPropertyRelative("overrideValue");
        effect_LuminanceMaskThresholdMin_override = serializedObject.FindProperty("luminanceMaskThresholdMin").FindPropertyRelative("overrideValue");
        effect_LuminanceMaskThresholdMax_override = serializedObject.FindProperty("luminanceMaskThresholdMax").FindPropertyRelative("overrideValue");


        for (int i = 0; i < _numOfLayer; i++)
        {
            GetProperties(i);
        }
        //for (int i = 0; i < effect_ValueFolderOpen.Length; i++)
        //{
        //    effect_ValueFolderOpen[i].boolValue = false;
        //}
        if (!Application.isPlaying)
        {
            spriteEffect.OneTimeInitialize();
            spriteEffect.KillSelfIfMultipleExist();
        }
    }

    void ApplySetting()
    {
        spriteEffect.ApplySetting();
    }

    void GetProperties(int i)
    {
        effect_Texture[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectTexture").FindPropertyRelative("textureValue");
        effect_TextureTileOffset[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectTextureTileOffset").FindPropertyRelative("vector4Value");
        effect_UseFlipBook[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseFlipBook").FindPropertyRelative("boolValue");
        effect_UseFlipBookBlend[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseFlipBookBlend").FindPropertyRelative("boolValue");
        effect_FlipBookValue[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectFlipBookValue").FindPropertyRelative("vector4Value");
        effect_UseSpriteMask[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseSpriteMask").FindPropertyRelative("boolValue");
        effect_SpriteMaskValue[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectSpriteMaskValue").FindPropertyRelative("vector4Value");
        effect_Mask[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectMask").FindPropertyRelative("textureValue");
        effect_UseMaskUV[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseMaskUV").FindPropertyRelative("boolValue");
        effect_UniformUV[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUniformUV").FindPropertyRelative("boolValue");
        effect_UseTimerMask[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseTimerMask").FindPropertyRelative("boolValue");
        effect_TimerMaskValue[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectTimerMaskValue").FindPropertyRelative("vector4Value");
        effect_TimerMaskBaseUV[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectTimerMaskBaseUV").FindPropertyRelative("boolValue");
        effect_Color[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectColor").FindPropertyRelative("colorValue");
        effect_Gradient[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectGradient").FindPropertyRelative("gradientValue");
        effect_Brightness[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectBrightness").FindPropertyRelative("floatValue");
        effect_ScaleOrigin[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectScale").FindPropertyRelative("floatValue");
        effect_ScaleMultiplier[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectScaleMultiplier").FindPropertyRelative("floatValue");
        effect_ScaleSpeed[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectScaleSpeed").FindPropertyRelative("floatValue");
        effect_ScalePingPong[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectScalePingPong").FindPropertyRelative("boolValue");
        effect_RandomRotate[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectRandomRotation").FindPropertyRelative("boolValue");
        effect_Power[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectPower").FindPropertyRelative("floatValue");
        effect_RotateAngle[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectRotateAngle").FindPropertyRelative("floatValue");
        effect_RotateSpeed[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectRotateSpeed").FindPropertyRelative("floatValue");
        effect_VerticalSpeed[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectVerticalSpeed").FindPropertyRelative("floatValue");
        effect_HorizontalSpeed[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectHorizontalSpeed").FindPropertyRelative("floatValue");
        effect_ScrollDirection[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectScrollDirectional").FindPropertyRelative("boolValue");
        effect_GlowSpeed[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectGlowSpeed").FindPropertyRelative("floatValue");
        effect_TimingOffset[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectTimingOffset").FindPropertyRelative("floatValue");
        effect_BlendMode[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectBlendMode").FindPropertyRelative("layerBlendModeValue");
        effect_UseAlpha[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseAlpha").FindPropertyRelative("boolValue");
        effect_DistortStrength[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectDistortStrength").FindPropertyRelative("floatValue");
        effect_UseScrollCurve[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseScrollCurve").FindPropertyRelative("boolValue");
        effect_UseRotateCurve[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseRotateCurve").FindPropertyRelative("boolValue");
        effect_UseScaleCurve[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseScaleCurve").FindPropertyRelative("boolValue");
        effect_UseColorCurve[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseColorCurve").FindPropertyRelative("boolValue");
        effect_UseFlipBookCurve[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseFlipBookCurve").FindPropertyRelative("boolValue");
        effect_ScrollCurveX[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectScrollCurveX");
        effect_ScrollCurveY[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectScrollCurveY");
        effect_RotateCurve[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectRotateCurve");
        effect_ScaleCurve[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectScaleCurve");
        effect_ColorCurve[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectColorCurve");
        effect_FlipBookCurve[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectFlipBookCurve");
        effect_UseLuminanceMask[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseLuminanceMask").FindPropertyRelative("boolValue");
        effect_Active[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("isEffectActive");
        //effect_ValueFolderOpen[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("isEffectvalueFolderOpen"); 
        _isEffectActive[i] = effect_Active[i].boolValue;

        effect_Texture_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectTexture").FindPropertyRelative("overrideValue");
        effect_TextureTileOffset_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectTextureTileOffset").FindPropertyRelative("overrideValue");
        effect_UseFlipBook_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseFlipBook").FindPropertyRelative("overrideValue");
        effect_UseFlipBookBlend_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseFlipBookBlend").FindPropertyRelative("overrideValue");
        effect_FlipBookValue_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectFlipBookValue").FindPropertyRelative("overrideValue");
        effect_UseSpriteMask_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseSpriteMask").FindPropertyRelative("overrideValue");
        effect_SpriteMaskValue_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectSpriteMaskValue").FindPropertyRelative("overrideValue");
        effect_Mask_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectMask").FindPropertyRelative("overrideValue");
        effect_UseMaskUV_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseMaskUV").FindPropertyRelative("overrideValue");
        effect_UniformUV_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUniformUV").FindPropertyRelative("overrideValue");
        effect_UseTimerMask_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseTimerMask").FindPropertyRelative("overrideValue");
        effect_TimerMaskValue_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectTimerMaskValue").FindPropertyRelative("overrideffect_FlipBookCurve_overrideeValue");
        effect_TimerMaskBaseUV_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectTimerMaskBaseUV").FindPropertyRelative("overrideValue");
        effect_Color_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectColor").FindPropertyRelative("overrideValue");
        effect_Gradient_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectGradient").FindPropertyRelative("overrideValue");
        effect_Brightness_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectBrightness").FindPropertyRelative("overrideValue");
        effect_ScaleOrigin_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectScale").FindPropertyRelative("overrideValue");
        effect_ScaleMultiplier_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectScaleMultiplier").FindPropertyRelative("overrideValue");
        effect_ScaleSpeed_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectScaleSpeed").FindPropertyRelative("overrideValue");
        effect_ScalePingPong_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectScalePingPong").FindPropertyRelative("overrideValue");
        effect_RandomRotate_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectRandomRotation").FindPropertyRelative("overrideValue");
        effect_Power_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectPower").FindPropertyRelative("overrideValue");
        effect_RotateAngle_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectRotateAngle").FindPropertyRelative("overrideValue");
        effect_RotateSpeed_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectRotateSpeed").FindPropertyRelative("overrideValue");
        effect_VerticalSpeed_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectVerticalSpeed").FindPropertyRelative("overrideValue");
        effect_HorizontalSpeed_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectHorizontalSpeed").FindPropertyRelative("overrideValue");
        effect_ScrollDirection_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectScrollDirectional").FindPropertyRelative("overrideValue");
        effect_GlowSpeed_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectGlowSpeed").FindPropertyRelative("overrideValue");
        effect_TimingOffset_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectTimingOffset").FindPropertyRelative("overrideValue");
        effect_BlendMode_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectBlendMode").FindPropertyRelative("overrideValue");
        effect_UseAlpha_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseAlpha").FindPropertyRelative("overrideValue");
        effect_DistortStrength_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectDistortStrength").FindPropertyRelative("overrideValue");
        effect_UseScrollCurve_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseScrollCurve").FindPropertyRelative("overrideValue");
        effect_UseRotateCurve_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseRotateCurve").FindPropertyRelative("overrideValue");
        effect_UseScaleCurve_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseScaleCurve").FindPropertyRelative("overrideValue");
        effect_UseColorCurve_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseColorCurve").FindPropertyRelative("overrideValue");
        effect_UseFlipBookCurve_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseFlipBookCurve").FindPropertyRelative("overrideValue");
        effect_UseLuminanceMask_override[i] = effects.GetArrayElementAtIndex(i).FindPropertyRelative("effectUseLuminanceMask").FindPropertyRelative("overrideValue");
    }

    public override void OnInspectorGUI()
    {
        if (!Application.isPlaying)
        {
            guiTextStyle = MyEditorStyles.customStyle;
            // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
            serializedObject.Update();
            if (effect_Name != null)
            {
                _isEffectEnabled = EditorGUILayout.Foldout(spriteEffect.enabled, new GUIContent(effect_Name.stringValue));
            }
            if (_isEffectEnabled)
            {
                DoBaseArea();
                for (int i = 0; i < _numOfLayer; i++)
                {
                    DoEffectArea(i);
                }
                //GUILayout.Space(20);
                //ResetButtons();
                DrawUILine();
                DoAddLayerButton();

                bool _needUpdate = serializedObject.hasModifiedProperties;
                if (_needUpdate && !Application.isPlaying)
                {
                    spriteEffect.SetDirty();
                }
                //스프라이트렌더러에서 [Draw Mode, Size, Sprite] 가 변경되엇는지 체크
                //if (spriteEffect.CheckSpriteDataChange())
                //{
                //    _needUpdate = true;  // 변경점이 있을경우 강제로 업데이트를 true
                //}

                // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
                serializedObject.ApplyModifiedProperties();

                if (spriteEffect.enabled && _needUpdate)   // 업데이트 할 필요가 있는지 체크
                {
                    if (spriteEffect.CheckMaterialChange())  // 이팩트 메테리얼이 에디터에서 변경됏을경우 변경된 메테리얼 값을 에디터로 가져옴
                    {
                        spriteEffect.LoadMaterialValue();
                        effectName = effect_Name.stringValue;
                        spriteEffect.SaveSetting();
                    }
                    else
                    {
                        ApplySetting();
                    }
                }

                if (_needUpdate || overrideCheckBool)
                {
                    spriteEffect.CheckOverride();
                    overrideCheckBool = false;
                }
            }
            DoRemoveLayer();
        }
    }

    public void CreateEffectMaterialFolder()
    {
        assetPath = resourcesPath + "/" + materialAssetFolderName;
        if (!AssetDatabase.IsValidFolder(resourcesPath))
            AssetDatabase.CreateFolder("Assets", "Resources");
        if (!AssetDatabase.IsValidFolder(assetPath))
        {
            AssetDatabase.CreateFolder(resourcesPath, materialAssetFolderName);
            Initialize(); // 폴더 생성직후에 SerializedProperty의 밸류값이 null이 들어와서 예외오류가 발생하는걸 방지하기위해 이때만 한번 다시 프로퍼티 가져옴.
        }
    }

    public void ApplyButtons()
    {
        if (GUILayout.Button("Apply Effect"))
        {
            spriteEffect.ApplySetting();
        }
    }

    public void SaveMaterialButtons()
    {
        var defaultColor = GUI.backgroundColor;
        if (holdCtrlKey)
        {
            GUI.backgroundColor = Color.green;
            if (GUILayout.Button("Copy Material"))
            {
                if (IsNameChanged())  // 이팩트명이 변경됏을경우 메테리얼에셋명도 변경
                {
                    CreateEffectMaterialFolder();
                    //SLog.LogWarning("effectName Change from : " + effectName);
                    effectName = effect_Name.stringValue;
                    spriteEffect.SaveAsNewMaterialAsset(assetPath);
                }
                else
                {
                    spriteEffect.SaveSetting();
                }
            }
            GUI.backgroundColor = defaultColor;
        }
        else if (holdAltKey)
        {
            GUI.backgroundColor = Color.blue;
            if (GUILayout.Button("Load Material"))
            {
                spriteEffect.LoadCreatedMaterialValue();
                effectName = effect_Name.stringValue;
                EditorUtility.SetDirty(this);
                this.Repaint();
            }
            GUI.backgroundColor = defaultColor;
        }
        else
        {
            GUI.backgroundColor = spriteEffect.haveUnsavedChange ? Color.red : defaultColor;
            if (GUILayout.Button("Save Material"))
            {
                if (IsNameChanged())  // 이팩트명이 변경됏을경우 메테리얼에셋명도 변경
                {
                    CreateEffectMaterialFolder();
                    //SLog.LogWarning("effectName Change from : " + effectName);
                    effectName = effect_Name.stringValue;
                    spriteEffect.CreateAndSaveMaterialAsset(assetPath);
                }
                else
                {
                    spriteEffect.SaveSetting();
                }
            }
            GUI.backgroundColor = defaultColor;
        }
    }

    public void FocusAssetFolderButton()
    {
        if (GUILayout.Button("Focus Folder"))
        {
            CreateEffectMaterialFolder();
            UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath(assetPath, typeof(UnityEngine.Object));

            EditorUtility.FocusProjectWindow();

            var pt = Type.GetType("UnityEditor.ProjectBrowser,UnityEditor");
            var ins = pt.GetField("s_LastInteractedProjectBrowser", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).GetValue(null);
            var showDirMeth = pt.GetMethod("ShowFolderContents", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            showDirMeth.Invoke(ins, new object[] { obj.GetInstanceID(), true });
        }
    }


    public void SwapLayerButtons(int layer1,int layer2)
    {
        if (layer1 > layer2)
        {
            if (holdCtrlKey)
            {
                if (GUILayout.Button("Copy↑"))
                {
                    spriteEffect.SwapLayer(layer2, layer1, true);
                    //_isEffectValueOpen[layer1] = _isEffectValueOpen[layer2];
                    //_isEffectValueOpen[layer2] = true;
                    _isEffectValueOpen[layer2] = true;
                    ApplySetting();
                }
            }
            else
            {
                if (GUILayout.Button("↑"))
                {
                    spriteEffect.SwapLayer(layer1, layer2, false);
                    //_isEffectValueOpen[layer1] = _isEffectValueOpen[layer2];
                    //_isEffectValueOpen[layer2] = true;
                    _isEffectValueOpen[layer2] = true;
                    ApplySetting();
                }
            }
        }
        else
        {
            if (holdCtrlKey)
            {
                if (GUILayout.Button("Copy↓"))
                {
                    spriteEffect.SwapLayer(layer2, layer1, true);
                    //_isEffectValueOpen[layer1] = _isEffectValueOpen[layer2];
                    _isEffectValueOpen[layer2] = true;
                    ApplySetting();
                }
            }
            else
            {
                if (GUILayout.Button("↓"))
                {
                    spriteEffect.SwapLayer(layer2, layer1, false);
                    //_isEffectValueOpen[layer1] = _isEffectValueOpen[layer2];
                    //_isEffectValueOpen[layer2] = true;
                    _isEffectValueOpen[layer2] = true;
                    ApplySetting();
                }
            }
        }
    }

    //https://forum.unity.com/threads/horizontal-line-in-editor-window.520812/
    public static void DrawUILine(int thickness = 2, int padding = 10)
    {
        Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
        r.height = thickness;
        r.y += padding / 2;
        r.x -= 2;
        r.width += 6;
        EditorGUI.DrawRect(r, Color.black);
    }

    //https://forum.unity.com/threads/how-to-check-if-a-property-is-missing-or-not-set-none.642919/
    private bool IsNone(SerializedProperty property)
    {
        var prop = typeof(SerializedProperty).GetProperty("objectReferenceStringValue", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var result = (string)prop.GetValue(property, null);
        if (result == "None (Texture 2D)")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsNameChanged()
    {
        if (effect_Name.stringValue == "No Name" && !spriteEffect.HaveCreatedMaterial())
        {
            return true;
        }
        return (effectName != effect_Name.stringValue) ? true : false;
    }

    private void CustomPropertyField(SerializedProperty property , GUIContent label , SerializedProperty overrideVal = null)   // 프로퍼티의 오버라이드여부에 따라 필드 색상 변경
    {
        if (overrideVal != null)
        {
            var defaultColor = GUI.backgroundColor;
            GUI.backgroundColor = overrideVal.boolValue ? Color.red : defaultColor;
            EditorGUILayout.PropertyField(property, label);
            GUI.backgroundColor = defaultColor;
        }
        else EditorGUILayout.PropertyField(property, label);
    }

    private void CustomSliderField(SerializedProperty property, string label, float min, float max , SerializedProperty overrideVal = null)  // 프로퍼티의 오버라이드여부에 따라 필드 색상 변경
    {
        EditorGUIUtility.labelWidth = label.Length * 8;
        if (overrideVal != null)
        {
            var defaultColor = GUI.backgroundColor;
            GUI.backgroundColor = overrideVal.boolValue ? Color.red : defaultColor;
            EditorGUILayout.Slider(property, min, max, label);
            GUI.backgroundColor = defaultColor;
        }
        else EditorGUILayout.Slider(property, min, max, label);
        EditorGUIUtility.labelWidth = 0;
    }

    private void CustomVector4Field(string label, ref SerializedProperty property, SerializedProperty overrideVal = null)
    {
        var vector4Val = property.vector4Value;
        if (overrideVal != null)
        {
            var defaultColor = GUI.backgroundColor;
            GUI.backgroundColor = overrideVal.boolValue ? Color.red : defaultColor;
            vector4Val = EditorGUILayout.Vector4Field(label, vector4Val);
            GUI.backgroundColor = defaultColor;
        }
        else vector4Val = EditorGUILayout.Vector4Field(label, vector4Val);
        property.vector4Value = vector4Val;
    }

    private void CustomMinMaxSlider(string label, ref SerializedProperty minProperty, ref SerializedProperty maxProperty, float minSlider, float maxSlider, SerializedProperty minOverrideVal = null, SerializedProperty maxOverrideVal = null)  // 프로퍼티의 오버라이드여부에 따라 필드 색상 변경
    {
        float minval = minProperty.floatValue;
        float maxval = maxProperty.floatValue;
        if (minOverrideVal != null || maxOverrideVal != null)
        {
            var defaultColor = GUI.backgroundColor;
            bool overriadeVal = minOverrideVal.boolValue || maxOverrideVal.boolValue ? true : false; 
            GUI.backgroundColor = overriadeVal ? Color.red : defaultColor;
            EditorGUILayout.MinMaxSlider(label, ref minval, ref maxval, minSlider, maxSlider);
            GUI.backgroundColor = defaultColor;
        }
        else EditorGUILayout.MinMaxSlider(label, ref minval, ref maxval, minSlider, maxSlider);
        minProperty.floatValue = minval;
        maxProperty.floatValue = maxval;
    }

    void DoBaseArea()
    {
        EditorGUILayout.BeginHorizontal();
        CustomPropertyField(effect_Name, new GUIContent("Name"));
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
        SaveMaterialButtons();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        CustomPropertyField(effectMaterial, new GUIContent("Material"));
        FocusAssetFolderButton();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        CustomPropertyField(effect_SpriteTransparentMode, new GUIContent("Set Sprite Transparent"), effect_SpriteTransparentMode_override);
        CustomPropertyField(effect_UseUnscaledTime, new GUIContent("Use Unscaled Time"), effect_UseUnscaledTime_override);
        EditorGUILayout.EndHorizontal();
        if (ISLuminanceMaskON())
        {
            CustomMinMaxSlider("Luminance Mask Threshold", ref effect_LuminanceMaskThresholdMin, ref effect_LuminanceMaskThresholdMax, 0, 1, effect_LuminanceMaskThresholdMin_override, effect_LuminanceMaskThresholdMax_override);
        }
        //if  (!effect_SpriteTransparentMode.boolValue == true ||  effect_SpriteCutOutMode.boolValue == true )
        //{
            _isSpriteValueOpen = spriteEffect.isSpriteOptionFolderOpen;
            _isSpriteValueOpen = EditorGUILayout.Foldout(_isSpriteValueOpen, new GUIContent("Show Sprite Options"));
            spriteEffect.isSpriteOptionFolderOpen = _isSpriteValueOpen;
            if (_isSpriteValueOpen)
            {
                if (effect_SpriteTransparentMode.boolValue == false)
                {
                    EditorGUILayout.BeginHorizontal();
                    CustomPropertyField(effect_SpriteGrayScaleMode, new GUIContent("└ Sprite GrayScale"), effect_SpriteGrayScaleMode_override);
                    if (effect_SpriteGrayScaleMode.boolValue == true)
                    {
                        if (effect_SpriteGrayScaleUseCurve.boolValue == false)
                        {
                            CustomSliderField(effect_SpriteGrayScaleValue, "", 0f, 1f, effect_SpriteGrayScaleValue_override);
                        }
                        EditorGUILayout.EndHorizontal();
                        EditorGUILayout.BeginHorizontal();
                        EditorGUIUtility.labelWidth = 0;
                        CustomPropertyField(effect_SpriteGrayScaleUseCurve, new GUIContent("    └ Use AnimCurve"), effect_SpriteGrayScaleUseCurve_override);
                        if (effect_SpriteGrayScaleUseCurve.boolValue == true)
                        {
                            CustomPropertyField(effect_SpriteGrayScaleCurve, new GUIContent(""),effect_SpriteGrayScaleCurve_override);
                        }
                    }
                    else
                    {
                    effect_SpriteGrayScaleUseCurve.boolValue = false;
                    }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    CustomPropertyField(effect_SpriteBrightnessMode, new GUIContent("└ Sprite Brightness"), effect_SpriteBrightnessMode_override);
                    if (effect_SpriteBrightnessMode.boolValue == true)
                    {
                        if (effect_SpriteBrightnessUseCurve.boolValue == false)
                        {
                            CustomSliderField(effect_SpriteBrightnessValue, "", 0f, 10f, effect_SpriteBrightnessValue_override);
                        }
                        EditorGUILayout.EndHorizontal();
                        EditorGUILayout.BeginHorizontal();
                        EditorGUIUtility.labelWidth = 0;
                        CustomPropertyField(effect_SpriteBrightnessUseCurve, new GUIContent("    └ Use AnimCurve"), effect_SpriteBrightnessUseCurve_override);
                        if (effect_SpriteBrightnessUseCurve.boolValue == true)
                        {
                            CustomPropertyField(effect_SpriteBrightnessCurve, new GUIContent(""), effect_SpriteBrightnessCurve_override);
                        }
                        EditorGUILayout.EndHorizontal();
                        EditorGUILayout.BeginHorizontal();
                        CustomPropertyField(effect_SpriteBrightnessUseLuminanceMask, new GUIContent("    └ Use Luminance Mask"), effect_SpriteBrightnessUseLuminanceMask_override);
                    }
                    else
                    {
                        effect_SpriteBrightnessUseCurve.boolValue = false;
                        effect_SpriteBrightnessUseLuminanceMask.boolValue = false;
                    }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    CustomPropertyField(effect_SpriteTintColorMode, new GUIContent("└ Sprite Tint Color"), effect_SpriteTintColorMode_override);
                    if (effect_SpriteTintColorMode.boolValue)
                    {
                        if (effect_SpriteTintColorUseCurve.boolValue == true)
                        {
                            CustomPropertyField(effect_SpriteTintColorGradient, new GUIContent(""), effect_SpriteTintColorGradient_override);
                        }
                        else
                        {
                            CustomPropertyField(effect_SpriteTintColorValue, new GUIContent(""), effect_SpriteTintColorValue_override);
                        }
                        EditorGUILayout.EndHorizontal();
                        EditorGUILayout.BeginHorizontal();
                        EditorGUIUtility.labelWidth = 0;
                        CustomPropertyField(effect_SpriteTintColorUseCurve, new GUIContent("    └ Use AnimCurve"), effect_SpriteTintColorUseCurve_override);
                        if (effect_SpriteTintColorUseCurve.boolValue == true)
                        {
                            CustomPropertyField(effect_SpriteTintColorCurve, new GUIContent(""), effect_SpriteTintColorCurve_override);
                        }
                        EditorGUILayout.EndHorizontal();
                        EditorGUILayout.BeginHorizontal();
                        CustomPropertyField(effect_SpriteTintColorUseLuminanceMask, new GUIContent("    └ Use Luminance Mask"), effect_SpriteTintColorUseLuminanceMask_override);
                    }
                    else
                    {
                        effect_SpriteTintColorUseCurve.boolValue = false;
                        effect_SpriteTintColorUseLuminanceMask.boolValue = false;
                    }
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.BeginHorizontal();
                CustomPropertyField(effect_SpriteCutOutMode, new GUIContent("└ Sprite CutOut"), effect_SpriteCutOutMode_override);
                if (effect_SpriteCutOutMode.boolValue == true)
                {
                    EditorGUIUtility.labelWidth = 30;
                    CustomPropertyField(effect_SpriteCutOutTexture, new GUIContent(""), effect_SpriteCutOutTexture_override);
                    EditorGUILayout.EndHorizontal();
                    EditorGUIUtility.labelWidth = 0;
                    CustomVector4Field("   └ Tile & Offset", ref effect_SpriteCutOutTextureTileOffset, effect_SpriteCutOutTextureTileOffset_override);
                    CustomVector4Field("   └ Smoothness / Contrast / Min / Max", ref effect_SpriteCutOutValue, effect_SpriteCutOutValue_override);
                    EditorGUILayout.BeginHorizontal();
                    EditorGUIUtility.labelWidth = 90;
                    CustomPropertyField(effect_SpriteCutOutEdgeColor, new GUIContent("   └ Edge Color"), effect_SpriteCutOutEdgeColor_override);
                    CustomPropertyField(effect_SpriteCutOutEdgeBrightness, new GUIContent("Edge Brightness"), effect_SpriteCutOutEdgeBrightness_override);
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    CustomPropertyField(effect_SpriteCutOutFillColor, new GUIContent("   └ Fill Color"), effect_SpriteCutOutFillColor_override);
                    CustomPropertyField(effect_SpriteCutOutFillBrightness, new GUIContent("Fill Brightness"), effect_SpriteCutOutFillBrightness_override);
                    EditorGUIUtility.labelWidth = 0;
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    if (effect_SpriteCutOutUniformUV.boolValue == false)
                    {
                        CustomPropertyField(effect_SpriteCutOutUseSliceUV, new GUIContent("   └ Slice UV"), effect_SpriteCutOutUseSliceUV_override);
                    }
                    if (effect_SpriteCutOutUseSliceUV.boolValue == false)
                    {
                        CustomPropertyField(effect_SpriteCutOutUniformUV, new GUIContent("   └ Uniform UV"), effect_SpriteCutOutUniformUV_override);
                    }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    if (effect_SpriteCutOutDoNotUseAlpha.boolValue == false)
                    {
                        CustomPropertyField(effect_SpriteCutOutDoNotUseAlpha, new GUIContent("   └ Do not use Alpha Val"), effect_SpriteCutOutDoNotUseAlpha_override);
                    }
                    if (effect_SpriteCutOutDoNotUseAlpha.boolValue == true)
                    {
                        CustomPropertyField(effect_SpriteCutOutDoNotUseAlpha, new GUIContent("   └ \"_BaseCutOutProgress\""), effect_SpriteCutOutDoNotUseAlpha_override);
                        CustomSliderField(effect_SpriteCutOutProgress, "", 0f,1f, effect_SpriteCutOutProgress_override);
                    }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUIUtility.labelWidth = 0;
                    CustomPropertyField(effect_SpriteCutOutUseCurve, new GUIContent("    └ Use AnimCurve"), effect_SpriteCutOutUseCurve_override);
                    if (effect_SpriteCutOutUseCurve.boolValue == true)
                    {
                        CustomPropertyField(effect_SpriteCutOutCurve, new GUIContent(""), effect_SpriteCutOutCurve_override);
                    }
                }
                else
                {
                    effect_SpriteCutOutUseCurve.boolValue = false;
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                CustomPropertyField(effect_SpriteVertexAnimMode, new GUIContent("└ Sprite Vertex Animation"), effect_SpriteVertexAnimMode_override);
                if (effect_SpriteVertexAnimMode.boolValue == true)
                {
                    EditorGUIUtility.labelWidth = 0;
                    CustomVector4Field("",ref effect_SpriteVertexAnimValue, effect_SpriteVertexAnimValue_override);
                }
                EditorGUILayout.EndHorizontal();
            }
        EditorGUILayout.BeginHorizontal();
        DoPlayCurveButton();
        EditorGUILayout.EndHorizontal();
        //}
    }
    void DoPlayCurveButton()
    {
        if (spriteEffect.CheckUseCurveInEditor())
        {
            if (spriteEffect.IsPlayCurveInEditor())
            {
                if (GUILayout.Button($"Stop Animation Curve"))
                {
                    spriteEffect.PlayCurveInEditor();
                }
            }
            else
            {
                if (GUILayout.Button($"Play Animation Curve"))
                {
                    spriteEffect.PlayCurveInEditor();
                }
            }
        }
    }

    void DoEffectArea(int i)
    {
        if (effect_Active[i] == null)
        {
            return;
        }
        //if (effect_Active[i].boolValue == true && !IsNone(effect_Texture[i]))
        //{
        //    spriteEffect.spriteEffectLayers[i].isEffectCreated = effect_Active[i].boolValue;
        //}
        if (spriteEffect.spriteEffectLayers[i].isEffectCreated == false)
        {
            return;
        }
        DrawUILine();
        EditorGUILayout.BeginHorizontal();
        //_isEffectActive[i] = effect_Active[i].boolValue && !IsNone(effect_Texture[i]) ? true:false ;
        guiTextStyle.normal.textColor = _isEffectActive[i] ? Color.white : darkRedColor;
        var textHoverColor = guiTextStyle.hover.textColor;
        var textFocusedColor = guiTextStyle.focused.textColor;
        guiTextStyle.hover.textColor = _isEffectActive[i] ? textHoverColor : Color.red;
        guiTextStyle.focused.textColor = _isEffectActive[i] ? textFocusedColor : Color.red;
        _isEffectActive[i] = EditorGUILayout.ToggleLeft($"Effect {i + 1}", _isEffectActive[i], guiTextStyle);
        DoRemoveLayerButton(i);
        guiTextStyle.normal.textColor = Color.white;
        guiTextStyle.hover.textColor = textHoverColor;
        guiTextStyle.focused.textColor = textFocusedColor;
        effect_Active[i].boolValue = _isEffectActive[i];
        EditorGUILayout.EndHorizontal();
        EditorGUI.indentLevel++;
        //_isEffectValueOpen[i] = effect_ValueFolderOpen[i].boolValue;
        //_isEffectValueOpen[i] = EditorGUILayout.Foldout(effect_ValueFolderOpen[i].boolValue, new GUIContent("Show Animation Value"));
        //effect_ValueFolderOpen[i].boolValue = _isEffectValueOpen[i];
        //if (_isEffectActive[i])
        //{
        _isEffectValueOpen[i] = spriteEffect.spriteEffectLayers[i].isEffectvalueFolderOpen;
        _isEffectValueOpen[i] = EditorGUILayout.Foldout(_isEffectValueOpen[i], new GUIContent("Show Animation Value"));
        spriteEffect.spriteEffectLayers[i].isEffectvalueFolderOpen = _isEffectValueOpen[i];
        //}

        CustomPropertyField(effect_Texture[i], new GUIContent("Texture"), effect_Texture_override[i]);
        
        if (_isEffectValueOpen[i])
        {
            if (!IsNone(effect_Texture[i]))
            {
                CustomVector4Field("Tile & Offset",ref effect_TextureTileOffset[i], effect_TextureTileOffset_override[i]);
                EditorGUILayout.BeginHorizontal();
                CustomPropertyField(effect_UseFlipBook[i], new GUIContent("Use FlipBook UV"), effect_UseFlipBook_override[i]);
                if (effect_UseFlipBook[i].boolValue)
                {
                    CustomVector4Field("",ref effect_FlipBookValue[i], effect_FlipBookValue_override[i]);
                    if (!effect_UseFlipBookCurve[i].boolValue)
                    {
                        EditorGUILayout.EndHorizontal();
                        EditorGUILayout.BeginHorizontal();
                        CustomPropertyField(effect_UseFlipBookCurve[i], new GUIContent(" └ Use Curve"), effect_UseFlipBookCurve_override[i]);
                        CustomPropertyField(effect_UseFlipBookBlend[i], new GUIContent(" └ Flipbook Blending"), effect_UseFlipBookBlend_override[i]);
                        EditorGUILayout.EndHorizontal();
                        EditorGUILayout.BeginHorizontal();
                    }
                    else
                    {
                        EditorGUILayout.EndHorizontal();
                        EditorGUILayout.BeginHorizontal();
                        CustomPropertyField(effect_UseFlipBookCurve[i], new GUIContent(" └ FlipBook Index"), effect_UseFlipBookCurve_override[i]);
                        EditorGUIUtility.labelWidth = 60;
                        CustomPropertyField(effect_FlipBookCurve[i], new GUIContent(""), effect_FlipBookCurve_override[i]);
                        EditorGUIUtility.labelWidth = 0;
                        EditorGUILayout.EndHorizontal();
                        EditorGUILayout.BeginHorizontal();
                        CustomPropertyField(effect_UseFlipBookBlend[i], new GUIContent(" └ Flipbook Blending"), effect_UseFlipBookBlend_override[i]);
                        EditorGUILayout.EndHorizontal();
                        EditorGUILayout.BeginHorizontal();
                    }
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                CustomPropertyField(effect_UseSpriteMask[i], new GUIContent("Use _SpritEffecteMask"), effect_UseSpriteMask_override[i]);
                if (effect_UseSpriteMask[i].boolValue)
                {
                    CustomVector4Field("", ref effect_SpriteMaskValue[i], effect_SpriteMaskValue_override[i]);
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUIUtility.labelWidth = 60;
                CustomPropertyField(effect_Mask[i], new GUIContent("Mask"), effect_Mask_override[i]);
                if (!IsNone(effect_Mask[i])) 
                {
                    EditorGUIUtility.labelWidth = 70;
                    CustomPropertyField(effect_UseMaskUV[i], new GUIContent("Slice UV"), effect_UseMaskUV_override[i]);
                }
                else
                {
                    effect_UseMaskUV[i].boolValue = false;
                }
                EditorGUIUtility.labelWidth = 120;
                CustomPropertyField(effect_UseLuminanceMask[i], new GUIContent("Luminance Mask"), effect_UseLuminanceMask_override[i]);
                EditorGUIUtility.labelWidth = 0;
                EditorGUILayout.EndHorizontal();
                if (!IsNone(effect_Mask[i]))
                {
                    EditorGUILayout.BeginHorizontal();
                    CustomPropertyField(effect_UseTimerMask[i], new GUIContent(" └ Use Timer Mask(b)"), effect_UseTimerMask_override[i]);
                    if (effect_UseTimerMask[i].boolValue)
                    {
                        CustomVector4Field("",ref effect_TimerMaskValue[i], effect_TimerMaskValue_override[i]);
                        EditorGUILayout.EndHorizontal();
                        EditorGUILayout.BeginHorizontal();
                        CustomPropertyField(effect_TimerMaskBaseUV[i], new GUIContent("       └ Use Sprite UV"), effect_TimerMaskBaseUV_override[i]);
                    }
                    EditorGUILayout.EndHorizontal();
                }
                if (effect_UseColorCurve[i].boolValue)
                {
                    CustomPropertyField(effect_Gradient[i], new GUIContent("Gradient"), effect_Gradient_override[i]); 
                }
                else
                {
                    CustomPropertyField(effect_Color[i], new GUIContent("Color"), effect_Color_override[i]);
                }     
                EditorGUILayout.BeginHorizontal();
                CustomPropertyField(effect_Brightness[i], new GUIContent("Brightness"), effect_Brightness_override[i]);
                CustomPropertyField(effect_GlowSpeed[i], new GUIContent("Glow Speed"), effect_GlowSpeed_override[i]);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                CustomPropertyField(effect_ScaleOrigin[i], new GUIContent("Scale"), effect_ScaleOrigin_override[i]);
                CustomPropertyField(effect_ScaleMultiplier[i], new GUIContent("Scale Anim Multiplier"), effect_ScaleMultiplier_override[i]);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                CustomPropertyField(effect_ScaleSpeed[i], new GUIContent("Scale Speed"), effect_ScaleSpeed_override[i]);
                CustomPropertyField(effect_Power[i], new GUIContent("Power"), effect_Power_override[i]);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                if (!effect_UseRotateCurve[i].boolValue)
                {
                    CustomPropertyField(effect_RotateAngle[i], new GUIContent("Rotate Angle"), effect_RotateAngle_override[i]);
                    CustomPropertyField(effect_RotateSpeed[i], new GUIContent("Rotate Speed"), effect_RotateSpeed_override[i]);
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                if (!effect_UseScrollCurve[i].boolValue)
                {
                    CustomPropertyField(effect_VerticalSpeed[i], new GUIContent("Vertical Speed"), effect_VerticalSpeed_override[i]);
                    CustomPropertyField(effect_HorizontalSpeed[i], new GUIContent("Horizontal Speed"), effect_HorizontalSpeed_override[i]);
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                CustomPropertyField(effect_TimingOffset[i], new GUIContent("Timing Offset"), effect_TimingOffset_override[i]);
                CustomPropertyField(effect_UseAlpha[i], new GUIContent("Use Alpha"), effect_UseAlpha_override[i]);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                CustomPropertyField(effect_BlendMode[i], new GUIContent("Blend Mode"), effect_BlendMode_override[i]);
                CustomPropertyField(effect_UniformUV[i], new GUIContent("Unstretch UV"), effect_UniformUV_override[i]);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUIUtility.labelWidth = 120;
                if (!Mathf.Approximately(effect_ScaleSpeed[i].floatValue, 0.0f))
                {
                    CustomPropertyField(effect_ScalePingPong[i], new GUIContent("PingPong Scale"), effect_ScalePingPong_override[i]);
                }
                else
                {
                    effect_ScalePingPong[i].boolValue = false;
                }
                if (!Mathf.Approximately(effect_ScaleSpeed[i].floatValue, 0.0f) && effect_ScalePingPong[i].boolValue == false)
                {
                    CustomPropertyField(effect_RandomRotate[i], new GUIContent("Random Rotation"), effect_RandomRotate_override[i]);
                }
                else
                {
                    effect_RandomRotate[i].boolValue = false;
                }
                CustomPropertyField(effect_ScrollDirection[i], new GUIContent("Directional Scroll"), effect_ScrollDirection_override[i]);
                EditorGUIUtility.labelWidth = 0;
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                CustomSliderField(effect_DistortStrength[i],"Mask Distort Strength", 0f, 1f, effect_DistortStrength_override[i]);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUIUtility.labelWidth = 60;   // 라벨이랑 필드 사이의 간격을 작게 조절
                CustomPropertyField(effect_UseScrollCurve[i], new GUIContent("Scroll"), effect_UseScrollCurve_override[i]);
                CustomPropertyField(effect_UseRotateCurve[i], new GUIContent("Rotate"), effect_UseRotateCurve_override[i]);
                CustomPropertyField(effect_UseScaleCurve[i], new GUIContent("Scale"), effect_UseScaleCurve_override[i]);
                CustomPropertyField(effect_UseColorCurve[i], new GUIContent("Color"), effect_UseColorCurve_override[i]);
                EditorGUIUtility.labelWidth = 0;    // 라벨이랑 필드 사이의 간격을 기본값으로 리셋
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                if (effect_UseScrollCurve[i].boolValue)
                {
                    CustomPropertyField(effect_ScrollCurveX[i], new GUIContent("Scroll Curve X"), effect_ScrollCurveX_override[i]);
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    CustomPropertyField(effect_ScrollCurveY[i], new GUIContent("Scroll Curve Y"), effect_ScrollCurveY_override[i]);
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                if (effect_UseRotateCurve[i].boolValue)
                {
                    CustomPropertyField(effect_RotateCurve[i], new GUIContent("Rotate Curve"), effect_RotateCurve_override[i]);
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                if (effect_UseScaleCurve[i].boolValue)
                {
                    CustomPropertyField(effect_ScaleCurve[i], new GUIContent("Scale Curve"), effect_ScaleCurve_override[i]);
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                if (effect_UseColorCurve[i].boolValue)
                {
                    CustomPropertyField(effect_ColorCurve[i], new GUIContent("Color Curve"), effect_ColorCurve_override[i]);
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                //ApplyButtons();
                EditorGUILayout.Space(10);
                if (FindNextCreatedLayer(i) > -1)
                {
                    SwapLayerButtons(i, FindNextCreatedLayer(i));
                }
                if (FindNextCreatedLayer(i, false) > -1)
                {
                    SwapLayerButtons(i, FindNextCreatedLayer(i, false));
                }
                EditorGUILayout.Space(10);
                DoEffectReset(i);
                EditorGUILayout.EndHorizontal();
            }
        }
        EditorGUI.indentLevel--;
    }

    int FindNextCreatedLayer(int i, bool Reverse = true)
    {
        if (Reverse)
        {
            for (int j = i + 1; j < spriteEffect.spriteEffectLayers.Length; j++)
            {
                if (spriteEffect.spriteEffectLayers[j].isEffectCreated == true)
                {
                    return j;
                }
            }
        }
        else
        {
            for (int j = i - 1; j > -1; j--)
            {
                if (spriteEffect.spriteEffectLayers[j].isEffectCreated == true)
                {
                    return j;
                }
            }
        }
        //Debug.LogWarning("Can't find created layer");
        return -1;
    }

    void DoAddLayerButton()
    {
        int index;
        for (index = 0; index < spriteEffect.spriteEffectLayers.Length; index++)
        {
            if (spriteEffect.spriteEffectLayers[index].isEffectCreated == false)
            {
                break;
            }
        }
        if (index < spriteEffect.spriteEffectLayers.Length)
        {
            if (GUILayout.Button($"Add Effect {index + 1}"))
            {
                spriteEffect.spriteEffectLayers[index].isEffectCreated = true;
                EditorUtility.SetDirty(this);
                this.Repaint();
            }
        }
    }

    void DoRemoveLayerButton(int i)
    {
        var defaultColor = GUI.backgroundColor;
        if (spriteEffect.spriteEffectLayers[i].confirmRemove && confirmRemove == true)
        {
            GUI.backgroundColor = Color.red;
            if (GUILayout.Button($"        Really?        "))
            {
                ResetLayer(i);
                _layerToRemove = i;
                confirmRemove = false;
            }
            if (Event.current.type == EventType.Repaint)
            {
                var rect = GUILayoutUtility.GetLastRect();
                var pos = Event.current.mousePosition;
                if (!rect.Contains(pos))
                {
                    confirmRemove = false;
                    spriteEffect.spriteEffectLayers[i].confirmRemove = false;
                }
            }
        }
        else
        {
            GUI.backgroundColor = removeButtonColor;
            if (GUILayout.Button($"Remove Effect {i + 1}"))
            {
                confirmRemove = true;
                spriteEffect.spriteEffectLayers[i].confirmRemove = true;
            }
        }
        GUI.backgroundColor = defaultColor;
    }

    void DoRemoveLayer()
    {
        if (_layerToRemove >= 0)
        {
            spriteEffect.spriteEffectLayers[_layerToRemove].isEffectCreated = false;
            EditorUtility.SetDirty(this);
            this.Repaint();
        }
        _layerToRemove = -1;
    }

    void DoEffectReset(int i)
    {
        if (GUILayout.Button($"Reset Effect {i + 1}"))
        {
            ResetLayer(i);
        }
    }

    void ResetLayer(int i)
    {
        if (i < 0)
        {
            return;
        }
        effect_Texture[i].objectReferenceValue = null;
        effect_UseFlipBook[i].boolValue = false;
        effect_UseFlipBookBlend[i].boolValue = false;
        effect_FlipBookValue[i].vector4Value = new Vector4(1, 1, 0, 0);
        effect_UseSpriteMask[i].boolValue = false;
        effect_SpriteMaskValue[i].vector4Value = Vector4.zero;
        effect_Mask[i].objectReferenceValue = null;
        effect_UseMaskUV[i].boolValue = false;
        effect_UseTimerMask[i].boolValue = false;
        effect_TimerMaskValue[i].vector4Value = new Vector4(0.3f, 0.7f, 0.1f, 0.1f);
        effect_TimerMaskBaseUV[i].boolValue = false;
        effect_Color[i].colorValue = Color.white;
        Gradient whiteGradient = new Gradient
        {
            alphaKeys = new[]
            {
                    new GradientAlphaKey(1, 0f),
                    new GradientAlphaKey(1, 1f)
                },

            colorKeys = new[]
            {
                    new GradientColorKey(Color.white, 0f),
                    new GradientColorKey(Color.white, 1f)
                }
        };
        effect_Gradient[i].gradientValue = whiteGradient;
        effect_TextureTileOffset[i].vector4Value = new Vector4(1, 1, 0, 0);
        effect_Brightness[i].floatValue = 1f;
        effect_ScaleOrigin[i].floatValue = 1f;
        effect_ScaleMultiplier[i].floatValue = 1f;
        effect_ScaleSpeed[i].floatValue = 0f;
        effect_Power[i].floatValue = 1f;
        effect_RotateAngle[i].floatValue = 0f;
        effect_RotateSpeed[i].floatValue = 0f;
        effect_HorizontalSpeed[i].floatValue = 0f;
        effect_VerticalSpeed[i].floatValue = 0f;
        effect_GlowSpeed[i].floatValue = 0f;
        effect_BlendMode[i].intValue = 0;
        effect_TimingOffset[i].floatValue = 0f;
        effect_UniformUV[i].boolValue = false;
        effect_UseAlpha[i].boolValue = false;
        effect_ScalePingPong[i].boolValue = false;
        effect_RandomRotate[i].boolValue = false;
        effect_ScrollDirection[i].boolValue = false;
        effect_DistortStrength[i].floatValue = 0f;
        effect_UseLuminanceMask[i].boolValue = false;
        effect_UseScrollCurve[i].boolValue = false;
        effect_UseRotateCurve[i].boolValue = false;
        effect_UseScaleCurve[i].boolValue = false;
        effect_UseColorCurve[i].boolValue = false;
        effect_UseFlipBookCurve[i].boolValue = false;
        effect_ScrollCurveX[i].animationCurveValue.ClearKeys();
        effect_ScrollCurveY[i].animationCurveValue.ClearKeys();
        effect_RotateCurve[i].animationCurveValue.ClearKeys();
        effect_ScaleCurve[i].animationCurveValue.ClearKeys();
        effect_ColorCurve[i].animationCurveValue.ClearKeys();
        effect_FlipBookCurve[i].animationCurveValue.ClearKeys();
    }

    bool ISLuminanceMaskON()
    {
        if (effect_SpriteTintColorUseLuminanceMask.boolValue || effect_SpriteBrightnessUseLuminanceMask.boolValue)
        {
            return true;
        }
        for (int i = 0; i < _numOfLayer; i++)
        {
            if (effect_UseLuminanceMask[i] != null && effect_UseLuminanceMask[i].boolValue == true)
            {
                return true;
            }
        }
        return false;
    }

    //private void OnDisable()
    //{
    //    if (target == null)
    //    {
    //        
    //        if (PrefabStageUtility.GetCurrentPrefabStage() == null)
    //        {
    //            Debug.Log("COMPONENT Ondisable!");
    //            DeleteMaterialAsset();
    //        }
    //        else
    //        {
    //            Debug.Log("COMPONENT Ondisable in PrefabMode!");
    //        }
    //    }
    //}

    //private void OnDestroy()
    //{
    //    Debug.Log("COMPONENT Ondestroy!");
    //    if (PrefabStageUtility.GetCurrentPrefabStage() == null)
    //    {
    //        DeleteMaterialAsset();
    //    }
    //}

    //private void DeleteMaterialAsset()
    //{
    //    string matName = "Assets/Resources/Material/" + _effectMaterialName + ".mat";
    //    if (AssetDatabase.DeleteAsset(matName))
    //    {
    //        SLog.Log(matName + "가 삭제되엇습니다.");
    //    }
    //    else
    //    {
    //        SLog.Log(matName + "가 이미 삭제되었거나 존재하지 않습니다.");
    //    }
    //}
}
/*
public static class SerializedPropertyExtensions
{
    public static SerializedProperty FindParentProperty(this SerializedProperty serializedProperty)
    {
        var propertyPaths = serializedProperty.propertyPath.Split('.');
        if (propertyPaths.Length <= 1)
        {
            return default;
        }

        var parentSerializedProperty = serializedProperty.serializedObject.FindProperty(propertyPaths.First());
        for (var index = 1; index < propertyPaths.Length - 1; index++)
        {
            if (propertyPaths[index] == "Array")
            {
                if (index + 1 == propertyPaths.Length - 1)
                {
                    // reached the end
                    break;
                }
                if (propertyPaths.Length > index + 1 && Regex.IsMatch(propertyPaths[index + 1], "^data\\[\\d+\\]$"))
                {
                    var match = Regex.Match(propertyPaths[index + 1], "^data\\[(\\d+)\\]$");
                    var arrayIndex = int.Parse(match.Groups[1].Value);
                    parentSerializedProperty = parentSerializedProperty.GetArrayElementAtIndex(arrayIndex);
                    index++;
                }
            }
            else
            {
                parentSerializedProperty = parentSerializedProperty.FindPropertyRelative(propertyPaths[index]);
            }
        }

        return parentSerializedProperty;
    }
}*/

