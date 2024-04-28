using _Assets.Scripts.Services.Factories;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.Grids
{
    public class GridView : MonoBehaviour
    {
        private Grid _grid;

        public Grid Grid => _grid;

        [Inject] private CellViewFactory _cellViewFactory;

        [Inject] private GridCompleteService _gridCompleteService;
        private CellView[,] _cellViews;

        public void Init(int width, int height)
        {
            _grid = new Grid(width, height);
            _cellViews = new CellView[width, height];
            _grid.Init();

            var gridWidth = _grid.Cells.GetLength(0);
            var gridHeight = _grid.Cells.GetLength(1);

            var cellWidth = 1f;
            var startX = -(gridWidth * cellWidth) / 2 + cellWidth / 2;
            var cellHeight = 1f;
            var startY = gridHeight * cellHeight / 2 - cellHeight / 2;

            for (var y = 0; y < gridHeight; y++)
            {
                for (var x = 0; x < gridWidth; x++)
                {
                    // Calculate the position for each cell
                    float xPos = startX + x * cellWidth;
                    float yPos = startY - y * cellHeight;

                    // Instantiate and initialize the cell
                    var cellObject = _cellViewFactory.Create(x, y);
                    cellObject.Init(x, y, CellState.Empty, _grid);
                    _cellViews[x, y] = cellObject;

                    // Assuming the cell object has a Transform component
                    cellObject.transform.SetParent(transform, false);
                    cellObject.transform.localPosition = new Vector3(xPos, yPos, 0);
                }
            }

            _gridCompleteService.SetPlayerGrid(_grid);

            transform.position += new Vector3(0, 0, 10f);
        }


        public void SetCells(Cell[,] cells)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                for (int x = 0; x < cells.GetLength(0); x++)
                {
                    _cellViews[x, y].SetState(cells[x, y].State);
                }
            }
        }
    }
}