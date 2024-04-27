using System;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.LevelEditor;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;
using _Assets.Scripts.Services.UIs.StateMachine.States;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly GridViewFactory _gridViewFactory;
        private readonly LevelEditorService _levelEditorService;

        private GameStatesFactory(UIStateMachine uiStateMachine, GridViewFactory gridViewFactory, LevelEditorService levelEditorService)
        {
            _uiStateMachine = uiStateMachine;
            _gridViewFactory = gridViewFactory;
            _levelEditorService = levelEditorService;
        }

        public IAsyncState CreateAsyncState(GameStateType gameStateType, GameStateMachine gameStateMachine)
        {
            switch (gameStateType)
            {
                case GameStateType.Init:
                    return new InitState(gameStateMachine, _uiStateMachine);
                case GameStateType.Game:
                    return new GameState(gameStateMachine, _gridViewFactory);
                case GameStateType.Editor:
                    return new EditorState(_uiStateMachine, _levelEditorService);
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null);
            }
        }
    }
}