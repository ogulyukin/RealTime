using System.Collections.Generic;

namespace Rewards
{
    public interface IReward
    {
        public List<Reward> GetRewardAmount();
    }
}