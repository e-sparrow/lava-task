using System;

namespace Game.Plants.Interfaces
{
    public interface IPlantModel
    {
        TimeSpan GrowDelay
        {
            get;
        }

        int ExperienceReward
        {
            get;
        }
    }
}