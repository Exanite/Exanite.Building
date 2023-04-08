using Exanite.Building.Versioning.Internal;
using UnityEngine;

namespace Exanite.Building.Versioning
{
    /// <summary>
    ///     Contains information about the game and its current version
    /// </summary>
    public struct GameVersion
    {
        /// <summary>
        ///     The default version.
        ///     <para/>
        ///     Note: This is also used when the Git commit version generation
        ///     fails (Git was not found in Path).
        /// </summary>
        public static GameVersion DefaultVersion => new("branch", "0.0.0.0");

        public GameVersion(string branch, string commitVersion)
        {
            Branch = branch;
            CommitVersion = commitVersion;
        }

        public string Branch { get; }
        public string CommitVersion { get; }

        public override string ToString()
        {
            return $"{Branch}/{CommitVersion}";
        }

        public static GameVersion Generate()
        {
            try
            {
                return new GameVersion(Git.GetBranchName(), Git.GenerateCommitVersion());
            }
            catch (GitException e)
            {
                Debug.LogError($"Failed to generate build version\n{e}");

                return DefaultVersion;
            }
        }
    }
}
