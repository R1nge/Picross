using _Assets.Scripts.Configs;
using _Assets.Scripts.Services.LevelEditor;
using _Assets.Scripts.Services.UIs.StateMachine;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using Grid = _Assets.Scripts.Services.Grids.Grid;

namespace _Assets.Scripts.Services.UIs.LevelEditor
{
    public class LevelEditorController
    {
        private readonly LevelEditorService _levelEditorService;
        private readonly ConfigProvider _configProvider;
        private LevelEditorView _levelEditorView;
        private UIStateMachine _uiStateMachine;
        private Grid _grid;


        private LevelEditorController(LevelEditorService levelEditorService, ConfigProvider configProvider)
        {
            _levelEditorService = levelEditorService;
            _configProvider = configProvider;
        }

        public void Init(LevelEditorView levelEditorView, UIStateMachine uiStateMachine)
        {
            _uiStateMachine = uiStateMachine;
            
            _levelEditorView = levelEditorView;
            _levelEditorView.SaveButton.onClick.AddListener(Save);
            _levelEditorView.LoadButton.onClick.AddListener(Load);

            _levelEditorView.Sizes.options.Clear();

            for (int i = 0; i < _configProvider.PicrossConfig.SizeCount; i++)
            {
                var width = _configProvider.PicrossConfig.GetSize(i).Value.width;
                var height = _configProvider.PicrossConfig.GetSize(i).Value.height;

                _levelEditorView.Sizes.options.Add(new TMP_Dropdown.OptionData($"{width}x{height}"));
            }

            _levelEditorView.Sizes.onValueChanged.AddListener(SizeChanged);
            _levelEditorView.MainMenuButton.onClick.AddListener(SwitchToMainMenu);
        }

        private void SwitchToMainMenu() => _uiStateMachine.SwitchState(UIStateType.MainMenu).Forget();

        private void SizeChanged(int index)
        {
            var size = _configProvider.PicrossConfig.GetSize(index);

            if (size != null)
            {
                _levelEditorService.ChangeSize(size.Value);
            }
        }

        private void Save()
        {
            var levelName = _levelEditorView.LevelName.text;

            if (!LevelNameIsEmpty(levelName))
            {
                _levelEditorService.Save(levelName);
            }
        }

        private void LoadAll(int maxCount)
        {
            
        }

        private void Load()
        {
            var levelName = _levelEditorView.LevelName.text;

            if (!LevelNameIsEmpty(levelName))
            {
                _levelEditorService.Load(levelName);
            }
        }

        private bool LevelNameIsEmpty(string levelName)
        {
            if (string.IsNullOrEmpty(levelName) || string.IsNullOrWhiteSpace(levelName))
            {
                Debug.LogError("Level name is empty");
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            if (_levelEditorView != null)
            {
                _levelEditorView.SaveButton.onClick.RemoveListener(Save);
                _levelEditorView.LoadButton.onClick.RemoveListener(Load);
                _levelEditorView.Sizes.onValueChanged.RemoveListener(SizeChanged);
                _levelEditorView.MainMenuButton.onClick.RemoveListener(SwitchToMainMenu);
            }
            
            _levelEditorService.Dispose();
        }
    }
}