using System;
using Game.Balance.Enums;
using Game.Balance.Interfaces;
using Game.Plants.Enums;
using Game.Plants.Interfaces;
using UnityEngine;
using Utils;
using Zenject;

namespace Game.Plants
{
    public class PlantPresenter : IInitializable
    {
        public PlantPresenter(IPlantModel model, IPlantView view, EPlantType type, IBalanceService balanceService)
        {
            _model = model;
            _view = view;
            _type = type;

            _balanceService = balanceService;
        }

        public event Action OnRemoved = () => { };

        private readonly IPlantModel _model;
        private readonly IPlantView _view;
        private readonly EPlantType _type;

        private readonly IBalanceService _balanceService;

        private bool _isGrown = false;
        
        public void Initialize()
        {
            _view.StartTimer(_model.GrowDelay);
            
            new WaitForSeconds((float) _model.GrowDelay.TotalSeconds)
                .AsCoroutine()
                .AppendCallback(Grow)
                .Start();
        }

        private void Grow()
        {
            _view.Grow();
            
            var amount = _model.ExperienceReward;
            _balanceService
                .GetWallet(EBalanceType.Experience)
                .Add(amount);

            _isGrown = true;
        }

        public bool Click()
        {
            if (!_isGrown) return false;
            
            switch (_type)
            {
                case EPlantType.Carrot:
                    _view.Dispose();
                    _balanceService
                        .GetWallet(EBalanceType.Carrot)
                        .Add(1);
                    
                    OnRemoved.Invoke();
                    break;
                
                case EPlantType.Grass:
                    _view.Dispose();
                    OnRemoved.Invoke();
                    break;
                
                case EPlantType.Tree:
                    break;
            }

            return true;
        }
    }
}