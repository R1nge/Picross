using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Services.UIs.LevelEditor
{
    public class LevelEditorView : MonoBehaviour
    {
        [SerializeField] private Dropdown sizes;
        [SerializeField] private Button saveButton;
        [SerializeField] private Button loadButton;
        [SerializeField] private TMP_Dropdown dropdown;
        public Button SaveButton => saveButton;
        public Button LoadButton => loadButton;
        public TMP_Dropdown Dropdown => dropdown;
    }
}