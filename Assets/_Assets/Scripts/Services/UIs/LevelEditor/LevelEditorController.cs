using _Assets.Scripts.Services.Factories;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs.LevelEditor
{
    public class LevelEditorController
    {
        private readonly GridViewFactory _gridViewFactory;

        public LevelEditorController(GridViewFactory gridViewFactory)
        {
            _gridViewFactory = gridViewFactory;
        }

        public void Init()
        {
            _gridViewFactory.CreateGrid(Vector3.zero, 10, 10);
        }
    }
}