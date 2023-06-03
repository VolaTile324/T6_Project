using Hex.TopDownGame;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialogText))]
[CanEditMultipleObjects]

public class DialogueTextEditor : Editor
{
    SerializedProperty text;
    SerializedProperty isPlayer;
    SerializedProperty isQuestion;
    SerializedProperty answers;
    SerializedProperty canSkipIndex;
    SerializedProperty nextIndex;

    void OnEnable()
    {
        text = serializedObject.FindProperty("text");
        isPlayer = serializedObject.FindProperty("isPlayer");
        isQuestion = serializedObject.FindProperty("isQuestion");
        answers = serializedObject.FindProperty("answers");
        canSkipIndex = serializedObject.FindProperty("canSkipIndex");
        nextIndex = serializedObject.FindProperty("nextIndex");
    }

    public override void OnInspectorGUI()
    {
        var dialogText = (DialogText)target;
        serializedObject.Update();
        EditorGUILayout.PropertyField(text);
        EditorGUILayout.PropertyField(isPlayer);
        EditorGUILayout.PropertyField(isQuestion);
        if (dialogText.isQuestion)
        {
            EditorGUILayout.PropertyField(answers, true);
        }
        EditorGUILayout.PropertyField(canSkipIndex);
        if (dialogText.canSkipIndex)
        {
            EditorGUILayout.PropertyField (nextIndex, true);
        }
        serializedObject.ApplyModifiedProperties();
    }
}
