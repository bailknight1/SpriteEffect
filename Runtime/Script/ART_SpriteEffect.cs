using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Collections.Generic;

//[InitializeOnLoad]
//[ExecuteAlways]
//[ExecuteInEditMode]
public class ART_SpriteEffect : MonoBehaviour
{
	[SerializeField]
	public new string name;
	public enum LayerBlendMode
	{
		Additive,
		AlphaBlend,
		Mask
	}

	[System.Serializable]
	public class SpriteEffectProperties
	{
		public Texture2D textureValue = null;
		public Vector4 vector4Value = new Vector4(1, 1, 0, 0);
		public bool boolValue = false;
		public Color colorValue = Color.white;
		public float floatValue = 0f;
		public LayerBlendMode layerBlendModeValue = 0;
		public Gradient gradientValue = new Gradient();
		public bool overrideValue = false;  // 에디터의 값과 메테리얼의 값이 다를경우 true;

		public SpriteEffectProperties(Texture2D texVal, Vector4 vector4Val, bool boolVal, Color colorVal, float floatVal)
		{
			textureValue = texVal;
			vector4Value = vector4Val;
			boolValue = boolVal;
			colorValue = colorVal;
			floatValue = floatVal;
		}
		public SpriteEffectProperties(Texture2D val)
		{
			textureValue = val;
		}
		public SpriteEffectProperties(Vector4 val)
		{
			vector4Value = val;
		}
		public SpriteEffectProperties(bool val)
		{
			boolValue = val;
		}
		public SpriteEffectProperties(Color val)
		{
			colorValue = val;
		}
		public SpriteEffectProperties(float val)
		{
			floatValue = val;
		}
		public SpriteEffectProperties(LayerBlendMode val)
		{
			layerBlendModeValue = val;
		}
		public SpriteEffectProperties(Gradient val)
		{
			gradientValue = val;
		}

		public void CompareValue(Texture2D val, string valName, ref int counter)
        {
			overrideValue = textureValue != val ? true : false;
			//if (overrideValue) counter.Add(valName);
		}
		public void CompareValue(Vector4 val, string valName, ref int counter)
		{
			overrideValue = vector4Value != val ? true : false;
			//if (overrideValue) counter.Add(valName);
		}
		public void CompareValue(bool val, string valName, ref int counter)
		{
			overrideValue = boolValue != val ? true : false;
			//if (overrideValue) counter.Add(valName);
		}
		public void CompareValue(Color val, string valName, ref int counter)
		{
			overrideValue = colorValue != val ? true : false;
			//if (overrideValue) counter.Add(valName);
		}
		public void CompareValue(float val, string valName, ref int counter)
		{
			overrideValue = !Mathf.Approximately(floatValue,val);
			//if (overrideValue) counter.Add(valName);
		}
		public void CompareValue(LayerBlendMode val, string valName, ref int counter)
		{
			overrideValue = layerBlendModeValue != val ? true : false;
			//if (overrideValue) counter.Add(valName);
		}
		public void CompareValue(Gradient val, string valName, ref int counter)
		{
			overrideValue = gradientValue != val ? true : false;
			//if (overrideValue) counter.Add(valName);
		}
	}

	[System.Serializable]
	public class SpriteEffectLayer
	{
		#region Editor Only
#if UNITY_EDITOR
		public SpriteEffectProperties effectTexture;   //tex
		public SpriteEffectProperties effectTextureTileOffset = new SpriteEffectProperties(new Vector4(1, 1, 0, 0));// = new Vector4(1, 1, 0, 0);
		public SpriteEffectProperties effectUseFlipBook = new SpriteEffectProperties(false);    //bool false;
		public SpriteEffectProperties effectUseFlipBookBlend = new SpriteEffectProperties(false);  //bool false;
		public SpriteEffectProperties effectUseSpriteMask = new SpriteEffectProperties(false); //bool false;
		public SpriteEffectProperties effectSpriteMaskValue = new SpriteEffectProperties(new Vector4(0, 0, 0, 0));
		public SpriteEffectProperties effectMask;   //tex
		public SpriteEffectProperties effectUseMaskUV = new SpriteEffectProperties(false); //bool false;
		public SpriteEffectProperties effectUseTimerMask = new SpriteEffectProperties(false);  //bool false;
		public SpriteEffectProperties effectTimerMaskValue = new SpriteEffectProperties(new Vector4(0.3f, 0.7f, 0.1f, 0.1f)); //new Vector4(0.3f, 0.7f, 0.1f, 0.1f)
		public SpriteEffectProperties effectTimerMaskBaseUV = new SpriteEffectProperties(false); //bool false;
		public SpriteEffectProperties effectUniformUV = new SpriteEffectProperties(false);  //bool false;
		public SpriteEffectProperties effectColor = new SpriteEffectProperties(Color.white); //Color.white;
		public SpriteEffectProperties effectBrightness = new SpriteEffectProperties(1f); //1f;
		//[Range(0.001f, 10.0f)]
		public SpriteEffectProperties effectScale = new SpriteEffectProperties(1f); //1f;
		//[Range(0.001f, 10.0f)]
		public SpriteEffectProperties effectScaleMultiplier = new SpriteEffectProperties(1f); //1f;
		public SpriteEffectProperties effectScaleSpeed = new SpriteEffectProperties(0f); //0f;
		public SpriteEffectProperties effectScalePingPong = new SpriteEffectProperties(false);  //bool false;
		public SpriteEffectProperties effectRandomRotation = new SpriteEffectProperties(false);  //bool false;
		//[Range(0.001f, 100.0f)]
		public SpriteEffectProperties effectPower = new SpriteEffectProperties(1f); //1f;
		//[Range(0.0f, 360.0f)]
		public SpriteEffectProperties effectRotateAngle = new SpriteEffectProperties(0f); //0f;
		public SpriteEffectProperties effectRotateSpeed = new SpriteEffectProperties(0f); //0f;
		public SpriteEffectProperties effectVerticalSpeed = new SpriteEffectProperties(0f); //0f;
		public SpriteEffectProperties effectHorizontalSpeed = new SpriteEffectProperties(0f); //0f;
		public SpriteEffectProperties effectGlowSpeed = new SpriteEffectProperties(0f); //0f;
		public SpriteEffectProperties effectBlendMode = new SpriteEffectProperties(LayerBlendMode.Additive); //LayerBlendMode = 0;
		public SpriteEffectProperties effectUseAlpha = new SpriteEffectProperties(false);  //bool false;
		public SpriteEffectProperties effectScrollDirectional = new SpriteEffectProperties(false);  //bool false;
		//[Range(0f, 1.0f)]
		public SpriteEffectProperties effectDistortStrength = new SpriteEffectProperties(0f);    //0f;

		public bool isEffectvalueFolderOpen = false;   //에디터에서 프로퍼티 창을 펼쳤는가?
		public bool isEffectCreated = false;   //에디터에서 레이어가 생성되었는가?
		public bool confirmRemove = false;     //에디터에서 레이어를 지울 예정인가?
#endif
#endregion
        public bool isEffectActive = false;
		public SpriteEffectProperties effectTimingOffset = new SpriteEffectProperties(0f); //0;
		public SpriteEffectProperties effectGradient;  //Gradient

		public bool effectUseColorCurve = false;
		public bool effectUseScrollCurve = false;
		public bool effectUseRotateCurve = false;
		public bool effectUseScaleCurve = false;
		public bool effectUseFlipBookCurve = false;
		public SpriteEffectProperties effectFlipBookValue = new SpriteEffectProperties(new Vector4(1, 1, 0, 0));	// = new Vector4(1, 1, 0, 0);

		public float effectTimeColor = 0f;
		public float effectTimeScrollX = 0f;
		public float effectTimeScrollY = 0f;
		public float effectTimeRotate = 0f;
		public float effectTimeScale = 0f;
		public float effectTimeFlipBook = 0f;

		public AnimationCurve effectColorCurve;
		public AnimationCurve effectScrollCurveX;
		public AnimationCurve effectScrollCurveY;
		public AnimationCurve effectRotateCurve;
		public AnimationCurve effectScaleCurve;
		public AnimationCurve effectFlipBookCurve;
		public SpriteEffectProperties effectUseLuminanceMask = new SpriteEffectProperties(false);  // = false;
	}


	/*
	[System.Serializable]
	public class SpriteEffectLayer
	{
#if UNITY_EDITOR
		public Texture2D effectTexture;
		public Vector4 effectTextureTileOffset = new Vector4(1, 1, 0, 0);
		public bool effectUseFlipBook = false;
		public bool effectUseFlipBookBlend = false;
		public Texture2D effectMask;
		public bool effectUseMaskUV = false;
		public bool effectUseTimerMask = false;
		public Vector4 effectTimerMaskValue = new Vector4(0.3f, 0.7f, 0.1f, 0.1f);
		public bool effectTimerMaskBaseUV = false;
		public bool effectUniformUV = false;
		public Color effectColor = Color.white;
		public float effectBrightness = 1f;
		[Range(0.001f, 10.0f)]
		public float effectScale = 1f;
		[Range(0.001f, 10.0f)]
		public float effectScaleMultiplier = 1f;
		public float effectScaleSpeed = 0f;
		public bool effectScalePingPong = false;
		public bool effectRandomRotation = false;
		[Range(0.001f, 100.0f)]
		public float effectPower = 1f;
		[Range(0.0f, 360.0f)]
		public float effectRotateAngle = 0f;
		public float effectRotateSpeed = 0f;
		public float effectVerticalSpeed = 0f;
		public float effectHorizontalSpeed = 0f;
		public float effectGlowSpeed = 0f;
		public LayerBlendMode effectBlendMode = 0;
		public bool effectUseAlpha = false;
		public bool effectScrollDirectional = false;
		[Range(0f, 1.0f)]
		public float effectDistortStrength = 0f;

		public bool isEffectvalueFolderOpen = false;   //에디터에서 프로퍼티 창을 펼쳤는가?
		public bool isEffectCreated = false;   //에디터에서 레이어가 생성되었는가?
		public bool confirmRemove = false;     //에디터에서 레이어를 지울 예정인가?
#endif
		public bool isEffectActive = true;
		public float effectTimingOffset = 0;
		public Gradient effectGradient;

		public bool effectUseColorCurve = false;
		public bool effectUseScrollCurve = false;
		public bool effectUseRotateCurve = false;
		public bool effectUseScaleCurve = false;
		public bool effectUseFlipBookCurve = false;
		public Vector4 effectFlipBookValue = new Vector4(1, 1, 0, 0);

		public float effectTimeColor = 0f;
		public float effectTimeScrollX = 0f;
		public float effectTimeScrollY = 0f;
		public float effectTimeRotate = 0f;
		public float effectTimeScale = 0f;
		public float effectTimeFlipBook = 0f;

		public AnimationCurve effectColorCurve;
		public AnimationCurve effectScrollCurveX;
		public AnimationCurve effectScrollCurveY;
		public AnimationCurve effectRotateCurve;
		public AnimationCurve effectScaleCurve;
		public AnimationCurve effectFlipBookCurve;
		public bool effectUseLuminanceMask = false;
	}*/

	[System.Serializable]
	struct SpriteEffectPropertyID
	{
		public int scrollString;
		public int rotateString;
		public int scaleString;
		public int colorString;
		public int flipBookString;

		public SpriteEffectPropertyID(string a, string b, string c, string d, string e)
		{
			scrollString = Shader.PropertyToID(a);
			rotateString = Shader.PropertyToID(b);
			scaleString = Shader.PropertyToID(c);
			colorString = Shader.PropertyToID(d);
			flipBookString = Shader.PropertyToID(e);
		}
	}

	public SpriteEffectLayer[] spriteEffectLayers = new SpriteEffectLayer[_numOfLayer];
	const int _numOfLayer = 6;

	public bool isSpriteOptionFolderOpen = false;   //에디터에서 스프라이트 옵션폴더를 펼쳤는가?

	public SpriteEffectProperties setSpriteGrayScale = new SpriteEffectProperties(false); // = false;
																						  //[Range(0f, 1f)]
	public SpriteEffectProperties spriteGrayScaleValue = new SpriteEffectProperties(1f); //1f;
	public SpriteEffectProperties spriteGrayScaleUseCurve = new SpriteEffectProperties(false);// = false;
	public AnimationCurve spriteGrayScaleCurve;
	public float spriteTimeGrayScale = 0f;
	//public SpriteEffectProperties spriteGrayScaleUseLuminanceMask = new SpriteEffectProperties(false);// = false;
	private int spriteGrayScaleValueID = Shader.PropertyToID("_BaseGrayscaleValue");

	public SpriteEffectProperties setSpriteBrightness = new SpriteEffectProperties(false);// = false;
																						  //[Range(0f, 10.0f)]
	public SpriteEffectProperties spriteBrightnessValue = new SpriteEffectProperties(10f); //10f;
	public SpriteEffectProperties spriteBrightnessUseCurve = new SpriteEffectProperties(false);// = false;
	public AnimationCurve spriteBrightnessCurve;
	public float spriteTimeBrightness = 0f;
	public SpriteEffectProperties spriteBrightnessUseLuminanceMask = new SpriteEffectProperties(false);// = false;
	private int spriteBrightnessValueID = Shader.PropertyToID("_BaseBrightnessValue");

	public SpriteEffectProperties setSpriteTintColor = new SpriteEffectProperties(false);// = false;
	public SpriteEffectProperties spriteTintColorValue = new SpriteEffectProperties(Color.white);// = Color.white;
	public SpriteEffectProperties spriteTintColorUseLuminanceMask = new SpriteEffectProperties(false);// = false;
	public SpriteEffectProperties spriteTintColorUseCurve = new SpriteEffectProperties(false);// = false;
	public AnimationCurve spriteTintColorCurve;
	public SpriteEffectProperties spriteTintColorGradient; //Gradient
	public float spriteTimeTintColor = 0f;
	private int spriteTintColorID = Shader.PropertyToID("_BaseTintColor");

	public SpriteEffectProperties setSpriteCutOut = new SpriteEffectProperties(false);  // = false;
	public SpriteEffectProperties spriteCutOutTexture;	//tex
	public SpriteEffectProperties spriteCutOutTextureTileOffset = new SpriteEffectProperties(new Vector4(1, 1, 0, 0));   // = new Vector4(1, 1, 0, 0);
	public SpriteEffectProperties spriteCutOutValue = new SpriteEffectProperties(new Vector4(0.5f, 1, 0, 1));	//	 = new Vector4(0.5f, 1, 0, 1);
	public SpriteEffectProperties spriteCutOutEdgeColor = new SpriteEffectProperties(Color.white); // = Color.white;
	public SpriteEffectProperties spriteCutOutEdgeBrightness = new SpriteEffectProperties(1f); //1f;
	public SpriteEffectProperties spriteCutOutFillColor = new SpriteEffectProperties(Color.white); // = Color.white;
	public SpriteEffectProperties spriteCutOutFillBrightness = new SpriteEffectProperties(1f); //1f;
	public SpriteEffectProperties spriteCutOutUseSliceUV = new SpriteEffectProperties(false); // = false;
	public SpriteEffectProperties spriteCutOutUniformUV = new SpriteEffectProperties(false);  // = false;
	public SpriteEffectProperties spriteCutOutDoNotUseAlpha = new SpriteEffectProperties(false);  // = false;
	public SpriteEffectProperties spriteCutOutUseCurve = new SpriteEffectProperties(false); // = false;
	public AnimationCurve spriteCutOutCurve;
	public float spriteTimeCutOut = 0f;
	public SpriteEffectProperties spriteCutOutProgress = new SpriteEffectProperties(0f);
	//private int spriteCutOutValueID = Shader.PropertyToID("_BaseCutOutVal");
	private int spriteCutOutProgressID = Shader.PropertyToID("_BaseCutOutProgress");

	private int spriteDataID = Shader.PropertyToID("_SpriteData");

	public SpriteEffectProperties setSpriteVertexAnim = new SpriteEffectProperties(false);    // = false;
	public SpriteEffectProperties spriteVertexAnimValue = new SpriteEffectProperties(new Vector4(0, 0, 0, 0));   // = new Vector4(0, 0, 0, 0);

	public SpriteEffectProperties setSpriteTransparent = new SpriteEffectProperties(false);   // = false;
	public SpriteEffectProperties useUnscaledTime = new SpriteEffectProperties(false);    // = false;

	//[Range(0f, 1.0f)]
	public SpriteEffectProperties luminanceMaskThresholdMin = new SpriteEffectProperties(0.01f); // = 0.01f;
	//[Range(0f, 1.0f)]
	public SpriteEffectProperties luminanceMaskThresholdMax = new SpriteEffectProperties(0.1f);    // = 0.1f;

	private Vector4 aspectRatio = new Vector4(1, 1, 0, 0);
	private Vector4 maskData = new Vector4(1, 1, 0, 0);
	private int aspectRatioPropertyID = Shader.PropertyToID("_AspectRatio");
	private int maskDataPropertyID = Shader.PropertyToID("_MaskData");
	private int rectPropertyID = Shader.PropertyToID("_Rect");

