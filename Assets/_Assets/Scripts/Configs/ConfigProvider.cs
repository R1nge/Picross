using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private PicrossConfig picrossConfig;
        public UIConfig UIConfig => uiConfig;
        public GameConfig GameConfig => gameConfig;
        public PicrossConfig PicrossConfig => picrossConfig;
    }
}