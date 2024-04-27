using System;
using System.IO;
using _Assets.Scripts.Services.Grids;
using Newtonsoft.Json;
using UnityEngine;

namespace _Assets.Scripts.Services.Saves
{
    public class LevelSaveService
    {
        public LevelData LevelData { get; private set; }

        public event Action<LevelData> OnLevelLoaded;

        public void Save(Cell[,] cells, string levelName)
        {
            LevelData = new LevelData
            {
                Cells = cells,
                LevelName = levelName
            };

            var json = JsonConvert.SerializeObject(LevelData);
            File.WriteAllText($"{Application.persistentDataPath}/{levelName}.json", json);
        }

        public void Load(string levelName)
        {
            var data = File.ReadAllText($"{Application.persistentDataPath}/{levelName}.json");
            LevelData = JsonConvert.DeserializeObject<LevelData>(data);
            OnLevelLoaded?.Invoke(LevelData);
        }
    }

    [Serializable]
    public struct LevelData
    {
        public Cell[,] Cells;
        public string LevelName;

        public LevelData(Cell[,] cells, string levelName)
        {
            Cells = cells;
            LevelName = levelName;
        }
    }
}