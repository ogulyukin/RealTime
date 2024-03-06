using System;
using System.Collections.Generic;
using Core;
using JetBrains.Annotations;
using Rewards;
using UI;
using Zenject;

namespace Chests
{
    [UsedImplicitly]
    public sealed class ChestManager: IDisposable, IFixedTickable
    {
        private readonly ChestPanelView _chestPanelView;
        private readonly List<ChestTimer> _chestTimers = new();
        private readonly RewardGiver _rewardGiver;


        public ChestManager(ChestPanelView chestPanelView, RewardGiver rewardGiver)
        {
            _chestPanelView = chestPanelView;
            _rewardGiver = rewardGiver;
        }

        public void AddNewChest(Chest chest, float currentDuration)
        {
            var chestView = _chestPanelView.AddNewChest(chest.ClosedSprite, chest.OpenedSprite);
            chestView.SetChestName(chest.ChestName);
            var chestTimer = new ChestTimer(chestView, chest, currentDuration);
            chestTimer.OnGetReward += GetReward;
            _chestTimers.Add(chestTimer);
        }

        public List<ChestTimer> GetAllChests()
        {
            return _chestTimers;
        }

        public void Dispose()
        {
            foreach (var chestTimer in _chestTimers)
            {
                chestTimer.OnGetReward -= GetReward;
            }
        }

        public void FixedTick()
        {
            for (var i = 0; i < _chestTimers.Count; i++)
            {
                _chestTimers[i].FixedTick();
            }
        }

        private void GetReward(IReward reward)
        {
            _rewardGiver.GiveReward(reward);
        }
    }
}
