using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateScriptableObjects {
    [MenuItem("Assets/Create/My Scriptable Object")]
    public static QuestScriptableObject CreateMyAsset() {
        QuestScriptableObject asset = ScriptableObject.CreateInstance<QuestScriptableObject>();

        AssetDatabase.CreateAsset(asset, "Assets/NewScripableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
        return asset;
    }
}