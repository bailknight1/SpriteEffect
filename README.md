# (Unity Package) Sprite Effect For UI Image & Sprite Renderer <!-- omit in toc -->

This package can create various texture based VFX material for UI Image & Sprite renderer for Unity.
![Image](https://github.com/user-attachments/assets/31dcfa96-b0ca-4199-ab20-b1d31db91120)
<br>
<img width="416" height="1034" alt="Image" src="https://github.com/user-attachments/assets/2b46da41-5142-477f-8771-014291dd2365" />

<br><br>

## 📌 Key Features

* A versatile texture-based effect creation tool for UI Image or Sprite Renderers.
* Create up to six layers of effect materials at once, combining features like UV scrolling, scaling, rotation, masking, distortion, color change, dissolving, and flipbooks.
* Supports atlased sprites.
* Supports masked sprites.
* Supports sliced ​​and tiling sprites.
* Create, delete, and manage multiple effects with a manager script.
* Animate most values ​​with Time or AnimationCurve.

<br><br>
## ⚙ Installation

_This package requires **Unity 2018.3 or later**._

#### Install via UPM (with Package Manager UI)

- Click `Window > Package Manager` to open Package Manager UI.
- Click `+ > Add package from git URL...` and input the repository URL: `https://github.com/bailknight/SpriteEffect.git`  
<br><br>

## 🚀 How to use

1. Attach the `ART_SpriteEffectManager` component to the `UIImage` or `SpriteRenderer` to which you want to add an effect.
2. Click the `Create Effect` button in the manager to create a new `ART_SpriteEffect`.
3. Set the created `ART_SpriteEffect` to the desired values ​​and click the `Save Material` button to save the material.
4. If it shows as you intended at runtime, PROFIT.
<br><br>
- **Caution** Be sure to save the material by pressing the `Save Material` button after completing the work. Unsaved changes will not be reflected in the build.
- **Caution** Be sure to include the materials starting with `SpriteEffect_` in the `Assets\Resources\SpriteEffectMaterial` folder in the build.
- **Caution** Give each sprite that requires an effect a unique name and save it as a separate material.
- **Caution** When using `UIImage`, the `ART_SpriteEffectUIImageHelper` component must be attached to work properly.
<br><br>

## 🚀 Menu explanation

### Component: ART_SpriteEffectManager

`ART_SpriteEffectManager` can create or delete SpriteEffect to UIImage or SpriteRenderer.
- **Create Effect**: Create a new sprite effect. Multiple effects can be created for a single sprite renderer (or UI image). Only one effect can be applied at a time.
- **Play "Effect Name"**: Replace the renderer's material with the effect with the given name.
- **Remove "Effect Name"**: Delete the effect with the given name.
<br><br>
- **ART_SpriteEffectManager.ActiveEffect(int index):** Replaces the renderer material with the sprite effect corresponding to the given index value.

<br><br>
### Component: ART_SpriteEffect
`ART_SpriteEffect` can create SpriteEffect Material for UIImage or SpriteRenderer.
  - **Main Properties**: Material properties.
  - **Name:** The name of the effect material. When saved, it will be saved in the `Assets/Resources/SpriteEffectMaterial` folder in the format `SpriteEffect_"Name"`.
  - **Material:** The last saved and currently editing effect material. If it hasn't been saved yet, it will be blank.
  - **Save Material:** Saves the effect material to the `Assets/Resources/SpriteEffectMaterial` folder (it will be created automatically if it doesn't exist). Unsaved changes are shown in red.
      - **Load Material:** Pressing the Alt key activates material load mode. Loads the material values ​​in the Material section into the editor.
      - **Copy Material:** Pressing the Ctrl key activates material copy mode. Copies the current editor values ​​to the material specified by `Name`.
  - **Focus Folder:** Focuses the effect material storage folder in the project.
  - **Set Sprite Transparent**: Makes the sprite assigned to the renderer transparent. This makes the renderer sprite act as a transparency mask for the effect material.
  - **Use Unscaled Time:** Shaders are animated at a fixed timescale, ignoring unity timescale. (At runtime, the shader must be passed the global shader property `_ShaderUnscaledTime` for this to work.)
  - **Luminance Mask Threshold:** If any of other effects request a Luminance Mask, enable this. This allows you to use the sprite's grayscale shading as a mask.
<br><br>
- **Show Sprite Options**: Expands the sprite's option folder.
  - **Sprite GrayScale:** Converts the sprite color to black and white.
    - **0~1 Slider** full color(0) to Black and white(1).
    - **Anim:** Adjusts the black and white level over time using an animation curve.
  - **Sprite Brightness:** Adjusts the brightness of the sprite.
    - **0~10 Slider** Black(0) to very bright(10) (default brightness 1).
    - **Anim:** Adjusts the brightness level over time using an animation curve.
  - **Luminance Mask:** Masks the area to be brightened using a luminance mask.
  - **Sprite Tint Color:** Multiply color on a sprite.
    - **Color Picker** Selects the color to multiply. When using an animation curve, it operates in gradient mode.
    - **Anim:** Adjusts the color over time using an animation curve.
    - **Luminance Mask:** Masks the area to be multiplied with a luminance mask.
  - **Sprite Cutout:** Cuts off a sprite below a certain transparency level, based on the color alpha value of the sprite renderer.
    - **Texture** Cutout mask texture (R channel only).
    - **Tile & Offset** Cutout mask texture tile & offset.
    - **Smoothness / Contrast / Min / Max**
        - **X:** The softness of the cutout edge (sharp(0) to soft(1)).
        - **Y:** Controls the contrast of the cutout mask (no contrast(0) to high contrast(1 or greater), default value is 1).
        - **Z:** The minimum cutout value of the cutout mask (e.g., if set to 0.5, pixels will be cut out starting at cutout progress 0.5).
        - **W:** The maximum cutout value of the cutout mask (e.g., if set to 0.5, all pixels will be cut out at cutout progress 0.5).
    - **Edge Color / Edge Brightness** Color/brightness of the cutout edge. Disabled when brightness is 0.
    - **Fill Color / Fill Brightness** Color/brightness of the area other than the cutout edge. Disabled when brightness is 0.
    - **Slice UV** Uses sliced ​​or tiled sprite UVs as the UV for the cutout mask texture (cannot be used simultaneously with Uniform UV).
    - **Uniform UV** Forces the cutout mask texture UV to be square regardless of the sprite aspect ratio (cannot be used simultaneously with Slice UV).
    - **Do not use Alpha Val** Uses the `_BaseCutOutProgress` shader property as the cutout progress instead of the sprite renderer's color alpha value.
    - **"_BaseCutOutProgress** Shader property that can be used for cutout progress.
    - **Anim:** Control the `_BaseCutOutProgress` value over time with an animation curve.
  - **Sprite Vertex Animation** Sprite vertex animation. Area masking is possible with the B channel of the sprite secondary texture `_MaskMap`.
      - **X** X-axis animation intensity.
      - **Y** Y-axis animation intensity.
      - **Z** Adjusts the intensity of the animation offset based on the world position of each vertex (0 disables it).
      - **W** Vertex animation playback speed.
  - **Add Effect "number":** Add a new effect layer (up to 6)
<br><br>
- **Effect "Number"**: Effect layer properties.
  - **Remove Effect "Layer number":** Deletes the current effect layer.
  - **Texture:** Effect texture.
  - **Tile & Offset:** Effect texture tiles and offsets.
  - **Use FlipBook UV:** Flipbook animation function.
      - **X** Horizontal sprite count.
      - **Y** Vertical sprite count.
      - **Z** Sprite index.
      - **W** Flipbook playback speed.
    - **Use Curve:** Adjust the flipbook index over time with an animation curve.
    - **FlipBook Blending:** Smoothly linearly interpolates the transition between the current and next indexes.
  - **Use _SpriteEffectMask:** Use the sprite secondary texture `_SpriteEffectMask` as the effect mask.
    - **X:** If set to 1, use the R channel of the _SpriteEffectMask mask as the mask. If set to 0, disable it.
    - **Y:** If set to 1, use the G channel of the _SpriteEffectMask mask as the mask. If set to 0, disable it.
    - **Z:** If set to 1, use the B channel of the _SpriteEffectMask mask as the mask. If set to 0, disable it.
    - **W:** If set to 1, use the A channel of the _SpriteEffectMask mask as the mask. If set to 0, disable it.
  - **Mask:** Effect mask. 3-channel configuration (R: Transparency mask / G: UV distortion mask / B: Timer mask).
    - **Slice UV:** Uses sliced ​​or tiled sprite UVs as mask UVs.
    - **Luminance Mask:** Uses the Luminance Mask as a mask.
    - **Use Timer Mask(b):** Timer mask function (B channel). Can be used to make an effect appear and disappear over time.
      - **X:** The point at which the effect appears (0-1).
      - **Y:** The point at which the effect disappears (0-1).
      - **Z:** The smooth interval at which the effect appears or disappears (0-1).
      - **W:** The animation playback speed.
      - (Example: If x:0.3/y:0.7/z:0.1/w:1, the effect appears smoothly for 0.3 to 0.4 seconds, lasts for 0.6 seconds, and then disappears smoothly for 0.6 to 0.7 seconds.)
  - **Color:** The color to multiply the effect by.
  - **Brightness:** The brightness of the effect.
  - **GlowSpeed:** The speed at which the effect blinks over time. 0 disables this.
  - **Scale:** The scale of the effect.
  - **Scale Anim Multiplier:** The target scale factor for animating the effect's scale (e.g., a value of 2 will cause the scale animation to repeat between `Scale` and `Scale`*2). 0 disables this.
  - **Scale Speed:** The speed of the scale animation. The default scale method is a one-way flow loop. A value of 0 disables the scale animation.
    - **PingPong Scale:** Instead of a one-way flow loop, a ping-pong loop is used, returning to the original value when the target value is reached. (Cannot be used with `Random Rotation`.)
    - **Random Rotation:** Randomly applies the effect rotation value every loop in a one-way flow loop. (Cannot be used with `PingPong Scale`.)
  - **Power:** The contrast of the effect (default 1).
  - **Rotate Angle:** The fixed rotation angle of the effect (0-360 degrees).
  - **Rotate Speed:** The rotation speed of the effect (negative values ​​indicate counterclockwise rotation).
  - **Vertical Speed:** The vertical scroll speed of the effect (negative values ​​indicate downward scrolling).
  - **Horizontal Speed:** The horizontal scroll speed of the effect (negative values ​​indicate left scrolling).
  - **Timing Offset:** The offset of the timing used for effect animations.
  - **Use Alpha:** Use the alpha channel value of the effect texture as transparency (only works when the `AlphaBlend` blending mode is set).
  - **Blend Mode:** Determines how the current effect layer will blend with other layers.
    - **Additive:** Additive blending with the upper layer (the brighter the color, the brighter it becomes, and the closer it is to black, the more transparent it becomes).
    - **AlphaBlend:** Alpha blending with the upper layer (using the brightness value of the effect as transparency for blending. When the `Use Alpha` option is used, the alpha channel value of the effect texture is used as transparency).
    - **Mask:** Use as an effect mask for the next numbered layer (Note: Mask mode always applies as a mask only to the layer immediately following the number. If a number is skipped, it will not be applied. When in mask mode, the effect of the current layer becomes transparent).
  - **Unstretch UV:** Forces the effect texture UV to be square regardless of the sprite aspect ratio.
  - **Directional Scroll:** Applies the effect rotation angle to the effect scroll direction (e.g., if an effect is rotated 90 degrees and scrolled vertically, it will scroll in the 90 degree rotated direction instead of vertically).
  - **Mask Distort Strength:** Sets the distortion strength of the effect texture UV by the effect mask G channel (0 means no distortion).
  - **Scroll:** Control the scroll distance of the time-based effect using an animation curve.
  - **Rotate:** Control the rotation angle of the time-based effect using an animation curve.
  - **Scale:** Control the size of the time-based effect using an animation curve.
  - **Color:** Control the color of the time-based effect using an animation curve.
  - **↓ & ↑:** Move effect settings to the upper or lower effect layer. Pressing the `Ctrl` key activates the settings copy mode.
  - **Reset Effect "Layer number":** Resets the settings of the current effect layer to their default values.
  <br><br>
- **ART_SpriteEffect.SpriteChange()**: When replacing the renderer's sprite at runtime, this must be called once immediately after changing the sprite for properly operate.
<br><br>
### Component: ART_SpriteEffectUIImageHelper
`ART_SpriteEffectUIImageHelper` set necessary value for SpriteEffect work properly when use with UIImage.

<br><br>

---------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------
﻿# (유니티 패키지) UI Image & Sprite Renderer 용 스프라이트 이팩트 <!-- omit in toc -->

유니티 UI이미지 & 스프라이트 랜더러용 텍스쳐기반 이팩트 메테리얼을 제작할수 있는 패키지.
![Image](https://github.com/user-attachments/assets/31dcfa96-b0ca-4199-ab20-b1d31db91120)
<br>
<img width="416" height="1034" alt="Image" src="https://github.com/user-attachments/assets/2b46da41-5142-477f-8771-014291dd2365" />

<br><br>

## 📌 핵심기능

* UI Image 또는 Sprite Renderer용의 다양한 텍스쳐 기반 이팩트 제작툴
* UV 스크롤, 스케일, 회전 기능, 마스킹, 디스토션, 색상변경, 디졸브, 플립북 등의 기능을 복합적으로 사용하는 이팩트 메테리얼을 최대 6 레이어까지 한번에 제작가능
* 아틀라스화된 스프라이트 대응.
* 마스킹된 스프라이트 대응.
* 슬라이스되거나 타일링되는 스프라이트 대응.
* 매니저 스크립트로 생성,삭제,여러 이팩트간 교채를 관리 가능.
* Time 또는 AnimationCurve로 대부분의 값을 애니메이션 가능.

<br><br>
## ⚙ 설치방법

_**Unity 2018.3 또는 그 이상 버전**._ 지원(빌트인 & URP)

#### 유니티 패키지 매니저로 설치

- `Window > Package Manager` 를 클릭하여 패키지 매니저 열기.
- `+ > Add package from git URL...` 를 클릭하고 다음 저장소 주소 입력: `https://github.com/bailknight/SpriteEffect.git`  
<br><br>

## 🚀 사용법

1. 이팩트를 붙이고 싶은 `UIImage` 또는 `SpriteRenderer`에 `ART_SpriteEffectManager`컴포넌트 부착.
2. 매니저에서 `Create Effect` 버튼을 눌러서 신규 `ART_SpriteEffect` 생성.
3. 생성된 `ART_SpriteEffect`를 원하는 값으로 셋팅후 `Save Material` 버튼을 눌러서 메테리얼 저장.
4. 런타임에서 잘 나오면 끝.
<br><br>
- **주의** 반드시 작업 완료후 `Save Material` 버튼을 눌러서 메테리얼을 저장할것. 저장되지않은 변경값은 플레이시 반영되지 않음.
- **주의** 반드시 빌드에 `Assets\Resources\SpriteEffectMaterial` 폴더안에 있는 `SpriteEffect_`로 시작되는 메테리얼들을 포함시킬것.
- **주의** 이팩트가 필요한 스프라이트마다 유니크한 이름을 지정하여 개별 메테리얼로 저장할것.
- **주의** `UIImage`에 사용할경우 반드시 `ART_SpriteEffectUIImageHelper`컴포넌트가 함깨 붙어있어야 정상적으로 동작함.
<br><br>

## 🚀 메뉴 설명

### ART_SpriteEffectManager 컴포넌트

`ART_SpriteEffectManager` 로 UI이미지나 스프라이트 렌더러에 스프라이트 이팩트를 생성또는 삭제 가능.
  - **Create Effect**: 신규 스프라이트 이팩트를 생성. 한 스프라이트렌더러(또는 UI이미지)에 복수의 이팩트를 생성 가능. 한번에 한개의 이팩트만 적용할수 있음.
  - **Play "Effect Name"**: 해당 명칭의 이팩트로 렌더러 메테리얼을 교체
  - **Remove "Effect Name"**: 해당 명칭의 이팩트를 삭제.
<br><br>
- **ART_SpriteEffectManager.ActiveEffect(int index):** index값에 해당되는 스프라이트 이팩트로 렌더러 메테리얼을 교체.

<br><br>
### ART_SpriteEffect 컴포넌트
`ART_SpriteEffect` 로 UI이미지나 스프라이트 렌더러용 VFX메테리얼 작성 가능.
- **메인 속성**: 메테리얼의 속성.
  - **Name:** 이팩트 메테리얼의 이름. 저장될때 SpriteEffect_"Name" 형식으로 Assets/Resources/SpriteEffectMaterial 폴더에 저장됨.
  - **Material:** 마지막으로 저장하고 현재 편집중인 이팩트 메테리얼. 아직 한번도 저장하지 않았을경우 빈칸.
  - **Save Material:** 이팩트 메테리얼을 Assets/Resources/SpriteEffectMaterial 폴더에 저장 (폴더가 없을경우 자동으로 생성됨). 저장안한 변경사항이 있을경우 붉은색.
    - **Load Material:** Alt 버튼 입력시 메테리얼 로드 모드로 동작. Material 항목에 있는 메테리얼 값을 에디터로 불러옴.
    - **Copy Material:** Ctrl  버튼 입력시 메테리얼 복사 모드로 동작. 현재 에디터의 값을 Name으로 지정된 메테리얼로 복사.
  - **Focus Folder:** 이팩트 메테리얼 저장 폴더를 프로젝트에서 포커스.
  - **Set Sprite Transparent**: 렌더러에 지정된 스프라이트를 투명하게 만듬. 이렇게 할경우 렌더러 스프라이트는 이팩트메테리얼의 투명도 마스크처럼 동작.
  - **Use Unscaled Time:** TimeScale을 무시하고 픽스된 타임스케일로 쉐이더가 애니메이션됨. (런타임에서는 반드시 쉐이더에 글로벌 쉐이더 프로퍼티 "_ShaderUnscaledTime" 을 전달해줘야 동작)
  - **Luminance Mask Threshold:** 이팩트들중에 Luminanace Mask를 요청하는 이팩트가 있으면 활성화. 스프라이트의 그레이스케일 명암을 마스크용도로 사용가능.
<br><br>
- **Show Sprite Options**: 스프라이트의 속성폴더 확장.
  - **Sprite GrayScale:** 스프라이트 색상을 흑백으로.
    - **0~1 Slider**  풀컬러 0 ~ 1 흑백.
    - **Anim:**  시간별 흑백 정도를 애니메이션 커브로 조절.
  - **Sprite Brightness:** 스프라이트 밝기 조절.
    - **0~10 Slider** 검정 0 ~ 10 아주밝음(기본밝기 1).
    - **Anim:**  시간별 밝기 정도를 애니메이션 커브로 조절.
    - **Luminance Mask:** 밝게 만들 부분을 Luminanace Mask로 마스킹.
  - **Sprite Tint Color:** 스프라이트에 색 곱하기.
    - **Color Picker** 곱할 색상 선택. 애니메이션 커브 사용시엔 그라디언트로 모드로 동작.
    - **Anim:** 시간별 색상을 애니메이션 커브로 조절.
    - **Luminance Mask:** 색상을 곱할 부분을 Luminanace Mask로 마스킹.
  - **Sprite Cutout:** 스프라이트 렌더러의 컬러 알파값에 따라 스프라이트의 일정 투명도 이하를 잘라냄.
    - **Texture** 컷아웃 마스크 텍스쳐(R채널만 사용).
    - **Tile & Offset** 컷아웃 마스크 텍스쳐 타일& 오프셋.
    - **Smoothness / Contrast / Min / Max**
      - **X:** 컷아웃 경계의 부드러운 정도 (날카로움 0 ~ 1 부드러움).
      - **Y:** 컷아웃 마스크의 대비 조절 (대비없음 0 ~ 1이상 고대비, 기본값 1).
      - **Z:** 컷아웃 마스크의 최소컷아웃지점 (예: 0.5로 설정할 경우 컷아웃 진행도 0.5부터 컷아웃되는 픽셀이 생김).
      - **W:** 컷아웃 마스크의 최대컷아웃지점 (예: 0.5로 설정할 경우 컷아웃 진행도 0.5에서 모든 픽셀이 컷아웃됨).
    - **Edge Color / Edge Brightness** 컷아웃 경계 색상/밝기. 밝기가 0일경우 비활성화됨.
    - **Fill Color / Fill Brightness** 컷아웃 경계 이외의 부분의 색상/밝기. 밝기가 0일경우 비활성화됨.
    - **Slice UV** 컷아웃 마스크 텍스쳐의 UV로 sliced 또는 tiled된 스프라이트 UV를 사용(Uniform UV와 동시에 사용불가).
    - **Uniform UV** 스프라이트 종횡비에 관계없이 컷아웃 마스트 텍스쳐 UV를 정사각형으로 고정(Slice UV와 동시에 사용불가).
    - **Do not use Alpha Val** 스프라이트 렌더러의 컬러 알파값 대신 쉐이더 프로퍼티 `_BaseCutOutProgress` 프로퍼티를 컷아웃 진행도로 사용.
    - **"_BaseCutOutProgress** 컷아웃 진행도용으로 사용할수 있는 쉐이더 프로퍼티.
    - **Anim:** 시간별 `_BaseCutOutProgress` 값을 애니메이션 커브로 조절.
  - **Sprite Vertex Animation** 스프라이트 버택스 애니메이션. 스프라이트 세컨데리 텍스쳐 `_MaskMap` B채널로 적용범위 마스킹 가능.
    - **X** X축 애니메이션 강도.
    - **Y** Y축 애니메이션 강도.
    - **Z** 각 버택스의 월드포지션에 의한 애니메이션 오프셋의 강도 조절(0일경우 비활성화).
    - **W** 버택스 애니메이션 재생속도.
  - **Add Effect "number":** 신규 이팩트 레이어를 추가 (최대 6까지)
<br><br>
- **Effect "Number"**: 이팩트 레이어의 속성.
  - **Remove Effect "Layer number":** 현재 이팩트 레이어를 삭제.
  - **Texture:** 이팩트 텍스쳐.
  - **Tile & Offset:** 이팩트 텍스쳐 타일 & 오프셋.
  - **Use FlipBook UV:** 플립북 애니메이션 기능
    - **X** 가로 스프라이트 갯수.
    - **Y** 세로 스프라이트 갯수.
    - **Z** 스프라이트 인덱스.
    - **W** 플립북 재생속도.
    - **Use Curve:** 시간별 플립북 인덱스를 애니메이션 커브로 조절.
    - **FlipBook Blending:** 현재 인덱스와 다음 인덱스 전환을 부드럽게 선형보간.
  - **Use _SpriteEffectMask:** 스프라이트 세컨데리 텍스쳐 `_SpriteEffectMask`를 이팩트 마스크로 사용.
    - **X:** 1로 설정할 경우 _SpriteEffectMask 마스크의 R채널을 마스크로 사용. 0일땐 사용안함.
    - **Y:** 1로 설정할 경우 _SpriteEffectMask 마스크의 G채널을 마스크로 사용. 0일땐 사용안함.
    - **Z:** 1로 설정할 경우 _SpriteEffectMask 마스크의 B채널을 마스크로 사용. 0일땐 사용안함.
    - **W:** 1로 설정할 경우 _SpriteEffectMask 마스크의 A채널을 마스크로 사용. 0일땐 사용안함.
  - **Mask:** 이팩트 마스크. 3채널 구성(R: 투명도 마스크 / G: UV왜곡 마스크 / B: 타이머 마스크)
    - **Slice UV:** 마스크 UV로 sliced 또는 tiled된 스프라이트 UV를 사용.
    - **Luminance Mask:** Luminanace Mask를 마스크로 사용.
    - **Use Timer Mask(b):** 타이머 마스크 기능(B채널). 이팩트가 시간이 흐름에 따라 보엿다 안보엿다 하는 효과등으로 사용가능.
      - **X:** 이팩트가 나타나는 시점(0~1).
      - **Y:** 이팩트가 사라지는 시점(0~1).
      - **Z:** 이팩트가 나타나거나 사라질때 부드럽게 나타나거나 사라지는 간격(0~1). 
      - **W:** 애니메이션 재생속도.
      - (예시: x:0.3/y:0.7/z:0.1/w:1 일 경우 0.3~0.4초동안 이팩트가 부드럽게 나타나고 0.6초까지 유지된후 0.6~0.7초동안 이팩트가 부드럽게사라짐)
  - **Color:** 이팩트에 곱할 컬러.
  - **Brightness:** 이팩트의 밝기.
  - **GlowSpeed:** 시간에 따라 이팩트가 깜빡이는 속도 설정. 0일경우 비활성화.
  - **Scale:** 이팩트의 크기.
  - **Scale Anim Multiplier:** 이팩트 크기를 애니메이션할 경우 변경 목표로 하는 크기배율(예: 2로 설정할경우 크기 애니메이션이 `Scale`~`Scale`*2 사이의 범위로 반복됨). `Scale Speed`가 0일경우 비활성화.
  - **Scale Speed:** 스케일 애니메이션 속도. 기본 스케일 방식은 단방향 플로우 루프. 0일경우 스케일 애니메이션 비활성화.
    - **PingPong Scale:** 단방향 플로우 루프방식 대신 목표값에 도달하면 원래 값으로 되돌아오는 핑퐁 루프를 사용(`Random Rotation`와 동시에 사용불가).
    - **Random Rotation:** 단방향 플로우 루프에서 매 루프마다 이팩트 회전값을 랜덤하게 적용(`PingPong Scale`와 동시에 사용불가).
  - **Power:** 이팩트의 대비(기본값 1).
  - **Rotate Angle:** 이팩트 고정 회전각도(0~360도 단위).
  - **Rotate Speed:** 이팩트 회전속도(-값일경우 반시계회전).
  - **Vertical Speed:** 이팩트 수직방향 스크롤 속도(-값일때는 아래쪽).
  - **Horizontal Speed:** 이팩트 수평방향 스크롤 속도(-값일때는 왼쪽).
  - **Timing Offset:** 이팩트 애니메이션들에 사용되는 시간값의 오프셋.
  - **Use Alpha:** 이팩트 텍스쳐의 알파채널값을 투명도로 사용(`AlphaBlend` 블렌딩모드일때만 동작).
  - **Blend Mode:** 현재 이팩트 레이어를 다른 레이어와 어떻게 블랜딩할것인지 결정.
    - **Additive:** 상위 레이어에 가산블렌딩(밝은색을 겹칠수록 밝아지고 검정에 가까울수록 투명해짐).
    - **AlphaBlend:** 상위 레이어에 알파블렌딩(이펙트의 명도값을 투명도로 사용하여 블렌딩. `Use Alpha` 옵션 사용시 이팩트 텍스쳐의 알파채널값을 투명도로 사용).
    - **Mask:** 다음 숫자의 레이어에 이펙트 마스크로 사용(주의: 마스크 모드는 항상 바로 다음 숫자의 레이어에만 마스크로서 적용됨. 숫자를 건너뛰면 적용되지않음. 마스크 모드시 현 레이어의 이팩트는 투명해짐).
  - **Unstretch UV:** 스프라이트 종횡비에 관계없이 이팩트 텍스쳐 UV를 정사각형으로 고정.
  - **Directional Scroll:** 이팩트 스크롤 방향에 이팩트 회전각도를 적용(예: 90도 회전한 이팩트를 수직방향으로 스크롤할경우 수직방향이 아닌 90도 회전된 방향으로 스크롤됨).
  - **Mask Distort Strength:** 이팩트 마스크 G채널에 의한 이팩트 텍스쳐 UV의 왜곡 강도 설정(0일경우 왜곡없음).
  - **Scroll:** 시간별 이팩트 스크롤 거리를 애니메이션 커브로 제어.
  - **Rotate:** 시간별 이팩트 회전 각도를 애니메이션 커브로 제어.
  - **Scale:** 시간별 이팩트 크기를 애니메이션 커브로 제어.
  - **Color:** 시간별 이팩트 색상을 애니메이션 커브로 제어.
  - **↓ & ↑:** 상위 또는 하위 이팩트 레이어로 이팩트 설정값을 이동. `Ctrl`키 입력시 설정값 복사 모드로 동작.
  - **Reset Effect "Layer number":** 현재 이팩트 레이어의 설정값을 초기값으로 리셋.
  <br><br>
- **ART_SpriteEffect.SpriteChange()**: 런타임에서 렌더러의 스프라이트를 교채할경우 스프라이트 변경 직후 반드시 한번 호출해야 정상동작.
<br><br>
### ART_SpriteEffectUIImageHelper 컴포넌트
`ART_SpriteEffectUIImageHelper` 스프라이트 이팩트가 UI이미지에 제대로 동작하는데 필요한 도우미.

<br><br>
