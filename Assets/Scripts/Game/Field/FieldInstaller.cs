using UnityEngine;
using Zenject;

namespace Game.Field
{
    public class FieldInstaller : MonoInstaller<FieldInstaller>
    {
        [SerializeField] private MonoFieldService fieldService;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<MonoFieldService>()
                .FromInstance(fieldService)
                .AsSingle();
        }
    }
}