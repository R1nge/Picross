using System;
using _Assets.Scripts.Services.UIs.LevelEditor;
using _Assets.Scripts.Services.UIs.StateMachine.States;

namespace _Assets.Scripts.Services.UIs.StateMachine
{
    public class UIStatesFactory
    {
        private readonly UIFactory _uiFactory;
        private readonly LevelEditorController _levelEditorController;

        private UIStatesFactory(UIFactory uiFactory, LevelEditorController levelEditorController)
        {
            _uiFactory = uiFactory;
            _levelEditorController = levelEditorController;
        }

        public IAsyncState CreateState(UIStateType uiStateType, UIStateMachine uiStateMachine)
        {
            switch (uiStateType)
            {
                case UIStateType.Loading:
                    return new UILoadingState(_uiFactory, uiStateMachine);
                case UIStateType.MainMenu:
                    return new UIMainMenuState(_uiFactory);
                case UIStateType.Options:
                    return new UIOptionsState(_uiFactory);
                case UIStateType.Editor:
                    return new UIEditorState(_uiFactory, _levelEditorController);
                case UIStateType.Game:
                    return new UIGameState(_uiFactory);
                default:
                    throw new ArgumentOutOfRangeException(nameof(uiStateType), uiStateType, null);
            }
        }
    }
}