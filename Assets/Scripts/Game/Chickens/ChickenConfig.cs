using Game.Chickens.Interfaces;
using UnityEngine;

namespace Game.Chickens
{
    [CreateAssetMenu(menuName = "Configs/Chicken", fileName = "ChickenConfig")]
    public class ChickenConfig : ScriptableObject, IChickenConfig
    {
        [field: SerializeField]
        public int ChickenCount
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float MinBoringPeriod
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float MaxBoringPeriod
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float MinPeckPeriod
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float MaxPeckPeriod
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float MinSpeed
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float MaxSpeed
        {
            get;
            private set;
        }
    }
}