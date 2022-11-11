using System;
using Game.Balance.Interfaces;

namespace Game.Balance
{
    public class Wallet : IWallet
    {
        public event Action<int> OnBalanceChanged = _ => { };

        private int _balance = 0;
        
        public void Add(int amount)
        {
            Balance += amount;
        }

        public bool TrySpend(int amount)
        {
            var canSpend = Balance >= amount;
            if (canSpend)
            {
                Balance -= amount;
            }

            return canSpend;
        }

        public int Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnBalanceChanged.Invoke(_balance);
            }
        }
    }
}