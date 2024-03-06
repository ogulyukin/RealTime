using System.Collections.Generic;
using JetBrains.Annotations;
using SaveSystem.Core;
using Tools;

namespace SaveSystem.Data
{
    [UsedImplicitly]
    public sealed class ChestInstallerSavingManager : ISaveAble
    {
        private readonly ChestsInstaller _chestsInstaller;

        public ChestInstallerSavingManager(ChestsInstaller chestsInstaller)
        {
            _chestsInstaller = chestsInstaller;
        }

        public List<Dictionary<string, string>> CaptureState()
        {
            var capturedChests = new List<Dictionary<string, string>>();
            var data = new Dictionary<string, string>()
            {
                {"SaveAbleType", "ChestInstaller"},
                {"IsSaved", "true"}
            };
            capturedChests.Add(data);
            return capturedChests;
        }

        public void RestoreState(List<Dictionary<string, string>> loadedData)
        {
            foreach (var data in loadedData)
            {
                if (data["SaveAbleType"] == "ChestInstaller")
                {
                    _chestsInstaller.isGameLoaded = bool.Parse(data["IsSaved"]);
                }
            }
        }
    }
}
