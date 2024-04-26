namespace _Assets.Scripts.Services.Grids
{
    public class Cell
    {
        private int _x;
        private int _y;
        private CellState _state;

        public Cell(int x, int y, CellState state)
        {
            _x = x;
            _y = y;
            _state = state;
        }
        
        public int X => _x;
        public int Y => _y;
        public CellState State => _state;

        public void SetState(CellState state) => _state = state;
    }
}