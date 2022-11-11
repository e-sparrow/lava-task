using System;
using Game.Balance.Enums;
using Game.Balance.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Balance
{
    public class BalanceUI : MonoBehaviour
    {
        [SerializeField] private EBalanceType type;

        [SerializeField] private TMP_Text text;

        private IBalanceService _service;

        private IWallet _wallet;
        
        [Inject]
        private void Construct(IBalanceService service)
        {
            _service = service;
        }

        private void OnEnable()
        {
            _wallet = _service.GetWallet(type);
            _wallet.OnBalanceChanged += ChangeBalance;
            
            ChangeBalance(_wallet.Balance);
        }

        private void OnDisable()
        {
            _wallet.OnBalanceChanged -= ChangeBalance;
        }

        private void ChangeBalance(int balance)
        {
            text.text = balance.ToString();
        }
    }
}