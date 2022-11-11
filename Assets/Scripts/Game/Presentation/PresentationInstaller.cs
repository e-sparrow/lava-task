using System;
using UnityEngine;
using Zenject;

namespace Game.Presentation
{
    public class PresentationInstaller : MonoInstaller<PresentationInstaller>
    {
        [SerializeField] private CameraTarget cameraTarget;
        
        public override void InstallBindings()
        {
            Container
                .BindInstance(cameraTarget)
                .AsSingle();
        }
    }
}