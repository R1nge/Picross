using System;
using System.IO;
using UnityEngine;

namespace _Assets.Scripts.Misc
{
    public static class GameConstants
    {
        public enum Paths
        {
            MapsFolder,
        }

        public static string GetPath(Paths path)
        {
            switch (path)
            {
                case Paths.MapsFolder:
                    var modsPath = $"{Application.persistentDataPath}/Maps/";
                    if (File.Exists(modsPath))
                    {
                        return modsPath;
                    }

                    Directory.CreateDirectory(modsPath);
                    return modsPath;

                default:
                    throw new ArgumentOutOfRangeException(nameof(path), path, null);
            }
        }
    }
}