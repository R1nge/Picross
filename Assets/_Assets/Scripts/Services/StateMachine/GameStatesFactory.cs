using System;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly GridViewFactory _gridViewFactory;

        private GameStatesFactory(UIStateMachine uiStateMachine, GridViewFactory gridViewFactory)
        {
            _uiStateMachine = uiStateMachine;
            _gridViewFactory = gridViewFactory;
        }

        public IAsyncState CreateAsyncState(GameStateType gameStateType, GameStateMachine gameStateMachine)
        {
            switch (gameStateType)
            {
                case GameStateType.Init:
                    return new InitState(gameStateMachine, _uiStateMachine);
                case GameStateType.Game:
                    return new GameState(gameStateMachine, _gridViewFactory);
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null);
            }
        }
    }
}