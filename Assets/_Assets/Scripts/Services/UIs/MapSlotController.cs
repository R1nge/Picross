using _Assets.Scripts.Services.Gameplay;

namespace _Assets.Scripts.Services.UIs
{
    public class MapSlotController
    {
        private readonly GameService _gameService;
        private MapSlotView _view;
        
        private MapSlotController(GameService gameService)
        {
            _gameService = gameService;
        }
        
        public void Init(MapSlotView mapSlotView)
        {
            _view = mapSlotView;
            
            _view.SelectButton.onClick.AddListener(Select);
            
        }

        private void Select()
        {
            //_gameService.Init();
        }

        public void Dispose()
        {
            _view.SelectButton.onClick.RemoveListener(Select);
        }
    }
}