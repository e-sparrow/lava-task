using System.Collections.Generic;
using Game.Chickens.Interfaces;
using Game.Field.Interfaces;
using Game.Sound.Enums;
using Game.Sound.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Chickens
{
    public class ChickenFactory : IFactory<ChickenPresenter>, ILateDisposable
    {
        public ChickenFactory(ChickenView prefab, IChickenConfig config, IFieldService fieldService, ISoundService<ESoundType> soundService)
        {
            _prefab = prefab;
            _config = config;
            
            _fieldService = fieldService;
            _soundService = soundService;
        }

        private readonly ChickenView _prefab;
        private readonly IChickenConfig _config;
        
        private readonly IFieldService _fieldService;
        private readonly ISoundService<ESoundType> _soundService;

        private readonly IList<ChickenPresenter> _presenters = new List<ChickenPresenter>();

        public ChickenPresenter Create()
        {
            var x = Random.Range(0, _fieldService.Size.x);
            var y = Random.Range(0, _fieldService.Size.y);

            var cell = new Vector2Int(x, y);
            var position = _fieldService.GetCellPosition(cell);

            var view = Object.Instantiate(_prefab, position, Quaternion.identity);

            var boringPeriod = Random.Range(_config.MinBoringPeriod, _config.MaxBoringPeriod);
            var peckPeriod = Random.Range(_config.MinPeckPeriod, _config.MaxPeckPeriod);
            var speed = Random.Range(_config.MinSpeed, _config.MaxSpeed);
            
            var model = new ChickenModel(boringPeriod, peckPeriod, speed);
            
            var presenter = new ChickenPresenter(model, view, _fieldService, _soundService);
            presenter.Initialize();
            
            _presenters.Add(presenter);

            return presenter;
        }

        public void LateDispose()
        {
            foreach (var presenter in _presenters)
            {
                presenter.LateDispose();
            }
            
            _presenters.Clear();
        }
    }
}