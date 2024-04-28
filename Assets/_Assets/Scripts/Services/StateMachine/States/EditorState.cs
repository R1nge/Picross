using _Assets.Scripts.Services.LevelEditor;
using _Assets.Scripts.Services.UIs.StateMachine;
using Cysharp.Threading.Tasks;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class EditorState : IAsyncState
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly LevelEditorService _levelEditorService;

        public EditorState(UIStateMachine uiStateMachine, LevelEditorService levelEditorService)
        {
            _uiStateMachine = uiStateMachine;
            _levelEditorService = levelEditorService;
        }

        public async UniTask Enter()
        {
            await _uiStateMachine.SwitchState(UIStateType.Editor);
            //TODO: config with presets
            _levelEditorService.Init();
        }

        public async UniTask Exit()
        {
        }
    }
}