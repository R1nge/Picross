using System;
using _Assets.Scripts.Services.Grids;
using _Assets.Scripts.Services.LevelEditor;
using _Assets.Scripts.Services.LevelEditor.Commands;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private new Camera camera;
        [Inject] private EditorCommandBufferService _editorCommandBufferService;
        private PlayerState _playerState;
        private PaintDirection _paintDirection;
        private Cell _previousCell;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (_editorCommandBufferService.HasCommands())
                {
                    _editorCommandBufferService.Undo();
                }
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                if (_editorCommandBufferService.HasUndoCommands())
                {
                    _editorCommandBufferService.Redo();
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                var cell = GetCellView();

                if (cell == null)
                {
                    return;
                }

                if (cell.Cell.State == CellState.Empty)
                {
                    _playerState = PlayerState.Fill;
                }
                else if (cell.Cell.State == CellState.Filled)
                {
                    _playerState = PlayerState.EmptyFill;
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                var cell = GetCellView();

                if (cell == null)
                {
                    return;
                }

                if (cell.Cell.State == CellState.Empty)
                {
                    _playerState = PlayerState.Cross;
                }
                else if (cell.Cell.State == CellState.Crossed)
                {
                    _playerState = PlayerState.EmptyCross;
                }
            }

            if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
            {
                _playerState = PlayerState.None;
                _paintDirection = PaintDirection.None;
                _previousCell = null;
            }

            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                var cell = GetCellView();

                if (cell == null)
                {
                    return;
                }

                if (_playerState == PlayerState.None)
                {
                    return;
                }

                _previousCell ??= cell.Cell;

                if (_previousCell != null)
                {
                    if (_paintDirection == PaintDirection.None)
                    {
                        var deltaX = Mathf.Abs(cell.Cell.X - _previousCell.X);
                        var deltaY = Mathf.Abs(cell.Cell.Y - _previousCell.Y);

                        if (deltaX > deltaY)
                        {
                            _paintDirection = PaintDirection.Horizontal;
                        }

                        if (deltaX < deltaY)
                        {
                            _paintDirection = PaintDirection.Vertical;
                        }
                    }
                }

                switch (_paintDirection)
                {
                    case PaintDirection.None:
                        ChangeCellState(cell);

                        break;
                    case PaintDirection.Vertical:
                        if (cell.Cell.X == _previousCell.X && cell.Cell.Y != _previousCell.Y)
                        {
                            ChangeCellState(cell);
                        }

                        break;
                    case PaintDirection.Horizontal:
                        if (cell.Cell.X != _previousCell.X && cell.Cell.Y == _previousCell.Y)
                        {
                            ChangeCellState(cell);
                        }

                        break;
                }
            }
        }

        private CellView GetCellView()
        {
            var rayHit = Physics2D.GetRayIntersection(camera.ScreenPointToRay(Input.mousePosition));

            if (rayHit.collider == null)
            {
                return null;
            }

            var cell = rayHit.collider.GetComponent<CellView>();

            if (cell == null)
            {
                return null;
            }

            return cell;
        }

        private void ChangeCellState(CellView cell)
        {
            switch (_playerState)
            {
                case PlayerState.None:
                    break;
                case PlayerState.Fill:

                    if (cell.Cell.State != CellState.Filled && cell.Cell.State != CellState.Crossed)
                    {
                        _editorCommandBufferService.Execute(new FillCellCommand(cell, cell.Cell.State));
                    }

                    break;

                case PlayerState.Cross:

                    if (cell.Cell.State != CellState.Crossed && cell.Cell.State != CellState.Filled)
                    {
                        _editorCommandBufferService.Execute(new CrossCellCommand(cell, cell.Cell.State));
                    }

                    break;

                case PlayerState.EmptyFill:

                    if (cell.Cell.State == CellState.Filled)
                    {
                        _editorCommandBufferService.Execute(new EmptyCellCommand(cell, cell.Cell.State));
                    }

                    break;


                case PlayerState.EmptyCross:

                    if (cell.Cell.State == CellState.Crossed)
                    {
                        _editorCommandBufferService.Execute(new EmptyCellCommand(cell, cell.Cell.State));
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private enum PlayerState : byte
        {
            None = 0,
            Fill = 1,
            Cross = 2,
            EmptyFill = 3,
            EmptyCross = 4
        }

        private enum PaintDirection : byte
        {
            None = 0,
            Vertical = 1,
            Horizontal = 2
        }
    }
}