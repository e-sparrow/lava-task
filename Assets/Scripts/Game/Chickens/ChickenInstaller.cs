using UnityEngine;
using Zenject;

namespace Game.Chickens
{
    public class ChickenInstaller : MonoInstaller<ChickenInstaller>
    {
        [SerializeField] private ChickenConfig config;
        [SerializeField] private ChickenView prefab;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<ChickenConfig>()
                .FromInstance(config)
                .AsSingle();

            Container
                .BindInterfacesTo<ChickenFactory>()
                .AsSingle()
                .WithArguments(prefab);

            Container
                .BindInterfacesTo<ChickenSystem>()
                .AsSingle()
                .NonLazy();
        }
    }
}