using UnityEditor;
using UnityEngine;

namespace Exanite.Building.Editor
{
    /// <summary>
    ///     Defines all the Unity MenuItems used in this assembly
    /// </summary>
    public static class MenuItemDefines
    {
        [MenuItem("Tools/Exanite.Builds/Log Current Game Version", priority = 200)]
        private static void LogGameVersion()
        {
            var version = GameBuilder.GenerateGameVersion();

            Debug.Log($"The current version of the game is '{version}'");
        }
    }
}
