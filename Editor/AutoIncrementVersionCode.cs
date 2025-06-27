using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace Muco
{
    public class AutoIncrementVersionCode : IPostprocessBuildWithReport
    {
        // Defines the order of the callback (lower means earlier)
        public int callbackOrder => 0;

        public void OnPostprocessBuild(BuildReport report)
        {
            // Only increment for Android platform
            if (report.summary.platform == BuildTarget.Android)
            {
                int currentVersionCode = PlayerSettings.Android.bundleVersionCode;
                int newVersionCode = currentVersionCode + 1;

                PlayerSettings.Android.bundleVersionCode = newVersionCode;
                Debug.Log($"[AutoIncrementVersionCode] Bundle Version Code incremented to: {newVersionCode}");
            }
        }
    }
}