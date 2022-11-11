using System.Collections.Generic;
using System.Linq;
using Game.Balance.Interfaces;
using Game.Plants.Enums;
using Game.Plants.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Plants
{
    public class PlantFactory : IFactory<EPlantType, Vector3, PlantPresenter>
    {
        public PlantFactory(IEnumerable<IPlantInfo> infos, IBalanceService balanceService)
        {
            _infos = infos;
            _balanceService = balanceService;
        }

        private readonly IEnumerable<IPlantInfo> _infos;
        private readonly IBalanceService _balanceService;

        public PlantPresenter Create(EPlantType type, Vector3 position)
        {
            var info = _infos.FirstOrDefault(value => value.Type == type);
            
            var view = Object.Instantiate(info.Prefab);
            view.transform.position = position;
            
            var presenter = new PlantPresenter(info.Model, view, type, _balanceService);
            presenter.Initialize();
            
            return presenter;
        }
    }
}