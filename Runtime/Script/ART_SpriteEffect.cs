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
		public bool overrideValue = false;  // �������� ���� ���׸����� ���� �ٸ���� true;

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

		public bool isEffectvalueFolderOpen = false;   //�����Ϳ��� ������Ƽ â�� ���ƴ°�?
		public bool isEffectCreated = false;   //�����Ϳ��� ���̾ �����Ǿ��°�?
		public bool confirmRemove = false;     //�����Ϳ��� ���̾ ���� �����ΰ�?
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

		public bool isEffectvalueFolderOpen = false;   //�����Ϳ��� ������Ƽ â�� ���ƴ°�?
		public bool isEffectCreated = false;   //�����Ϳ��� ���̾ �����Ǿ��°�?
		public bool confirmRemove = false;     //�����Ϳ��� ���̾ ���� �����ΰ�?
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

	public bool isSpriteOptionFolderOpen = false;   //�����Ϳ��� ��������Ʈ �ɼ������� ���ƴ°�?

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
	private Material effectMaterial;    //���� �������� ���׸���
	private Material previousMaterial;   //���� ���׸��� 
	[SerializeField]
	private Material createdMaterial;  // ������ ���׸���
	private Material tempMaterial;   // �ӽ� ���׸���
	private Material instancedMaterial;   // �ִϸ��̼�Ŀ�� ����� �ν��Ͻ� ���׸���
	private Material instanceSourceMaterial;   // �ν��Ͻ��� �ҽ� ���׸���
	private Material defaultSpriteMaterial;  // ����Ʈ�� �����Ҷ� ��������Ʈ �������� �������� ���׸��� (Sprite-Default)

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
	private bool? isSpriteChanged = null;  //�̹������ӿ� ��������Ʈ ���� üũ�� �̹� �ߴ°�?
	private bool killCheck = false;   //ųüũ �����ߴ°�?
	private bool imageMaskableState = false;    //���� ����Ŀ�� ����
