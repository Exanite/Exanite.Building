using System.IO;
using Exanite.Building.Versioning;
using UnityEditor;
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
            var buildDirectoryPath = Path.GetDirectoryName(pathToBuiltProject);
            var versionFilePath = Path.Combine(buildDirectoryPath, "VERSION");

            File.WriteAllText(versionFilePath, GameVersion.Generate().ToString());
        }
    }
}
