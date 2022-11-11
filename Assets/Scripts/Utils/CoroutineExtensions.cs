using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    public static class CoroutineExtensions
    {
        private const string OriginName = "CoroutineOrigin";
        
        private static CoroutineOrigin _origin;

        public static IEnumerator AsCoroutine(this YieldInstruction self)
        {
            yield return self;
        }
        
        public static Coroutine Start(this IEnumerator self)
        {
            var coroutine = Origin.StartCoroutine(self);
            return coroutine;
        }

        public static void Stop(this Coroutine self)
        {
            Origin.StopCoroutine(self);
        }

        public static IEnumerator Append(this IEnumerator self, IEnumerator other)
        {
            yield return self;
            yield return other;
        }

        public static IEnumerator AppendCallback(this IEnumerator self, Action callback)
        {
            yield return self;
            callback.Invoke();
        }

        private static CoroutineOrigin Origin
        {
            get
            {
                if (_origin == null)
                {
                    _origin = new GameObject(OriginName)
                        .AddComponent<CoroutineOrigin>();
                }

                return _origin;
            }
        }
        
        private class CoroutineOrigin : MonoBehaviour { }
    }
}