using System;
using Chests;
using Rewards;
using Timer;
using UI;
using UnityEngine;

namespace Core
{
    public sealed class ChestController :IDisposable
    {
        private readonly ChestConfig _chestConfig;
        private readonly ChestView _chestView;
        private readonly RewardGiver _rewardGiver;
        private readonly CustomTimer _customTimer;

        public ChestController(ChestView chestView, ChestConfig chestConfig, RewardGiver rewardGiver, CustomTimer customTimer)
        {
            _chestView = chestView;
            _chestConfig = chestConfig;
            _chestView.AddOpenButtonListener(GetReward);
            _chestView.ActiveChest(false);
            _rewardGiver = rewardGiver;
            _customTimer = customTimer;
            _customTimer.OnTimeChanged += ChangedTime;
            _customTimer.OnTimerEnded += OpenChest;
        }

        public void Dispose()
        {
            _chestView.RemoveListener(GetReward);
            _customTimer.OnTimeChanged -= ChangedTime;
            _customTimer.OnTimerEnded -= OpenChest;
        }

        private void ChangedTime(float currentDuration)
        {
            _chestView.SetTimerText(GetChestTimerString(currentDuration));
        }

        private void OpenChest()
        {
            _chestView.SetTimerText("00h:00m:00s");
            _chestView.ActiveChest(true);
        }

        public float GetCurrentDuration()
        {
            return _customTimer.GetCurrentDuration();
        }

        public ChestConfig GetChest()
        {
            return _chestConfig;
        }

        private string GetChestTimerString(float currentDuration)
        {
            var minutes = Mathf.FloorToInt(currentDuration / 60);
            var hours = Mathf.FloorToInt(minutes / 60f);
            minutes -= hours * 60; 
            var seconds = Mathf.FloorToInt(currentDuration % 60);
            
            return $"{hours:00}h:{minutes:00}m:{seconds:00}s";
        }
        
        private void GetReward()
        {
            _rewardGiver.GiveReward(_chestConfig.ChestRewardConfig);
            ResetChest();
        }

        private void ResetChest()
        {
            _customTimer.ResetTimer(_chestConfig.TimerDuration);
            _chestView.ActiveChest(false);
        }
        
    }
}
