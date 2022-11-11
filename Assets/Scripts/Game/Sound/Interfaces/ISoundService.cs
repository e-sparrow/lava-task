namespace Game.Sound.Interfaces
{
    public interface ISoundService<in TKey>
    {
        void PlayOneShot(TKey key);
    }
}