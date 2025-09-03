using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
    using UnityEditor;
#endif
using System.Collections;
//[ExecuteInEditMode]
public class ART_SpriteEffectHelper : MonoBehaviour
{
    //public Material[] effectMaterials;
    //[SerializeField]
    private Image m_image;
    //[SerializeField]
    private SpriteRenderer m_spriteRenderer;
    //public Image dice_image;
    //[SerializeField]
    private Material initialmat;
    ////[SerializeField]
    //[SerializeField]
    private Material oldmat;
    //[SerializeField]
    private Material mat;

    //[Range(0.0f, 1.0f)]
    //public float overlayAmount;
    //private float overlayAmount_old;
    //public Color overlayColor = Color.white;
    //private Color overlayColor_old;
    //
    //[Range(0.0f, 1.0f)]
    //public float dissolveAmount;
    //private float dissolveAmount_old;

    private Vector4 m_resultVector = Vector4.zero;
    //[SerializeField]
    private Sprite sprite;
    //[SerializeField]
    //private Sprite rdrSprite;
    //[SerializeField]
    //private Material rdrMaterial;
    private string matName;

    void Awake()
    {
        Initiailze();
    }

    void OnAwake()
    {

    }

    private void OnEnable()
    {
        SetRect();
    }

    private void OnDisable()
    {
        OnDestroy();
    }

    private void Update()
    {
        if (m_image != null && m_image.sprite != null)
        {
            //Debug.Log("Image Checked");
            CheckChanged();
            m_image.material = mat;
        }
        else if (m_spriteRenderer != null && m_spriteRenderer.sprite != null)
        {
            //Debug.Log("Sprite Checked");
            CheckChanged();
            m_spriteRenderer.material = mat;
        }
        //else
        //{
        //    //Debug.Log("Null Checked");
        //}
    }

    private void OnDestroy()
    {
        oldmat = null;
        DestroyMaterial(mat);
        if (m_image != null && m_image.material != null && m_spriteRenderer == null)
        {
            m_image.material = initialmat;
        }
        else if (m_spriteRenderer != null && m_spriteRenderer.material != null && m_image == null)
        {
            m_spriteRenderer.material = initialmat;
        }
    }

    public void ApplyRect()
    {
        Initiailze();
    }

    public void ResetRect()
    {
        OnDestroy();
    }

    private void Initiailze()
    {
        m_image = GetComponent<Image>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        if (m_image == null && m_spriteRenderer == null)
        {
            //Debug.Log("Renderer Not Found");
            m_resultVector = Vector2.zero;
        }
        else
        {
            //Debug.Log("Renderer Found");
            sprite = RendererSprite();
            initialmat = RendererMaterial();
            oldmat = null;
        }
        CreatMaterialInstance();
        SetRect();
        //overlayAmount_old = overlayAmount;
        //overlayColor_old = overlayColor;
        //dissolveAmount_old = dissolveAmount;
    }

    private void SetRect()
    {
        if (sprite == null) return;
        m_resultVector = new Vector4(sprite.textureRect.min.x / sprite.texture.width,
                                    sprite.textureRect.min.y / sprite.texture.height,
                                    sprite.textureRect.max.x / sprite.texture.width,
                                    sprite.textureRect.max.y / sprite.texture.height);
        mat.SetVector("_Rect", m_resultVector);
        if (m_image != null && m_spriteRenderer == null)
        {
            m_image.material = mat;
        }
        else if (m_image == null && m_spriteRenderer != null)
        {
            m_spriteRenderer.material = mat;
        }
    }

    private void CreatMaterialInstance()
    {
        DestroyMaterial(mat);
        mat = new Material(RendererMaterial());
        mat.name = new string(mat.name + " (Instanced)");
        mat.hideFlags = HideFlags.HideAndDontSave;
    }

    public Sprite RendererSprite()
    {
        if (m_image != null && m_spriteRenderer == null)
        {
            //Debug.Log("Sprite : Image");
            return m_image.sprite;
        }
        else if (m_image == null && m_spriteRenderer != null)
        {
            //Debug.Log("Sprite : Sprite");
            return m_spriteRenderer.sprite;
        }
        else
        {
            //Debug.Log("Sprite : Null");
            return null;
        }
    }

