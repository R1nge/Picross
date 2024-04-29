using System;
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
                    return $"{Application.persistentDataPath}/";
                default:
                    throw new ArgumentOutOfRangeException(nameof(path), path, null);
            }
        }
    }
}