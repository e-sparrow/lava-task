using Game.Plants.Enums;

namespace Game.Plants.Interfaces
{
    public interface IPlantInfo
    {
        EPlantType Type
        {
            get;
        }
        
        IPlantModel Model
        {
            get;
        }

        MonoPlantView Prefab
        {
            get;
        }
    }
}