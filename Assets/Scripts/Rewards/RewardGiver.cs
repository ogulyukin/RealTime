using JetBrains.Annotations;
using UnityEngine;

namespace Rewards
{
    [UsedImplicitly]
    public sealed class RewardGiver
    {
        public void GiveReward(IReward reward)
        {
            foreach (var rwd in reward.GetRewardAmount())
            {
                Debug.Log($"Reward granted: {rwd.rewardType} : {rwd.value}");
                //Here will actual method of reward giving...
            }
        }
    }
}
