using Exanite.Building.Versioning.Git;
using UnityEngine;

namespace Exanite.Building.Versioning
{
    /// <summary>
    ///     Contains information about the game and its current version
    /// </summary>
    public class GameVersion : MonoBehaviour
    {
        /// <summary>
        ///     Game company name
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        ///     Game product name
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        ///     The version of the game
        ///     <para/>
        ///     Format: branch/0.0.0.0
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        ///     The branch the game is built on
        ///     <para/>
        ///     Format: branch
        /// </summary>
        public string Branch { get; private set; }

        /// <summary>
        ///     The version number of the game
        ///     <para/>
        ///     Format: 0.0.0.0
        /// </summary>
        public string Number { get; private set; }

        /// <summary>
        ///     Logs the current game version
        /// </summary>
        public void LogCurrentVersion()
        {
            Debug.Log($"The current version of the game is {Version}");
        }

        private void GetGameInfo()
        {
            GetProductInfo();
            GetVersionInfo();
        }

        private void GetProductInfo()
        {
            Company = Application.companyName;
            Product = Application.productName;
        }

        private void GetVersionInfo()
        {
            if (Application.isEditor)
            {
                try
                {
                    Version = $"{Git.Git.GetBranchName()}/{Git.Git.GenerateCommitVersion()}";
                }
                catch (GitException)
                {
                    Debug.LogError("Failed to generate build version");
                }
            }
            else
            {
                Version = Application.version;
            }

            var index = Version.LastIndexOf('/');

            Branch = Version.Substring(0, index);
            Number = Version.Substring(index + 1);
        }
    }
}
