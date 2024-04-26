using UnityEngine;

namespace _Assets.Scripts.Services.Grids
{
    public class GridView : MonoBehaviour
    {
        private Grid _grid;

        public void Init(int width, int height, CellView cellPrefab)
        {
            _grid = new Grid(width, height);
            _grid.Init();

            for (var y = 0; y < _grid.Cells.GetLength(0); y++)
            {
                for (var x = 0; x < _grid.Cells.GetLength(1); x++)
                {
                    var cellObject = Instantiate(cellPrefab, transform);
                    cellObject.Init(x, y, CellState.Empty);
                    cellObject.transform.position = new Vector3(x, y, 10f);
                }
            }
        }

        public void SetCellState(int x, int y, CellState state) => _grid.SetCellState(x, y, state);
    }
}