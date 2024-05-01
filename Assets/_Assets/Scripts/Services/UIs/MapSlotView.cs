using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Services.UIs
{
    public class MapSlotView : MonoBehaviour
    {
        [SerializeField] private Button selectButton;
        [SerializeField] private TextMeshProUGUI levelName;
        
        public Button SelectButton => selectButton;
        public TextMeshProUGUI LevelName => levelName;
    }
}