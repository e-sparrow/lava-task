using System.Collections.Generic;
using Game.Balance.Enums;
using Game.Balance.Interfaces;

namespace Game.Balance
{
    public class BalanceService : IBalanceService
    {
        public BalanceService()
        {
            _wallets.Add(EBalanceType.Experience, new Wallet());
            _wallets.Add(EBalanceType.Carrot, new Wallet());
        }
        
        private readonly IDictionary<EBalanceType, IWallet> _wallets = new Dictionary<EBalanceType, IWallet>();

        public IWallet GetWallet(EBalanceType type)
        {
            return _wallets[type];
        }
    }
}