using _Assets.Scripts.Services.Factories;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IAsyncState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly GridViewFactory _gridViewFactory;

        public GameState(GameStateMachine stateMachine, GridViewFactory gridViewFactory)
        {
            _stateMachine = stateMachine;
            _gridViewFactory = gridViewFactory;
        }

        public async UniTask Enter()
        {
            _gridViewFactory.CreateGrid(Vector3.zero, 20, 20);
        }

        public async UniTask Exit()
        {
        }
    }
}