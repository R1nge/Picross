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

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _playerState = PlayerState.Fill;
            }

            if (Input.GetMouseButtonDown(1))
            {
                _playerState = PlayerState.Cross;
            }

            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                var rayHit = Physics2D.GetRayIntersection(camera.ScreenPointToRay(Input.mousePosition));

                if (rayHit.collider == null)
                {
                    return;
                }

                var cell = rayHit.collider.GetComponent<CellView>();

                if (cell == null)
                {
                    return;
                }

                switch (_playerState)
                {
                    case PlayerState.None:
                        break;
                    case PlayerState.Fill:
                        _editorCommandBufferService.Execute(new FillCellCommand(cell, cell.Cell.State));
                        break;
                    case PlayerState.Cross:
                        _editorCommandBufferService.Execute(new CrossCellCommand(cell, cell.Cell.State));
                        break;
                    case PlayerState.Empty:
                        _editorCommandBufferService.Execute(new EmptyCellCommand(cell, cell.Cell.State));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

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
        }

        private enum PlayerState : byte
        {
            None = 0,
            Fill = 1,
            Cross = 2,
            Empty = 3
        }
    }
}