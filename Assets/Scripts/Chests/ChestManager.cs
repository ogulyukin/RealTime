using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UI;
using UnityEngine;
using Zenject;

namespace Chests
{
    [UsedImplicitly]
    public class ChestManager: IInitializable, IDisposable, IFixedTickable
    {
        private readonly ChestPanelView _chestPanelView;
        private readonly List<ChestView> _chestViews = new();


        public ChestManager(ChestPanelView chestPanelView)
        {
            _chestPanelView = chestPanelView;
        }

        public void AddNewChest(string chestName, Sprite closed, Sprite opened)
        {
            var newChest = _chestPanelView.AddNewChest(closed, opened);
            newChest.SetChestName(chestName);
            _chestViews.Add(newChest);
        }
        

        public void Initialize()
        {
            
        }

        public void Dispose()
        {
            
        }

        public void FixedTick()
        {
            for (var i = 0; i < _chestViews.Count; i++)
            {
                _chestViews[i].SetTimerText($"0:00:00");
            }
        }

    }
}
