using _Assets.Scripts.Services.Grids;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Game Config", menuName = "Configs/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private GridView gridPrefab;
        [SerializeField] private CellView cellPrefab;
        
        public GridView GridPrefab => gridPrefab;
        public CellView CellPrefab => cellPrefab;
    }
}