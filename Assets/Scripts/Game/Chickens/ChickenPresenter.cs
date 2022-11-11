using System;
using System.Collections;
using Game.Chickens.Interfaces;
using Game.Field.Interfaces;
using Game.Sound.Enums;
using Game.Sound.Interfaces;
using UnityEngine;
using Utils;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Chickens
{
    public class ChickenPresenter : IInitializable, ILateDisposable
    {
        public ChickenPresenter(IChickenModel model, IChickenView view, IFieldService fieldService, ISoundService<ESoundType> soundService)
        {
            _model = model;
            _view = view;

            _fieldService = fieldService;
            _soundService = soundService;
        }

        public event Action OnRequestUpdate = () => { };

        private readonly IChickenModel _model;
        private readonly IChickenView _view;

        private readonly IFieldService _fieldService;
        private readonly ISoundService<ESoundType> _soundService;

        private Coroutine _boringLoop;
        private Coroutine _peckLoop;

        public void Initialize()
        {
            _boringLoop = BoringLoopCoroutine().Start();
            _peckLoop = PeckLoopCoroutine().Start();

            _view.SetSpeed(_model.Speed);
            _view.OnHit += Hit;
        }

        public void LateDispose()
        {
            _boringLoop.Stop();
            _peckLoop.Stop();
                
            _view.OnHit -= Hit;
        }

        private void Hit()
        {
            _soundService.PlayOneShot(ESoundType.Hit);
            _soundService.PlayOneShot(ESoundType.Chicken);
                
            LateDispose();

            const float Delay = 10f;
            
            new WaitForSeconds(Delay)
                .AsCoroutine()
                .AppendCallback(Perform)
                .Start();

            void Perform()
            {
                _view.Dispose();
                OnRequestUpdate.Invoke();
            }
        }

        private IEnumerator BoringLoopCoroutine()
        {
            while (Application.isPlaying)
            {
                yield return new WaitForSeconds(_model.BoringPeriod);

                var x = Random.Range(0, _fieldService.Size.x);
                var y = Random.Range(0, _fieldService.Size.y);

                var randomCell = new Vector2Int(x, y);
                var point = _fieldService.GetCellPosition(randomCell);

                _view.GoTo(point);
            }
        }

        private IEnumerator PeckLoopCoroutine()
        {
            while (Application.isPlaying)
            {
                yield return new WaitForSeconds(_model.PeckPeriod);
                _view.Peck();
            }
        }
    }
}