#endif

	private Vector2 previousSpriteRendererSize;
	private SpriteDrawMode previousDrawMode;
	private Sprite previousSprite;

	private bool changeSpriteCall = false;   //��������Ʈ�����û�� �ִ°�?
	private bool useCurveInPlayMode = false;  //�÷��̸���� �׻� �ִϸ��̼� Ŀ�긦 ����Ұ��ΰ�?
	private bool? haveRenderer = null;  //�÷��̸���� �������� �����ϴ°�?
	private bool? isSpriteRenderer = null;  //�÷��̸���� ����ϴ� �������� ��������Ʈ �������ΰ�?
	private bool? isUseCurve = null;    //�̹������ӿ� Ŀ��üũ�� �̹� �ߴ°�?
	private bool? isAspectChanged = null;  //�̹������ӿ� ��Ⱦ�� ���� üũ�� �̹� �ߴ°�?
	private bool isInitialized = false;  //�ʱ�ȭ�Ǿ��°�?


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

	public void Initialize()  // �Ŵ��������� ȣ��
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
	/// ��������Ʈ ����� �ʱ�ȭ ȣ��
	/// </summary>
	public void SpriteChange()	//��������Ʈ��ü ��
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

	private void UpdateMat(Material mat)  // ���� ������Ʈ ����
	{
		if (this.enabled == true)
		{
			ResetBoolChecks();
			if (NeedUpdate())  // ������Ʈ�� ��Ұ� �����ϴ��� Ȯ��
			{
				mat = RenderingMat(mat);// 1.�����Ϳ��� ���׸��� �����Ȳ�� ���� ������ ������ ���׸����� ����.			
				SetMaterial(ref mat);// 2.���׸����� �������� ����
				UpdateMaterial(mat);// 3.��ũ��Ʈ�� ������ ���� ������ ���׸��� ����	
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

	private Material RenderingMat(Material mat)    // �������� ���� ������ ���׸����� ��ȯ
	{
		if (needMaterialUpdate)   //Ŀ����� haveUnsavedChange �� �׻� ������(�ν��Ͻ� ��û��)
		{
			haveUnsavedChange = true;
		}
		if (createdMaterial != null && !haveUnsavedChange)   // ��������� ���� createdMaterial�� ������ mat�� ����
		{
			//Debug.LogWarning("ManageMaterial() set to create");
			mat = createdMaterial;
			return mat;
		}
		else if (createdMaterial != null && haveUnsavedChange && instancedMaterial != null && instanceSourceMaterial == createdMaterial)// ��������� ������ �̹� �ν��Ͻ��� ������ ����
		{
			//Debug.LogWarning("ManageMaterial() reuse Instance");
			mat = instancedMaterial;
			if (instancedMaterial.name != createdMaterial.name + " (Instanced)")  // ���׸��� �̸��� �مf���� ����� �ν��Ͻ� �̸��� ������
			{
				instancedMaterial.name = createdMaterial.name + " (Instanced)";
			}
			return mat;
		}
		else if (createdMaterial != null && haveUnsavedChange && instanceSourceMaterial != createdMaterial)  // ��������� �ְ� �ν��Ͻ��� ���� ���׸����� �ν��Ͻ��� �ƴ� ��� ���� ����
		{
			//Debug.LogWarning("ManageMaterial() create Instance");
			mat = CreateMaterialInstance(createdMaterial);
			return mat;
		}
		else if (tempMaterial != null)   //  ���� ������ ���׸����� ������ �̹� �ӽ� ���׸����� ������ ����
		{
			//Debug.LogWarning("ManageMaterial() reuse Temp");
			mat = tempMaterial;
			if (tempMaterial.name != this.name + " (Instanced)")  // ���׸��� �̸��� �مf���� ����� �ν��Ͻ� �̸��� ������
			{
				tempMaterial.name = this.name + " (Instanced)";
			}
			return mat;
		}
		if (createdMaterial == null && mat == null)   // createdMaterial �� mat�� �Ѵ� ������ �ӽû���
		{
			if (Application.isPlaying)  // �÷������϶� �⺻���׸����� ���� (�������϶� Async�������� �ȵǼ� ����Ʈ���̴��� ���׸����� �����ص� �ǹ̰� ����)
            {
				//Debug.LogWarning("ManageMaterial() reset to default");
				Debug.LogError("Effect Material is null at", this.gameObject);
				mat = IsSpriteRenderer() ? SpriteDefaultMaterial() : m_image.defaultMaterial;
            }
#if UNITY_EDITOR
            else   // �÷������� �ƴҶ��� �ӽø��׸����� ����
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

	private void UpdateMaterial(Material mat)   // ���׸��� ������Ƽ ����
	{
		if (mat != null)
		{
			if (CheckValueChange())  // ��ũ��Ʈ�� ������ ���� ���׸��� ����
			{
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
					SetMaterialValue(mat); //�����Ϳ����� ó��. �÷����߿� ������ ��������� 99% ����.
				}
#endif
				needUpdate = false;
			}

			if (IsSpriteRenderer())   // ��������Ʈ �������� ��� �߰� ����
			{
				if (CheckSpriteDataChange())    //��������Ʈ�� ����ɰ��
				{
					SetRect(mat);
					SetMaskData(mat);
				}
				if (CheckSpriteDataChange() || NeedAspectUpdate())  //��������Ʈ�� ����ǰų� ��Ⱦ�� ���Ұ��
                {
					SetAspect(mat);
				}
				changeSpriteCall = false;  // ��������Ʈ ��ü ���� �۾��Ϸ�
				
			}

			if (CheckUseCurve())  //Ŀ�긦 ���ٸ� Ŀ�갪�� ���׸��� ����
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
			if (m_spriteRenderer.drawMode != SpriteDrawMode.Simple)   // ��������Ʈ ������ ��尡 slice �� tile �� ���
			{
				m_spriteRendererData = new Vector4(Mathf.Max(0.0001f, m_spriteRenderer.size.x),
													Mathf.Max(0.0001f, m_spriteRenderer.size.y),
													transform.position.x, transform.position.y);  // <- ������ ���̴����� �����������. ������Ƽ���� �����ϱ����ػ��
			}
			else
			{
				m_spriteRendererData = new Vector4(Mathf.Max(0.0001f, sprite.rect.width / sprite.pixelsPerUnit),
													Mathf.Max(0.0001f, sprite.rect.height / sprite.pixelsPerUnit),
													0, 0);  // <- ������ ���̴����� �����������. ������Ƽ���� �����ϱ����ػ��
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
	private bool HaveRenderer()  // �������� �����ϴ°�?
	{
        if (Application.isPlaying)	//�÷������϶��� �ѹ��� üũ �����ϸ� �׵ڷ� �׻� ��
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
	private bool IsSpriteRenderer()  //��������Ʈ �������� ����? false�� �̹���������
	{
		if (Application.isPlaying)  //�÷������϶��� �ѹ��� üũ
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

	private void ResetBoolChecks() // 1������ 1���� boolüũ�ϵ��� �����ϴ� ó��
    {
		isUseCurve = null;
		isAspectChanged = null;
#if UNITY_EDITOR
		isSpriteChanged = null;
#endif
	}

	private bool NeedUpdate()    //������Ʈ�� �ʿ��� ���  1. �ʱ�ȭ��û�� ������ /2. �ִϸ��̼�Ŀ�긦 ����� /3. ��������Ʈ�������� ��Ⱦ�� ����� /4. ��������Ʈ�� ����� /5. ���� ��������� ����
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

	private bool CheckUseCurve() //Ŀ�긦 ������ΰ�?
	{
		if (Application.isPlaying)  // ������ ������  useCurveInPlayMode �� ���̸� �׻� ��
		{
			if (useCurveInPlayMode)
			{
				return true;
			}
			else return false;
		}
		else return CheckUseCurveInternal();
	}

	private bool CheckUseCurveInternal()  //������ Ŀ�긦 ��������� �˻�
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
			if (spriteEffectLayers[i] != null) // �Ŵ������� �űԻ����Ҷ� ó���� null�� ��. �� �׷���...?
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

	private bool CheckValueChange()  //���� ����Ǿ��°�?
    {
		if (!isInitialized)
		{
			return true;
		}
		return needUpdate;
    }

	private bool CheckSpriteDataChange()  //��������Ʈ�� ����Ǿ��°�?
	{
		if (!isInitialized)
		{
			return true;
		}
		if (changeSpriteCall)  //��������Ʈ��ü ���� ���� ������ ��
        {
			return true;
        }
		if (Application.isPlaying && !changeSpriteCall)  //�÷������϶� ��������Ʈ ��ü ���� ������ ������ ����
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
            if (Application.isPlaying && previousSprite == m_spriteRenderer.sprite)  // ���ӽ������϶� ��������Ʈ�� ������������� ���� false
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

	private bool NeedAspectUpdate()   // ��������Ʈ�� �������� ����Ǿ��°�?
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
	/// ������ ����. �Ŵ����� ������ �ϳ� �̻��� ��������Ʈ ����Ʈ�� �����Ϸ��� �Ұ�� ������ ������Ŵ
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
			Debug.LogWarning("���Ƿ� ������ ����Ʈ ������Ʈ�� �������� ������. ����Ʈ �Ŵ����� ���ؼ� �������� ������� �ڵ����� �����˴ϴ�.", this.gameObject);
			DestroyImmediate(this);
		}
	}

	/// <summary>
	/// ������ ����. �ٸ� �ڵ忡�� ȣ���ϸ� �ȵ�.
	/// </summary>
	public void ApplySetting()  // �����Ϳ�
	{
		haveUnsavedChange = true;
		Reload();
	}

	/// <summary>
	/// ������ ����. �ٸ� �ڵ忡�� ȣ���ϸ� �ȵ�.
	/// </summary>
	public void SaveSetting()  // �����Ϳ�
	{
		haveUnsavedChange = false;
		needUpdate = true;
		Reload();
	}

	/// <summary>
	/// ������ ����. �ٸ� �ڵ忡�� ȣ���ϸ� �ȵ�.
	/// </summary>
	public void SetDirty()  // �����Ϳ�
	{
		haveUnsavedChange = true;
		needUpdate = true;
	}

	/// <summary>
	/// ������ ����. �ٸ� �ڵ忡�� ȣ���ϸ� �ȵ�.
	/// </summary>
	public void OneTimeInitialize()  // �����Ϳ�
	{
		if (!isInitialized)
		{
			Reload();
		}
		isInitialized = true;
	}

	/// <summary>
	/// ������ ����. �ٸ� �ڵ忡�� ȣ���ϸ� �ȵ�.
	/// </summary>
	public void Cleanup()   // �Ŵ������� �����Ҷ�
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
	/// ������ ����. �ٸ� �ڵ忡�� ȣ���ϸ� �ȵ�.
	/// </summary>
	public void SwapLayer(int layer1, int layer2, bool copyLayer = false)   // �����Ϳ�
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
		if (CheckImageMaskableStateChanged() || CheckUseCurve())  //����ũ üũ�� �����ؾ���. Ŀ�긦 ���� üũ�Ұ�� ����ũüũ�� ��ŵ��
        {
			UpdateMat(effectMaterial);
		}
		SetShaderUnscaledTime();
	}

	private bool CheckImageMaskableStateChanged()   //�̹��� ����Ŀ�� ���°� ��������� �ʱ�ȭ��û
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


	//Ư�� ������Ƽ�� ����� �������� �ƴ��� Ȯ��
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
            if (overrideList > 0)   // ���׸���� �������� ������Ƽ ���̰� �ϳ� �̻��� ��� ����������� �κ��� �ִٰ� �Ǵ�
            {
				//string overrideNameList = new string("");
                //for (int i = 0; i < overrideList.Count; i++)
                //{
				//	overrideNameList += overrideList[i] + "/ ";
				//}

				//Debug.LogWarning(this.gameObject.name + " property override count = " + overrideList.Count + "\n" + overrideNameList, this.gameObject);
				Debug.LogWarning("SetOverride() true Count: " + overrideList);
				haveUnsavedChange = true;  //�ν��Ͻ� ���׸��� ���
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
	/// ������ ����. �ٸ� �ڵ忡�� ȣ���ϸ� �ȵ�.
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
	/// ������ ����. �ٸ� �ڵ忡�� ȣ���ϸ� �ȵ�.
	/// </summary>
	public void SaveAsNewMaterialAsset(string path)
    {
		CreatMaterialAsset(path);
		SaveSetting();
	}

	/// <summary>
	/// ������ ����. �ٸ� �ڵ忡�� ȣ���ϸ� �ȵ�.
	/// </summary>
	public bool CheckMaterialChange()    // �����Ϳ�
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
		if (existAssets.Length >= 1)   // �ٲ� �̸��� ��ġ�ϴ� ���ڿ��� ���� ������ 1���̻� �����Ҷ�
		{
			foreach (var existAsset in existAssets)   //�ٲ� �̸��̶� ���� �̸��� �̹� �����ϴ��� Ȯ��
			{
				//Debug.LogWarning("Exist Name : " + AssetDatabase.GUIDToAssetPath(existAsset).Replace(materialAssetPath, ""));
				if (AssetDatabase.GUIDToAssetPath(existAsset).Replace(materialAssetPath + "/", "") == matName + ".mat")   // ���� �̸��� �����Ұ��
				{
					Debug.LogWarning("�ߺ����̸����� : " + AssetDatabase.GUIDToAssetPath(existAsset).Replace(materialAssetPath, ""));
					foreach (var existAsset2 in existAssets)
					{
						// �ڿ� matID�� ���̰� ���� �̸��� �������� ���������� matID�� +1 �ϰ� �ٽ� üũ
						while (AssetDatabase.GUIDToAssetPath(existAsset2).Replace(materialAssetPath + "/", "") == matName + "_" + matID + ".mat")
							matID++;
					}
					createdMaterial = new Material(Shader.Find(effectShader));
					createdMaterial.name = matName + "_" + matID;
					AssetDatabase.CreateAsset(createdMaterial, materialAssetPath + "/" + matName + "_" + matID + ".mat");
					Debug.Log(AssetDatabase.GetAssetPath(createdMaterial) + "�� �����Ǿ����ϴ�." + "\r\n" + "Ŀ���Ҷ� �Ա� �÷��ּ���");
					Debug.LogWarning("�ߺ����ϸ��� : " + matName + "_" + matID);
					previousMaterial = createdMaterial;
					effectMaterial = createdMaterial;
					return;  // �ߺ��� �̸��� ���� ���׸��� ������ �����ߴٸ� ����
				}
			}
		}
		//������ ���� �̸��� ��� return���� ������ �ʾ��� ��� �Ǵ� �ٲ� �̸��� ��ġ�ϴ� ���ڿ��� ���� ������ �������
		createdMaterial = new Material(Shader.Find(effectShader));
		createdMaterial.name = matName;
		AssetDatabase.CreateAsset(createdMaterial, materialAssetPath + "/" + matName + ".mat");
		Debug.Log(AssetDatabase.GetAssetPath(createdMaterial) + "�� �����Ǿ����ϴ�." + "\r\n" + "Ŀ���Ҷ� �Ա� �÷��ּ���");
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
			if (AssetDatabase.GUIDToAssetPath(asset).Replace(materialAssetPath + "/", "") == createdMaterial.name + ".mat")   // �̸��ٲ� �������� �˻�
			{
				var path = AssetDatabase.GUIDToAssetPath(asset);  // ���� ���� �н�
				string[] existAssets = AssetDatabase.FindAssets(newName, new[] { materialAssetPath });
				foreach (var existAsset in existAssets)   //�ٲ� �̸��̶� ���� �̸��� �̹� �����ϴ��� Ȯ��
				{
					if (AssetDatabase.GUIDToAssetPath(existAsset).Replace(materialAssetPath + "/", "") == newName + ".mat")   // ���� �̸��� �����Ұ��
					{
						Debug.LogWarning("�ߺ����̸����� : " + AssetDatabase.GUIDToAssetPath(existAsset).Replace(materialAssetPath + "/", ""));
						foreach (var existAsset2 in existAssets)
						{
							// �ڿ� matID�� ���̰� ���� �̸��� �������� ���������� matID�� +1 �ϰ� �ٽ� üũ
							while (AssetDatabase.GUIDToAssetPath(existAsset2).Replace(materialAssetPath + "/", "") == newName + "_" + matID + ".mat")
								matID++;
						}
						AssetDatabase.RenameAsset(path, newName + "_" + matID);
						Debug.LogWarning("�ߺ����ϸ��� : " + newName + "_" + matID);
						return;
					}
				}
				AssetDatabase.RenameAsset(path, newName); // ���� �̸��� ������ �׳� �ٷ� ����
				Debug.LogWarning("���ϸ��� : " + newName);
				return;
			}
			Debug.LogWarning(createdMaterial.name + ".mat ������ �߰����� ���߽��ϴ�.");
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
		if (existAssets.Length >= 1)   // �ٲ� �̸��� ��ġ�ϴ� ���ڿ��� ���� ������ 1���̻� �����Ҷ�
		{
			foreach (var existAsset in existAssets)   //�ٲ� �̸��̶� ���� �̸��� �̹� �����ϴ��� Ȯ��
			{
				//Debug.LogWarning("Exist Name : " + AssetDatabase.GUIDToAssetPath(existAsset).Replace(materialAssetPath+"/", ""));
                if (AssetDatabase.GUIDToAssetPath(existAsset).Replace(materialAssetPath + "/", "") == matName + ".mat")   // ���� �̸��� �����Ұ��
                {
                    //Debug.LogWarning("Return exist default material");
					defaultMat = Resources.Load<Material>("SpriteEffectMaterial/SpriteEffect_Default");// �ߺ��� �̸��� ������ ��ȯ
                }
			}
		}
        else
        {
			//������ ���� �̸��� ��� return���� ������ �ʾ��� ��� �Ǵ� �ٲ� �̸��� ��ġ�ϴ� ���ڿ��� ���� ������ �������
			defaultMat = new Material(Shader.Find("Sprites/Default"));
			defaultMat.name = matName;
			AssetDatabase.CreateAsset(defaultMat, materialAssetPath + "/" + matName + ".mat");
			Debug.Log(AssetDatabase.GetAssetPath(defaultMat) + "�� �����Ǿ����ϴ�." + "\r\n" + "Ŀ���Ҷ� �Ա� �÷��ּ���");
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
	//			Debug.Log(matName + "�� �����Ǿ����ϴ�.");
	//		}
	//		else
	//		{
	//			Debug.Log(matName + "�� �̹� �����Ǿ��ų� �������� �ʽ��ϴ�.");
	//		}
	//	}
	//}
#endregion

	private void ResetRenderer()   //�������� �⺻���׸���� ����
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

	private void SetShaderUnscaledTime()  //�����Ϳ����� ����ϴ� ������ Ÿ��. �����÷����߿��� �ٸ� ��ũ��Ʈ���� _ShaderUnscaledTime�� ��������
	{
		Shader.SetGlobalFloat("_ShaderUnscaledTime", Time.realtimeSinceStartup);
	}

#endif //UNITY_EDITOR
#endregion //Editor Only
}
