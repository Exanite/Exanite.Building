﻿using Exanite.Building.Versioning;
using UnityEditor;
using UnityEngine;

namespace Exanite.Building.Editor
{
    /// <summary>
    ///     Defines all the Unity MenuItems used in this assembly
    /// </summary>
    public static class MenuItemDefines
    {
        [MenuItem("Tools/Exanite.Building/Log Current Game Version")]
        private static void LogGameVersion()
        {
            var version = GameVersion.Generate().ToString();

            Debug.Log($"The current version of the game is '{version}'");
        }
    }
}
