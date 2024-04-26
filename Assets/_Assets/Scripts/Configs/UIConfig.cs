using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "UI Config", menuName = "Configs/UI")]
    public class UIConfig : ScriptableObject
    {
        [SerializeField] private GameObject loadingUI;
        [SerializeField] private GameObject mainMenuUI;
        [SerializeField] private GameObject optionsUI;
        [SerializeField] private GameObject editorUI;
        [SerializeField] private GameObject gameUI;
        public GameObject LoadingUI => loadingUI;
        public GameObject MainMenuUI => mainMenuUI;
        public GameObject OptionsUI => optionsUI;
        public GameObject EditorUI => editorUI;
        public GameObject GameUI => gameUI;
    }
}