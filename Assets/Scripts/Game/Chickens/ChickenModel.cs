using Game.Chickens.Interfaces;

namespace Game.Chickens
{
    public readonly struct ChickenModel : IChickenModel
    {
        public ChickenModel(float boringPeriod, float peckPeriod, float speed)
        {
            BoringPeriod = boringPeriod;
            PeckPeriod = peckPeriod;
            Speed = speed;
        }

        public float BoringPeriod
        {
            get;
        }

        public float PeckPeriod
        {
            get;
        }

        public float Speed
        {
            get;
        }
    }
}