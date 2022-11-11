using System;
using Game.Plants.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Plants
{
    public class MonoGrowingUI : MonoBehaviour, IGrowingUI
    {
        [SerializeField] private GameObject panel;
        
        [SerializeField] private TMP_Text text;
        [SerializeField] private Image bar;

        private TimeSpan _maxTime;
        
        public void SetMaxTime(TimeSpan time)
        {
            _maxTime = time;
        }

        public void SetTimeLeft(TimeSpan time)
        {
            text.text = $"{time.Minutes}:{time.Seconds}";
            bar.fillAmount = (float) (time / _maxTime);
        }

        public void Show()
        {
            panel.SetActive(true);
        }

        public void Hide()
        {
            panel.SetActive(false);
        }

        public bool IsActive => panel.activeSelf;
    }
}