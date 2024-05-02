using System;

namespace _Assets.Scripts.Services.Saves
{
    public interface ILevelLoader
    {
        void Save(LevelData levelData);
        void Load(string levelName);
        event Action<LevelData> OnLevelLoaded; 
    }
}