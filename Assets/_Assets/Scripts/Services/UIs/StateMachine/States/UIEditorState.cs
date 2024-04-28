using _Assets.Scripts.Services.UIs.LevelEditor;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs.StateMachine.States
{
    public class UIEditorState : IAsyncState
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly UIFactory _uiFactory;
        private readonly LevelEditorController _levelEditorController;
        private GameObject _ui;

        public UIEditorState(UIStateMachine uiStateMachine, UIFactory uiFactory,
            LevelEditorController levelEditorController)
        {
            _uiStateMachine = uiStateMachine;
            _uiFactory = uiFactory;
            _levelEditorController = levelEditorController;
        }

        public async UniTask Enter()
        {
            _ui = _uiFactory.CreateUI(UIStateType.Editor);
            _levelEditorController.Init(_ui.GetComponent<LevelEditorView>(), _uiStateMachine);
        }

        public async UniTask Exit()
        {
            _levelEditorController.Dispose();
            Object.Destroy(_ui.gameObject);
        }
    }
}