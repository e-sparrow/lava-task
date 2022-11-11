using Game.Sound.Pitch;
using UnityEngine;
using Zenject;

namespace Game.Sound
{
    public class SoundInstaller : MonoInstaller<SoundInstaller>
    {
        private const string AudioPoolTransformGroup = "AudioPool";
        
        [SerializeField] private SerializableSoundSettings soundSettings;
        [SerializeField] private SerializablePitchSettings pitchSettings;
        
        [SerializeField] private AudioSource audioSourcePrefab;
        
        public override void InstallBindings()
        {
            Container
                .BindMemoryPool<AudioSource, MemoryPool<AudioSource>>()
                .WithInitialSize(8)
                .WithMaxSize(16)
                .FromComponentInNewPrefab(audioSourcePrefab)
                .UnderTransformGroup(AudioPoolTransformGroup);
            
            Container
                .BindInterfacesTo<SerializableSoundSettings>()
                .FromInstance(soundSettings)
                .AsSingle();

            Container
                .BindInterfacesTo<SerializablePitchSettings>()
                .FromInstance(pitchSettings)
                .AsSingle();
            
            Container
                .BindInterfacesTo<PitchService>()
                .AsSingle();

            Container
                .BindInterfacesTo<SoundService>()
                .AsSingle();
        }
    }
}