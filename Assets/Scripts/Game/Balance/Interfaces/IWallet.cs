using System;

namespace Game.Balance.Interfaces
{
    public interface IWallet
    {
        event Action<int> OnBalanceChanged;

        void Add(int amount);
        bool TrySpend(int amount);
        
        int Balance
        {
            get;
        }
    }
}