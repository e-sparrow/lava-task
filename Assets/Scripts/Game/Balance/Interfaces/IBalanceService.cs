using Game.Balance.Enums;

namespace Game.Balance.Interfaces
{
    public interface IBalanceService
    {
        IWallet GetWallet(EBalanceType type);
    }
}