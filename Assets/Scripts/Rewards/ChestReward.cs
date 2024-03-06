using System.Collections.Generic;
using UnityEngine;

namespace Rewards
{
    [CreateAssetMenu(menuName = ("Rewards/Chest Reward"))]
    public sealed class ChestReward : ScriptableObject, IReward
    {
        [SerializeField] private List<Reward> rewardsList;

        public List<Reward> GetRewardAmount()
        {
            return rewardsList;
        }
    }
}
