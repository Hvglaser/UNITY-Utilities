using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.SceneManagement;

namespace Muco
{
    public class ReplaceSceneListWithOpenScene : IPreprocessBuildWithReport
    {
        private const string PREF_KEY = "ReplaceSceneListWithOpenScene";

        public int callbackOrder => -10; // Run before other preprocessors

        public void OnPreprocessBuild(BuildReport report)
        {
            if (!EditorPrefs.GetBool(PREF_KEY, false))
                return;

            var activeScene = EditorSceneManager.GetActiveScene();

            if (string.IsNullOrEmpty(activeScene.path))
            {
                Debug.LogWarning("ReplaceSceneListWithOpenScene: Active scene has no path (unsaved scene). Skipping.");
                return;
            }

            EditorBuildSettingsScene[] newScenes = new EditorBuildSettingsScene[]
            {
                new EditorBuildSettingsScene(activeScene.path, true)
            };

            EditorBuildSettings.scenes = newScenes;

            Debug.Log($"ReplaceSceneListWithOpenScene: Build scene list replaced with: {activeScene.name}");
        }
    }
}
