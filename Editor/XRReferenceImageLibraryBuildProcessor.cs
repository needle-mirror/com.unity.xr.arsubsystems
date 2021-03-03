using System;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace UnityEditor.XR.ARSubsystems
{
    class XRReferenceImageLibraryBuildProcessor : IPreprocessBuildWithReport, IPostprocessBuildWithReport
    {
        public int callbackOrder => -1000;

        static void ClearDataStore()
        {
            foreach (var library in XRReferenceImageLibrary.All())
            {
                library.ClearDataStore();
            }
        }

        public void OnPostprocessBuild(BuildReport report) => ClearDataStore();

        // Clear all native data and let each provider decide whether to populate it or not.
        public void OnPreprocessBuild(BuildReport report) => ClearDataStore();
    }
}
