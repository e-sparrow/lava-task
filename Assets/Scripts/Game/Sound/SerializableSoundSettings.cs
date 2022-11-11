using System;
using System.Collections.Generic;
using Game.Sound.Interfaces;
using UnityEngine;

namespace Game.Sound
{
    [Serializable]
    public class SerializableSoundSettings : ISoundSettings
    {
        [NonReorderable]
        [SerializeField] private SoundSource[] sources;

        public IEnumerable<SoundSource> Sources => sources;
    }
}