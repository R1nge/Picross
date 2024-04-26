using _Assets.Scripts.Services.Factories;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.Grids
{
    public class GridView : MonoBehaviour
    {
        private Grid _grid;
        [Inject] private CellViewFactory _cellViewFactory;
        [Inject] private GridCompleteService _gridCompleteService;

        public void Init(int width, int height)
        {
            _grid = new Grid(width, height);
            _grid.Init();

            for (var y = 0; y < _grid.Cells.GetLength(0); y++)
            {
                for (var x = 0; x < _grid.Cells.GetLength(1); x++)
                {
                    var cellObject = _cellViewFactory.Create(x, y);
                    cellObject.Init(x, y, CellState.Empty, _grid);
                    cellObject.transform.SetParent(transform);
                }
            }
            
            _gridCompleteService.SetPlayerGrid(_grid);
        }
    }
}