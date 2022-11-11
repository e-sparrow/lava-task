using Zenject;

namespace Game.Balance
{
    public class BalanceInstaller : MonoInstaller<BalanceInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<BalanceService>()
                .AsSingle();
        }
    }
}