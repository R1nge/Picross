using System;
using System.IO;
using _Assets.Scripts.Configs;
using _Assets.Scripts.Misc;
using _Assets.Scripts.Services.Grids;
using Newtonsoft.Json;
using UnityEngine;

namespace _Assets.Scripts.Services.Saves
{
    public class LevelSaveService
    {
        public LevelData LevelData { get; private set; }

        public event Action<LevelData> OnLevelLoaded;

        public void Save(LevelData levelData)
        {
            LevelData = levelData;
            var json = JsonConvert.SerializeObject(LevelData);
            File.WriteAllText($"{GameConstants.GetPath(GameConstants.Paths.ModsFolder)}{levelData.LevelName}.json", json);
        }

        public void Load(string levelName)
        {
            var data = File.ReadAllText($"{GameConstants.GetPath(GameConstants.Paths.ModsFolder)}{levelName}.json");
            LevelData = JsonConvert.DeserializeObject<LevelData>(data);
            OnLevelLoaded?.Invoke(LevelData);
        }
    }

    [Serializable]
    public struct LevelData
    {
        public Cell[,] Cells;
        public Size Size;
        public string LevelName;

        public LevelData(Cell[,] cells, Size size, string levelName)
        {
            Cells = cells;
            Size = size;
            LevelName = levelName;
        }
    }
}