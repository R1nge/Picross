using UnityEngine;
using Grid = _Assets.Scripts.Services.Grids.Grid;

namespace _Assets.Scripts.Services
{
    public class GridCompleteService
    {
        private Grid _playerGrid;
        private Grid _targetGrid;
        
        public void SetPlayerGrid(Grid playerGrid) => _playerGrid = playerGrid;

        public void SetTargetGrid(Grid targetGrid) => _targetGrid = targetGrid;

        public void TryComplete()
        {
            bool completed = true;
            for (int y = 0; y < _targetGrid.Cells.GetLength(0); y++)
            {
                for (int x = 0; x < _targetGrid.Cells.GetLength(1); x++)
                {
                    if (_playerGrid.Cells[x, y].State != _targetGrid.Cells[x, y].State)
                    {
                        completed = false;
                        break;
                    }
                }
            }

            if (completed)
            {
                Debug.Log("Completed");
            }
        }
    }
}