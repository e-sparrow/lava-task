using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Plants.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Plants
{
    public class PlantInstaller : MonoInstaller<PlantInstaller>
    {
        [SerializeField] private MonoPlantUI plantUI;

        [SerializeField] private List<SerializablePlantInfo> infos;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<PlantFactory>()
                .AsSingle()
                .WithArguments(infos.Cast<IPlantInfo>());

            Container
                .BindInterfacesTo<MonoPlantUI>()
                .FromInstance(plantUI)
                .AsSingle();
        }
    }
}