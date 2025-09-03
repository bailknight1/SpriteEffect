using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
[DisallowMultipleComponent]
public class ART_SpriteEffectManager : MonoBehaviour
{
	[System.Serializable]
	public class SpriteEffects
	{
		[HideInInspector]
		public string name;
		//[HideInInspector]
		public ART_SpriteEffect effect;
		[HideInInspector]
		public bool confirmDelete = false;

		public void Validate()
		{
			if (effect != null)
			{
				if (string.IsNullOrWhiteSpace(effect.name))
				{
					name = "No Name";
				}
				else
				{
					name = effect.name;
				}
			}
			//name = effect ? effect.name : "No Name";
		}
	}
	public List<SpriteEffects> spriteEffects = new List<SpriteEffects>();
	private int _playingIndex { get; set; } = -1;

	private const string noName = "No Name";
	private void Start()
	{
		if (_playingIndex == -1) ActiveEffect(0);
	}

	public void ActiveEffect(int index)
	{
		if (spriteEffects.Count < 1)
		{
			return;
		}
		//#if UNITY_EDITOR
		//        UnityEditorInternal.InternalEditorUtility.SetIsInspectorExpanded(spriteEffects[index].effect, false);
		//#endif

		if (_playingIndex == index) return;
		_playingIndex = index;

		for (int i = 0; i < spriteEffects.Count; i++)
		{
			var spriteEffect = spriteEffects[i];
			spriteEffect.effect.enabled = _playingIndex == i;
			if (_playingIndex == i) spriteEffect.effect.Initialize();
			//if (_playingIndex == i) spriteEffect.effect.UpdateMatFromManager();
		}
	}

#region Editor Only
#if UNITY_EDITOR
	public void ApplyNameField()
	{
		for (int i = 0; i < spriteEffects.Count; i++)
		{
			spriteEffects[i].Validate();
		}
	}
	public void CreateEffect()
	{
		var element = new SpriteEffects();
		element.effect = this.gameObject.AddComponent(typeof(ART_SpriteEffect)) as ART_SpriteEffect;
		element.effect.name = noName;
		//element.effect.ApplySetting();
		spriteEffects.Add(element);
		ActiveEffect(spriteEffects.FindIndex(x => x == element));
		PrefabUtility.RecordPrefabInstancePropertyModifications(this);
	}

	public void RemoveEffect(int index)
	{
		spriteEffects[index].effect.Cleanup();
		DestroyImmediate(spriteEffects[index].effect);
		spriteEffects.RemoveAt(index);
		if (spriteEffects.Count > 1)  //　이팩트가 두개이상 있을경우
		{
			if (_playingIndex == index)  // 삭제한 이팩트가 플레이중이였던 이팩트일 경우
			{
				if (spriteEffects.Count >= index + 1)  //인덱스 범위 안벗어나는지
				{
					if (spriteEffects[index + 1] != null)   // 다음 이팩트가 있으면 그거 플레이
					{
						ActiveEffect(index + 1);
					}
				}
				else if (spriteEffects[index - 1] != null)  // 또는 이전 이팩트가 있으면 그거 플레이
				{
					ActiveEffect(index - 1);
				}
			}
			else    // 삭제한 이팩트가 플레이중이였던 이팩트가 아닌경우
			{
				if (_playingIndex > index)   // 플레이중인 이팩트가 삭제한 이팩트보다 나중에 있을경우 플레잉인덱스 한칸 땡김
				{
					_playingIndex--;
				}
			}
		}
		else if (spriteEffects.Count == 1)   // 이팩트가 하나밖에 없으면 맨 처음껄 켬
		{
			_playingIndex = 1000;
			ActiveEffect(0);
		}
		PrefabUtility.RecordPrefabInstancePropertyModifications(this);
	}

	/// <summary>
	/// 이팩트 매니저에 등록되지않은 이팩트를 발견할경우 삭제
	/// </summary>
	public void KillUnlistedEffect()
    {
		var effectList = GetComponents<ART_SpriteEffect>();
		foreach (var effect in effectList)
		{
			bool found = false;
			for (int i = 0; i < spriteEffects.Count; i++)
		    {
		        if (spriteEffects[i].effect == effect)
		        {
					found = true;
					break;
				}
			}
			if (!found)
			{
				Debug.LogWarning("임의로 복수의 이팩트 컴포넌트를 생성하지 마세요. 이팩트 매니저를 통해서 생성하지 않을경우 자동으로 삭제됩니다.", this.gameObject);
				DestroyImmediate(effect);
			}
		}
	}
#endif
#endregion //Editor Only
}