	private SpriteEffectPropertyID[] curveID = new SpriteEffectPropertyID[_numOfLayer]
	{
		new SpriteEffectPropertyID ("_Effect1ScrollCurve","_Effect1RotateCurve","_Effect1ScaleCurve","_Effect1Color","_Effect1FlipbookValue"),
		new SpriteEffectPropertyID ("_Effect2ScrollCurve","_Effect2RotateCurve","_Effect2ScaleCurve","_Effect2Color","_Effect2FlipbookValue"),
		new SpriteEffectPropertyID ("_Effect3ScrollCurve","_Effect3RotateCurve","_Effect3ScaleCurve","_Effect3Color","_Effect3FlipbookValue"),
		new SpriteEffectPropertyID ("_Effect4ScrollCurve","_Effect4RotateCurve","_Effect4ScaleCurve","_Effect4Color","_Effect4FlipbookValue"),
		new SpriteEffectPropertyID ("_Effect5ScrollCurve","_Effect5RotateCurve","_Effect5ScaleCurve","_Effect5Color","_Effect5FlipbookValue"),
		new SpriteEffectPropertyID ("_Effect6ScrollCurve","_Effect6RotateCurve","_Effect6ScaleCurve","_Effect6Color","_Effect6FlipbookValue")
	};
	/*
    //[Space(10)]
    //[Header("Effect 1")]
    [SerializeField]
    private Texture2D effect1Texture;
    [SerializeField]
    private Vector4 effect1TextureTileOffset= new Vector4(1,1,0,0);
    [SerializeField]
    private Texture2D effect1Mask;
    [SerializeField]
    private bool effect1UniformUV = false;
    [SerializeField]
    private Color effect1Color = Color.white;
    [SerializeField]
    private float effect1Brightness = 1f;
    [SerializeField]
    [Range(0.001f, 10.0f)]
    private float effect1Scale = 1f;
    [SerializeField]
    [Range(0.001f, 10.0f)]
    private float effect1Power = 1f;
    [SerializeField]
    [Range(0.0f, 360.0f)]
    private float effect1RotateAngle = 0f;
    [SerializeField]
    private float effect1RotateSpeed = 0f;
    [SerializeField]
    private float effect1VerticalSpeed = 0f;
    [SerializeField]
    private float effect1HorizontalSpeed = 0f;
    [SerializeField]
    private float effect1GlowSpeed = 0f;
    //[SerializeField]
    //private bool effect1MultiplyBlend = false;
    //[SerializeField]
    //private bool effect1AlphaBlend = false;
    //[SerializeField]
    public LayerBlendMode effect1BlendMode = 0;
    [SerializeField]
    private bool isEffect1Active = true;

    //[Space(10)]
    //[Header("Effect 2")]
    [SerializeField]
    private bool isEffect2Active = true;
    [SerializeField]
    private Texture2D effect2Texture;
    [SerializeField]
    private Vector4 effect2TextureTileOffset = new Vector4(1, 1, 0, 0);
    [SerializeField]
    private Texture2D effect2Mask;
    [SerializeField]
    private bool effect2UniformUV = false;
    [SerializeField]
    private Color effect2Color = Color.white;
    [SerializeField]
    private float effect2Brightness = 1f;
    [SerializeField]
    [Range(0.001f, 10.0f)]
    private float effect2Scale = 1f;
    [SerializeField]
    [Range(0.001f, 10.0f)]
    private float effect2Power = 1f;
    [SerializeField]
    [Range(0.0f, 360.0f)]
    private float effect2RotateAngle = 0f;
    [SerializeField]
    private float effect2RotateSpeed = 0f;
    [SerializeField]
    private float effect2VerticalSpeed = 0f;
    [SerializeField]
    private float effect2HorizontalSpeed = 0f;
    [SerializeField]
    private float effect2GlowSpeed = 0f;
    //[SerializeField]
    //private bool effect2MultiplyBlend = false;
    //[SerializeField]
    //private bool effect2AlphaBlend = false;
    //[SerializeField]
    public LayerBlendMode effect2BlendMode = 0;

    //[Space(10)]
    //[Header("Effect 3")]
    [SerializeField]
    private bool isEffect3Active = true;
    [SerializeField]
    private Texture2D effect3Texture;
    [SerializeField]
    private Vector4 effect3TextureTileOffset = new Vector4(1, 1, 0, 0);
    [SerializeField]
    private Texture2D effect3Mask;
    [SerializeField]
    private bool effect3UniformUV = false;
    [SerializeField]
    private Color effect3Color = Color.white;
    [SerializeField]
    private float effect3Brightness = 1f;
    [SerializeField]
    [Range(0.001f, 10.0f)]
    private float effect3Scale = 1f;
    [SerializeField]
    [Range(0.001f, 10.0f)]
    private float effect3Power = 1f;
    [SerializeField]
    [Range(0.0f, 360.0f)]
    private float effect3RotateAngle = 0f;
    [SerializeField]
    private float effect3RotateSpeed = 0f;
    [SerializeField]
    private float effect3VerticalSpeed = 0f;
    [SerializeField]
    private float effect3HorizontalSpeed = 0f;
    [SerializeField]
    private float effect3GlowSpeed = 0f;
    //[SerializeField]
    //private bool effect3MultiplyBlend = false;
    //[SerializeField]
    //private bool effect3AlphaBlend = false;
    //[SerializeField]
    public LayerBlendMode effect3BlendMode = 0;

    //[Space(10)]
    //[Header("Effect 4")]
    [SerializeField]
    private bool isEffect4Active = true;
    [SerializeField]
    private Texture2D effect4Texture;
    [SerializeField]
    private Vector4 effect4TextureTileOffset = new Vector4(1, 1, 0, 0);
    [SerializeField]
    private Texture2D effect4Mask;
    [SerializeField]
    private bool effect4UniformUV = false;
    [SerializeField]
    private Color effect4Color = Color.white;
    [SerializeField]
    private float effect4Brightness = 1f;
    [SerializeField]
    [Range(0.001f, 10.0f)]
    private float effect4Scale = 1f;
    [SerializeField]
    [Range(0.001f, 10.0f)]
    private float effect4Power = 1f;
    [SerializeField]
    [Range(0.0f, 360.0f)]
    private float effect4RotateAngle = 0f;
    [SerializeField]
    private float effect4RotateSpeed = 0f;
    [SerializeField]
    private float effect4VerticalSpeed = 0f;
    [SerializeField]
    private float effect4HorizontalSpeed = 0f;
    [SerializeField]
    private float effect4GlowSpeed = 0f;
    //[SerializeField]
    //private bool effect4MultiplyBlend = false;
    //[SerializeField]
    //private bool effect4AlphaBlend = false;
    //[SerializeField]
    public LayerBlendMode effect4BlendMode = 0;

    //[Space(10)]
    //[Header("Effect 5")]
    [SerializeField]
    private bool isEffect5Active = true;
    [SerializeField]
    private Texture2D effect5Texture;
    [SerializeField]
    private Vector4 effect5TextureTileOffset = new Vector4(1, 1, 0, 0);
    [SerializeField]
    private Texture2D effect5Mask;
    [SerializeField]
    private bool effect5UniformUV = false;
    [SerializeField]
    private Color effect5Color = Color.white;
    [SerializeField]
    private float effect5Brightness = 1f;
    [SerializeField]
    [Range(0.001f, 10.0f)]
    private float effect5Scale = 1f;
    [SerializeField]
    [Range(0.001f, 10.0f)]
    private float effect5Power = 1f;
    [SerializeField]
    [Range(0.0f, 360.0f)]
    private float effect5RotateAngle = 0f;
    [SerializeField]
    private float effect5RotateSpeed = 0f;
    [SerializeField]
    private float effect5VerticalSpeed = 0f;
    [SerializeField]
    private float effect5HorizontalSpeed = 0f;
    [SerializeField]
    private float effect5GlowSpeed = 0f;
    //[SerializeField]
    //private bool effect5MultiplyBlend = false;
    //[SerializeField]
    //private bool effect5AlphaBlend = false;
    //[SerializeField]
    public LayerBlendMode effect5BlendMode = 0;
    */
	private Image m_image;
	private SpriteRenderer m_spriteRenderer;
	private Sprite sprite;
	private Vector4 m_spriteRendererData = new Vector4(1, 1, 0, 0);
	private Vector4 m_resultVector = new Vector4(0, 0, 1, 1);
	private MaterialPropertyBlock block;
	//private Vector3 previousSpriteRendererPosition;

	[SerializeField]
	private Material effectMaterial;    //현재 렌더러의 메테리얼
	private Material previousMaterial;   //이전 메테리얼 
	[SerializeField]
	private Material createdMaterial;  // 생성된 메테리얼
	private Material tempMaterial;   // 임시 메테리얼
	private Material instancedMaterial;   // 애니메이션커브 적용용 인스턴스 메테리얼
	private Material instanceSourceMaterial;   // 인스턴스한 소스 메테리얼
	private Material defaultSpriteMaterial;  // 이펙트를 제거할때 스프라이트 렌더러에 배정해줄 메테리얼 (Sprite-Default)

	public bool haveUnsavedChange;

	private bool needUpdate = false;
	private bool needCurveReset = false;
	private Vector3 previousRendererScale = Vector3.one;

	private bool needMaterialUpdate = false;

#if UNITY_EDITOR
	private string effectShader = "Hidden/UI_Effect_Optimized";
	//private string oldEffectShader = "Hidden/UI_Effect_Variant";
	private string materialAssetPrefix = "SpriteEffect_";
	private float editorTime = 0f;
	private bool? isSpriteChanged = null;  //이번프레임에 스프라이트 변경 체크를 이미 했는가?
	private bool killCheck = false;   //킬체크 실행했는가?
	private bool imageMaskableState = false;    //이전 마스커블 상태
#endif

	private Vector2 previousSpriteRendererSize;
	private SpriteDrawMode previousDrawMode;
	private Sprite previousSprite;

	private bool changeSpriteCall = false;   //스프라이트변경요청이 있는가?
	private bool useCurveInPlayMode = false;  //플레이모드중 항상 애니메이션 커브를 사용할것인가?
	private bool? haveRenderer = null;  //플레이모드중 렌더러가 존재하는가?
	private bool? isSpriteRenderer = null;  //플레이모드중 사용하는 렌더러가 스프라이트 렌더러인가?
	private bool? isUseCurve = null;    //이번프레임에 커브체크를 이미 했는가?
	private bool? isAspectChanged = null;  //이번프레임에 종횡비 변경 체크를 이미 했는가?
	private bool isInitialized = false;  //초기화되었는가?


	void OnEnable()
	{
		RunTimeInitialize();
		if (block == null)
		{
			block = new MaterialPropertyBlock();
		}
	}

	void OnDisable()
	{
		RemoveMaterialInstance(true);
		//ResetTimeCurve();
	}

	void OnDestroy()
	{
		RemoveMaterialInstance(true);
	}

	public void Initialize()  // 매니저에서만 호출
	{
        if (!Application.isPlaying)
        {
			if (HaveRenderer())
			{
				isInitialized = false;
                if (createdMaterial == null && effectMaterial != null && !isInitialized)
                {
					createdMaterial = effectMaterial;
				}

#if UNITY_EDITOR
				if (createdMaterial != null && !isInitialized)
                {
					LoadCreatedMaterialValue();
                }
#endif
				UpdateMat(effectMaterial);
				isInitialized = true;
			}
		}
	}

	/// <summary>
	/// 스프라이트 변경시 초기화 호출
	/// </summary>
	public void SpriteChange()	//스프라이트교체 콜
	{
		changeSpriteCall = true;
		sprite = RendererSprite();
		RunTimeInitialize();
	}

	private void RunTimeInitialize()
	{
		if (Application.isPlaying)
		{
			if (HaveRenderer())
			{
				isInitialized = false;
				if (effectMaterial == null && createdMaterial != null)
				{
					effectMaterial = createdMaterial;
				}
				if (effectMaterial != null)
				{
					useCurveInPlayMode = CheckUseCurveInternal();

					if (useCurveInPlayMode)
                    {
						ResetTimeCurve();
					}
					UpdateMat(effectMaterial);
				}
				else Debug.LogWarning("SpriteEffect : effectMaterial is null", this);
				isInitialized = true;
			}
		}
	}

	private void Update()
	{
		if (HaveRenderer())
		{
			UpdateMat(effectMaterial);
		}
	}

	private void UpdateMat(Material mat)  // 메인 업데이트 루프
	{
		if (this.enabled == true)
		{
			ResetBoolChecks();
			if (NeedUpdate())  // 업데이트할 요소가 존재하는지 확인
			{
				mat = RenderingMat(mat);// 1.에디터에서 매테리얼 저장상황에 따라 적절한 렌더링 메테리얼을 지정.			
				SetMaterial(ref mat);// 2.메테리얼을 렌더러에 지정
				UpdateMaterial(mat);// 3.스크립트에 지정된 값을 렌더링 메테리얼에 설정	
#if UNITY_EDITOR
				if (!Application.isPlaying)
				{
					PrefabUtility.RecordPrefabInstancePropertyModifications(this);
				}
#endif
			}
			ResetBoolChecks();
		}
	}

	private Material RenderingMat(Material mat)    // 렌더러에 사용될 적절한 메테리얼을 반환
	{
		if (needMaterialUpdate)   //커브사용시 haveUnsavedChange 를 항상 참으로(인스턴스 상시사용)
		{
			haveUnsavedChange = true;
		}
		if (createdMaterial != null && !haveUnsavedChange)   // 변경사항이 없고 createdMaterial이 있으면 mat로 설정
		{
			//Debug.LogWarning("ManageMaterial() set to create");
			mat = createdMaterial;
			return mat;
		}
		else if (createdMaterial != null && haveUnsavedChange && instancedMaterial != null && instanceSourceMaterial == createdMaterial)// 변경사항이 있을때 이미 인스턴스가 있으면 유지
		{
			//Debug.LogWarning("ManageMaterial() reuse Instance");
			mat = instancedMaterial;
			if (instancedMaterial.name != createdMaterial.name + " (Instanced)")  // 메테리얼 이름을 바꿧을때 저장된 인스턴스 이름도 맞춰줌
			{
				instancedMaterial.name = createdMaterial.name + " (Instanced)";
			}
			return mat;
		}
		else if (createdMaterial != null && haveUnsavedChange && instanceSourceMaterial != createdMaterial)  // 변경사항이 있고 인스턴스가 현재 메테리얼의 인스턴스가 아닐 경우 새로 생성
		{
			//Debug.LogWarning("ManageMaterial() create Instance");
			mat = CreateMaterialInstance(createdMaterial);
			return mat;
		}
		else if (tempMaterial != null)   //  아직 저장한 메테리얼이 없을때 이미 임시 메테리얼이 있으면 유지
		{
			//Debug.LogWarning("ManageMaterial() reuse Temp");
			mat = tempMaterial;
			if (tempMaterial.name != this.name + " (Instanced)")  // 메테리얼 이름을 바꿧을때 저장된 인스턴스 이름도 맞춰줌
			{
				tempMaterial.name = this.name + " (Instanced)";
			}
			return mat;
		}
		if (createdMaterial == null && mat == null)   // createdMaterial 과 mat이 둘다 없을때 임시생성
		{
			if (Application.isPlaying)  // 플레이중일땐 기본메테리얼을 리턴 (실행중일땐 Async컴파일이 안되서 이팩트쉐이더로 메테리얼을 생성해도 의미가 없음)
            {
				//Debug.LogWarning("ManageMaterial() reset to default");
				Debug.LogError("Effect Material is null at", this.gameObject);
				mat = IsSpriteRenderer() ? SpriteDefaultMaterial() : m_image.defaultMaterial;
            }
#if UNITY_EDITOR
            else   // 플레이중이 아닐때는 임시메테리얼을 리턴
            {
				//Debug.LogWarning("ManageMaterial() create Temp");
				mat = CreatTemporatyMaterial();
			}
#endif
			return mat;
		}
		//Debug.LogWarning("ManageMaterial() do nothing");
		return mat;
	}

