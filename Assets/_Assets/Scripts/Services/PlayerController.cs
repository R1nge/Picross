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

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var rayHit = Physics2D.GetRayIntersection(camera.ScreenPointToRay(Input.mousePosition));

                if (rayHit.collider != null)
                {
                    var cell = rayHit.collider.GetComponent<CellView>();
                    if (cell != null)
                    {
                        var command = new FillCellCommand(cell, cell.Cell.State);
                        _editorCommandBufferService.Execute(command);
                    }
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                var rayHit = Physics2D.GetRayIntersection(camera.ScreenPointToRay(Input.mousePosition));

                if (rayHit.collider != null)
                {
                    var cell = rayHit.collider.GetComponent<CellView>();
                    if (cell != null)
                    {
                        var command = new CrossCellCommand(cell, cell.Cell.State);
                        _editorCommandBufferService.Execute(command);
                    }
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
    }
}