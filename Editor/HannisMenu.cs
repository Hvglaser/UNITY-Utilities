using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class HannisMenu : EditorWindow
{

    private const string PREF_KEY = "AutoIncrimentVersionCodeOnBuild";
    private bool toggle_AutoIncrimentVersionCodeOnBuild;

    private const string PREF_KEY_RENAME_SCENE = "RenameProductNameToSceneName";
    private bool toggle_RenameProductNameToSceneName;

    [MenuItem("Tools/HannisMenu")]
    public static void ShowWindow()
    {
        GetWindow<HannisMenu>("Hannis Menu");
    }
    private void OnGUI()
    {
        EditorGUI.BeginChangeCheck();
        toggle_AutoIncrimentVersionCodeOnBuild = GUILayout.Toggle(toggle_AutoIncrimentVersionCodeOnBuild,"Auto Incriment Version Code On Build","Button",GUILayout.ExpandWidth(true));
        toggle_RenameProductNameToSceneName = GUILayout.Toggle(toggle_RenameProductNameToSceneName,"Rename Product Name to Scene Name","Button",GUILayout.ExpandWidth(true));
        if (EditorGUI.EndChangeCheck())
        {
            // Save the new value to EditorPrefs
            EditorPrefs.SetBool(PREF_KEY, toggle_AutoIncrimentVersionCodeOnBuild);
            EditorPrefs.SetBool(PREF_KEY_RENAME_SCENE,toggle_RenameProductNameToSceneName);
        }
    }

    void OnEnable()
    {
        toggle_AutoIncrimentVersionCodeOnBuild = EditorPrefs.GetBool(PREF_KEY, false);
        toggle_RenameProductNameToSceneName = EditorPrefs.GetBool(PREF_KEY_RENAME_SCENE, false);
    }
}

