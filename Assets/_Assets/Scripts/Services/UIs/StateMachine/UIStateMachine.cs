using System.Collections.Generic;

namespace _Assets.Scripts.Services.UIs.StateMachine
{
    public class UIStateMachine : GenericAsyncStateMachine<UIStateType, IAsyncState>
    {
        private UIStateMachine(UIStatesFactory uiStatesFactory)
        {
            States = new Dictionary<UIStateType, IAsyncState>
            {
                { UIStateType.Loading, uiStatesFactory.CreateState(UIStateType.Loading, this) },
                { UIStateType.MainMenu, uiStatesFactory.CreateState(UIStateType.MainMenu, this) },
                { UIStateType.Options, uiStatesFactory.CreateState(UIStateType.Options, this) },
                { UIStateType.Editor, uiStatesFactory.CreateState(UIStateType.Editor, this) },
                { UIStateType.Game, uiStatesFactory.CreateState(UIStateType.Game, this) }
            };
        }
    }
}