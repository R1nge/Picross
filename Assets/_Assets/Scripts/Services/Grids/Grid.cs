using UnityEngine;

namespace _Assets.Scripts.Services.Grids
{
    public class Grid
    {
        private readonly int _width;
        private readonly int _height;
        private Cell[,] _cells;
        public Cell[,] Cells => _cells;
        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public Cell GetCell(int x, int y)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height)
            {
                Debug.LogError("GRID GetCell: cell is out of bounds");
                return null;
            }

            return _cells[x, y];
        }

        public void SetCellState(int x, int y, CellState state)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height)
            {
                Debug.LogError("GRID SetCell: cell is out of bounds");
                return;
            }
            
            _cells[x, y].SetState(state);
        }

        public void Init()
        {
            _cells = new Cell[_width, _height];
            
            for (var y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _cells[x,y] = new Cell(x, y, CellState.Empty);
                }
            }
        }
    }
}