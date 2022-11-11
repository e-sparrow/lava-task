using System;

namespace Game.Plants.Interfaces
{
    public interface IPlantView : IDisposable
    {
        void StartTimer(TimeSpan time);
        void Grow();
    }
}