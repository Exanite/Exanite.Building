using UnityEditor;
using UnityEngine;

namespace Exanite.Arpg.Editor.Builds
{
    /// <summary>
    ///     Defines all the Unity MenuItems used in this assembly
    /// </summary>
    public static class MenuItemDefines
    {
        [MenuItem("Build/Log current build version", priority = 200)]
        private static void LogBuildVersion()
        {
            var version = GameBuilder.GenerateBuildVersion();

            Debug.Log($"The current version of the game is '{version}'");
        }
    }
}
