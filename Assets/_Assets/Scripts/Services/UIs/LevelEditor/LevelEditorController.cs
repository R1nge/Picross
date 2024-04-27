using _Assets.Scripts.Services.Grids;
using _Assets.Scripts.Services.LevelEditor;

namespace _Assets.Scripts.Services.UIs.LevelEditor
{
    public class LevelEditorController
    {
        private readonly LevelEditorService _levelEditorService;
        private LevelEditorView _levelEditorView;
        private Grid _grid;

        private LevelEditorController(LevelEditorService levelEditorService)
        {
            _levelEditorService = levelEditorService;
        }

        public void Init(LevelEditorView levelEditorView)
        {
            _levelEditorView = levelEditorView;
            _levelEditorView.SaveButton.onClick.AddListener(Save);
            _levelEditorView.LoadButton.onClick.AddListener(Load);
        }

        private void Save() => _levelEditorService.Save();

        private void Load() => _levelEditorService.Load();
    }
}