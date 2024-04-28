using _Assets.Scripts.Services.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Assets.Scripts.Services.UIs.MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button levelEditorButton;
        [Inject] private GameStateMachine _gameStateMachine;

        private void Start()
        {
           levelEditorButton.onClick.AddListener(LevelEditor); 
        }

        private void LevelEditor()
        {
            _gameStateMachine.SwitchState(GameStateType.Editor).Forget();
        }

        private void OnDestroy()
        {
            levelEditorButton.onClick.RemoveListener(LevelEditor);
        }
    }
}