using Game.Chickens.Interfaces;
using Zenject;

namespace Game.Chickens
{
    public class ChickenSystem : IInitializable
    {
        public ChickenSystem(IChickenConfig config, IFactory<ChickenPresenter> factory)
        {
            _config = config;
            _factory = factory;
        }

        private readonly IChickenConfig _config;
        private readonly IFactory<ChickenPresenter> _factory;

        public void Initialize()
        {
            for (var i = 0; i < _config.ChickenCount; i++)
            {
                CreateNew();
            }

            void CreateNew()
            {
                var presenter = _factory.Create();
                presenter.OnRequestUpdate += CreateNew;
            }
        }
    }
}