	private void UpdateMaterial(Material mat)   // 메테리얼 프로퍼티 셋팅
	{
		if (mat != null)
		{
			if (CheckValueChange())  // 스크립트에 지정된 값을 메테리얼에 셋팅
			{
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
					SetMaterialValue(mat); //에디터에서만 처리. 플레이중엔 앞으로 변경될일이 99% 없다.
				}
#endif
				needUpdate = false;
			}

			if (IsSpriteRenderer())   // 스프라이트 렌더러일 경우 추가 설정
			{
				if (CheckSpriteDataChange())    //스프라이트가 변경될경우
				{
					SetRect(mat);
					SetMaskData(mat);
				}
				if (CheckSpriteDataChange() || NeedAspectUpdate())  //스프라이트가 변경되거나 종횡비가 변할경우
                {
					SetAspect(mat);
				}
				changeSpriteCall = false;  // 스프라이트 교체 관련 작업완료
				
			}

			if (CheckUseCurve())  //커브를 쓴다면 커브값을 메테리얼에 셋팅
			{
				SetAnimCurve(mat);
			}
		}
	}

	#region Set material for renderer
	private Sprite RendererSprite()
	{
		if (m_image != null && m_spriteRenderer == null)
		{
			return m_image.sprite;
		}
		else if (m_image == null && m_spriteRenderer != null)
		{
			return m_spriteRenderer.sprite;
		}
		else
		{
			return null;
		}
	}

	private void SetRect(Material mat)
	{
		if (m_spriteRenderer != null)
		{
			if (m_spriteRenderer.drawMode != SpriteDrawMode.Simple)   // 스프라이트 랜더러 모드가 slice 나 tile 일 경우
			{
				m_spriteRendererData = new Vector4(Mathf.Max(0.0001f, m_spriteRenderer.size.x),
													Mathf.Max(0.0001f, m_spriteRenderer.size.y),
													transform.position.x, transform.position.y);  // <- 실제로 쉐이더에서 사용하지않음. 프로퍼티블럭을 분할하기위해사용
			}
			else
			{
				m_spriteRendererData = new Vector4(Mathf.Max(0.0001f, sprite.rect.width / sprite.pixelsPerUnit),
													Mathf.Max(0.0001f, sprite.rect.height / sprite.pixelsPerUnit),
													0, 0);  // <- 실제로 쉐이더에서 사용하지않음. 프로퍼티블럭을 분할하기위해사용
			}

			if (sprite != null)
			{
				m_resultVector = new Vector4(sprite.textureRect.min.x / sprite.texture.width,
											sprite.textureRect.min.y / sprite.texture.height,
											sprite.textureRect.max.x / sprite.texture.width,
											sprite.textureRect.max.y / sprite.texture.height);
			}
			else m_resultVector = new Vector4(0, 0, 1, 1);

			if (block == null)
			{
				block = new MaterialPropertyBlock();
			}
			block.SetVector(spriteDataID, m_spriteRendererData);
			block.SetVector(rectPropertyID, m_resultVector);
			m_spriteRenderer.SetPropertyBlock(block);
		}
	}

	private void SetAspect(Material mat)
	{
		if (m_spriteRenderer != null)
		{
			float rendererAspect = ((float)m_spriteRenderer.sprite.textureRect.width * m_spriteRenderer.gameObject.transform.lossyScale.x) / ((float)m_spriteRenderer.sprite.textureRect.height * m_spriteRenderer.gameObject.transform.lossyScale.y);
			if (rendererAspect >= 1f)
			{
				aspectRatio.x = 1f;
				aspectRatio.y = rendererAspect;
			}
			else
			{
				aspectRatio.x = 1f / rendererAspect;
				aspectRatio.y = 1f;
			}

			if (block == null)
			{
				block = new MaterialPropertyBlock();
			}
			block.SetVector(aspectRatioPropertyID, aspectRatio);
			m_spriteRenderer.SetPropertyBlock(block);
		}
	}

	private void SetMaskData(Material mat)
	{
		if (m_spriteRenderer != null)
		{
			if (sprite == null)
			{
				sprite = RendererSprite();
			}
			if (sprite != null)
			{
				float ratioWidth = sprite.textureRect.width / sprite.rect.width;
				float ratioHeight = sprite.textureRect.height / sprite.rect.height;
				float pivotX = 0.5f - (sprite.pivot.x - sprite.textureRectOffset.x) / sprite.rect.width;
				float pivotY = 0.5f - (sprite.pivot.y - sprite.textureRectOffset.y) / sprite.rect.height;
				maskData.x = ratioWidth;
				maskData.y = ratioHeight;
				maskData.z = pivotX;
				maskData.w = pivotY;

				if (block == null)
				{
					block = new MaterialPropertyBlock();
				}
				block.SetVector(maskDataPropertyID, maskData);
				m_spriteRenderer.SetPropertyBlock(block);
			}
		}
	}

	private Material CreateMaterialInstance(Material mat)
	{
		instanceSourceMaterial = mat;
		RemoveMaterialInstance();
		instancedMaterial = Instantiate(mat);
		instancedMaterial.name = mat.name + " (Instanced)";
		instancedMaterial.hideFlags = HideFlags.HideAndDontSave;
		return instancedMaterial;
	}

	private void RemoveMaterialInstance(bool reset = false)
	{
		if (instancedMaterial != null)
		{
			if (Application.isPlaying)
				Destroy(instancedMaterial);
			else
				DestroyImmediate(instancedMaterial);
			instancedMaterial = null;
		}
		if (reset)
		{
			instanceSourceMaterial = null;
			if (this.isActiveAndEnabled)
			{
				if (effectMaterial != null)
				{
					SetMaterial(ref effectMaterial);
				}
			}
		}
	}

	private Material SpriteDefaultMaterial()
	{
#if UNITY_EDITOR
		defaultSpriteMaterial = DefaultSpriteMaterialAsset("Assets/Resources/SpriteEffectMaterial");
#endif
		if (defaultSpriteMaterial == null)
		{
			defaultSpriteMaterial = Resources.Load<Material>("SpriteEffectMaterial/SpriteEffect_Default");
		}
		return defaultSpriteMaterial;
	}

	private void SetMaterial(ref Material mat)
	{
		if (IsSpriteRenderer())
		{
			SetMaterialForSprite(mat);
		}
		else
		{
			SetMaterialForImage(ref mat);
		}
	}

	private void SetMaterialForImage(ref Material mat)
	{
		if (m_image.material != mat)
		{
			m_image.material = mat;
			if (m_image.maskable == true)
			{
				m_image.RecalculateMasking();
			}
		}
		if (m_image.maskable == true && m_image.material == mat && m_image.materialForRendering != null)
		{
			mat = m_image.materialForRendering;
			mat.SetFloat("_UseUIAlphaClip", 1);
			LocalKeyword keyword = new LocalKeyword(mat.shader, "UNITY_UI_ALPHACLIP");
			mat.SetKeyword(keyword, true);
		}
	}

	private void SetMaterialForSprite(Material mat)
	{
		if (m_spriteRenderer.sharedMaterial != mat)
		{
			m_spriteRenderer.sharedMaterial = mat;
		}
	}

	#region Set Animtaion Curve
	private void SetAnimCurve(Material mat)
	{
		if (mat != null && HaveRenderer())
		{
			if (needCurveReset && !CheckUseCurve())
			{
				ResetTimeCurve();
				needCurveReset = false;
			}

			float deltatime = useUnscaledTime.boolValue ? Time.unscaledDeltaTime : Time.deltaTime;

#if UNITY_EDITOR
			if (!Application.isPlaying)
			{
				deltatime = Time.realtimeSinceStartup - editorTime;
				editorTime = Time.realtimeSinceStartup;
			}
#endif
			if (!setSpriteTransparent.boolValue)
			{
				SetSpriteCurve(mat, spriteGrayScaleValueID, spriteGrayScaleCurve, ref spriteTimeGrayScale, spriteGrayScaleValue.floatValue, deltatime, spriteGrayScaleUseCurve.boolValue);
				SetSpriteCurve(mat, spriteBrightnessValueID, spriteBrightnessCurve, ref spriteTimeBrightness, spriteBrightnessValue.floatValue, deltatime, spriteBrightnessUseCurve.boolValue);
				SetGradientCurve(mat, spriteTintColorID, spriteTintColorCurve, spriteTintColorGradient.gradientValue, ref spriteTimeTintColor, deltatime, 0f, spriteTintColorUseCurve.boolValue);
			}

			SetValueCurve(mat, spriteCutOutProgressID, ref spriteCutOutProgress.floatValue, spriteCutOutCurve, ref spriteTimeCutOut, deltatime, spriteCutOutUseCurve.boolValue && setSpriteCutOut.boolValue);

			for (int i = 0; i < _numOfLayer; i++)
			{
				SetScrollCurve(mat, curveID[i].scrollString, spriteEffectLayers[i].effectScrollCurveX, spriteEffectLayers[i].effectScrollCurveY, ref spriteEffectLayers[i].effectTimeScrollX, ref spriteEffectLayers[i].effectTimeScrollY, deltatime, spriteEffectLayers[i].effectTimingOffset.floatValue, spriteEffectLayers[i].effectUseScrollCurve);
				SetRotateCurve(mat, curveID[i].rotateString, spriteEffectLayers[i].effectRotateCurve, ref spriteEffectLayers[i].effectTimeRotate, deltatime, spriteEffectLayers[i].effectTimingOffset.floatValue, spriteEffectLayers[i].effectUseRotateCurve);
				SetScaleCurve(mat, curveID[i].scaleString, spriteEffectLayers[i].effectScaleCurve, ref spriteEffectLayers[i].effectTimeScale, deltatime, spriteEffectLayers[i].effectTimingOffset.floatValue, spriteEffectLayers[i].effectUseScaleCurve);
				SetGradientCurve(mat, curveID[i].colorString, spriteEffectLayers[i].effectColorCurve, spriteEffectLayers[i].effectGradient.gradientValue, ref spriteEffectLayers[i].effectTimeColor, deltatime, spriteEffectLayers[i].effectTimingOffset.floatValue, spriteEffectLayers[i].effectUseColorCurve);
				SetFlipBookCurve(mat, curveID[i].flipBookString, spriteEffectLayers[i].effectFlipBookCurve, ref spriteEffectLayers[i].effectTimeFlipBook, ref spriteEffectLayers[i].effectFlipBookValue.vector4Value, deltatime, spriteEffectLayers[i].effectTimingOffset.floatValue, spriteEffectLayers[i].effectUseFlipBookCurve);
			}
		}
	}

	private void SetSpriteCurve(Material mat, int propertyID, AnimationCurve animCurve, ref float effectTime, float maxValue, float deltaTime, bool isEnabled)
	{
		if (isEnabled)
		{
			mat.SetFloat(propertyID, animCurve.Evaluate(CurveTime(animCurve, ref effectTime, deltaTime, 0f)) * maxValue);
		}
	}

	private void SetScrollCurve(Material mat, int propertyID, AnimationCurve animCurve1, AnimationCurve animCurve2, ref float effectTime1, ref float effectTime2, float deltaTime, float timeOffset, bool isEnabled)
	{
		if (isEnabled)
		{
			Vector2 curveVal = Vector2.zero;
			curveVal.x = animCurve1.Evaluate(CurveTime(animCurve1, ref effectTime1, deltaTime, timeOffset));
			curveVal.y = animCurve2.Evaluate(CurveTime(animCurve2, ref effectTime2, deltaTime, timeOffset));
			mat.SetVector(propertyID, curveVal);
		}
	}

	private void SetRotateCurve(Material mat, int propertyID, AnimationCurve animCurve, ref float effectTime, float deltaTime, float timeOffset, bool isEnabled)
	{
		if (isEnabled)
		{
			mat.SetFloat(propertyID, animCurve.Evaluate(CurveTime(animCurve, ref effectTime, deltaTime, timeOffset)) * 360f * -Mathf.Deg2Rad);
		}
	}

	private void SetScaleCurve(Material mat, int propertyID, AnimationCurve animCurve, ref float effectTime, float deltaTime, float timeOffset, bool isEnabled)
	{
		if (isEnabled)
		{
			mat.SetFloat(propertyID, animCurve.Evaluate(CurveTime(animCurve, ref effectTime, deltaTime, timeOffset)));
		}
	}

	private void SetGradientCurve(Material mat, int propertyID, AnimationCurve animCurve, Gradient gradient, ref float effectTime, float deltaTime, float timeOffset, bool isEnabled)
	{
		if (isEnabled)
		{
			mat.SetColor(propertyID, gradient.Evaluate(CurveTime(animCurve, ref effectTime, deltaTime, timeOffset, true)));
		}
	}

	private void SetFlipBookCurve(Material mat, int propertyID, AnimationCurve animCurve, ref float effectTime, ref Vector4 flipbookValue, float deltaTime, float timeOffset, bool isEnabled)
	{
		if (isEnabled)
		{
			flipbookValue.z = animCurve.Evaluate(CurveTime(animCurve, ref effectTime, deltaTime, timeOffset));
			flipbookValue.w = 0f;
			mat.SetVector(propertyID, flipbookValue);
		}
	}

	private void SetValueCurve(Material mat, int propertyID, ref float value, AnimationCurve animCurve, ref float effectTime, float deltaTime, bool isEnabled)
    {
		if (isEnabled)
		{
			value = animCurve.Evaluate(CurveTime(animCurve, ref effectTime, deltaTime, 0f));
			mat.SetFloat(propertyID, value);
		}
	}

	private float CurveTime(AnimationCurve animCurve, ref float effectTime, float deltaTime, float timeOffset, bool normalize = false)
	{
		if (animCurve.length != 0)
		{
			var lastFrameTime = animCurve[animCurve.length - 1].time;
			effectTime += deltaTime;
			if (effectTime > lastFrameTime)
			{
				effectTime = 0;
			}
			var evalTime = effectTime + timeOffset;
			if (evalTime > lastFrameTime)
			{
				evalTime = evalTime - lastFrameTime;
			}
			if (normalize)
			{
				evalTime /= lastFrameTime;
			}
			return evalTime;
		}
		else
		{
			return 0f;
		}
	}

	private void ResetTimeCurve()
	{
		spriteTimeGrayScale = 0f;
		spriteTimeBrightness = 0f;
		spriteTimeTintColor = 0f;
		for (int i = 0; i < _numOfLayer; i++)
		{
			if (spriteEffectLayers[i] != null)
			{
				spriteEffectLayers[i].effectTimeScrollX = 0f;
				spriteEffectLayers[i].effectTimeScrollY = 0f;
				spriteEffectLayers[i].effectTimeRotate = 0f;
				spriteEffectLayers[i].effectTimeScale = 0f;
				spriteEffectLayers[i].effectTimeColor = 0f;
				spriteEffectLayers[i].effectTimeFlipBook = 0f;
			}
		}
	}
	#endregion Set Animation Curve
	#endregion Set material for renderer

	#region Bool Check Group
	private bool HaveRenderer()  // 랜더러가 존재하는가?
	{
        if (Application.isPlaying)	//플레이중일때는 한번만 체크 성공하면 그뒤론 항상 참
        {
			if (haveRenderer.HasValue && haveRenderer.Value == true)
			{
				return true;
			}
		}

		if (m_image == null)
			m_image = GetComponent<Image>();
		if (m_spriteRenderer == null)
			m_spriteRenderer = GetComponent<SpriteRenderer>();
		if (m_image == null && m_spriteRenderer == null)
		{
			Debug.LogError("Renderer Not Found in " + this.gameObject);
			m_resultVector = Vector4.zero;
			return false;
		}
		else
		{
			sprite = RendererSprite();
			haveRenderer = true;
			return true;
		}
	}
	private bool IsSpriteRenderer()  //스프라이트 렌더러를 쓰나? false면 이미지렌더러
	{
		if (Application.isPlaying)  //플레이중일때는 한번만 체크
		{
			if (isSpriteRenderer.HasValue)
			{
				return isSpriteRenderer.Value;
			}
		}
		
		if (m_image == null && m_spriteRenderer != null)
		{
			isSpriteRenderer = true;
			return true;
		}
		else if (m_image != null && m_spriteRenderer == null)
		{
			isSpriteRenderer = false;
			return false;
		}
        else
        {
			Debug.LogError("No available Renderer Present", this.gameObject);
			isSpriteRenderer = false;
			return false;
		}
	}

	private void ResetBoolChecks() // 1루프중 1번만 bool체크하도록 강제하는 처리
    {
		isUseCurve = null;
		isAspectChanged = null;
#if UNITY_EDITOR
		isSpriteChanged = null;
#endif
	}

	private bool NeedUpdate()    //업데이트가 필요한 경우  1. 초기화요청이 왓을때 /2. 애니메이션커브를 사용중 /3. 스프라이트랜더러의 종횡비가 변경됨 /4. 스프라이트가 변경됨 /5. 값의 변경사항이 있음
	{
		if (!isInitialized || CheckUseCurve() || NeedAspectUpdate() || CheckSpriteDataChange() || CheckValueChange())
		{
			return true;
		}
		else
		{
			return false;
		}
    }

	private bool CheckUseCurve() //커브를 사용중인가?
	{
		if (Application.isPlaying)  // 게임이 실행중  useCurveInPlayMode 가 참이면 항상 참
		{
			if (useCurveInPlayMode)
			{
				return true;
			}
			else return false;
		}
		else return CheckUseCurveInternal();
	}

	private bool CheckUseCurveInternal()  //실제로 커브를 사용중인지 검사
    {
		if (isUseCurve.HasValue)
		{
			return isUseCurve.Value;
		}
		if (spriteBrightnessUseCurve.boolValue || spriteGrayScaleUseCurve.boolValue || spriteTintColorUseCurve.boolValue || spriteCutOutUseCurve.boolValue)
		{
			needCurveReset = true;
			isUseCurve = true;
			return isUseCurve.Value;
		}
		for (int i = 0; i < _numOfLayer; i++)
		{
			if (spriteEffectLayers[i] != null) // 매니저에서 신규생성할때 처음에 null이 됨. 왜 그럴까...?
			{
				if (spriteEffectLayers[i].effectUseScrollCurve || spriteEffectLayers[i].effectUseRotateCurve || spriteEffectLayers[i].effectUseScaleCurve || spriteEffectLayers[i].effectUseColorCurve || spriteEffectLayers[i].effectUseFlipBookCurve)
				{
					needCurveReset = true;
					isUseCurve = true;
					return isUseCurve.Value;
				}
			}
		}
		isUseCurve = false;
		return isUseCurve.Value;
	}

	private bool CheckValueChange()  //값이 변경되엇는가?
    {
		if (!isInitialized)
		{
			return true;
		}
		return needUpdate;
    }

	private bool CheckSpriteDataChange()  //스프라이트가 변경되엇는가?
	{
		if (!isInitialized)
		{
			return true;
		}
		if (changeSpriteCall)  //스프라이트교체 콜이 오면 무조건 참
        {
			return true;
        }
		if (Application.isPlaying && !changeSpriteCall)  //플레이중일땐 스프라이트 교체 콜이 없으면 무조건 거짓
		{
			return false;
		}
#region Editor Only
#if UNITY_EDITOR
		if (isSpriteChanged.HasValue)
        {
			return isSpriteChanged.Value;
        }
        if (IsSpriteRenderer())
        {
            if (Application.isPlaying && previousSprite == m_spriteRenderer.sprite)  // 게임실행중일땐 스프라이트가 변경되지않으면 빠른 false
            {
				isSpriteChanged = false;
				return isSpriteChanged.Value;
            }
			if (previousSprite != m_spriteRenderer.sprite)
			{
				previousSprite = m_spriteRenderer.sprite;
				isSpriteChanged = true;
				return isSpriteChanged.Value;
			}
			if (previousDrawMode != m_spriteRenderer.drawMode)
			{
				previousDrawMode = m_spriteRenderer.drawMode;
				isSpriteChanged = true;
				return isSpriteChanged.Value;
			}
			if (previousSpriteRendererSize != m_spriteRenderer.size)
			{
				previousSpriteRendererSize = m_spriteRenderer.size;
				isSpriteChanged = true;
				return isSpriteChanged.Value;
			}
			//if (previousSpriteRendererPosition != m_spriteRenderer.gameObject.transform.position)
			//{
			//	previousSpriteRendererPosition = m_spriteRenderer.gameObject.transform.position;
			//	return true;
			//}
			else
			{
				isSpriteChanged = false;
				return isSpriteChanged.Value;
			}
		}
        else if(!IsSpriteRenderer())
        {
			if (previousSprite != m_image.sprite)
			{
				previousSprite = m_image.sprite;
				isSpriteChanged = true;
				return isSpriteChanged.Value;
			}
            else
            {
				isSpriteChanged = false;
				return isSpriteChanged.Value;
			}
		}
#endif
#endregion
		else return false;
	}

	private bool NeedAspectUpdate()   // 스프라이트의 스케일이 변경되었는가?
	{
		if (!isInitialized)
		{
			return true;
		}
		if (isAspectChanged.HasValue)
        {
			return isAspectChanged.Value;
		}
		if (IsSpriteRenderer())
        {
			if (previousRendererScale != m_spriteRenderer.transform.lossyScale)
			{
				previousRendererScale = m_spriteRenderer.transform.lossyScale;
				isAspectChanged = true;
				return isAspectChanged.Value;
			}
			else
            {
				isAspectChanged = false;
				return isAspectChanged.Value;
			}
		}
        else
        {
			isAspectChanged = false;
			return isAspectChanged.Value;
		}
	}

	#endregion

	#region Editor Only

