using System.Collections.Generic;
using Chests;
using UnityEngine;
using Zenject;

namespace Tools
{
    public sealed class ChestsInstaller : MonoBehaviour
    {
        [SerializeField] private List<ChestConfig> chests;

        public bool isGameLoaded;
        
        private ChestManager _chestManager;

        [Inject]
        private void Construct(ChestManager manager)
        {
            _chestManager = manager;
        }

        private void Start()
        {
            if (!isGameLoaded)
            {
                foreach (var chest in chests)
                {
                    _chestManager.AddNewChest(chest, chest.TimerDuration);
                }    
            }
        }
    }
}
