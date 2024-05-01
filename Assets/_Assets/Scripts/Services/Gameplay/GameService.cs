using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Grids;
using _Assets.Scripts.Services.Saves;
using UnityEngine;

namespace _Assets.Scripts.Services.Gameplay
{
    public class GameService
    {
        private readonly GridViewFactory _gridViewFactory;
        private GridView _gridView;
        
        private GameService(GridViewFactory gridViewFactory)
        {
            _gridViewFactory = gridViewFactory;
        }
        
        public void Init(LevelData levelData)
        {
            _gridView = _gridViewFactory.CreateGrid(Vector3.zero, levelData.Size);
        }


        public void Dispose()
        {
            if (_gridView != null)
            {
                Object.Destroy(_gridView.gameObject);
            }
        }
    }
}