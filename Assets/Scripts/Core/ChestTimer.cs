using System;
using Chests;
using Rewards;
using UI;
using UnityEngine;

namespace Core
{
    public sealed class ChestTimer
    {
        public Action<IReward> OnGetReward;


        private readonly Chest _chest;
        private float _currentDuration;
        private readonly ChestView _chestView;
        private bool _isStarted;

        public ChestTimer(ChestView chestView, Chest chest, float currentDuration)
        {
            _chestView = chestView;
            _chest = chest;
            _chestView.AddListener(GetReward);
            _currentDuration = currentDuration;
            _isStarted = true;
            _chestView.OpenChest(false);
        }

        ~ChestTimer()
        {
            _chestView.RemoveListener(GetReward);
        }

        public void FixedTick()
        {
            if(!_isStarted)
                return;
            if (_currentDuration > 0)
            {
                _currentDuration -= Time.fixedDeltaTime;
                _chestView.SetTimerText(GetChestTimerString());
            }
            else
            {
                _chestView.SetTimerText("00h:00m:00s");
                _chestView.OpenChest(true);
                _isStarted = false;
            }
        }

        public float GetCurrentDuration()
        {
            return _currentDuration;
        }

        public Chest GetChest()
        {
            return _chest;
        }

        private string GetChestTimerString()
        {
            var minutes = Mathf.FloorToInt(_currentDuration / 60);
            var hours = Mathf.FloorToInt(minutes / 60f);
            minutes -= hours * 60; 
            var seconds = Mathf.FloorToInt(_currentDuration % 60);
            
            return $"{hours:00}h:{minutes:00}m:{seconds:00}s";
        }

        private void ResetTimer()
        {
            _currentDuration = _chest.TimerDuration;
            _isStarted = true;
            _chestView.OpenChest(false);
        }

        private void GetReward()
        {
            Debug.Log("Timer Get Reward");
            OnGetReward?.Invoke(_chest.ChestReward);
            ResetTimer();
        }
    }
}
