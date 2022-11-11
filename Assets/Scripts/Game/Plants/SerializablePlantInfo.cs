using System;
using Game.Plants.Enums;
using Game.Plants.Interfaces;
using UnityEngine;

namespace Game.Plants
{
    [Serializable]
    public class SerializablePlantInfo : IPlantInfo
    {
        [field: SerializeField]
        public EPlantType Type
        {
            get;
            private set;
        }
        
        [SerializeField] private SerializablePlantModel model;
        public IPlantModel Model => model;

        [SerializeField] private MonoPlantView prefab;
        public MonoPlantView Prefab => prefab;
    }
}