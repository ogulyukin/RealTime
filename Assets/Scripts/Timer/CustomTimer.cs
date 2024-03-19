using System;
using UnityEngine;

namespace Timer
{
    public sealed class CustomTimer
    {
        public Action<float> OnTimeChanged;
        public Action OnTimerEnded;
        private bool _isStarted;
        private float _currentDuration;

        public CustomTimer(float currentDuration)
        {
            ResetTimer(currentDuration);
        }

        public void FixedTick()
        {
            if(!_isStarted)
                return;
            if (_currentDuration > 0)
            {
                _currentDuration -= Time.fixedDeltaTime;
               OnTimeChanged?.Invoke(_currentDuration);
            }
            else
            {
                OnTimerEnded?.Invoke();
                _isStarted = false;
            }
        }
        
        public float GetCurrentDuration()
        {
            return _currentDuration;
        }
        
        public void ResetTimer(float duration)
        {
            _currentDuration = duration;
            _isStarted = true;
        }
    }
}
