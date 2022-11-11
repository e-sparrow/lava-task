using System;
using Game.Sound.Enums;
using UnityEngine;

namespace Game.Sound
{
    [Serializable]
    public struct SoundSource
    {
        [field: SerializeField]
        public ESoundType Type
        {
            get;
            private set;
        }

        [field: SerializeField]
        public AudioClip Clip
        {
            get;
            private set;
        }
    }
}