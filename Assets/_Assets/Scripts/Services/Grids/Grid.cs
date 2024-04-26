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