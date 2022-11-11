using System;
using Game.Plants.Enums;

namespace Game.Plants.Interfaces
{
    public interface IPlantUI
    {
        event Action<EPlantType> OnPlantSelected;

        void Show();
        void Hide();

        bool IsActive
        {
            get;
        }
    }
}