namespace _Assets.Scripts.Services.LevelEditor.Commands
{
    public interface IEditorCommand
    {
        void Execute();
        void Undo();
    }
}