#if UNITY_EDITOR
	/// <summary>
	/// 에디터 전용. 매니저가 없을때 하나 이상의 스프라이트 이팩트를 생성하려고 할경우 스스로 삭제시킴
	/// </summary>
	public void KillSelfIfMultipleExist()
	{
		if (killCheck)
		{
			return;
		}
		killCheck = true;
		var effect = GetComponent<ART_SpriteEffect>();
		if (GetComponent<ART_SpriteEffectManager>() == null && effect != null && effect != this)
		{
			Debug.LogWarning("임의로 복수의 이팩트 컴포넌트를 생성하지 마세요. 이팩트 매니저를 통해서 생성하지 않을경우 자동으로 삭제됩니다.", this.gameObject);
			DestroyImmediate(this);
		}
	}

	/// <summary>
	/// 에디터 전용. 다른 코드에서 호출하면 안됨.
	/// </summary>
	public void ApplySetting()  // 에디터용
	{
		haveUnsavedChange = true;
		Reload();
	}

	/// <summary>
	/// 에디터 전용. 다른 코드에서 호출하면 안됨.
	/// </summary>
	public void SaveSetting()  // 에디터용
	{
		haveUnsavedChange = false;
		needUpdate = true;
		Reload();
	}

	/// <summary>
	/// 에디터 전용. 다른 코드에서 호출하면 안됨.
	/// </summary>
	public void SetDirty()  // 에디터용
	{
		haveUnsavedChange = true;
		needUpdate = true;
	}

	/// <summary>
	/// 에디터 전용. 다른 코드에서 호출하면 안됨.
	/// </summary>
	public void OneTimeInitialize()  // 에디터용
	{
		if (!isInitialized)
		{
			Reload();
		}
		isInitialized = true;
	}

	/// <summary>
	/// 에디터 전용. 다른 코드에서 호출하면 안됨.
	/// </summary>
	public void Cleanup()   // 매니저에서 삭제할때
	{
		effectMaterial = null;
		previousMaterial = null;
		DestroyMaterial(tempMaterial);
		DestroyMaterial(instancedMaterial);
		tempMaterial = null;
		instancedMaterial = null;
		instanceSourceMaterial = null;
		ResetRenderer();
		createdMaterial = null;
		RemoveHelper();
	}

	/// <summary>
	/// 에디터 전용. 다른 코드에서 호출하면 안됨.
	/// </summary>
	public void SwapLayer(int layer1, int layer2, bool copyLayer = false)   // 에디터용
	{
		bool layer1FolderOpen = spriteEffectLayers[layer1].isEffectvalueFolderOpen;
		Texture2D layer1Texture = spriteEffectLayers[layer1].effectTexture.textureValue;
		Vector4 layer1TextureTileOffset = spriteEffectLayers[layer1].effectTextureTileOffset.vector4Value;
		bool layer1UseSpriteMask = spriteEffectLayers[layer1].effectUseSpriteMask.boolValue;
		Vector4 layer1SpriteMaskValue = spriteEffectLayers[layer1].effectSpriteMaskValue.vector4Value;
		Texture2D layer1Mask = spriteEffectLayers[layer1].effectMask.textureValue;
		bool layer1UseMaskUV = spriteEffectLayers[layer1].effectUseMaskUV.boolValue;
		bool layer1UniformUV = spriteEffectLayers[layer1].effectUniformUV.boolValue;
		Color layer1Color = spriteEffectLayers[layer1].effectColor.colorValue;
		Gradient layer1Gradient = spriteEffectLayers[layer1].effectGradient.gradientValue;
		float layer1Brightness = spriteEffectLayers[layer1].effectBrightness.floatValue;
		float layer1Scale = spriteEffectLayers[layer1].effectScale.floatValue;
		float layer1ScaleMultiplier = spriteEffectLayers[layer1].effectScaleMultiplier.floatValue;
		float layer1ScaleSpeed = spriteEffectLayers[layer1].effectScaleSpeed.floatValue;
		float layer1Power = spriteEffectLayers[layer1].effectPower.floatValue;
		float layer1RotateAngle = spriteEffectLayers[layer1].effectRotateAngle.floatValue;
		float layer1RotateSpeed = spriteEffectLayers[layer1].effectRotateSpeed.floatValue;
		float layer1VerticalSpeed = spriteEffectLayers[layer1].effectVerticalSpeed.floatValue;
		float layer1HorizontalSpeed = spriteEffectLayers[layer1].effectHorizontalSpeed.floatValue;
		float layer1GlowSpeed = spriteEffectLayers[layer1].effectGlowSpeed.floatValue;
		float layer1TimingOffset = spriteEffectLayers[layer1].effectTimingOffset.floatValue;
		LayerBlendMode layer1BlendMode = spriteEffectLayers[layer1].effectBlendMode.layerBlendModeValue;
		bool layer1effectUseAlpha = spriteEffectLayers[layer1].effectUseAlpha.boolValue;
		bool layer1effectActive = spriteEffectLayers[layer1].isEffectActive;
		bool layer1ScalePingPong = spriteEffectLayers[layer1].effectScalePingPong.boolValue;
		bool layer1RandomRotation = spriteEffectLayers[layer1].effectRandomRotation.boolValue;
		bool layer1ScrollDirectional = spriteEffectLayers[layer1].effectScrollDirectional.boolValue;
		float layer1DistortStrength = spriteEffectLayers[layer1].effectDistortStrength.floatValue;
		bool layer1UseScrollCurve = spriteEffectLayers[layer1].effectUseScrollCurve;
		bool layer1UseRotateCurve = spriteEffectLayers[layer1].effectUseRotateCurve;
		bool layer1UseScaleCurve = spriteEffectLayers[layer1].effectUseScaleCurve;
		bool layer1UseColorCurve = spriteEffectLayers[layer1].effectUseColorCurve;
		bool layer1UseFlipBookCurve = spriteEffectLayers[layer1].effectUseFlipBookCurve;
		AnimationCurve layer1ScrollCurveX = spriteEffectLayers[layer1].effectScrollCurveX;
		AnimationCurve layer1ScrollCurveY = spriteEffectLayers[layer1].effectScrollCurveY;
		AnimationCurve layer1RotateCurve = spriteEffectLayers[layer1].effectRotateCurve;
		AnimationCurve layer1ScaleCurve = spriteEffectLayers[layer1].effectScaleCurve;
		AnimationCurve layer1ColorCurve = spriteEffectLayers[layer1].effectColorCurve;
		AnimationCurve layer1FlipBookCurve = spriteEffectLayers[layer1].effectFlipBookCurve;
		bool layer1UseLuminanceMask = spriteEffectLayers[layer1].effectUseLuminanceMask.boolValue;
		bool layer1UseFlipBook = spriteEffectLayers[layer1].effectUseFlipBook.boolValue;
		bool layer1UseFlipBookBlend = spriteEffectLayers[layer1].effectUseFlipBookBlend.boolValue;
		Vector4 layer1FlipBookValue = spriteEffectLayers[layer1].effectFlipBookValue.vector4Value;
		bool layer1UseTimerMask = spriteEffectLayers[layer1].effectUseTimerMask.boolValue;
		Vector4 layer1TimerMaskVal = spriteEffectLayers[layer1].effectTimerMaskValue.vector4Value;
		bool layer1UseTimerMaskBaseUV = spriteEffectLayers[layer1].effectTimerMaskBaseUV.boolValue;


		spriteEffectLayers[layer1].isEffectvalueFolderOpen = spriteEffectLayers[layer2].isEffectvalueFolderOpen;
		spriteEffectLayers[layer1].effectTexture.textureValue = spriteEffectLayers[layer2].effectTexture.textureValue;
		spriteEffectLayers[layer1].effectTextureTileOffset.vector4Value = spriteEffectLayers[layer2].effectTextureTileOffset.vector4Value;
		spriteEffectLayers[layer1].effectUseSpriteMask.boolValue = spriteEffectLayers[layer2].effectUseSpriteMask.boolValue;
		spriteEffectLayers[layer1].effectSpriteMaskValue.vector4Value = spriteEffectLayers[layer2].effectSpriteMaskValue.vector4Value;
		spriteEffectLayers[layer1].effectMask.textureValue = spriteEffectLayers[layer2].effectMask.textureValue;
		spriteEffectLayers[layer1].effectUseMaskUV.boolValue = spriteEffectLayers[layer2].effectUseMaskUV.boolValue;
		spriteEffectLayers[layer1].effectUniformUV.boolValue = spriteEffectLayers[layer2].effectUniformUV.boolValue;
		spriteEffectLayers[layer1].effectColor.colorValue = spriteEffectLayers[layer2].effectColor.colorValue;
		spriteEffectLayers[layer1].effectGradient.gradientValue = spriteEffectLayers[layer2].effectGradient.gradientValue;
		spriteEffectLayers[layer1].effectBrightness.floatValue = spriteEffectLayers[layer2].effectBrightness.floatValue;
		spriteEffectLayers[layer1].effectScale.floatValue = spriteEffectLayers[layer2].effectScale.floatValue;
		spriteEffectLayers[layer1].effectScaleMultiplier.floatValue = spriteEffectLayers[layer2].effectScaleMultiplier.floatValue;
		spriteEffectLayers[layer1].effectScaleSpeed.floatValue = spriteEffectLayers[layer2].effectScaleSpeed.floatValue;
		spriteEffectLayers[layer1].effectPower.floatValue = spriteEffectLayers[layer2].effectPower.floatValue;
		spriteEffectLayers[layer1].effectRotateAngle.floatValue = spriteEffectLayers[layer2].effectRotateAngle.floatValue;
		spriteEffectLayers[layer1].effectRotateSpeed.floatValue = spriteEffectLayers[layer2].effectRotateSpeed.floatValue;
		spriteEffectLayers[layer1].effectVerticalSpeed.floatValue = spriteEffectLayers[layer2].effectVerticalSpeed.floatValue;
		spriteEffectLayers[layer1].effectHorizontalSpeed.floatValue = spriteEffectLayers[layer2].effectHorizontalSpeed.floatValue;
		spriteEffectLayers[layer1].effectGlowSpeed.floatValue = spriteEffectLayers[layer2].effectGlowSpeed.floatValue;
		spriteEffectLayers[layer1].effectTimingOffset.floatValue = spriteEffectLayers[layer2].effectTimingOffset.floatValue;
		spriteEffectLayers[layer1].effectBlendMode.layerBlendModeValue = spriteEffectLayers[layer2].effectBlendMode.layerBlendModeValue;
		spriteEffectLayers[layer1].effectUseAlpha.boolValue = spriteEffectLayers[layer2].effectUseAlpha.boolValue;
		spriteEffectLayers[layer1].isEffectActive = spriteEffectLayers[layer2].isEffectActive;
		spriteEffectLayers[layer1].effectScalePingPong.boolValue = spriteEffectLayers[layer2].effectScalePingPong.boolValue;
		spriteEffectLayers[layer1].effectRandomRotation.boolValue = spriteEffectLayers[layer2].effectRandomRotation.boolValue;
		spriteEffectLayers[layer1].effectScrollDirectional.boolValue = spriteEffectLayers[layer2].effectScrollDirectional.boolValue;
		spriteEffectLayers[layer1].effectDistortStrength.floatValue = spriteEffectLayers[layer2].effectDistortStrength.floatValue;
		spriteEffectLayers[layer1].effectUseScrollCurve = spriteEffectLayers[layer2].effectUseScrollCurve;
		spriteEffectLayers[layer1].effectUseRotateCurve = spriteEffectLayers[layer2].effectUseRotateCurve;
		spriteEffectLayers[layer1].effectUseScaleCurve = spriteEffectLayers[layer2].effectUseScaleCurve;
		spriteEffectLayers[layer1].effectUseColorCurve = spriteEffectLayers[layer2].effectUseColorCurve;
		spriteEffectLayers[layer1].effectUseFlipBookCurve = spriteEffectLayers[layer2].effectUseFlipBookCurve;
		spriteEffectLayers[layer1].effectScrollCurveX = spriteEffectLayers[layer2].effectScrollCurveX;
		spriteEffectLayers[layer1].effectScrollCurveY = spriteEffectLayers[layer2].effectScrollCurveY;
		spriteEffectLayers[layer1].effectRotateCurve = spriteEffectLayers[layer2].effectRotateCurve;
		spriteEffectLayers[layer1].effectScaleCurve = spriteEffectLayers[layer2].effectScaleCurve;
		spriteEffectLayers[layer1].effectColorCurve = spriteEffectLayers[layer2].effectColorCurve;
		spriteEffectLayers[layer1].effectFlipBookCurve = spriteEffectLayers[layer2].effectFlipBookCurve;
		spriteEffectLayers[layer1].effectUseLuminanceMask.boolValue = spriteEffectLayers[layer2].effectUseLuminanceMask.boolValue;
		spriteEffectLayers[layer1].effectUseFlipBook.boolValue = spriteEffectLayers[layer2].effectUseFlipBook.boolValue;
		spriteEffectLayers[layer1].effectUseFlipBookBlend.boolValue = spriteEffectLayers[layer2].effectUseFlipBookBlend.boolValue;
		spriteEffectLayers[layer1].effectFlipBookValue.vector4Value = spriteEffectLayers[layer2].effectFlipBookValue.vector4Value;
		spriteEffectLayers[layer1].effectUseTimerMask.boolValue = spriteEffectLayers[layer2].effectUseTimerMask.boolValue;
		spriteEffectLayers[layer1].effectTimerMaskValue.vector4Value = spriteEffectLayers[layer2].effectTimerMaskValue.vector4Value;
		spriteEffectLayers[layer1].effectTimerMaskBaseUV.boolValue = spriteEffectLayers[layer2].effectTimerMaskBaseUV.boolValue;


		if (!copyLayer)
        {
			spriteEffectLayers[layer2].isEffectvalueFolderOpen = layer1FolderOpen;
			spriteEffectLayers[layer2].effectTexture.textureValue = layer1Texture;
			spriteEffectLayers[layer2].effectTextureTileOffset.vector4Value = layer1TextureTileOffset;
			spriteEffectLayers[layer2].effectUseSpriteMask.boolValue = layer1UseSpriteMask;
			spriteEffectLayers[layer2].effectSpriteMaskValue.vector4Value = layer1SpriteMaskValue;
			spriteEffectLayers[layer2].effectMask.textureValue = layer1Mask;
			spriteEffectLayers[layer2].effectUseMaskUV.boolValue = layer1UseMaskUV;
			spriteEffectLayers[layer2].effectUniformUV.boolValue = layer1UniformUV;
			spriteEffectLayers[layer2].effectColor.colorValue = layer1Color;
			spriteEffectLayers[layer2].effectGradient.gradientValue = layer1Gradient;
			spriteEffectLayers[layer2].effectBrightness.floatValue = layer1Brightness;
			spriteEffectLayers[layer2].effectScale.floatValue = layer1Scale;
			spriteEffectLayers[layer2].effectScaleMultiplier.floatValue = layer1ScaleMultiplier;
			spriteEffectLayers[layer2].effectScaleSpeed.floatValue = layer1ScaleSpeed;
			spriteEffectLayers[layer2].effectPower.floatValue = layer1Power;
			spriteEffectLayers[layer2].effectRotateAngle.floatValue = layer1RotateAngle;
			spriteEffectLayers[layer2].effectRotateSpeed.floatValue = layer1RotateSpeed;
			spriteEffectLayers[layer2].effectVerticalSpeed.floatValue = layer1VerticalSpeed;
			spriteEffectLayers[layer2].effectHorizontalSpeed.floatValue = layer1HorizontalSpeed;
			spriteEffectLayers[layer2].effectGlowSpeed.floatValue = layer1GlowSpeed;
			spriteEffectLayers[layer2].effectTimingOffset.floatValue = layer1TimingOffset;
			spriteEffectLayers[layer2].effectBlendMode.layerBlendModeValue = layer1BlendMode;
			spriteEffectLayers[layer2].effectUseAlpha.boolValue = layer1effectUseAlpha;
			spriteEffectLayers[layer2].isEffectActive = layer1effectActive;
			spriteEffectLayers[layer2].effectScalePingPong.boolValue = layer1ScalePingPong;
			spriteEffectLayers[layer2].effectRandomRotation.boolValue = layer1RandomRotation;
			spriteEffectLayers[layer2].effectScrollDirectional.boolValue = layer1ScrollDirectional;
			spriteEffectLayers[layer2].effectDistortStrength.floatValue = layer1DistortStrength;
			spriteEffectLayers[layer2].effectUseScrollCurve = layer1UseScrollCurve;
			spriteEffectLayers[layer2].effectUseRotateCurve = layer1UseRotateCurve;
			spriteEffectLayers[layer2].effectUseScaleCurve = layer1UseScaleCurve;
			spriteEffectLayers[layer2].effectUseColorCurve = layer1UseColorCurve;
			spriteEffectLayers[layer2].effectUseFlipBookCurve = layer1UseFlipBookCurve;
			spriteEffectLayers[layer2].effectScrollCurveX = layer1ScrollCurveX;
			spriteEffectLayers[layer2].effectScrollCurveY = layer1ScrollCurveY;
			spriteEffectLayers[layer2].effectRotateCurve = layer1RotateCurve;
			spriteEffectLayers[layer2].effectScaleCurve = layer1ScaleCurve;
			spriteEffectLayers[layer2].effectColorCurve = layer1ColorCurve;
			spriteEffectLayers[layer2].effectFlipBookCurve = layer1FlipBookCurve;
			spriteEffectLayers[layer2].effectUseLuminanceMask.boolValue = layer1UseLuminanceMask;
			spriteEffectLayers[layer2].effectUseFlipBook.boolValue = layer1UseFlipBook;
			spriteEffectLayers[layer2].effectUseFlipBookBlend.boolValue = layer1UseFlipBookBlend;
			spriteEffectLayers[layer2].effectFlipBookValue.vector4Value = layer1FlipBookValue;
			spriteEffectLayers[layer2].effectUseTimerMask.boolValue = layer1UseTimerMask;
			spriteEffectLayers[layer2].effectTimerMaskValue.vector4Value = layer1TimerMaskVal;
			spriteEffectLayers[layer2].effectTimerMaskBaseUV.boolValue = layer1UseTimerMaskBaseUV;
		}
	}

	public bool HaveCreatedMaterial()
    {
		return createdMaterial != null ? true : false;
    }

	private void Reload()
	{
		if (!Application.isPlaying)
		{
			if (HaveRenderer())
			{
				UpdateMat(effectMaterial);
			}
		}
	}

	private void OnDrawGizmos()
	{
		if (Application.isPlaying)
		{
			return;
		}
		if (CheckImageMaskableStateChanged() || CheckUseCurve())  //마스크 체크를 먼저해야함. 커브를 먼저 체크할경우 마스크체크가 스킵됨
        {
			UpdateMat(effectMaterial);
		}
		SetShaderUnscaledTime();
	}

	private bool CheckImageMaskableStateChanged()   //이미지 마스커블 상태가 변경됏을때 초기화요청
	{
		if (HaveRenderer() && !IsSpriteRenderer())
		{
			if (imageMaskableState != m_image.maskable)
			{
				imageMaskableState = m_image.maskable;
				isInitialized = false;
				//Debug.LogWarning("Image maskable state changed",this.gameObject);
				return true;
			}
		}
		return false;
	}
	#region Manage Helper
	public void SetHelper()
	{
		if (GetComponent<Image>() != null)
		{
			if (GetComponentInParent<Canvas>() != null)
			{
				GetComponentInParent<Canvas>().additionalShaderChannels |= AdditionalCanvasShaderChannels.TexCoord1;
			}
			if (GetComponent<ART_SpriteEffectUIImageHelper>() == null)
			{
				ART_SpriteEffectUIImageHelper helper = this.gameObject.AddComponent<ART_SpriteEffectUIImageHelper>();
				UnityEditorInternal.ComponentUtility.MoveComponentUp(helper);
			}
		}
	}

	public void RemoveHelper()
	{
		if (GetComponents<ART_SpriteEffect>().Length <= 1)
		{
			ART_SpriteEffectUIImageHelper helper = GetComponent<ART_SpriteEffectUIImageHelper>();
			if (helper != null)
			{
				DestroyImmediate(helper);
			}
		}
	}
