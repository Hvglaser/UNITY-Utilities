using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System.Text.RegularExpressions;

namespace Muco
{
    public class RenameProductNameToSceneName : IPostprocessBuildWithReport
    {
        public int callbackOrder => 0;
        bool renameEnabled = true;

        public void OnPostprocessBuild(BuildReport report)
        {
            if (!renameEnabled)
                return;

            // Use the first enabled scene from the build settings
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

            Debug.Log($"Product name renamed to scene name: {sanitizedSceneName}");
        }

        private string SanitizeFilename(string filename)
        {
            string sanitizedFilename = Regex.Replace(filename, @"[\\/:*?""<>|]", "_");
            sanitizedFilename = sanitizedFilename.Trim();
            return sanitizedFilename;
        }
    }
}
