namespace _Assets.Scripts.Services.Grids
{
    public class Cell
    {
        private CellState _state;

        public Cell(int x, int y, CellState state)
        {
            X = x;
            Y = y;
            _state = state;
        }
        
        public int X { get; }

        public int Y { get; }

        public CellState State => _state;

        public void SetState(CellState state) => _state = state;
    }
}