using Game.Plants.Enums;
using UnityEngine;

namespace Game.Field.Interfaces
{
    public interface IFieldService
    {
        void Plant(EPlantType plant, Vector2Int position);
        
        Vector3 GetCellPosition(Vector2Int cell);

        Vector2Int Size
        {
            get;
        }
    }
}