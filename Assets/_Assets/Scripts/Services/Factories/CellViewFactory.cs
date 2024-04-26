using _Assets.Scripts.Configs;
using _Assets.Scripts.Services.Grids;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
    public class CellViewFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private CellViewFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }

        public CellView Create(int positionX, int positionY, int x, int y, CellState state)
        {
            var cell = _objectResolver.Instantiate(
                _configProvider.GameConfig.CellPrefab,
                new Vector3(positionX, positionY, 10),
                Quaternion.identity
            );

            cell.Init(x, y, state);

            return cell;
        }
    }
}