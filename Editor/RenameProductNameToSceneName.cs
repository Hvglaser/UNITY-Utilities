using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System.Text.RegularExpressions;

namespace Muco
{
    public class RenameProductNameToSceneName : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;
        bool renameEnabled = true;

        public void OnPreprocessBuild(BuildReport report)
        {
            if (!renameEnabled)
                return;

            // Find the first enabled scene in Build Settings
            string firstScenePath = null;

            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                if (scene.enabled)
                {
                    firstScenePath = scene.path;
                    break;
                }
            }

            if (string.IsNullOrEmpty(firstScenePath))
            {
                Debug.LogError("No enabled scenes found in Build Settings.");
                return;
            }

            string sceneName = System.IO.Path.GetFileNameWithoutExtension(firstScenePath);
            string sanitizedSceneName = SanitizeFilename(sceneName);
            PlayerSettings.productName = sanitizedSceneName;

            Debug.Log($"Product name set to scene name: {sanitizedSceneName}");
        }

        private string SanitizeFilename(string filename)
        {
            string sanitizedFilename = Regex.Replace(filename, @"[\\/:*?""<>|]", "_");
            sanitizedFilename = sanitizedFilename.Trim();
            return sanitizedFilename;
        }
    }
}
