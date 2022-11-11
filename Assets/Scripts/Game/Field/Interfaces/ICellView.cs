using System;

namespace Game.Field.Interfaces
{
    public interface ICellView
    {
        event Action OnClick;

        bool HasPlant
        {
            get;
            set;
        }
    }
}