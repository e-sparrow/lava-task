using System.Collections;
using UnityEngine;

namespace Game.Farmer.Interfaces
{
    public interface IFarmerView
    {
        IEnumerator Plant(Vector3 position);
    }
}