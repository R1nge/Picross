using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Saves;
using UnityEngine;
using Grid = _Assets.Scripts.Services.Grids.Grid;


namespace _Assets.Scripts.Services.UIs.LevelEditor
{
    public class LevelEditorController
    {
        private readonly GridViewFactory _gridViewFactory;
        private readonly LevelSaveService _levelSaveService;
        private LevelEditorView _levelEditorView;
        private Grid _grid;

        private LevelEditorController(GridViewFactory gridViewFactory, LevelSaveService levelSaveService)
        {
            _gridViewFactory = gridViewFactory;
            _levelSaveService = levelSaveService;
        }

        public void Init(LevelEditorView levelEditorView)
        {
            _grid = _gridViewFactory.CreateGrid(Vector3.zero, 10, 10).Grid;
            _levelEditorView = levelEditorView;
            _levelEditorView.SaveButton.onClick.AddListener(Save);
        }

        private void Save()
        {
            _levelSaveService.Save(_grid, "Test");
        }
    }
}