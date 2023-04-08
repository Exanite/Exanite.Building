using System;
using System.Collections;
using System.IO;
using Exanite.Building.Versioning;
using Exanite.Building.Versioning.Internal;
using UnityEditor;
using UnityEngine;
#if EXANITE_GENERATE_VERSION_FILE
using UnityEditor.Callbacks;
#endif

namespace Exanite.Building.Editor
{
    public static class GenerateVersionFile
    {
#if EXANITE_GENERATE_VERSION_FILE
        [PostProcessBuild]
#endif
        public static void Generate(BuildTarget target, string pathToBuiltProject)
        {
            foreach (DictionaryEntry environmentVariable in Environment.GetEnvironmentVariables())
            {
                Debug.Log($"{environmentVariable.Key}={environmentVariable.Value}");
            }
            var isGithubActions = Environment.GetEnvironmentVariable("GITHUB_ACTIONS")?.ToLower() == "true";
            if (isGithubActions)
            {
                Debug.Log("Adding all directories as safe directories for Git");

                Git.Run("config --global --add safe.directory '*'");
            }

            Git.Run("config --global --add safe.directory '*'");

            var buildDirectoryPath = Path.GetDirectoryName(pathToBuiltProject);
            var versionFilePath = Path.Combine(buildDirectoryPath, "VERSION");

            File.WriteAllText(versionFilePath, GameVersion.Generate().ToString());
        }
    }
}
