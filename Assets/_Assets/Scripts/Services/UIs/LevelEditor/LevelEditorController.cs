using _Assets.Scripts.Services.Factories;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs.LevelEditor
{
    public class LevelEditorController
    {
        private readonly GridViewFactory _gridViewFactory;
        private LevelEditorView _levelEditorView;

        private LevelEditorController(GridViewFactory gridViewFactory)
        {
            _gridViewFactory = gridViewFactory;
        }

        public void Init(LevelEditorView levelEditorView)
        {
            _gridViewFactory.CreateGrid(Vector3.zero, 10, 10);
            _levelEditorView = levelEditorView;
            _levelEditorView.SaveButton.onClick.AddListener(Save);
        }

        private void Save()
        {
            //TODO: save
        }
    }
}