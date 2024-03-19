using System.Collections.Generic;
using JetBrains.Annotations;
using Zenject;

namespace Timer
{
    [UsedImplicitly]
    public sealed class TimersManager : IFixedTickable
    {
        private readonly List<CustomTimer> _timers = new();
        public CustomTimer AddNewTimer(float duration)
        {
            var timer = new CustomTimer(duration);
            _timers.Add(timer);
            return timer;
        }

        void IFixedTickable.FixedTick()
        {
            foreach (var timer in _timers)
            {
                timer.FixedTick();
            }
        }
    }
}
