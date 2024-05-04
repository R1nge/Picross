using System;
using System.IO;
using UnityEngine;

namespace _Assets.Scripts.Misc
{
    public static class GameConstants
    {
        public enum Paths
        {
            ModsFolder,
        }

        public static string GetPath(Paths path)
        {
            switch (path)
            {
                case Paths.ModsFolder:
                    var modsPath = $"{Application.persistentDataPath}/Mods/";
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