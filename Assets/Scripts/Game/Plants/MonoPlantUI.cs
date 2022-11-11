using System;
using System.Collections.Generic;
using Game.Plants.Enums;
using Game.Plants.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Game.Plants
{
    public class MonoPlantUI : MonoBehaviour, IPlantUI
    {
        public event Action<EPlantType> OnPlantSelected = _ => { };

        [SerializeField] private RectTransform panel;
        [SerializeField] private List<PlantButton> buttons;

        public void Show()
        {
            panel.gameObject.SetActive(true);

            var rectTransform = (RectTransform) panel.transform;
            var position = rectTransform.FitInScreen(Input.mousePosition);
            
            rectTransform.anchoredPosition = position;
            
            foreach (var button in buttons)
            {
                button.Button.onClick.AddListener(() => OnPlantSelected.Invoke(button.Type));
            }
        }

        public void Hide()
        {
            panel.gameObject.SetActive(false);
            foreach (var button in buttons)
            {
                button.Button.onClick.RemoveAllListeners();
            }
        }

        public bool IsActive => panel.gameObject.activeSelf;

        [Serializable]
        private class PlantButton
        {
            public EPlantType Type;
            public Button Button;
        }
    }
}