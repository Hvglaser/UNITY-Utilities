using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine.XR.Management;
using System.Linq;
using UnityEditor.XR.Management;
using UnityEditor.XR.Management.Metadata;
using System.Collections.Generic;

namespace Muco
{
    public class XRPluginReport : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;

        bool switchEnabled = true;
        
        public void OnPreprocessBuild(BuildReport report)
        {
            if (!switchEnabled)
                return;

            // Check if there's a GameObject with "Pico" or "Quest" in its name
            bool hasPico = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None).Any(obj => obj.name.Contains("Pico"));
            bool hasQuest = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None).Any(obj => obj.name.Contains("Quest"));
            string currentPlugin = "";
            
            if (hasPico && hasQuest)
            {
                currentPlugin = "Both";
            }
            else if (hasPico)
            {
                currentPlugin = "PICO";
            }
            else if (hasQuest)
            {
                currentPlugin = "Quest";
            }
            else
            {
                currentPlugin = "None";
            }
            Debug.Log("MUCO Scene Device Target: " + currentPlugin);

            // Get XR settings for Android target
            var xrSettings = XRGeneralSettingsPerBuildTarget.XRGeneralSettingsForBuildTarget(BuildTargetGroup.Android);
            if (xrSettings == null)
            {
                Debug.LogWarning("No XR settings found for Android.");
                return;
            }

            // Get the XRManagerSettings from the XRGeneralSettings
            XRManagerSettings manager = xrSettings.Manager;
            if (manager == null)
            {
                Debug.LogWarning("No XR Manager Settings assigned for Android.");
                return;
            }

            // Print the names of all enabled XR loaders (providers)
            foreach (var loader in manager.activeLoaders)
            {
                Debug.Log($"Enabled XR plugin: {loader.name}");
            }
        }
    }
}