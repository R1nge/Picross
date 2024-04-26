using System;
using _Assets.Scripts.Services.Factories;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Assets.Scripts.Services.UIs.LevelEditor
{
    public class LevelEditorView : MonoBehaviour
    {
        [SerializeField] private Dropdown sizes;
        [Inject] private GridViewFactory _gridViewFactory;
        private LevelEditorController _levelEditorController;

        private void Start()
        {
            _levelEditorController = new LevelEditorController(_gridViewFactory);
            _levelEditorController.Init();
        }
    }
}