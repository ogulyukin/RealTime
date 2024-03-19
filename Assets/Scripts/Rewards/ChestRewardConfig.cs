using System.Collections.Generic;
using UnityEngine;

namespace Rewards
{
    [CreateAssetMenu(menuName = ("Rewards/Chest Reward"))]
    public sealed class ChestRewardConfig : ScriptableObject, IReward
    {
        [SerializeField] private List<Reward> rewardsList;

        public List<Reward> GetRewardAmount()
        {
            return rewardsList;
        }
    }
}
