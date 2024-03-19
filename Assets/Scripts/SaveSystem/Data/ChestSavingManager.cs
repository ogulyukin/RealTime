using System;
using System.Collections.Generic;
using System.Globalization;
using Chests;
using JetBrains.Annotations;
using SaveSystem.Core;
using UnityEngine;

namespace SaveSystem.Data
{
    [UsedImplicitly]
    public sealed class ChestSavingManager : ISaveAble
    {
        private readonly ChestManager _chestManager;

        public ChestSavingManager(ChestManager chestManager)
        {
            _chestManager = chestManager;
        }

        public List<Dictionary<string, string>> CaptureState()
        {
            var chestTimers = _chestManager.GetAllChests();
            var capturedChests = new List<Dictionary<string, string>>();
            foreach (var timer in chestTimers)
            {
                var data = new Dictionary<string, string>()
                {
                    {"SaveAbleType", "Chest"},
                    {"id", timer.GetChest().ItemID},
                    {"currentDuration", timer.GetCurrentDuration().ToString(CultureInfo.InvariantCulture)},
                    {"currentTime", DateTime.Now.ToString(CultureInfo.InvariantCulture)}
                };
                capturedChests.Add(data);
            }

            return capturedChests;
        }

        public void RestoreState(List<Dictionary<string, string>> loadedData)
        {
            Debug.Log("Restoring Chests");
            foreach (var data in loadedData)
            {
                if (data["SaveAbleType"] == "Chest")
                {
                    var storedDuration = float.Parse(data["currentDuration"], CultureInfo.InvariantCulture);
                    var storedTime = DateTime.Parse(data["currentTime"], CultureInfo.InvariantCulture);
                    var now = DateTime.Now;
                    var passedTime = (float)(now - storedTime).TotalSeconds;
                    _chestManager.AddNewChest(GetChestById(data["id"]), storedDuration - passedTime);
                }
            }
        }

        private ChestConfig GetChestById(string chestId)
        {
            var chests = Resources.LoadAll<ChestConfig>("");
            foreach (var chest in chests)
            {
                if (chest.ItemID == chestId)
                {
                    return chest;
                }
            }

            throw new Exception($"No chest found with id {chestId}");
        }
    }
}
