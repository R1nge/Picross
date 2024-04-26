using System;
using UnityEngine;

namespace _Assets.Scripts.Services.Grids
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        private Cell _cell;

        public void Init(int x, int y, CellState state)
        {
            _cell = new Cell(x, y, state);
            UpdateView(state);
        }

        public void SetState(CellState state)
        {
            _cell.SetState(state);
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