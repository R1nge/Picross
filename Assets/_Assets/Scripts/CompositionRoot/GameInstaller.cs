using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.LevelEditor;
using _Assets.Scripts.Services.Saves;
using _Assets.Scripts.Services.StateMachine;
using _Assets.Scripts.Services.UIs;
using _Assets.Scripts.Services.UIs.LevelEditor;
using _Assets.Scripts.Services.UIs.StateMachine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class GameInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<LevelEditorService>(Lifetime.Singleton);
            builder.Register<LevelSaveService>(Lifetime.Singleton);
            
            builder.Register<LevelEditorController>(Lifetime.Singleton);
            
            builder.Register<GridCompleteService>(Lifetime.Singleton);
            
            builder.Register<CellViewFactory>(Lifetime.Singleton);
            builder.Register<GridViewFactory>(Lifetime.Singleton);
            
            builder.Register<UIStatesFactory>(Lifetime.Singleton);
            builder.Register<UIStateMachine>(Lifetime.Singleton);
            builder.Register<UIFactory>(Lifetime.Singleton);
            
            builder.Register<GameStatesFactory>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton);
        }
    }
}