#endregion

#region SetMaterial

	/*
	void SetUID()
	{
		if (!string.IsNullOrWhiteSpace(spriteEffectUniqueID))
		{
			haveUID = true;
		}
		if (!haveUID || string.IsNullOrWhiteSpace(spriteEffectUniqueID))
		{
			spriteEffectUniqueID = Guid.NewGuid().ToString();
			haveUID = true;
		}
	}
	*/

	private void SetMaterialValue(Material mat)
	{
		SetKeyword(mat, "_REMOVEBASESPRITE_ON", setSpriteTransparent.boolValue);
		//SetKeyword(mat, "_BASESPRITEGRAYSCALE_ON", setSpriteGrayScale.boolValue);
		mat.SetFloat("_BaseSpriteGrayscale", setSpriteGrayScale.boolValue ? 1 : 0);
		mat.SetFloat("_BaseGrayscaleValue", spriteGrayScaleValue.floatValue);
		//SetKeyword(mat, "_BASESPRITEGRAYSCALELUMINANCEMASK_ON", spriteGrayScaleUseLuminanceMask.boolValue);

		//SetKeyword(mat, "_BASESPRITEBRIGHTNESS_ON", setSpriteBrightness.boolValue);
		mat.SetFloat("_BaseSpriteBrightness", setSpriteBrightness.boolValue ? 1 : 0);
		mat.SetFloat("_BaseBrightnessValue", spriteBrightnessValue.floatValue);
		//SetKeyword(mat, "_BASESPRITEBRIGHTNESSLUMINANCEMASK_ON", spriteBrightnessUseLuminanceMask.boolValue);
		mat.SetFloat("_BaseBrightnessUseLuminanceMask", spriteBrightnessUseLuminanceMask.boolValue ? 1 : 0);

		//SetKeyword(mat, "_BASETINTCOLOR_ON", setSpriteTintColor.boolValue);
		mat.SetFloat("_BaseSpriteTintColor", setSpriteTintColor.boolValue ? 1 : 0);
		mat.SetFloat("_BaseTintColorUseLuminanceMask", spriteTintColorUseLuminanceMask.boolValue ? 1 : 0);
		if (!spriteTintColorUseCurve.boolValue)
		{
			mat.SetColor("_BaseTintColor", spriteTintColorValue.colorValue);
		}

		SetKeyword(mat, "_BASECUTOUT_ON", setSpriteCutOut.boolValue);
        if (setSpriteCutOut.boolValue)
        {
			mat.SetTexture("_BaseCutOutTex", spriteCutOutTexture.textureValue);
			mat.SetVector("_BaseCutOutTex_ST", spriteCutOutTextureTileOffset.vector4Value);
			mat.SetVector("_BaseCutOutVal", spriteCutOutValue.vector4Value);
			SetKeyword(mat, "_BASECUTOUTUSESLICEUV_ON", spriteCutOutUseSliceUV.boolValue);
			SetKeyword(mat, "_BASECUTOUTUNIFORMUV_ON", spriteCutOutUniformUV.boolValue);
			SetKeyword(mat, "_BASECUTOUTEDGECOLOR_ON", spriteCutOutEdgeBrightness.floatValue > 0 && spriteCutOutEdgeColor.colorValue.a > 0);
            //if (spriteCutOutEdgeBrightness.floatValue > 0 || spriteCutOutEdgeColor.colorValue.a > 0)
            //{
				mat.SetColor("_BaseCutOutEdgeColor", spriteCutOutEdgeColor.colorValue);
				mat.SetFloat("_BaseCutOutEdgeColorBrightness", spriteCutOutEdgeBrightness.floatValue);
			//}
			SetKeyword(mat, "_BASECUTOUTFILLCOLOR_ON", spriteCutOutFillBrightness.floatValue > 0 && spriteCutOutFillColor.colorValue.a > 0);
			//if (spriteCutOutFillBrightness.floatValue > 0 || spriteCutOutFillColor.colorValue.a > 0)
            //{
				mat.SetColor("_BaseCutOutFillColor", spriteCutOutFillColor.colorValue);
				mat.SetFloat("_BaseCutOutFillColorBrightness", spriteCutOutFillBrightness.floatValue);
			//}
			SetKeyword(mat, "_BASECUTOUTDONOTUSEALPHA_ON", spriteCutOutDoNotUseAlpha.boolValue);
            //if (spriteCutOutDoNotUseAlpha.boolValue)
            //{
				mat.SetFloat(spriteCutOutProgressID, spriteCutOutProgress.floatValue);
			//}
		}

		SetKeyword(mat, "_BASEVERTEXANIM_ON", setSpriteVertexAnim.boolValue);
		//if (setSpriteVertexAnim.boolValue)
		//{
			mat.SetVector("_BaseVertexAnimVal", spriteVertexAnimValue.vector4Value);
		//}

		SetKeyword(mat, "_UIIMAGE_ON", (m_image != null));
		SetKeyword(mat, "_SPRITESLICED_ON", (m_spriteRenderer != null && m_spriteRenderer.drawMode != SpriteDrawMode.Simple));
		SetKeyword(mat, "_USEUNSCALEDTIME_ON", useUnscaledTime.boolValue);
		mat.SetFloat("_LuminanceMaskThresholdMin", luminanceMaskThresholdMin.floatValue);
		mat.SetFloat("_LuminanceMaskThresholdMax", luminanceMaskThresholdMax.floatValue);

		for (int i = 0; i < _numOfLayer; i++)
		{
			if (spriteEffectLayers[i] != null)
			{
				SetKeyword(mat, $"_EFFECT{i + 1}_ON", spriteEffectLayers[i].effectTexture.textureValue != null && spriteEffectLayers[i].isEffectActive);
				SetValue(mat, i);
			}
		}
	}

	private void SetValue(Material mat, int i)
	{
		mat.SetTexture($"_Effect{i + 1}Tex", spriteEffectLayers[i].effectTexture.textureValue);
		SetKeyword(mat, $"_EFFECT{i + 1}USEFLIPBOOK_ON", spriteEffectLayers[i].effectUseFlipBook.boolValue);
        if (spriteEffectLayers[i].effectUseFlipBook.boolValue)
        {
			SetKeyword(mat, $"_EFFECT{i + 1}USEFLIPBOOKBLEND_ON", spriteEffectLayers[i].effectUseFlipBookBlend.boolValue);
		}
		if (spriteEffectLayers[i].effectUseFlipBook.boolValue && !spriteEffectLayers[i].effectUseFlipBookCurve)
		{
			mat.SetVector($"_Effect{i + 1}FlipbookValue", spriteEffectLayers[i].effectFlipBookValue.vector4Value);
		}
		mat.SetFloat($"_Effect{i + 1}UseSpriteMask", spriteEffectLayers[i].effectUseSpriteMask.boolValue ? 1 : 0);
		mat.SetVector($"_Effect{i + 1}SpriteMaskValue", spriteEffectLayers[i].effectSpriteMaskValue.vector4Value);
		SetKeyword(mat, $"_EFFECT{i + 1}USEMASK_ON", spriteEffectLayers[i].effectMask.textureValue);
        if (spriteEffectLayers[i].effectMask.textureValue)
        {
			mat.SetTexture($"_Effect{i + 1}Mask", spriteEffectLayers[i].effectMask.textureValue);
			//SetKeyword(mat, $"_EFFECT{i + 1}USEMASKUV_ON", spriteEffectLayers[i].effectUseMaskUV.boolValue);
			mat.SetFloat($"_Effect{i + 1}UseMaskUV", spriteEffectLayers[i].effectUseMaskUV.boolValue ? 1: 0);
			if (spriteEffectLayers[i].effectUseTimerMask.boolValue)
			{
                if (spriteEffectLayers[i].effectTimerMaskValue.vector4Value.x == 0 && spriteEffectLayers[i].effectTimerMaskValue.vector4Value.y == 0)
                {
					SetKeyword(mat, $"_EFFECT{i + 1}USETIMEROFFSETMASK_ON", spriteEffectLayers[i].effectUseTimerMask.boolValue);
					SetKeyword(mat, $"_EFFECT{i + 1}USETIMERMASK_ON", !spriteEffectLayers[i].effectUseTimerMask.boolValue);
				}
                else
                {
					SetKeyword(mat, $"_EFFECT{i + 1}USETIMEROFFSETMASK_ON", !spriteEffectLayers[i].effectUseTimerMask.boolValue);
					SetKeyword(mat, $"_EFFECT{i + 1}USETIMERMASK_ON", spriteEffectLayers[i].effectUseTimerMask.boolValue);
				}
				//SetKeyword(mat, $"_EFFECT{i + 1}USETIMERMASKBASEUV_ON", spriteEffectLayers[i].effectTimerMaskBaseUV.boolValue);
				mat.SetFloat($"_Effect{i + 1}UseTimerMaskBaseUV", spriteEffectLayers[i].effectTimerMaskBaseUV.boolValue ? 1: 0);
				mat.SetVector($"_Effect{i + 1}TimerMaskVal", spriteEffectLayers[i].effectTimerMaskValue.vector4Value);
			}
            else
            {
				SetKeyword(mat, $"_EFFECT{i + 1}USETIMEROFFSETMASK_ON", spriteEffectLayers[i].effectUseTimerMask.boolValue);
				SetKeyword(mat, $"_EFFECT{i + 1}USETIMERMASK_ON", spriteEffectLayers[i].effectUseTimerMask.boolValue);
			}
		}
        else
        {
			//SetKeyword(mat, $"_EFFECT{i + 1}USEMASKUV_ON", false);
			mat.SetTexture($"_Effect{i + 1}Mask", null);
			mat.SetFloat($"_Effect{i + 1}UseMaskUV", 0);
			SetKeyword(mat, $"_EFFECT{i + 1}USETIMEROFFSETMASK_ON", false);
			SetKeyword(mat, $"_EFFECT{i + 1}USETIMERMASK_ON", false);
		}
		if (!spriteEffectLayers[i].effectUseColorCurve)
		{
			mat.SetColor($"_Effect{i + 1}Color", spriteEffectLayers[i].effectColor.colorValue);
		}
		mat.SetFloat($"_Effect{i + 1}Brightness", spriteEffectLayers[i].effectBrightness.floatValue);
		mat.SetFloat($"_Effect{i + 1}ScaleOrigin", spriteEffectLayers[i].effectScale.floatValue);
		mat.SetFloat($"_Effect{i + 1}ScaleMultiplier", spriteEffectLayers[i].effectScaleMultiplier.floatValue);
		SetToggleProperty(mat, $"_Effect{i + 1}ScaleSpeed", $"_EFFECT{i + 1}USESCALEPINGPONG_ON", spriteEffectLayers[i].effectScaleSpeed.floatValue, true, spriteEffectLayers[i].effectScalePingPong.boolValue);
		SetToggleProperty(mat, $"_Effect{i + 1}ScaleSpeed", $"_EFFECT{i + 1}USESCALE_ON", spriteEffectLayers[i].effectScaleSpeed.floatValue, true, !spriteEffectLayers[i].effectScalePingPong.boolValue);
		SetKeyword(mat, $"_EFFECT{i + 1}RANDOMROTATE_ON", spriteEffectLayers[i].effectRandomRotation.boolValue);
		//SetToggleProperties(mat, $"_Effect{i + 1}ScaleMultiplier", $"_Effect{i + 1}ScaleSpeed", $"_EFFECT{i + 1}USESCALE_ON", spriteEffectLayers[i].effectScaleMultiplier, spriteEffectLayers[i].effectScaleSpeed, true);
		mat.SetFloat($"_Effect{i + 1}Power", spriteEffectLayers[i].effectPower.floatValue);
		mat.SetVector($"_Effect{i + 1}Tex_ST", spriteEffectLayers[i].effectTextureTileOffset.vector4Value);

		if (spriteEffectLayers[i].effectUseScrollCurve)
		{
			SetKeyword(mat, $"_EFFECT{i + 1}USESCROLL_ON", spriteEffectLayers[i].effectUseScrollCurve);
		}
		else
		{
			SetToggleProperties(mat, $"_Effect{i + 1}VerticalSpeed", $"_Effect{i + 1}HorizontalSpeed", $"_EFFECT{i + 1}USESCROLL_ON", spriteEffectLayers[i].effectVerticalSpeed.floatValue, spriteEffectLayers[i].effectHorizontalSpeed.floatValue, true);
		}
		SetKeyword(mat, $"_EFFECT{i + 1}USESCROLLCURVE_ON", spriteEffectLayers[i].effectUseScrollCurve);

		if (spriteEffectLayers[i].effectUseRotateCurve)
		{
			SetKeyword(mat, $"_EFFECT{i + 1}USEROTATE_ON", spriteEffectLayers[i].effectUseRotateCurve);
		}
		else
		{
			SetToggleProperties(mat, $"_Effect{i + 1}RotateSpeed", $"_Effect{i + 1}RotateAngle", $"_EFFECT{i + 1}USEROTATE_ON", spriteEffectLayers[i].effectRotateSpeed.floatValue, -Mathf.Deg2Rad * spriteEffectLayers[i].effectRotateAngle.floatValue, true);
		}
		SetKeyword(mat, $"_EFFECT{i + 1}USEROTATECURVE_ON", spriteEffectLayers[i].effectUseRotateCurve);

		//SetToggleProperty(mat, $"_Effect{i + 1}GlowSpeed", $"_EFFECT{i + 1}USEGLOW_ON", spriteEffectLayers[i].effectGlowSpeed.floatValue, false);
		SetToggleIntProperty(mat, $"_Effect{i + 1}GlowSpeed", $"_Effect{i + 1}UseGlow", spriteEffectLayers[i].effectGlowSpeed.floatValue, false);
		//SetBlendModeKeyword(mat, $"_EFFECT{i + 1}BLENDMASK_ON", $"_EFFECT{i + 1}ALPHABLEND_ON", spriteEffectLayers[i].effectBlendMode.layerBlendModeValue);
		SetBlendModeInt(mat, $"_Effect{i + 1}BlendMask", $"_Effect{i + 1}AlphaBlend", spriteEffectLayers[i].effectBlendMode.layerBlendModeValue);
		mat.SetFloat($"_Effect{i + 1}TimingOffset", spriteEffectLayers[i].effectTimingOffset.floatValue);
		//SetKeyword(mat, $"_EFFECT{i + 1}UNIFORMUV_ON", spriteEffectLayers[i].effectUniformUV.boolValue);
		mat.SetFloat($"_Effect{i + 1}UniformUV", spriteEffectLayers[i].effectUniformUV.boolValue ? 1: 0);
		//SetKeyword(mat, $"_EFFECT{i + 1}USEALPHA_ON", spriteEffectLayers[i].effectUseAlpha.boolValue);
		mat.SetFloat($"_Effect{i + 1}UseAlpha", spriteEffectLayers[i].effectUseAlpha.boolValue ? 1 : 0);
		SetKeyword(mat, $"_EFFECT{i + 1}USEDIRECTIONALSCROLL_ON", spriteEffectLayers[i].effectScrollDirectional.boolValue);
		//SetToggleProperty(mat, $"_Effect{i + 1}MaskDistortStrength", $"_EFFECT{i + 1}USEDISTORTMASK_ON", spriteEffectLayers[i].effectDistortStrength.floatValue*0.2f, false);
		SetToggleIntProperty(mat, $"_Effect{i + 1}MaskDistortStrength", $"_Effect{i + 1}UseDistortMask", spriteEffectLayers[i].effectDistortStrength.floatValue * 0.2f, false);
		SetKeyword(mat, $"_EFFECT{i + 1}USEROTATECURVE_ON", spriteEffectLayers[i].effectUseRotateCurve);
		SetKeyword(mat, $"_EFFECT{i + 1}USESCALECURVE_ON", spriteEffectLayers[i].effectUseScaleCurve);
		//SetKeyword(mat, $"_EFFECT{i + 1}USEFLIPBOOKCURVE_ON", spriteEffectLayers[i].effectUseFlipBookCurve);
		//SetKeyword(mat, $"_EFFECT{i + 1}USELUMINANCEMASK_ON", spriteEffectLayers[i].effectUseLuminanceMask.boolValue);
		mat.SetFloat($"_Effect{i + 1}UseLuminanceMask", spriteEffectLayers[i].effectUseLuminanceMask.boolValue ? 1 : 0);
	}

	private void SetToggleProperty(Material mat, string propertyName, string togglerName, float value, bool isHaveMinusValue = false, bool isEnabled = true)
	{
		LocalKeyword keyword = new LocalKeyword(mat.shader, togglerName);
		if (!isHaveMinusValue)
		{
			Mathf.Abs(value);
		}
		if (Mathf.Approximately(value, 0f) || !isEnabled)
		{
			mat.SetKeyword(keyword, false);
			mat.SetFloat(togglerName, 0);
			mat.SetFloat(propertyName, value);
			return;
		}
		{
			mat.SetKeyword(keyword, true);
			mat.SetFloat(propertyName, value);
		}
	}

	private void SetToggleProperties(Material mat, string propertyName1, string propertyName2, string togglerName, float value1, float value2, bool isHaveMinusValue = false, bool isEnabled = true)
	{
		LocalKeyword keyword = new LocalKeyword(mat.shader, togglerName);
		if (!isHaveMinusValue)
		{
			Mathf.Abs(value1);
			Mathf.Abs(value2);
		}
		if (Mathf.Approximately(value1, 0f) && Mathf.Approximately(value2, 0f) || !isEnabled)
		{
			mat.SetKeyword(keyword, false);
			mat.SetFloat(propertyName1, value1);
			mat.SetFloat(propertyName2, value2);
			return;
		}
		{
			mat.SetKeyword(keyword, true);
			mat.SetFloat(propertyName1, value1);
			mat.SetFloat(propertyName2, value2);
		}
	}

	private void SetToggleVectorProperty(Material mat, string propertyName, string togglerName, float value1, float value2, bool isHaveMinusValue = false, bool isEnabled = true)
	{
		LocalKeyword keyword = new LocalKeyword(mat.shader, togglerName);
		if (!isHaveMinusValue)
		{
			Mathf.Abs(value1);
			Mathf.Abs(value2);
		}
		if (Mathf.Approximately(value1, 0f) && Mathf.Approximately(value2, 0f) || !isEnabled)
		{
			Vector2 value;
			value.x = value1;
			value.y = value2;
			mat.SetKeyword(keyword, false);
			mat.SetVector(propertyName, value);
			return;
		}
		{
			Vector2 value;
			value.x = value1;
			value.y = value2;
			mat.SetKeyword(keyword, true);
			mat.SetVector(propertyName, value);
		}
	}

	private void SetToggleIntProperty(Material mat, string propertyName, string togglerName, float value, bool isHaveMinusValue = false, bool isEnabled = true)
	{
		if (!isHaveMinusValue)
		{
			Mathf.Abs(value);
		}
		if (Mathf.Approximately(value, 0f) || !isEnabled)
		{
			mat.SetFloat(togglerName, 0);
			mat.SetFloat(propertyName, value);
			return;
		}
		{
			mat.SetFloat(togglerName, 1);
			mat.SetFloat(propertyName, value);
		}
	}

	private void SetBlendModeInt(Material mat, string BlendMaskPropertyName, string AlphaBlendIntPropertyName, LayerBlendMode value)
	{
		switch (value)
		{
			case LayerBlendMode.Additive:
				{
					mat.SetFloat(BlendMaskPropertyName, 0);
					mat.SetFloat(AlphaBlendIntPropertyName, 0);
				}
				break;
			case LayerBlendMode.AlphaBlend:
				{
					mat.SetFloat(BlendMaskPropertyName, 0);
					mat.SetFloat(AlphaBlendIntPropertyName, 1);
				}
				break;
			case LayerBlendMode.Mask:
				{
					mat.SetFloat(BlendMaskPropertyName, 1);
					mat.SetFloat(AlphaBlendIntPropertyName, 0);
				}
				break;
			default:
				{
					mat.SetFloat(BlendMaskPropertyName, 0);
					mat.SetFloat(AlphaBlendIntPropertyName, 0);
				}
				break;
		}
	}

	private void SetKeyword(Material mat, string keywordString, bool isActive)
	{
		LocalKeyword keyword = new LocalKeyword(mat.shader, keywordString);
		mat.SetKeyword(keyword, isActive);
	}
	private void SetKeyword(Material mat, LocalKeyword keyword, bool isActive)
	{
		mat.SetKeyword(keyword, isActive);
	}
	#endregion

	#region GetMaterial
	private bool IsKeywordEnabled(Material mat, string keywordString)
	{
		LocalKeyword keyword = new LocalKeyword(mat.shader, keywordString);
		return mat.IsKeywordEnabled(keyword);
	}

	private bool IsKeywordOrIntEnabled(Material mat, string keywordString, string intString)
	{
        if (mat.shader.keywordSpace.FindKeyword(keywordString).isValid)
        {
			LocalKeyword keyword = new LocalKeyword(mat.shader, keywordString);
			if (mat.IsKeywordEnabled(keyword))
			{
				return true;
			}
		}

        if (mat.HasFloat(intString) && mat.GetFloat(intString)>0)
        {
			return true;
		}

        else return false;
	}

	private void ResetKeywordOrInt(Material mat, string keywordString, string intString)
    {
        if (mat.shader.keywordSpace.FindKeyword(keywordString).isValid)
        {
			LocalKeyword keyword = new LocalKeyword(mat.shader, keywordString);
			SetKeyword(mat, keyword, false);
		}

        if (mat.HasFloat(intString))
        {
			mat.SetFloat(intString, 0);
        }
    }

	public void LoadMaterialValue()
	{
		effectMaterial = createdMaterial;
		GetMaterialValue(createdMaterial);
	}

	public void LoadCreatedMaterialValue()
	{
		name = createdMaterial.name.Replace(materialAssetPrefix, "");
		effectMaterial = createdMaterial;
		GetMaterialValue(createdMaterial);
		haveUnsavedChange = false;
		needUpdate = true;
		Reload();
	}

	void GetMaterialValue(Material mat)
	{
		setSpriteGrayScale.boolValue = IsKeywordOrIntEnabled(mat, "_BASESPRITEGRAYSCALE_ON", "_BaseSpriteGrayscale");
        if (setSpriteGrayScale.boolValue)
        {
			spriteGrayScaleValue.floatValue = mat.GetFloat("_BaseGrayscaleValue");
		}
        else
        {
			spriteGrayScaleValue.floatValue = 1f;
			mat.SetFloat("_BaseGrayscaleValue",1f);
		}

		setSpriteBrightness.boolValue = IsKeywordOrIntEnabled(mat, "_BASESPRITEBRIGHTNESS_ON", "_BaseSpriteBrightness");
        if (setSpriteBrightness.boolValue)
        {
			spriteBrightnessValue.floatValue = mat.GetFloat("_BaseBrightnessValue");
			spriteBrightnessUseLuminanceMask.boolValue = mat.GetFloat("_BaseBrightnessUseLuminanceMask") > 0 ? true : false;
		}
        else
        {
			spriteBrightnessValue.floatValue = 10f;
			mat.SetFloat("_BaseBrightnessValue",10f);
			mat.SetFloat("_BaseBrightnessUseLuminanceMask", 0);
		}

		setSpriteTintColor.boolValue = IsKeywordOrIntEnabled(mat, "_BASETINTCOLOR_ON", "_BaseSpriteTintColor");
        if (setSpriteTintColor.boolValue)
		{
			spriteTintColorValue.colorValue = mat.GetColor("_BaseTintColor");
			spriteBrightnessUseLuminanceMask.boolValue = mat.GetFloat("_BaseBrightnessUseLuminanceMask") > 0 ? true : false;
		}
        else
        {
			spriteTintColorValue.colorValue = Color.white;
			mat.SetColor("_BaseTintColor",Color.white);
			mat.SetFloat("_BaseTintColorUseLuminanceMask", 0);
		}

		setSpriteCutOut.boolValue = IsKeywordEnabled(mat, "_BASECUTOUT_ON");
        if (IsKeywordEnabled(mat, "_BASECUTOUT_ON"))
        {
			spriteCutOutValue.vector4Value = mat.GetVector("_BaseCutOutVal");
			spriteCutOutTexture.textureValue = mat.GetTexture($"_BaseCutOutTex") as Texture2D;
			spriteCutOutTextureTileOffset.vector4Value = mat.GetVector("_BaseCutOutTex_ST");
			spriteCutOutEdgeColor.colorValue = mat.GetColor("_BaseCutOutEdgeColor");
			spriteCutOutEdgeBrightness.floatValue = mat.GetFloat("_BaseCutOutEdgeColorBrightness");
			spriteCutOutFillColor.colorValue = mat.GetColor("_BaseCutOutFillColor");
			spriteCutOutFillBrightness.floatValue = mat.GetFloat("_BaseCutOutFillColorBrightness");
			spriteCutOutUseSliceUV.boolValue = IsKeywordEnabled(mat, "_BASECUTOUTUSESLICEUV_ON");
			spriteCutOutUniformUV.boolValue = IsKeywordEnabled(mat, "_BASECUTOUTUNIFORMUV_ON");
			spriteCutOutDoNotUseAlpha.boolValue = IsKeywordEnabled(mat, "_BASECUTOUTDONOTUSEALPHA_ON");
			spriteCutOutProgress.floatValue = mat.GetFloat("_BaseCutOutProgress");
		}
        else
        {
			spriteCutOutValue.vector4Value = new Vector4(0.5f, 1, 0, 1);
			spriteCutOutTexture.textureValue = null;
			spriteCutOutTextureTileOffset.vector4Value = new Vector4(1, 1, 0, 0);
			spriteCutOutEdgeColor.colorValue = Color.white;
			spriteCutOutEdgeBrightness.floatValue = 1f;
			spriteCutOutFillColor.colorValue = Color.white;
			spriteCutOutFillBrightness.floatValue = 1f;
			spriteCutOutUseSliceUV.boolValue = false;
			spriteCutOutUniformUV.boolValue = false;
			spriteCutOutDoNotUseAlpha.boolValue = false;
			spriteCutOutProgress.floatValue = 0f;
			mat.SetVector("_BaseCutOutVal", new Vector4(0.5f, 1, 0, 1));
			mat.SetTexture($"_BaseCutOutTex", null);
			mat.SetVector("_BaseCutOutTex_ST", new Vector4(1, 1, 0, 0));
			mat.SetColor("_BaseCutOutEdgeColor", Color.white);
			mat.SetFloat("_BaseCutOutEdgeColorBrightness", 1f);
			mat.SetColor("_BaseCutOutFillColor", Color.white);
			mat.SetFloat("_BaseCutOutFillColorBrightness", 1f);
			SetKeyword(mat, "_BASECUTOUTUSESLICEUV_ON", false);
			SetKeyword(mat, "_BASECUTOUTUNIFORMUV_ON", false);
			SetKeyword(mat, "_BASECUTOUTDONOTUSEALPHA_ON", false);
			mat.SetFloat("_BaseCutOutProgress", 0f);
		}

		setSpriteVertexAnim.boolValue = IsKeywordEnabled(mat, "_BASEVERTEXANIM_ON");
        if (IsKeywordEnabled(mat, "_BASEVERTEXANIM_ON"))
        {
			spriteVertexAnimValue.vector4Value = mat.GetVector("_BaseVertexAnimVal");
		}
        else
        {
			spriteVertexAnimValue.vector4Value = Vector4.zero;
			mat.SetVector("_BaseVertexAnimVal", Vector4.zero);
		}

		setSpriteTransparent.boolValue = IsKeywordEnabled(mat, "_REMOVEBASESPRITE_ON");
		useUnscaledTime.boolValue = IsKeywordEnabled(mat, "_USEUNSCALEDTIME_ON");

		luminanceMaskThresholdMin.floatValue = mat.GetFloat("_LuminanceMaskThresholdMin");
		luminanceMaskThresholdMax.floatValue = mat.GetFloat("_LuminanceMaskThresholdMax");

		for (int i = 0; i < _numOfLayer; i++)
		{
			spriteEffectLayers[i].isEffectActive = IsKeywordEnabled(mat, $"_EFFECT{i + 1}_ON");
			spriteEffectLayers[i].isEffectCreated = spriteEffectLayers[i].isEffectActive;
			GetValue(mat, i);
		}

        if (setSpriteGrayScale.boolValue || setSpriteBrightness.boolValue || setSpriteTintColor.boolValue || setSpriteCutOut.boolValue || setSpriteVertexAnim.boolValue)
        {
			isSpriteOptionFolderOpen = true;
		}
	}

	void GetValue(Material mat, int i)
	{
		spriteEffectLayers[i].effectTexture.textureValue = mat.GetTexture($"_Effect{i + 1}Tex") as Texture2D;
		spriteEffectLayers[i].effectTextureTileOffset.vector4Value = mat.GetVector($"_Effect{i + 1}Tex_ST");

		spriteEffectLayers[i].effectUseFlipBook.boolValue = IsKeywordEnabled(mat, $"_EFFECT{i + 1}USEFLIPBOOK_ON");
        if (IsKeywordEnabled(mat, $"_EFFECT{i + 1}USEFLIPBOOK_ON"))
        {
			spriteEffectLayers[i].effectUseFlipBookBlend.boolValue = IsKeywordEnabled(mat, $"_EFFECT{i + 1}USEFLIPBOOKBLEND_ON");
			spriteEffectLayers[i].effectFlipBookValue.vector4Value = mat.GetVector($"_Effect{i + 1}FlipbookValue");
		}
        else
        {
			spriteEffectLayers[i].effectUseFlipBookBlend.boolValue = false;
			spriteEffectLayers[i].effectFlipBookValue.vector4Value = new Vector4(1, 1, 0, 0);
			SetKeyword(mat, $"_EFFECT{i + 1}USEFLIPBOOKBLEND_ON", false);
			mat.SetVector($"_Effect{i + 1}FlipbookValue",new Vector4(1,1,0,0));
		}

		spriteEffectLayers[i].effectUseSpriteMask.boolValue = mat.GetFloat($"_Effect{i + 1}UseSpriteMask") > 0 ? true : false;
		spriteEffectLayers[i].effectSpriteMaskValue.vector4Value = mat.GetVector($"_Effect{i + 1}SpriteMaskValue");

		spriteEffectLayers[i].effectMask.textureValue = mat.GetTexture($"_Effect{i + 1}Mask") as Texture2D;

		spriteEffectLayers[i].effectUseMaskUV.boolValue = IsKeywordOrIntEnabled(mat, $"_EFFECT{i + 1}USEMASKUV_ON", $"_Effect{i + 1}UseMaskUV");

		spriteEffectLayers[i].effectUseTimerMask.boolValue = (IsKeywordEnabled(mat, $"_EFFECT{i + 1}USETIMERMASK_ON")|| IsKeywordEnabled(mat, $"_EFFECT{i + 1}USETIMEROFFSETMASK_ON"));
        if (IsKeywordEnabled(mat, $"_EFFECT{i + 1}USETIMERMASK_ON") || IsKeywordEnabled(mat, $"_EFFECT{i + 1}USETIMEROFFSETMASK_ON"))
        {
			spriteEffectLayers[i].effectTimerMaskValue.vector4Value = mat.GetVector($"_Effect{i + 1}TimerMaskVal");
			spriteEffectLayers[i].effectTimerMaskBaseUV.boolValue = IsKeywordOrIntEnabled(mat, $"_EFFECT{i + 1}USETIMERMASKBASEUV_ON", $"_Effect{i + 1}UseTimerMaskBaseUV");
		}
        else
        {
			spriteEffectLayers[i].effectTimerMaskValue.vector4Value = new Vector4(0.3f, 0.7f, 0.1f, 0.1f);
			spriteEffectLayers[i].effectTimerMaskBaseUV.boolValue = false;
			mat.SetVector($"_Effect{i + 1}TimerMaskVal", new Vector4(0.3f, 0.7f, 0.1f, 0.1f));
			ResetKeywordOrInt(mat, $"_EFFECT{i + 1}USETIMERMASKBASEUV_ON", $"_Effect{i + 1}UseTimerMaskBaseUV");
		}

		spriteEffectLayers[i].effectColor.colorValue = mat.GetColor($"_Effect{i + 1}Color");
		spriteEffectLayers[i].effectBrightness.floatValue = mat.GetFloat($"_Effect{i + 1}Brightness");

		if (IsKeywordOrIntEnabled(mat, $"_EFFECT{i + 1}USEGLOW_ON",$"_Effect{i + 1}UseGlow"))
		{
			spriteEffectLayers[i].effectGlowSpeed.floatValue = mat.GetFloat($"_Effect{i + 1}GlowSpeed");
		}
		else
		{
			ResetKeywordOrInt(mat, $"_EFFECT{i + 1}USEGLOW_ON", $"_Effect{i + 1}UseGlow");
			spriteEffectLayers[i].effectGlowSpeed.floatValue = 0f;
			mat.SetFloat($"_Effect{i + 1}GlowSpeed", 0f);
		}

		spriteEffectLayers[i].effectScale.floatValue = mat.GetFloat($"_Effect{i + 1}ScaleOrigin");
		spriteEffectLayers[i].effectScaleMultiplier.floatValue = mat.GetFloat($"_Effect{i + 1}ScaleMultiplier");
		spriteEffectLayers[i].effectScalePingPong.boolValue = IsKeywordEnabled(mat, $"_EFFECT{i + 1}USESCALEPINGPONG_ON");
        if (IsKeywordEnabled(mat, $"_EFFECT{i + 1}USESCALE_ON") || IsKeywordEnabled(mat, $"_EFFECT{i + 1}USESCALEPINGPONG_ON"))
        {
			spriteEffectLayers[i].effectScaleSpeed.floatValue = mat.GetFloat($"_Effect{i + 1}ScaleSpeed");
			spriteEffectLayers[i].effectRandomRotation.boolValue = IsKeywordEnabled(mat, $"_EFFECT{i + 1}RANDOMROTATE_ON");
		}
        else
        {
			spriteEffectLayers[i].effectScaleSpeed.floatValue = 0f;
			spriteEffectLayers[i].effectRandomRotation.boolValue = false;
			mat.SetFloat($"_Effect{i + 1}ScaleSpeed",0f);
			SetKeyword(mat, $"_EFFECT{i + 1}RANDOMROTATE_ON", false);
		}

		spriteEffectLayers[i].effectPower.floatValue = mat.GetFloat($"_Effect{i + 1}Power");

        if (IsKeywordEnabled(mat, $"_EFFECT{i + 1}USEROTATE_ON"))
        {
			spriteEffectLayers[i].effectRotateSpeed.floatValue = mat.GetFloat($"_Effect{i + 1}RotateSpeed");
			spriteEffectLayers[i].effectRotateAngle.floatValue = mat.GetFloat($"_Effect{i + 1}RotateAngle") / -Mathf.Deg2Rad;
		}
        else
        {
			spriteEffectLayers[i].effectRotateSpeed.floatValue = 0f;
			spriteEffectLayers[i].effectRotateAngle.floatValue = 0f;
			mat.SetFloat($"_Effect{i + 1}RotateSpeed",0f);
			mat.SetFloat($"_Effect{i + 1}RotateAngle",0f);
		}

        if (IsKeywordEnabled(mat, $"_EFFECT{i + 1}USESCROLL_ON"))
        {
			spriteEffectLayers[i].effectVerticalSpeed.floatValue = mat.GetFloat($"_Effect{i + 1}VerticalSpeed");
			spriteEffectLayers[i].effectHorizontalSpeed.floatValue = mat.GetFloat($"_Effect{i + 1}HorizontalSpeed");
		}
        else
        {
			spriteEffectLayers[i].effectVerticalSpeed.floatValue = 0f;
			spriteEffectLayers[i].effectHorizontalSpeed.floatValue = 0f;
			mat.SetFloat($"_Effect{i + 1}VerticalSpeed",0f);
			mat.SetFloat($"_Effect{i + 1}HorizontalSpeed",0f);
		}

		spriteEffectLayers[i].effectBlendMode.layerBlendModeValue = GetLayerBlendMode(mat, $"_Effect{i + 1}BlendMask", $"_Effect{i + 1}AlphaBlend");

		spriteEffectLayers[i].effectTimingOffset.floatValue = mat.GetFloat($"_Effect{i + 1}TimingOffset");

		spriteEffectLayers[i].effectUniformUV.boolValue = IsKeywordOrIntEnabled(mat, $"_EFFECT{i + 1}UNIFORMUV_ON", $"_EFFECT{i + 1}UNIFORMUV_ON");

		spriteEffectLayers[i].effectUseAlpha.boolValue = IsKeywordOrIntEnabled(mat, $"_EFFECT{i + 1}USEALPHA_ON", $"_Effect{i + 1}UseAlpha");

		spriteEffectLayers[i].effectScrollDirectional.boolValue = IsKeywordEnabled(mat, $"_EFFECT{i + 1}USEDIRECTIONALSCROLL_ON");

		if (IsKeywordOrIntEnabled(mat, $"_EFFECT{i + 1}USEDISTORTMASK_ON", $"_Effect{i + 1}UseDistortMask"))
		{
			spriteEffectLayers[i].effectDistortStrength.floatValue = mat.GetFloat($"_Effect{i + 1}MaskDistortStrength") * 5f;
		}
        else
        {
			ResetKeywordOrInt(mat, $"_EFFECT{i + 1}USEDISTORTMASK_ON", $"_Effect{i + 1}UseDistortMask");
			spriteEffectLayers[i].effectDistortStrength.floatValue = 0f;
			mat.SetFloat($"_Effect{i + 1}MaskDistortStrength", 0f);
		}

		spriteEffectLayers[i].effectUseLuminanceMask.boolValue = mat.GetFloat($"_Effect{i + 1}UseLuminanceMask") > 0 ? true : false;

		spriteEffectLayers[i].effectUseScrollCurve = IsKeywordEnabled(mat, $"_EFFECT{i + 1}USESCROLLCURVE_ON");
		spriteEffectLayers[i].effectUseRotateCurve = IsKeywordEnabled(mat, $"_EFFECT{i + 1}USEROTATECURVE_ON");
		spriteEffectLayers[i].effectUseScaleCurve = IsKeywordEnabled(mat, $"_EFFECT{i + 1}USESCALECURVE_ON");
	}

	private LayerBlendMode GetLayerBlendMode(Material mat, string BlendMaskPropertyName, string AlphaBlendPropertyName)
	{
		if (mat.HasFloat(BlendMaskPropertyName) && mat.HasFloat(AlphaBlendPropertyName))
		{
			if (mat.GetFloat(BlendMaskPropertyName) == 1)
			{
				return LayerBlendMode.Mask;
			}
			else if (mat.GetFloat(AlphaBlendPropertyName) == 1)
			{
				return LayerBlendMode.AlphaBlend;
			}
			else
			{
				return LayerBlendMode.Additive;
			}
		}
        else
        {
			if (mat.GetFloat(AlphaBlendPropertyName) == 1)
			{
				return LayerBlendMode.AlphaBlend;
			}
			else
			{
				return LayerBlendMode.Additive;
			}
		}
	}

	#endregion


	//특정 프로퍼티가 저장된 상태인지 아닌지 확인
	#region CheckOverride
	public void CheckOverride()
	{
		if (createdMaterial == null)
		{
			return;
		}
		SetOverride(createdMaterial);
	}

	private void SetOverride(Material mat)
	{
		if (mat != null)
		{
			//List<string> overrideList = new List<string>();
			//int haveDifference = 0;
			int overrideList = 0;
			CompareMaterialValue(mat, ref overrideList);
            if (overrideList > 0)   // 메테리얼과 에디터의 프로퍼티 차이가 하나 이상일 경우 저장되지않은 부분이 있다고 판단
            {
				//string overrideNameList = new string("");
                //for (int i = 0; i < overrideList.Count; i++)
                //{
				//	overrideNameList += overrideList[i] + "/ ";
				//}

				//Debug.LogWarning(this.gameObject.name + " property override count = " + overrideList.Count + "\n" + overrideNameList, this.gameObject);
				Debug.LogWarning("SetOverride() true Count: " + overrideList);
				haveUnsavedChange = true;  //인스턴스 메테리얼 사용
				needUpdate = true;
				UpdateMat(effectMaterial);
			}
		}
	}

	private void CompareMaterialValue(Material mat, ref int overrideList)
	{
		setSpriteGrayScale.CompareValue(IsKeywordOrIntEnabled(mat, "_BASESPRITEGRAYSCALE_ON", "_BaseSpriteGrayscale"), "_BaseSpriteGrayscale", ref overrideList);
		spriteGrayScaleValue.CompareValue(mat.GetFloat("_BaseGrayscaleValue"), "_BaseGrayscaleValue", ref overrideList);
		setSpriteBrightness.CompareValue(IsKeywordOrIntEnabled(mat, "_BASESPRITEBRIGHTNESS_ON", "_BaseSpriteBrightness"), "_BaseSpriteBrightness", ref overrideList);
		spriteBrightnessValue.CompareValue(mat.GetFloat("_BaseBrightnessValue"), "_BaseBrightnessValue", ref overrideList);
		spriteBrightnessUseLuminanceMask.CompareValue(mat.GetFloat("_BaseBrightnessUseLuminanceMask") > 0 ? true : false, "_BaseBrightnessUseLuminanceMask",ref overrideList);
		setSpriteTintColor.CompareValue(IsKeywordOrIntEnabled(mat, "_BASETINTCOLOR_ON", "_BaseSpriteTintColor"), "_BaseSpriteTintColor", ref overrideList);
		spriteTintColorValue.CompareValue(mat.GetColor("_BaseTintColor"), "_BaseTintColor", ref overrideList);
		spriteTintColorUseLuminanceMask.CompareValue(mat.GetFloat("_BaseTintColorUseLuminanceMask") > 0 ? true : false, "_BaseTintColorUseLuminanceMask", ref overrideList);
		setSpriteCutOut.CompareValue(IsKeywordEnabled(mat, "_BASECUTOUT_ON"), "_BASECUTOUT_ON", ref overrideList);
		spriteCutOutValue.CompareValue(mat.GetVector("_BaseCutOutVal"), "_BaseCutOutVal",ref overrideList);
		spriteCutOutTexture.CompareValue(mat.GetTexture($"_BaseCutOutTex") as Texture2D, $"_BaseCutOutTex",ref overrideList);
		spriteCutOutTextureTileOffset.CompareValue(mat.GetVector("_BaseCutOutTex_ST"), "_BaseCutOutTex_ST", ref overrideList);
		spriteCutOutEdgeColor.CompareValue(mat.GetColor("_BaseCutOutEdgeColor"), "_BaseCutOutEdgeColor", ref overrideList);
		spriteCutOutEdgeBrightness.CompareValue(mat.GetFloat("_BaseCutOutEdgeColorBrightness"), "_BaseCutOutEdgeColorBrightness", ref overrideList);
		spriteCutOutFillColor.CompareValue(mat.GetColor("_BaseCutOutFillColor"), "_BaseCutOutFillColor", ref overrideList);
		spriteCutOutFillBrightness.CompareValue(mat.GetFloat("_BaseCutOutFillColorBrightness"), "_BaseCutOutFillColorBrightness", ref overrideList);
		spriteCutOutUseSliceUV.CompareValue(IsKeywordEnabled(mat, "_BASECUTOUTUSESLICEUV_ON"), "_BASECUTOUTUSESLICEUV_ON", ref overrideList);
		spriteCutOutUniformUV.CompareValue(IsKeywordEnabled(mat, "_BASECUTOUTUNIFORMUV_ON"), "_BASECUTOUTUNIFORMUV_ON", ref overrideList);
		spriteCutOutDoNotUseAlpha.CompareValue(IsKeywordEnabled(mat, "_BASECUTOUTDONOTUSEALPHA_ON"), "_BASECUTOUTDONOTUSEALPHA_ON", ref overrideList);
		spriteCutOutProgress.CompareValue(mat.GetFloat("_BaseCutOutProgress"), "_BaseCutOutProgress", ref overrideList);
		setSpriteVertexAnim.CompareValue(IsKeywordEnabled(mat, "_BASEVERTEXANIM_ON"), "_BASEVERTEXANIM_ON", ref overrideList);
		spriteVertexAnimValue.CompareValue(mat.GetVector("_BaseVertexAnimVal"), "_BaseVertexAnimVal", ref overrideList);

		setSpriteTransparent.CompareValue(IsKeywordEnabled(mat, "_REMOVEBASESPRITE_ON"), "_REMOVEBASESPRITE_ON", ref overrideList);
		useUnscaledTime.CompareValue(IsKeywordEnabled(mat, "_USEUNSCALEDTIME_ON"), "_USEUNSCALEDTIME_ON", ref overrideList);
		luminanceMaskThresholdMin.CompareValue(mat.GetFloat("_LuminanceMaskThresholdMin"), "_LuminanceMaskThresholdMin", ref overrideList);
		luminanceMaskThresholdMax.CompareValue(mat.GetFloat("_LuminanceMaskThresholdMax"), "_LuminanceMaskThresholdMax", ref overrideList);

		for (int i = 0; i < _numOfLayer; i++)
		{
			if (spriteEffectLayers[i].isEffectActive != IsKeywordEnabled(mat, $"_EFFECT{i + 1}_ON"))
            {
				overrideList++;
				//overrideList.Add($"_EFFECT{i + 1}_ON");
			}
			CompareValue(mat, i, ref overrideList);
		}

		//if (setSpriteGrayScale.boolValue || setSpriteBrightness.boolValue || setSpriteTintColor.boolValue || setSpriteCutOut.boolValue || setSpriteVertexAnim.boolValue)
		//{
		//	isSpriteOptionFolderOpen = true;
		//}
	}

	private void CompareValue(Material mat, int i, ref int overrideList)
	{
		spriteEffectLayers[i].effectTexture.CompareValue(mat.GetTexture($"_Effect{i + 1}Tex") as Texture2D, $"_Effect{i + 1}Tex", ref overrideList);
		spriteEffectLayers[i].effectTextureTileOffset.CompareValue(mat.GetVector($"_Effect{i + 1}Tex_ST"), $"_Effect{i + 1}Tex_ST", ref overrideList);

		spriteEffectLayers[i].effectUseFlipBook.CompareValue(IsKeywordEnabled(mat, $"_EFFECT{i + 1}USEFLIPBOOK_ON"), $"_EFFECT{i + 1}USEFLIPBOOK_ON", ref overrideList);
		spriteEffectLayers[i].effectUseFlipBookBlend.CompareValue(IsKeywordEnabled(mat, $"_EFFECT{i + 1}USEFLIPBOOKBLEND_ON"), $"_EFFECT{i + 1}USEFLIPBOOKBLEND_ON", ref overrideList);
		spriteEffectLayers[i].effectFlipBookValue.CompareValue(mat.GetVector($"_Effect{i + 1}FlipbookValue"), $"_Effect{i + 1}FlipbookValue", ref overrideList);

		spriteEffectLayers[i].effectUseSpriteMask.CompareValue(mat.GetFloat($"_Effect{i + 1}UseSpriteMask") > 0 ? true : false, $"_Effect{i + 1}UseSpriteMask", ref overrideList);
		spriteEffectLayers[i].effectSpriteMaskValue.CompareValue(mat.GetVector($"_Effect{i + 1}SpriteMaskValue"), $"_Effect{i + 1}SpriteMaskValue", ref overrideList);
		spriteEffectLayers[i].effectMask.CompareValue(mat.GetTexture($"_Effect{i + 1}Mask") as Texture2D, $"_Effect{i + 1}Mask", ref overrideList);
		spriteEffectLayers[i].effectUseMaskUV.CompareValue(IsKeywordOrIntEnabled(mat, $"_EFFECT{i + 1}USEMASKUV_ON", $"_Effect{i + 1}UseMaskUV"), $"_Effect{i + 1}UseMaskUV", ref overrideList);
		spriteEffectLayers[i].effectUseTimerMask.CompareValue((IsKeywordEnabled(mat, $"_EFFECT{i + 1}USETIMERMASK_ON") || IsKeywordEnabled(mat, $"_EFFECT{i + 1}USETIMEROFFSETMASK_ON")), $"_EFFECT{i + 1}USETIMERMASK_ON", ref overrideList);
		spriteEffectLayers[i].effectTimerMaskValue.CompareValue(mat.GetVector($"_Effect{i + 1}TimerMaskVal"), $"_Effect{i + 1}TimerMaskVal", ref overrideList);
		spriteEffectLayers[i].effectTimerMaskBaseUV.CompareValue(IsKeywordOrIntEnabled(mat, $"_EFFECT{i + 1}USETIMERMASKBASEUV_ON", $"_Effect{i + 1}UseTimerMaskBaseUV"), $"_Effect{i + 1}UseTimerMaskBaseUV", ref overrideList);

		spriteEffectLayers[i].effectColor.CompareValue(mat.GetColor($"_Effect{i + 1}Color"), $"_Effect{i + 1}Color", ref overrideList);
		spriteEffectLayers[i].effectBrightness.CompareValue(mat.GetFloat($"_Effect{i + 1}Brightness"), $"_Effect{i + 1}Brightness", ref overrideList);
		spriteEffectLayers[i].effectScale.CompareValue(mat.GetFloat($"_Effect{i + 1}ScaleOrigin"), $"_Effect{i + 1}ScaleOrigin", ref overrideList);
		spriteEffectLayers[i].effectScaleMultiplier.CompareValue(mat.GetFloat($"_Effect{i + 1}ScaleMultiplier"), $"_Effect{i + 1}ScaleMultiplier", ref overrideList);
		spriteEffectLayers[i].effectScalePingPong.CompareValue(IsKeywordEnabled(mat, $"_EFFECT{i + 1}USESCALEPINGPONG_ON"), $"_EFFECT{i + 1}USESCALEPINGPONG_ON", ref overrideList);
		spriteEffectLayers[i].effectRandomRotation.CompareValue(IsKeywordEnabled(mat, $"_EFFECT{i + 1}RANDOMROTATE_ON"), $"_EFFECT{i + 1}RANDOMROTATE_ON",ref overrideList);
		spriteEffectLayers[i].effectScaleSpeed.CompareValue(mat.GetFloat($"_Effect{i + 1}ScaleSpeed"), $"_Effect{i + 1}ScaleSpeed", ref overrideList);
		spriteEffectLayers[i].effectPower.CompareValue(mat.GetFloat($"_Effect{i + 1}Power"), $"_Effect{i + 1}Power", ref overrideList);

		spriteEffectLayers[i].effectRotateSpeed.CompareValue(mat.GetFloat($"_Effect{i + 1}RotateSpeed"), $"_Effect{i + 1}RotateSpeed", ref overrideList);
		spriteEffectLayers[i].effectRotateAngle.CompareValue(mat.GetFloat($"_Effect{i + 1}RotateAngle") / -Mathf.Deg2Rad, $"_Effect{i + 1}RotateAngle", ref overrideList);
		spriteEffectLayers[i].effectVerticalSpeed.CompareValue(mat.GetFloat($"_Effect{i + 1}VerticalSpeed"), $"_Effect{i + 1}VerticalSpeed", ref overrideList);
		spriteEffectLayers[i].effectHorizontalSpeed.CompareValue(mat.GetFloat($"_Effect{i + 1}HorizontalSpeed"), $"_Effect{i + 1}HorizontalSpeed", ref overrideList);
		spriteEffectLayers[i].effectGlowSpeed.CompareValue(mat.GetFloat($"_Effect{i + 1}GlowSpeed"), $"_Effect{i + 1}GlowSpeed",ref overrideList);
		spriteEffectLayers[i].effectBlendMode.CompareValue(GetLayerBlendMode(mat, $"_Effect{i + 1}BlendMask", $"_Effect{i + 1}AlphaBlend"), $"_Effect{i + 1}BlendMode", ref overrideList);
		spriteEffectLayers[i].effectTimingOffset.CompareValue(mat.GetFloat($"_Effect{i + 1}TimingOffset"), $"_Effect{i + 1}TimingOffset", ref overrideList);
		spriteEffectLayers[i].effectUniformUV.CompareValue(IsKeywordOrIntEnabled(mat, $"_EFFECT{i + 1}UNIFORMUV_ON", $"_Effect{i + 1}UniformUV"), $"_Effect{i + 1}UniformUV", ref overrideList);
		spriteEffectLayers[i].effectUseAlpha.CompareValue(IsKeywordOrIntEnabled(mat, $"_EFFECT{i + 1}USEALPHA_ON", $"_Effect{i + 1}UseAlpha"), $"_Effect{i + 1}UseAlpha", ref overrideList);
		spriteEffectLayers[i].effectScrollDirectional.CompareValue(IsKeywordEnabled(mat, $"_EFFECT{i + 1}USEDIRECTIONALSCROLL_ON"), $"_EFFECT{i + 1}USEDIRECTIONALSCROLL_ON", ref overrideList);
		spriteEffectLayers[i].effectDistortStrength.CompareValue(mat.GetFloat($"_Effect{i + 1}MaskDistortStrength")*5f, $"_Effect{i + 1}MaskDistortStrength", ref overrideList);
		spriteEffectLayers[i].effectUseLuminanceMask.CompareValue(IsKeywordOrIntEnabled(mat, $"_EFFECT{i + 1}USELUMINANCEMASK_ON", $"_Effect{i + 1}UseLuminanceMask"), $"_Effect{i + 1}UseLuminanceMask", ref overrideList);
	}
	#endregion

	#region MaterialAssetControl
	#region Manage Temporary Material
	private void DestroyMaterial(Material mat)
	{
		if (mat != null)
		{
			if (Application.isPlaying)
			{
				Destroy(mat);
			}
			else
				DestroyImmediate(mat);
		}
	}

	private Material CreatTemporatyMaterial()
	{
		DestroyMaterial(tempMaterial);
		tempMaterial = new Material(Shader.Find(effectShader));
		tempMaterial.name = new string(tempMaterial.name + " (Instanced)");
		tempMaterial.hideFlags = HideFlags.HideAndDontSave;
		previousMaterial = tempMaterial;
		return tempMaterial;
	}
