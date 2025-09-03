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
		if (spriteEffects.Count > 1)  //������Ʈ�� �ΰ��̻� �������
		{
			if (_playingIndex == index)  // ������ ����Ʈ�� �÷������̿��� ����Ʈ�� ���
			{
				if (spriteEffects.Count >= index + 1)  //�ε��� ���� �ȹ������
				{
					if (spriteEffects[index + 1] != null)   // ���� ����Ʈ�� ������ �װ� �÷���
					{
						ActiveEffect(index + 1);
					}
				}
				else if (spriteEffects[index - 1] != null)  // �Ǵ� ���� ����Ʈ�� ������ �װ� �÷���
				{
					ActiveEffect(index - 1);
				}
			}
			else    // ������ ����Ʈ�� �÷������̿��� ����Ʈ�� �ƴѰ��
			{
				if (_playingIndex > index)   // �÷������� ����Ʈ�� ������ ����Ʈ���� ���߿� ������� �÷����ε��� ��ĭ ����
				{
					_playingIndex--;
				}
			}
		}
		else if (spriteEffects.Count == 1)   // ����Ʈ�� �ϳ��ۿ� ������ �� ó���� ��
		{
			_playingIndex = 1000;
			ActiveEffect(0);
		}
		PrefabUtility.RecordPrefabInstancePropertyModifications(this);
	}

	/// <summary>
	/// ����Ʈ �Ŵ����� ��ϵ������� ����Ʈ�� �߰��Ұ�� ����
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
				Debug.LogWarning("���Ƿ� ������ ����Ʈ ������Ʈ�� �������� ������. ����Ʈ �Ŵ����� ���ؼ� �������� ������� �ڵ����� �����˴ϴ�.", this.gameObject);
				DestroyImmediate(effect);
			}
		}
	}
#endif
#endregion //Editor Only
}
