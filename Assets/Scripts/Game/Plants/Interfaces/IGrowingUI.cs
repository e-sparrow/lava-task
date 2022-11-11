using System;

namespace Game.Plants.Interfaces
{
    public interface IGrowingUI
    {
        void SetMaxTime(TimeSpan time);
        void SetTimeLeft(TimeSpan time);

        void Show();
        void Hide();

        bool IsActive
        {
            get;
        }
    }
}