using System.Collections.Generic;

namespace Game.Sound.Interfaces
{
    public interface ISoundSettings
    {
        IEnumerable<SoundSource> Sources
        {
            get;
        }
    }
}