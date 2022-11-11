using UnityEngine;
using Zenject;

namespace Game.Farmer
{
    public class FarmerInstaller : MonoInstaller<FarmerInstaller>
    {
        [SerializeField] private FarmerView view;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<FarmerModel>()
                .AsSingle();
        
            Container
                .BindInterfacesTo<FarmerView>()
                .FromInstance(view)
                .AsSingle();

            Container
                .BindInterfacesTo<FarmerPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}