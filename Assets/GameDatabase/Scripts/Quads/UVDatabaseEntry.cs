using UnityEngine;

namespace ProjectSpacer.Database
{
    [System.Serializable]
    public class UVDatabaseEntry
    {
        public Vector2Int UV = Vector2Int.zero;
        public bool Colorable = false;
        public bool FlipAcrossX = false;

        public UVDatabaseEntry(Vector2Int newUV)
        {
            UV = newUV;
            Colorable = false;
            FlipAcrossX = false;
        }

        public UVDatabaseEntry(Vector2Int newUV, bool colorable, bool flipAcrossX)
        {
            UV = newUV;
            Colorable = colorable;
            FlipAcrossX = flipAcrossX;
        }

    }
}