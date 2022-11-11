using System;
using Game.Plants.Enums;
using UnityEngine;

namespace Game.Farmer.Interfaces
{
    public interface IFarmerModel
    {
        event Action<EPlantType, Vector2Int> OnPlantRequested; 

        void Plant(EPlantType type, Vector2Int position);
    }
}