#endregion

	/// <summary>
	/// 에디터 전용. 다른 코드에서 호출하면 안됨.
	/// </summary>
	public void CreateAndSaveMaterialAsset(string path)
	{
		if (createdMaterial == null)
		{
			CreatMaterialAsset(path);
			DestroyMaterial(tempMaterial);
		}
		else
		{
			RenameMaterialAsset(path);
		}
		SaveSetting();
	}

	/// <summary>
	/// 에디터 전용. 다른 코드에서 호출하면 안됨.
	/// </summary>
	public void SaveAsNewMaterialAsset(string path)
    {
		CreatMaterialAsset(path);
		SaveSetting();
	}

	/// <summary>
	/// 에디터 전용. 다른 코드에서 호출하면 안됨.
	/// </summary>
	public bool CheckMaterialChange()    // 에디터용
	{
		if (createdMaterial == null)
		{
			return false;
		}
		if (previousMaterial != createdMaterial)
		{
			previousMaterial = createdMaterial;
			name = createdMaterial.name.Replace(materialAssetPrefix, "");
			return true;
		}
		else
		{
			return false;
		}
	}

	private void CreatMaterialAsset(string materialAssetPath)
	{
		string matName = materialAssetPrefix + this.name;
		var matID = 0;
		string[] existAssets = AssetDatabase.FindAssets(matName, new[] { materialAssetPath });
		if (existAssets.Length >= 1)   // 바꿀 이름과 일치하는 문자열을 가진 에셋이 1개이상 존재할때
		{
			foreach (var existAsset in existAssets)   //바꿀 이름이랑 같은 이름이 이미 존재하는지 확인
			{
				//Debug.LogWarning("Exist Name : " + AssetDatabase.GUIDToAssetPath(existAsset).Replace(materialAssetPath, ""));
				if (AssetDatabase.GUIDToAssetPath(existAsset).Replace(materialAssetPath + "/", "") == matName + ".mat")   // 같은 이름이 존재할경우
				{
					Debug.LogWarning("중복된이름있음 : " + AssetDatabase.GUIDToAssetPath(existAsset).Replace(materialAssetPath, ""));
					foreach (var existAsset2 in existAssets)
					{
						// 뒤에 matID를 붙이고 같은 이름이 존재하지 않을때까지 matID를 +1 하고 다시 체크
						while (AssetDatabase.GUIDToAssetPath(existAsset2).Replace(materialAssetPath + "/", "") == matName + "_" + matID + ".mat")
							matID++;
					}
					createdMaterial = new Material(Shader.Find(effectShader));
					createdMaterial.name = matName + "_" + matID;
					AssetDatabase.CreateAsset(createdMaterial, materialAssetPath + "/" + matName + "_" + matID + ".mat");
					Debug.Log(AssetDatabase.GetAssetPath(createdMaterial) + "가 생성되엇습니다." + "\r\n" + "커밋할때 함깨 올려주세요");
					Debug.LogWarning("중복파일명변경 : " + matName + "_" + matID);
					previousMaterial = createdMaterial;
					effectMaterial = createdMaterial;
					return;  // 중복된 이름을 피해 메테리얼 생성에 성공했다면 종료
				}
			}
		}
		//완전히 같은 이름이 없어서 return으로 빠지지 않았을 경우 또는 바꿀 이름과 일치하는 문자열을 가진 에셋이 없을경우
		createdMaterial = new Material(Shader.Find(effectShader));
		createdMaterial.name = matName;
		AssetDatabase.CreateAsset(createdMaterial, materialAssetPath + "/" + matName + ".mat");
		Debug.Log(AssetDatabase.GetAssetPath(createdMaterial) + "가 생성되엇습니다." + "\r\n" + "커밋할때 함깨 올려주세요");
		previousMaterial = createdMaterial;
		effectMaterial = createdMaterial;
	}

	private void RenameMaterialAsset(string materialAssetPath)
	{
		Debug.LogWarning("RenameMaterialAsset to " + this.name);
		string newName = materialAssetPrefix + this.name;
		var matID = 0;
		foreach (var asset in AssetDatabase.FindAssets(createdMaterial.name, new[] { materialAssetPath }))
		{
			if (AssetDatabase.GUIDToAssetPath(asset).Replace(materialAssetPath + "/", "") == createdMaterial.name + ".mat")   // 이름바꿀 원본에셋 검색
			{
				var path = AssetDatabase.GUIDToAssetPath(asset);  // 원본 에셋 패스
				string[] existAssets = AssetDatabase.FindAssets(newName, new[] { materialAssetPath });
				foreach (var existAsset in existAssets)   //바꿀 이름이랑 같은 이름이 이미 존재하는지 확인
				{
					if (AssetDatabase.GUIDToAssetPath(existAsset).Replace(materialAssetPath + "/", "") == newName + ".mat")   // 같은 이름이 존재할경우
					{
						Debug.LogWarning("중복된이름있음 : " + AssetDatabase.GUIDToAssetPath(existAsset).Replace(materialAssetPath + "/", ""));
						foreach (var existAsset2 in existAssets)
						{
							// 뒤에 matID를 붙이고 같은 이름이 존재하지 않을때까지 matID를 +1 하고 다시 체크
							while (AssetDatabase.GUIDToAssetPath(existAsset2).Replace(materialAssetPath + "/", "") == newName + "_" + matID + ".mat")
								matID++;
						}
						AssetDatabase.RenameAsset(path, newName + "_" + matID);
						Debug.LogWarning("중복파일명변경 : " + newName + "_" + matID);
						return;
					}
				}
				AssetDatabase.RenameAsset(path, newName); // 같은 이름이 없으면 그냥 바로 적용
				Debug.LogWarning("파일명변경 : " + newName);
				return;
			}
			Debug.LogWarning(createdMaterial.name + ".mat 파일을 발견하지 못했습니다.");
		}
		//Debug.LogWarning("Rename Error");
	}

	private Material DefaultSpriteMaterialAsset(string materialAssetPath)
	{
		Material defaultMat = null;
		string matName = "SpriteEffect_Default";
		if (!AssetDatabase.IsValidFolder("Assets/Resources"))
			AssetDatabase.CreateFolder("Assets", "Resources");
		if (!AssetDatabase.IsValidFolder(materialAssetPath))
			AssetDatabase.CreateFolder("Assets/Resources", "SpriteEffectMaterial");
		string[] existAssets = AssetDatabase.FindAssets(matName, new[] { materialAssetPath });
		if (existAssets.Length >= 1)   // 바꿀 이름과 일치하는 문자열을 가진 에셋이 1개이상 존재할때
		{
			foreach (var existAsset in existAssets)   //바꿀 이름이랑 같은 이름이 이미 존재하는지 확인
			{
				//Debug.LogWarning("Exist Name : " + AssetDatabase.GUIDToAssetPath(existAsset).Replace(materialAssetPath+"/", ""));
                if (AssetDatabase.GUIDToAssetPath(existAsset).Replace(materialAssetPath + "/", "") == matName + ".mat")   // 같은 이름이 존재할경우
                {
                    //Debug.LogWarning("Return exist default material");
					defaultMat = Resources.Load<Material>("SpriteEffectMaterial/SpriteEffect_Default");// 중복된 이름이 있으면 반환
                }
			}
		}
        else
        {
			//완전히 같은 이름이 없어서 return으로 빠지지 않았을 경우 또는 바꿀 이름과 일치하는 문자열을 가진 에셋이 없을경우
			defaultMat = new Material(Shader.Find("Sprites/Default"));
			defaultMat.name = matName;
			AssetDatabase.CreateAsset(defaultMat, materialAssetPath + "/" + matName + ".mat");
			Debug.Log(AssetDatabase.GetAssetPath(defaultMat) + "가 생성되엇습니다." + "\r\n" + "커밋할때 함깨 올려주세요");
		}
		return defaultMat;
	}
	
	//private void DeleteMaterialAsset(Material mat)
	//{
	//	if (m_image != null && m_image.material != null)
	//	{
	//		m_image.material = null;
	//	}
	//	if (mat != null)
	//	{
	//		string matName = materialAssetPath + mat.name + ".mat";
	//		if (AssetDatabase.DeleteAsset(matName))
	//		{
	//			Debug.Log(matName + "가 삭제되엇습니다.");
	//		}
	//		else
	//		{
	//			Debug.Log(matName + "가 이미 삭제되었거나 존재하지 않습니다.");
	//		}
	//	}
	//}
#endregion

	private void ResetRenderer()   //렌더러별 기본메테리얼로 변경
	{
		if (m_image != null && m_spriteRenderer == null)
		{
			m_image.material = m_image.defaultMaterial;
		}
		else if (m_spriteRenderer != null && m_image == null)
		{
			m_spriteRenderer.material = SpriteDefaultMaterial();
		}
	}

	private void SetShaderUnscaledTime()  //에디터에서만 사용하는 언스케일 타임. 게임플레이중에는 다른 스크립트에서 _ShaderUnscaledTime을 셋팅해줌
	{
		Shader.SetGlobalFloat("_ShaderUnscaledTime", Time.realtimeSinceStartup);
	}

#endif //UNITY_EDITOR
#endregion //Editor Only
}
