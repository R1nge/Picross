using _Assets.Scripts.Services.Grids;
using UnityEngine;

namespace _Assets.Scripts.Services
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private new Camera camera;

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
                        cell.SetState(CellState.Filled);
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
                        cell.SetState(CellState.Crossed);
                    }
                }
            }
        }
    }
}