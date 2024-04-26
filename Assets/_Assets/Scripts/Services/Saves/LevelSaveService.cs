using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using Grid = _Assets.Scripts.Services.Grids.Grid;

namespace _Assets.Scripts.Services.Saves
{
    public class LevelSaveService
    {
        public void Save(Grid grid, string levelName)
        {
            var data = new LevelData
            {
                Grid = grid,
                LevelName = levelName
            };

            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText($"{Application.persistentDataPath}/{levelName}.json", json);
        }

        public void Load()
        {
            Debug.Log("Load");
        }
    }

    [Serializable]
    public struct LevelData
    {
        public Grid Grid;
        public string LevelName;
    }
}