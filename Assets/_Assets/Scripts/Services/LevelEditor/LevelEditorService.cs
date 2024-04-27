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
        private GridView _gridView;

        private LevelEditorService(LevelSaveService levelSaveService, GridViewFactory gridViewFactory)
        {
            _levelSaveService = levelSaveService;
            _gridViewFactory = gridViewFactory;
        }

        public void Init()
        {
            _levelSaveService.OnLevelLoaded += UpdateGrid;
            _gridView = _gridViewFactory.CreateGrid(Vector3.zero, 10,10);
        }

        private void UpdateGrid(LevelData data)
        {
            Debug.Log("Update grid");
            _gridView.SetCells(data.Cells);
        }

        public void Save()
        {
            Debug.Log($"Save {_gridView.Grid.Cells[0,0].State}");
            _levelSaveService.Save(_gridView.Grid.Cells, "Test");
        }

        public void Load()
        {
            _levelSaveService.Load("Test");   
        }
    }
}