using System;
using System.Collections.Generic;
using Core;
using JetBrains.Annotations;
using Rewards;
using Timer;
using UI;

namespace Chests
{
    [UsedImplicitly]
    public sealed class ChestManager: IDisposable
    {
        private readonly ChestPanelView _chestPanelView;
        private readonly List<ChestController> _chestControllers = new();
        private readonly RewardGiver _rewardGiver;
        private readonly TimersManager _timersManager;

        public ChestManager(ChestPanelView chestPanelView, RewardGiver rewardGiver, TimersManager timersManager)
        {
            _chestPanelView = chestPanelView;
            _rewardGiver = rewardGiver;
            _timersManager = timersManager;
        }

        public void AddNewChest(ChestConfig chestConfig, float duration)
        {
            var chestView = _chestPanelView.AddNewChest(chestConfig.ClosedSprite, chestConfig.OpenedSprite);
            chestView.SetChestName(chestConfig.ChestName);
            var chestController = new ChestController(chestView, chestConfig, _rewardGiver, _timersManager.AddNewTimer(duration));
            _chestControllers.Add(chestController);
        }

        public List<ChestController> GetAllChests()
        {
            return _chestControllers;
        }

        void IDisposable.Dispose()
        {
            foreach (var chestController in _chestControllers)
            {
                chestController.Dispose();
            }
        }
    }
}
