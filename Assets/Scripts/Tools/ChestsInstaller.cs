using System;
using Chests;
using UnityEngine;
using Zenject;

namespace Tools
{
    public class ChestsInstaller : MonoBehaviour
    {
        [SerializeField] private string woodenName;
        [SerializeField] private Sprite woodenClosed;
        [SerializeField] private Sprite woodenOpened;
        [SerializeField] private string steelName;
        [SerializeField] private Sprite steelClosed;
        [SerializeField] private Sprite steelOpened;
        [SerializeField] private string goldenName;
        [SerializeField] private Sprite goldenClosed;
        [SerializeField] private Sprite goldenOpened;

        private ChestManager _chestManager;

        [Inject]
        private void Construct(ChestManager manager)
        {
            _chestManager = manager;
        }

        private void Start()
        {
            _chestManager.AddNewChest(woodenName, woodenClosed, woodenOpened);
            _chestManager.AddNewChest(steelName, steelClosed, steelOpened);
            _chestManager.AddNewChest(goldenName, goldenClosed, goldenOpened);
        }
    }
}
