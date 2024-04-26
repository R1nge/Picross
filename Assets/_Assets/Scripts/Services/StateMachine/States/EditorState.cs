using _Assets.Scripts.Services.UIs.StateMachine;
using Cysharp.Threading.Tasks;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class EditorState : IAsyncState
    {
        private readonly UIStateMachine _uiStateMachine;

        public EditorState(UIStateMachine uiStateMachine)
        {
            _uiStateMachine = uiStateMachine;
        }

        public async UniTask Enter()
        {
            await _uiStateMachine.SwitchState(UIStateType.Editor);
        }

        public async UniTask Exit()
        {
        }
    }
}