    private Material RendererMaterial()
    {
        if (m_image != null && m_spriteRenderer == null)
        {
            //Debug.Log("Renderer : Image");
            return m_image.material;
        }
        else if (m_image == null && m_spriteRenderer != null)
        {
            //Debug.Log("Renderer : SpriteRenderer");
            return m_spriteRenderer.sharedMaterial;
        }
        else
        {
            //Debug.Log("Renderer : Null");
            return null;
        }
    }

    void CheckChanged()
    {
        Sprite rdrSprite = RendererSprite();
        if (NeedNewMaterial() && sprite != rdrSprite)
        {
            CreatMaterialInstance();
            sprite = rdrSprite;
            SetRect();
            //SetOneTimeMaterialValue();
            oldmat = mat;
            //Debug.Log("set Rect By all change");
        }
        if (NeedNewMaterial() && sprite == rdrSprite)
        {
            CreatMaterialInstance();
            SetRect();
            //SetOneTimeMaterialValue();
            oldmat = mat;
            //Debug.Log("set Rect By material change");
        }
        if (!NeedNewMaterial() && sprite != rdrSprite)
        {
            sprite = rdrSprite;
            SetRect();
            //SetMaterialValue();
            oldmat = mat;
            //Debug.Log("set Rect By sprite change");
        }
        else
        {
            //SetMaterialValue();
            //Debug.Log("No Rect change");
        }
    }

    bool NeedNewMaterial()
    {
        if (RendererMaterial() != oldmat)
        {
            return true;
        }
        else { return false; }
    }

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

//에디터상에서 컴포넌트 제거시 Ondestroy콜백을 받게해주는 부분
#if UNITY_EDITOR
    //tells if we have already hooked-up to the SceneView delegate, once, some time ago
    [System.NonSerialized]
    bool linked_SV = false;

    public void OnDrawGizmos()
    {
        if (linked_SV == false)
        {
            linked_SV = true;
            SceneView.duringSceneGui -= OnSceneDraw;
            SceneView.duringSceneGui += OnSceneDraw;
        }
    }


    void OnSceneDraw(SceneView sceneView)
    {

        try
        {
            this.gameObject.name = this.gameObject.name;
        }
        catch
        {
            SceneView.duringSceneGui -= OnSceneDraw;
            // this gameObject was destroyed. 
            OnDestroy();
            return;
        }
    }
#endif

        /*
        public void ChangeMaterial(int _materialNumber)
        {
            AnimEventSpriteEffectMaterialChanger(_materialNumber);
        }

        void AnimEventSpriteEffectMaterialChanger(int materialNumber)
        {
            if (effectMaterials != null)
            {
                m_image.material = effectMaterials[materialNumber];
                if (dice_image != null &&
                    dice_image.material != null)
                {
                    dice_image.material = effectMaterials[materialNumber];
                }
                CheckChanged();
            }
        }
        */

        /*
        public void SetRect()
        {
            if ( sprite == null ) return;

            m_resultVector = new Vector4(sprite.textureRect.min.x / sprite.texture.width,
                                                sprite.textureRect.min.y / sprite.texture.height,
                                                sprite.textureRect.max.x / sprite.texture.width,
                                                sprite.textureRect.max.y / sprite.texture.height);
            mat.SetVector("_Rect", m_resultVector);
        }
        */
        /*
        void SetMaterialValue()
        {
            if (m_image.material != null)
            {
                if (overlayAmount_old != overlayAmount)
                {
                    mat.SetFloat("_overlayAmount", overlayAmount);
                    overlayAmount_old = overlayAmount;
                }
                if (overlayColor_old != overlayColor)
                {
                    mat.SetColor("_overlayColor", overlayColor);
                    overlayColor_old = overlayColor;
                }
                if (dissolveAmount_old != dissolveAmount)
                {
                    mat.SetFloat("_dissolveAmount", dissolveAmount);
                    dissolveAmount_old = dissolveAmount;
                    //Debug.Log("change dissolve");
                }
            }
        }


        void SetOneTimeMaterialValue()
        {
            if (m_image.material != null)
            {
                mat.SetFloat("_overlayAmount", overlayAmount);
                overlayAmount_old = overlayAmount;

                mat.SetColor("_overlayColor", overlayColor);
                overlayColor_old = overlayColor;

                mat.SetFloat("_dissolveAmount", dissolveAmount);
                dissolveAmount_old = dissolveAmount;
            }
        }

        void OnDisable()
        {
            if (m_image != null && m_image.material != null)
            {
                oldmat = null;
                Destroy(mat);
                m_image.material = initialmat;         
            }
        }
        */
}
