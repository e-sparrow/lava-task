using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Utils
{
    public static class NavMeshExtensions
    {
        public static IEnumerator WaitDestination(this NavMeshAgent self, float sqrThreshold = 2f, float maxTime = float.MaxValue)
        {
            var time = 0f;
            while (!IsArrived() && time <= maxTime)
            {
                time += Time.deltaTime;
                yield return null;
            }

            bool IsArrived()
            {
                var result = (self.transform.position - self.destination).sqrMagnitude < sqrThreshold;
                return result;
            }
        }
    }
}