using System;
using Game.Plants.Interfaces;
using UnityEngine;

namespace Game.Plants
{
    [Serializable]
    public class SerializablePlantModel : IPlantModel
    {
        [SerializeField] private float growDelaySeconds;
        
        public TimeSpan GrowDelay => TimeSpan.FromSeconds(growDelaySeconds);

        [field: SerializeField]
        public int ExperienceReward
        {
            get;
            private set;
        }
    }
}