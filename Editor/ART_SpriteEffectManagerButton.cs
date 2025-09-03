using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(ART_SpriteEffectManager)), CanEditMultipleObjects]
public class ART_SpriteEffectManagerButton : Editor
{
    private Color deleteButtonColor = new Color(0.3f, 0.0f, 0.0f);
    private Color playButtonColor = new Color(0.0f, 0.3f, 0.0f);
    private bool confirmDelete = false;  //인스팩터창이 하나 이상일 경우 버튼의 마우스위치 판정 문제처리용
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        var defaultColor = GUI.backgroundColor;
        base.OnInspectorGUI();

        ART_SpriteEffectManager looper = (ART_SpriteEffectManager)target;
        looper.ApplyNameField();

        const int buttonWidth = 100;
        int numberOfButtonsPerRaw = (int)MathF.Max(1, ((int)EditorGUIUtility.currentViewWidth - 30) / buttonWidth);
        float buttonFlexibleWidth = (EditorGUIUtility.currentViewWidth - 30f) / numberOfButtonsPerRaw;

        GUI.backgroundColor = playButtonColor;
        EditorGUILayout.BeginHorizontal();
        for (int i = 0; i < looper.spriteEffects.Count; i++)
        {
            if (i % numberOfButtonsPerRaw == 0)
            {
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
            }
            if (looper.spriteEffects[i].effect == null)
            {
                looper.spriteEffects[i].effect = looper.gameObject.AddComponent(typeof(ART_SpriteEffect)) as ART_SpriteEffect;
            }
            if (looper.spriteEffects[i].effect.enabled)
            {
                GUI.backgroundColor = Color.green;
            }
            else
            {
                GUI.backgroundColor = playButtonColor;
            }
            if (GUILayout.Button($"Play {looper.spriteEffects[i].name}", GUILayout.Width(buttonFlexibleWidth)))
            {
                looper.ActiveEffect(i);
            }
        }
        EditorGUILayout.EndHorizontal();
        GUI.backgroundColor = defaultColor;
        if (!Application.isPlaying)
        {
            GUILayout.Space(20);
            if (GUILayout.Button($"Create Effect"))
            {
                looper.CreateEffect();
            }

            GUILayout.Space(20);

            GUI.backgroundColor = deleteButtonColor;
            EditorGUILayout.BeginHorizontal();

            for (int i = 0; i < looper.spriteEffects.Count; i++)
            {
                if (i % numberOfButtonsPerRaw == 0)
                {
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                }
                if (looper.spriteEffects[i].confirmDelete && confirmDelete == true)
                {
                    GUI.backgroundColor = Color.red;
                    if (GUILayout.Button($"Really?", GUILayout.Width(buttonFlexibleWidth)))
                    {
                        looper.RemoveEffect(i);
                        confirmDelete = false;
                    }
                    if (Event.current.type == EventType.Repaint)
                    {
                        var rect = GUILayoutUtility.GetLastRect();
                        var pos = Event.current.mousePosition;
                        if (!rect.Contains(pos))
                        {
                            confirmDelete = false;
                            looper.spriteEffects[i].confirmDelete = false;
                        }
                        GUI.backgroundColor = deleteButtonColor;
                    }
                }
                else
                {
                    if (GUILayout.Button($"Remove {looper.spriteEffects[i].name}", GUILayout.Width(buttonFlexibleWidth)))
                    {
                        confirmDelete = true;
                        looper.spriteEffects[i].confirmDelete = true;
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        GUI.backgroundColor = defaultColor;

        serializedObject.ApplyModifiedProperties();
        looper.KillUnlistedEffect();
    }
}

