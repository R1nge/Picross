using _Assets.Scripts.Configs;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Grids;
using _Assets.Scripts.Services.Saves;
using UnityEngine;

namespace _Assets.Scripts.Services.LevelEditor
{
    public class LevelEditorService
    {
        private readonly LevelSaveService _levelSaveService;
        private readonly GridViewFactory _gridViewFactory;
        private readonly ConfigProvider _configProvider;
        private GridView _gridView;
        private Size _currentSize;

        private LevelEditorService(LevelSaveService levelSaveService, GridViewFactory gridViewFactory,
            ConfigProvider configProvider)
        {
            _levelSaveService = levelSaveService;
            _gridViewFactory = gridViewFactory;
            _configProvider = configProvider;
        }

        public void Init()
        {
            _levelSaveService.OnLevelLoaded += UpdateGrid;
            var size = _configProvider.PicrossConfig.GetSize(0);

            if (size != null)
            {
                _currentSize = size.Value;
                _gridView = _gridViewFactory.CreateGrid(Vector3.zero, _currentSize.width, _currentSize.height);
            }
        }

        public void ChangeSize(Size size)
        {
            if (size.height == _currentSize.height && size.width == _currentSize.width)
            {
                Debug.Log("No changes");
                return;
            }

            if (_gridView != null)
            {
                Object.Destroy(_gridView.gameObject);
            }

            _currentSize = size;
            _gridView = _gridViewFactory.CreateGrid(Vector3.zero, _currentSize.width, _currentSize.height);
        }

        private void UpdateGrid(LevelData data)
        {
            if (_gridView != null)
            {
                if (_gridView.Grid.Cells.GetLength(0) != data.Cells.GetLength(0) ||
                    _gridView.Grid.Cells.GetLength(1) != data.Cells.GetLength(1))
                {
                    Object.Destroy(_gridView.gameObject);

                    _gridView = _gridViewFactory.CreateGrid(Vector3.zero, data.Size.width, data.Size.height);
                }
                else
                {
                    _gridView.SetCells(data.Cells);
                }
            }
            else
            {
                _gridView = _gridViewFactory.CreateGrid(Vector3.zero, data.Size.width, data.Size.height);
            }

            _gridView.SetCells(data.Cells);
        }

        public void Save(string levelName)
        {
            var levelData = new LevelData
            {
                Cells = _gridView.Grid.Cells,
                LevelName = levelName,
                Size = _currentSize
            };

            _levelSaveService.Save(levelData);
        }

        public void Load(string levelName) => _levelSaveService.Load(levelName);

        public void Dispose()
        {
            if (_gridView != null)
            {
                Object.Destroy(_gridView.gameObject);
            }

            _levelSaveService.OnLevelLoaded -= UpdateGrid;
        }
    }
}