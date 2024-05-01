﻿using _Assets.Scripts.Services.Grids;

namespace _Assets.Scripts.Services.LevelEditor.Commands
{
    public class FillCellCommand : IEditorCommand
    {
        private readonly CellView _cellView;
        private readonly CellState _previousState;

        public FillCellCommand(CellView cellView, CellState previousState)
        {
            _cellView = cellView;
            _previousState = previousState;
        }

        public void Execute() => _cellView.SetState(CellState.Filled);

        public void Undo() => _cellView.SetState(_previousState);
    }
}