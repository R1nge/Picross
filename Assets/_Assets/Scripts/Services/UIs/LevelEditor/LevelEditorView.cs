using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Services.UIs.LevelEditor
{
    public class LevelEditorView : MonoBehaviour
    {
        [SerializeField] private Button saveButton;
        [SerializeField] private Button loadButton;
        [SerializeField] private TMP_Dropdown sizes;
        [SerializeField] private TMP_InputField levelName;
        [SerializeField] private Button mainMenuButton;
        
        public Button SaveButton => saveButton;
        public Button LoadButton => loadButton;
        public TMP_Dropdown Sizes => sizes;
        public TMP_InputField LevelName => levelName;
        public Button MainMenuButton => mainMenuButton;
    }
}