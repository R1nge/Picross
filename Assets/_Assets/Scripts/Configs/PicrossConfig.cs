using System;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Picross", menuName = "Configs/Picross")]
    public class PicrossConfig : ScriptableObject
    {
        [SerializeField] private Size[] sizes;
        public int SizeCount => sizes.Length;

        public Size? GetSize(int index)
        {
            if (index < 0 || index >= sizes.Length)
            {
                Debug.LogError($"Index out of range: {index}");
                return null;
            }
            
            return sizes[index];
        }
    }

    [Serializable]
    public struct Size
    {
        public int width;
        public int height;

        public Size(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }
}