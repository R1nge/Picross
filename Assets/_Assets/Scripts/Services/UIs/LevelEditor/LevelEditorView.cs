using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Services.UIs.LevelEditor
{
    public class LevelEditorView : MonoBehaviour
    {
        [SerializeField] private Dropdown sizes;
        [SerializeField] private Button saveButton;
        [SerializeField] private Button loadButton;
        public Button SaveButton => saveButton;
        public Button LoadButton => loadButton;
    }
}