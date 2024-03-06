using Rewards;
using UnityEngine;

namespace Chests
{
    [CreateAssetMenu(menuName = ("Rewards/Chest"))]
    public sealed class Chest : ScriptableObject, ISerializationCallbackReceiver
    {
        [Tooltip("Auto-generated UUID for saving/loading. Clear this field if you want to generate a new one.")]
        [SerializeField] string itemID;
        [SerializeField] private string chestName;
        [SerializeField] private float timerDuration;
        [SerializeField] private ChestReward chestReward;
        [SerializeField] private Sprite closedSprite;
        [SerializeField] private Sprite openedSprite;
        
        public string ItemID => itemID;

        public string ChestName => chestName;

        public float TimerDuration => timerDuration;

        public ChestReward ChestReward => chestReward;

        public Sprite ClosedSprite => closedSprite;

        public Sprite OpenedSprite => openedSprite;
        
        public void OnBeforeSerialize()
        {
            if (string.IsNullOrWhiteSpace(itemID))
            {
                itemID = System.Guid.NewGuid().ToString();
            }
        }

        public void OnAfterDeserialize()
        {
        }
    }
}
