using UnityEngine;

namespace ProjectSpacer.Database
{
    [System.Serializable]
    public class UVLayerDatabaseEntry : UVDatabaseEntry
    {

        public MeshLayer UVLayer = MeshLayer.GRID_FLOOR;

        public UVLayerDatabaseEntry(Vector2Int newUV, MeshLayer layer) : base(newUV)
        {
            UV = newUV;
            Colorable = false;
            FlipAcrossX = false;
            UVLayer = layer;
        }

        public UVLayerDatabaseEntry(Vector2Int newUV, bool colorable, bool flipAcrossX, MeshLayer layer) : base (newUV,colorable,flipAcrossX)
        {
            UV = newUV;
            Colorable = colorable;
            FlipAcrossX = flipAcrossX;
            UVLayer = layer;
        }

    }
}