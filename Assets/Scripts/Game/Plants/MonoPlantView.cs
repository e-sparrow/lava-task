using System;
using System.Collections;
using Game.Plants.Interfaces;
using UnityEngine;
using Utils;

namespace Game.Plants
{
    public class MonoPlantView : MonoBehaviour, IPlantView
    {
        [SerializeField] private MonoGrowingUI growingUI;
        
        [SerializeField] private Animator growAnimator;
        [SerializeField] private string growKey;

        private bool _isGrown = false;

        public void StartTimer(TimeSpan time)
        {
            TimerCoroutine(time).Start();
        }

        public void Grow()
        {
            var grow = Animator.StringToHash(growKey);
            growAnimator.SetTrigger(grow);

            _isGrown = true;
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }

        private IEnumerator TimerCoroutine(TimeSpan time)
        {
            growingUI.SetMaxTime(time);
            growingUI.Show();

            var left = time;
            for (var i = 0; i < time.TotalSeconds; i++)
            {
                left -= TimeSpan.FromSeconds(1);
                growingUI.SetTimeLeft(left);

                yield return new WaitForSeconds(1);
            }
            
            growingUI.Hide();
        }
    }
}