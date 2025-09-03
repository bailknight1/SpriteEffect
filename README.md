# Sprite Effect For UI Image & Sprite Renderer <!-- omit in toc -->

This package can create various texture based VFX material for UI Image & Sprite renderer.


<br><br>

## 📌 Key Features

* UI Image 또는 Sprite Renderer용의 다양한 텍스쳐 기반 이팩트 제작툴
* UV 스크롤, 스케일, 회전 기능, 마스킹, 디스토션, 색상변경, 디졸브, 플립북 등의 기능을 복합적으로 사용하는 이팩트 메테리얼을 최대 6 레이어까지 한번에 제작가능
* 아틀라스화된 스프라이트 대응.
* 마스킹된 스프라이트 대응.
* 슬라이스되거나 타일링되는 스프라이트 대응.
* 매니저 스크립트로 생성,삭제,여러 이팩트간 교채를 관리 가능.
* Time 또는 AnimationCurve로 대부분의 값을 애니메이션 가능.

<br><br>
## ⚙ Installation

_This package requires **Unity 2018.3 or later**._

#### Install via UPM (with Package Manager UI)

- Click `Window > Package Manager` to open Package Manager UI.
- Click `+ > Add package from git URL...` and input the repository URL: `https://github.com/bailknight/SpriteEffect.git`  
- To update the package, change suffix `#{version}` to the target version.
  - e.g. `https://github.com/bailknight/SpriteEffect.git#4.9.0`

<br><br>
## 🚀 Usage

### Component: ART_SpriteEffectManager

`ART_SpriteEffectManager` can create or delete SpriteEffect to UIImage or SpriteRenderer.
- **Create Effect**: 신규 스프라이트 이팩트를 생성. 한 스프라이트렌더러(또는 UI이미지)에 복수의 이팩트를 생성 가능. 한번에 한개의 이팩트만 적용할수 있음.
- **Play "Effect Name"**: 해당 명칭의 이팩트로 렌더러 메테리얼을 교체
- **Remove "Effect Name"**: 해당 명칭의 이팩트를 삭제.

`ART_SpriteEffect` can create SpriteEffect Material for UIImage or SpriteRenderer.
- **메인 속성**: 메테리얼의 속성
  - **Name:** 이팩트 메테리얼의 이름. 저장될때 SpriteEffect_"Name" 형식으로 Assets/Resources/SpriteEffectMaterial 폴더에 저장됨.
  - **Material:** 마지막으로 저장하고 현재 편집중인 이팩트 메테리얼. 아직 한번도 저장하지 않았을경우 빈칸.
  - **Save Material:** 이팩트 메테리얼을 Assets/Resources/SpriteEffectMaterial 폴더에 저장 (폴더가 없을경우 자동으로 생성됨). 저장안한 변경사항이 있을경우 붉은색.
    - **Load Material:** Alt 버튼 입력시 메테리얼 로드 모드로 동작. Material 항목에 있는 메테리얼 값을 에디터로 불러옴.
    - **Copy Material:** Ctrl  버튼 입력시 메테리얼 복사 모드로 동작. 현재 에디터의 값을 Name으로 지정된 메테리얼로 복사.
  - **Focus Folder:** 이팩트 메테리얼 저장 폴더를 프로젝트에서 포커스.
  - **Set Sprite Transparent**: 렌더러에 지정된 스프라이트를 투명하게 만듬. 이렇게 할경우 렌더러 스프라이트는 이팩트메테리얼의 투명도 마스크처럼 동작.
  - **Use Unscaled Time:** TimeScale을 무시하고 픽스된 타임스케일로 쉐이더가 애니메이션됨. (런타임에서는 반드시 쉐이더에 글로벌 쉐이더 프로퍼티 "_ShaderUnscaledTime" 을 전달해줘야 동작)
  - **Luminance Mask Threshold:** 이팩트들중에 Luminanace Mask를 요청하는 이팩트가 있으면 활성화. 스프라이트의 그레이스케일 명암을 마스크용도로 사용가능.
- **Show Sprite Options**: 스프라이트의 속성
  - **Sprite GrayScale:** 
    - **0~1 Slider** 
    - **Anim:** 
  - **Sprite Brightness:** 
    - **0~10 Slider** 
    - **Anim:** 
    - **Luminance Mask:** 
  - **Sprite Tint Color:** 
    - **Color Picker** 
    - **Anim:** 
    - **Luminance Mask:** 
  - **Sprite Cutout:** 
    - **Texturer** 
    - **Tile & Offset**
    - **Smoothness / Contrast / Min / Max**
    - **Edge Color / Edge Brightness**
    - **Fill Color / Fill Brightness**
    - **Slice UV**
    - **Uniform UV**
    - **Do not use Alpha Val**
    - **"_BaseCutOutProgress**
    - **Anim:**
  - **Sprite Vertex Animation**
    - **X Y Z W**

- **Add Effect "number":** 신규 이팩트 레이어를 추가 (최대 6까지)
  - **Texture:** Change the bake view size.
  - **Tile & Offset:**
  - **Use FlipBook UV:**
    - **x/y/z/w:**
    - **Use Curve:**
    - **FlipBook Blending:**
  - **Use _SpriteEffectMask:**
    - **x/y/z/w:**
  - **Mask:**
    - **Slice UV:**
    - **Luminance Mask:**
    - **Use Timer Mask(b):**
  - **Color:**
  - **Brightness:**
  - **GlowSpeed:**
  - **Scale:**
  - **Scale Anim Multiplier:**
  - **Scale Speed:**
    - **PingPong Scale:**
    - **Random Rotation:**
  - **Power:**
  - **Rotate Angle:**
  - **Rotate Speed:**
  - **Vertical Speed:**
  - **Horizontal Speed:**
  - **Timing Offset:**
  - **Use Alpha:**
  - **Blend Mode:**
    - **Additive:**
    - **AlphaBlend:**
    - **Mask:**
  - **Unstretch UV:**
  - **Directional Scroll:**
  - **Mask Distort Strength:**
  - **Scroll:**
  - **Rotate:**
  - **Scale:**
  - **Color:**
  - **Reset Effect "Layer number":**

<br><br>
