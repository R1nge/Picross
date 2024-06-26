﻿using _Assets.Scripts.Configs;
using _Assets.Scripts.Services.Grids;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
    public class GridViewFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private GridViewFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }

        public GridView CreateGrid(Vector3 origin, int width, int height)
        {
            var grid = _objectResolver.Instantiate(_configProvider.GameConfig.GridPrefab, origin, Quaternion.identity);
            grid.Init(width, height);
            return grid;
        }

        public GridView CreateGrid(Vector3 origin, Size size)
        {
            var grid = _objectResolver.Instantiate(_configProvider.GameConfig.GridPrefab, origin, Quaternion.identity);
            grid.Init(size);
            return grid;
        }
    }
}