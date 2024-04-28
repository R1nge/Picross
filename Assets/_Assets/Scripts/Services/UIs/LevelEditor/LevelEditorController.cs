using System.Collections.Generic;
using _Assets.Scripts.Configs;
using _Assets.Scripts.Services.LevelEditor;
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
        private Grid _grid;

        private LevelEditorController(LevelEditorService levelEditorService, ConfigProvider configProvider)
        {
            _levelEditorService = levelEditorService;
            _configProvider = configProvider;
        }

        public void Init(LevelEditorView levelEditorView)
        {
            _levelEditorView = levelEditorView;
            _levelEditorView.SaveButton.onClick.AddListener(Save);
            _levelEditorView.LoadButton.onClick.AddListener(Load);
            
            _levelEditorView.Dropdown.options.Clear();

            for (int i = 0; i < _configProvider.PicrossConfig.SizeCount; i++)
            {
                var width = _configProvider.PicrossConfig.GetSize(i).Value.width;
                var height = _configProvider.PicrossConfig.GetSize(i).Value.height;

                _levelEditorView.Dropdown.options.Add(new TMP_Dropdown.OptionData($"{width}x{height}"));
            }

            _levelEditorView.Dropdown.onValueChanged.AddListener(SizeChanged);
        }

        private void SizeChanged(int index)
        {
            Debug.Log("Size changed: " + index);
            var size = _configProvider.PicrossConfig.GetSize(index);

            if (size != null)
            {
                _levelEditorService.ChangeSize(size.Value);
            }
        }

        private void Save() => _levelEditorService.Save();

        private void Load() => _levelEditorService.Load();
    }
}