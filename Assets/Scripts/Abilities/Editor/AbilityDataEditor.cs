using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AbilityData))]
public class AbilityDataEditor : Editor
{
    private SerializedProperty abilityNameProp;
    private SerializedProperty iconProp;
    private SerializedProperty cooldownProp;
    private SerializedProperty costProp;
    private SerializedProperty effectsProp;

    private void OnEnable()
    {
        abilityNameProp = serializedObject.FindProperty("abilityName");
        iconProp = serializedObject.FindProperty("icon");
        cooldownProp = serializedObject.FindProperty("cooldown");
        costProp = serializedObject.FindProperty("cost");
        effectsProp = serializedObject.FindProperty("effects");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawAbilityHeader();
        DrawCoreFields();
        DrawEffects();
        DrawWarnings();

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawAbilityHeader()
    {
        EditorGUILayout.LabelField("Ability", EditorStyles.boldLabel);

        Sprite icon = iconProp.objectReferenceValue as Sprite;

        if (icon != null)
        {
            Rect rect = GUILayoutUtility.GetRect(64, 64);
            EditorGUI.DrawTextureTransparent(
                rect,
                icon.texture,
                ScaleMode.ScaleToFit
            );
        }

        EditorGUILayout.PropertyField(abilityNameProp);
        EditorGUILayout.Space();
    }

    private void DrawCoreFields()
    {
        EditorGUILayout.PropertyField(iconProp);
        EditorGUILayout.PropertyField(cooldownProp);
        EditorGUILayout.PropertyField(costProp);
        EditorGUILayout.Space();
    }

    private void DrawEffects()
    {
        EditorGUILayout.PropertyField(effectsProp, new GUIContent("Effects"), true);
        EditorGUILayout.Space();
    }

    private void DrawWarnings()
    {
        if (effectsProp.arraySize == 0)
        {
            EditorGUILayout.HelpBox(
                "Ability has no effects and will do nothing.",
                MessageType.Error
            );
        }
    }
}