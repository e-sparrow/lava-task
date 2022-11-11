using System;
using Game.Field.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Field
{
    public class CellView : MonoBehaviour, ICellView
    {
        public event Action OnClick = () => { };

        [SerializeField] private Button button;

        private void OnEnable()
        {
            button.onClick.AddListener(Click);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(Click);
        }

        private void Click()
        {
            OnClick.Invoke();
        }
        
        public bool HasPlant 
        { 
            get; 
            set; 
        }
    }
}