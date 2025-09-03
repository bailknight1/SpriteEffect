using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.Rendering;
using Unity.Collections;

[DisallowMultipleComponent]
public class ART_SpriteEffectUIImageHelper : BaseMeshEffect
{
    [SerializeField]
    private Image image;
    //private ART_SpriteEffect spriteEffect;
    //private int rectPropertyID = Shader.PropertyToID("_Rect");
    protected override void Awake()
    {
        base.Awake();
        image = GetComponent<Image>();
        //spriteEffect = GetComponent<ART_SpriteEffect>();
        if (image == null)
        {
            Debug.LogError("Image component not found in :", this);
        }
    }
    //https://forum.unity.com/threads/get-standard-uvs-for-9-sliced-image-shader.482846/
    protected ART_SpriteEffectUIImageHelper()
    { }

    private Vector2 GetNormalizedAtlasUV(Vector2 uv)
    {
        if (image != null && image.sprite != null)
        {
            Vector4 _Rect;
            if (image.sprite != null)
            {
                _Rect = new Vector4(image.sprite.textureRect.min.x / image.sprite.texture.width,
                                            image.sprite.textureRect.min.y / image.sprite.texture.height,
                                            image.sprite.textureRect.max.x / image.sprite.texture.width,
                                            image.sprite.textureRect.max.y / image.sprite.texture.height);
            }
            else _Rect = new Vector4(0, 0, 1, 1);

            uv.x = (uv.x - _Rect.x) / (_Rect.z - _Rect.x);
            uv.y = (uv.y - _Rect.y) / (_Rect.w - _Rect.y);

            //스프라이트 원본텍스쳐의 종횡비에 맞춰서 제작한 마스크의 uv가 어긋나지 않게 보정
            float pivotX = 0.5f - (image.sprite.pivot.x - image.sprite.textureRectOffset.x) / image.sprite.rect.width;
            float pivotY = 0.5f - (image.sprite.pivot.y - image.sprite.textureRectOffset.y) / image.sprite.rect.height;
            uv.x = uv.x * (image.sprite.textureRect.width / image.sprite.rect.width) + pivotX;
            uv.y = uv.y * (image.sprite.textureRect.height / image.sprite.rect.height) + pivotY;
        }
        return uv;
    }

    // ART_SpriteEffect 가 없이 메테리얼과 헬퍼만 셋팅한 경우에도 Rect 셋팅을 가능하게(Rect가 아틀라스에 새 스프라이트가 들어올때마다 죄다 변경되서 답이 없다)
    //private void SetRect()
    //{
    //    if (spriteEffect == null && Application.isPlaying && image != null)
    //    {
    //        Vector4 _Rect;
    //        if (image.sprite != null)
    //        {
    //            _Rect = new Vector4(image.sprite.textureRect.min.x / image.sprite.texture.width,
    //                                        image.sprite.textureRect.min.y / image.sprite.texture.height,
    //                                        image.sprite.textureRect.max.x / image.sprite.texture.width,
    //                                        image.sprite.textureRect.max.y / image.sprite.texture.height);
    //        }
    //        else _Rect = new Vector4(0, 0, 1, 1);
    //
    //        image.material.SetVector(rectPropertyID, _Rect);
    //        //Debug.LogWarning("Helper Set Rect : " ,this);
    //    }
    //}

    public override void ModifyMesh(VertexHelper vh)
    {
        List<UIVertex> verts = new List<UIVertex>();
        vh.GetUIVertexStream(verts);

        var orderedVerts = verts.OrderBy(v => v.position.x).ToList();
        if (orderedVerts.Count < 1)
        {
            return;  // filled 타입을 쓸 경우 orderedVerts가 존재하지 않는데 원인은 잘 모르겟음...일단 첫프레임만 넘기면 정상적으로 진행됨
        }
        var minX = orderedVerts.First().position.x;
        var maxX = orderedVerts.Last().position.x;
        orderedVerts = verts.OrderBy(v => v.position.y).ToList();
        var minY = orderedVerts.First().position.y;
        var maxY = orderedVerts.Last().position.y;

        for (int i = 0; i < verts.Count; i++)
        {
            UIVertex vertex = verts[i];
            Vector3 position = vertex.position;

            //Texcoord0.zw 마스크용 rect 적용 UV
            Vector2 normalizedUV = GetNormalizedAtlasUV(vertex.uv0);
            vertex.uv0.z = normalizedUV.x;
            vertex.uv0.w = normalizedUV.y;

            //Texcoord1.xy 이팩트용 UV
            vertex.uv1.x = Mathf.InverseLerp(minX, maxX, position.x);
            vertex.uv1.y = Mathf.InverseLerp(minY, maxY, position.y);

            //if (image != null && image.type == Image.Type.Filled)
            //{
            //    Vector2 normalizedUV = GetNormalizedAtlasUV(vertex.uv0);
            //    vertex.uv1 = normalizedUV;
            //}
            //else
            //{
            //    vertex.uv1.x = Mathf.InverseLerp(minX, maxX, position.x);
            //    vertex.uv1.y = Mathf.InverseLerp(minY, maxY, position.y);
            //}

            //Texcoord1.zx 화면비
            if ((float)(maxX - minX) / (float)(maxY - minY) >= 1)
            {
                vertex.uv1.z = 1f;
                vertex.uv1.w = (float)(maxX - minX) / (float)(maxY - minY);
            }
            else
            {
                vertex.uv1.z = 1f / ((float)(maxX - minX) / (float)(maxY - minY));
                vertex.uv1.w = 1f;
            }
            //Debug.Log(vertex.uv1);
            verts[i] = vertex;
        }

        vh.Clear();
        vh.AddUIVertexTriangleStream(verts);
        //SetRect();
    }
}