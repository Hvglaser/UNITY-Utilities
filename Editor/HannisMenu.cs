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

    private const string PREF_KEY_XR_PLUGIN_REPORT = "XRPluginReport";
    private bool toggle_XRPluginReport;

    private const string PREF_KEY_REPLACE_SCENE_LIST = "ReplaceSceneListWithOpenScene";
    private bool toggle_ReplaceSceneListWithOpenScene;

    [MenuItem("Window/HannisMenu")]
    public static void ShowWindow()
    {
        GetWindow<HannisMenu>("Hannis Menu");
    }
    private void OnGUI()
    {
        EditorGUI.BeginChangeCheck();
        toggle_AutoIncrimentVersionCodeOnBuild = GUILayout.Toggle(toggle_AutoIncrimentVersionCodeOnBuild,"Auto Incriment Version Code On Build","Button",GUILayout.ExpandWidth(true));
        toggle_RenameProductNameToSceneName = GUILayout.Toggle(toggle_RenameProductNameToSceneName,"Rename Product Name to Scene Name","Button",GUILayout.ExpandWidth(true));
        toggle_XRPluginReport = GUILayout.Toggle(toggle_XRPluginReport,"XR Plugin Build Log Reminder","Button",GUILayout.ExpandWidth(true));
        toggle_ReplaceSceneListWithOpenScene = GUILayout.Toggle(toggle_ReplaceSceneListWithOpenScene,"Replace Scene List with Open Scene","Button",GUILayout.ExpandWidth(true));
        if (EditorGUI.EndChangeCheck())
        {
            // Save the new value to EditorPrefs
            EditorPrefs.SetBool(PREF_KEY, toggle_AutoIncrimentVersionCodeOnBuild);
            EditorPrefs.SetBool(PREF_KEY_RENAME_SCENE,toggle_RenameProductNameToSceneName);
            EditorPrefs.SetBool(PREF_KEY_XR_PLUGIN_REPORT,toggle_XRPluginReport);
            EditorPrefs.SetBool(PREF_KEY_REPLACE_SCENE_LIST,toggle_ReplaceSceneListWithOpenScene);
        }
    }

    void OnEnable()
    {
        toggle_AutoIncrimentVersionCodeOnBuild = EditorPrefs.GetBool(PREF_KEY, false);
        toggle_RenameProductNameToSceneName = EditorPrefs.GetBool(PREF_KEY_RENAME_SCENE, false);
        toggle_XRPluginReport = EditorPrefs.GetBool(PREF_KEY_XR_PLUGIN_REPORT, false);
        toggle_ReplaceSceneListWithOpenScene = EditorPrefs.GetBool(PREF_KEY_REPLACE_SCENE_LIST, false);
    }
}

