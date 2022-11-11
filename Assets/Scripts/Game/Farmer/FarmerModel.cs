using System;
using Game.Farmer.Interfaces;
using Game.Plants.Enums;
using UnityEngine;

namespace Game.Farmer
{
    public class FarmerModel : IFarmerModel
    {
        public event Action<EPlantType, Vector2Int> OnPlantRequested = (_, _) => { };
        
        public void Plant(EPlantType type, Vector2Int position)
        {
            OnPlantRequested.Invoke(type, position);
        }
    }
}