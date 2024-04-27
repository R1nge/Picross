using _Assets.Scripts.Services.Grids;
using _Assets.Scripts.Services.LevelEditor;
using _Assets.Scripts.Services.Saves;

namespace _Assets.Scripts.Services.UIs.LevelEditor
{
    public class LevelEditorController
    {
        private readonly LevelSaveService _levelSaveService;
        private readonly LevelEditorService _levelEditorService;
        private LevelEditorView _levelEditorView;
        private Grid _grid;

        private LevelEditorController(LevelSaveService levelSaveService, LevelEditorService levelEditorService)
        {
            _levelSaveService = levelSaveService;
            _levelEditorService = levelEditorService;
        }

        public void Init(LevelEditorView levelEditorView)
        {
            _levelEditorView = levelEditorView;
            _levelEditorView.SaveButton.onClick.AddListener(Save);
            _levelEditorView.LoadButton.onClick.AddListener(Load);
        }

        private void Save()
        {
            _levelEditorService.Save();
        }

        private void Load()
        {
            _levelEditorService.Load();
        }
    }
}