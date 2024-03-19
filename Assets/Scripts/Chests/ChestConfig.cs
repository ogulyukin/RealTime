using JetBrains.Annotations;
using Rewards;
using UnityEngine;

namespace Chests
{
    [CreateAssetMenu(menuName = ("Rewards/Chest"))]
    public sealed class ChestConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        [Tooltip("Auto-generated UUID for saving/loading. Clear this field if you want to generate a new one.")]
        [field: SerializeField] public string ItemID { get; private set;}
        [UsedImplicitly] [field:SerializeField] public string ChestName { get; private set;}
        [UsedImplicitly] [field:SerializeField] public float TimerDuration { get; private set;}
        [UsedImplicitly] [field:SerializeField] public ChestRewardConfig ChestRewardConfig { get; private set;}
        [UsedImplicitly] [field:SerializeField] public Sprite ClosedSprite { get; private set;}
        [UsedImplicitly] [field:SerializeField] public Sprite OpenedSprite { get; private set;}
        
        public void OnBeforeSerialize()
        {
            if (string.IsNullOrWhiteSpace(ItemID))
            {
                ItemID = System.Guid.NewGuid().ToString();
            }
        }

        public void OnAfterDeserialize()
        {
        }
    }
}
