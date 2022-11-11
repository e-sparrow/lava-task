using System;
using UnityEngine;

namespace Game.Chickens.Interfaces
{
    public interface IChickenView : IDisposable
    {
        event Action OnHit;
        
        void GoTo(Vector3 position, bool sitDown = false);
        void SetSpeed(float speed);
        void Peck();
    }
}