using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Services.UIs.LevelEditor
{
    public class LevelEditorView : MonoBehaviour
    {
        [SerializeField] private Dropdown sizes;
        [SerializeField] private Button saveButton;
        public Button SaveButton => saveButton;
    }
}