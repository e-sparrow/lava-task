namespace Game.Chickens.Interfaces
{
    public interface IChickenConfig
    {
        int ChickenCount
        {
            get;
        }

        float MinBoringPeriod
        {
            get;
        }

        float MaxBoringPeriod
        {
            get;
        }

        float MinPeckPeriod
        {
            get;
        }

        float MaxPeckPeriod
        {
            get;
        }

        float MinSpeed
        {
            get;
        }

        float MaxSpeed
        {
            get;
        }
    }
}