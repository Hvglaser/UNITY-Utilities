using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
    
public class MissingScriptTool : MonoBehaviour
{
    
    const string k_missingScriptsMenuFolder = "Window/Missing Scripts/";

    [MenuItem(k_missingScriptsMenuFolder + "Find")]

    static void FindMissingScriptsMenuItem()
    {
        foreach(GameObject gameObject in FindObjectsByType<GameObject>(FindObjectsSortMode.None))
        {
            foreach (Component component in gameObject.GetComponentsInChildren<Component>())
            {
                if (component == null)
                {
                    Debug.Log($"GameObject found with missing script {gameObject.name}",gameObject);
                }
            }
        }
    }

    [MenuItem(k_missingScriptsMenuFolder + "Delete")]

    static void DeleteMissingScriptsMenuItem()
    {
        foreach(GameObject gameObject in FindObjectsByType<GameObject>(FindObjectsSortMode.None))
        {
            foreach (Component component in gameObject.GetComponentsInChildren<Component>())
            {
                if (component == null)
                {
                    GameObjectUtility.RemoveMonoBehavioursWithMissingScript(gameObject);
                }
            }
        }
    }
}

#endif