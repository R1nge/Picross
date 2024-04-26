using System;
using UnityEngine;

namespace _Assets.Scripts.Services.Grids
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        private Cell _cell;
        private Grid _grid;

        public void Init(int x, int y, CellState state, Grid grid)
        {
            _cell = new Cell(x, y, state);
            _grid = grid;
            UpdateView(state);
        }

        public void SetState(CellState state)
        {
            _grid.SetCellState(_cell.X, _cell.Y, state);
            UpdateView(state);
        }

        private void UpdateView(CellState cellState)
        {
            switch (cellState)
            {
                case CellState.Empty:
                    spriteRenderer.color = Color.white;
                    break;
                case CellState.Filled:
                    spriteRenderer.color = Color.black;
                    break;
                case CellState.Crossed:
                    spriteRenderer.color = Color.red;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cellState), cellState, null);
            }
        }
    }
}