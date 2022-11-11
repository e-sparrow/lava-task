using Game.Farmer.Interfaces;
using Game.Field.Interfaces;
using Game.Plants.Enums;
using UnityEngine;
using Utils;
using Zenject;

namespace Game.Farmer
{
    public class FarmerPresenter : IInitializable, ILateDisposable
    {
        public FarmerPresenter(IFarmerModel model, IFarmerView view, IFieldService fieldService)
        {
            _model = model;
            _view = view;

            _fieldService = fieldService;
        }

        private readonly IFarmerModel _model;
        private readonly IFarmerView _view;

        private readonly IFieldService _fieldService;
        
        public void Initialize()
        {
            _model.OnPlantRequested += Plant;
        }

        public void LateDispose()
        {
            _model.OnPlantRequested -= Plant;
        }

        private void Plant(EPlantType type, Vector2Int position)
        {
            var realPosition = _fieldService.GetCellPosition(position);
            
            _view
                .Plant(realPosition)
                .AppendCallback(Perform)
                .Start();

            void Perform()
            {
                _fieldService.Plant(type, position);
            }
        }
    }
}