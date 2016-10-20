using UnityEngine;

namespace ProjectSpacer.Database
{
    [System.Serializable]
    public class UVLayerDEType4
    {
        public UVLayerDatabaseEntry[] Corner;
        public UVLayerDatabaseEntry[] Edge;
        public UVLayerDatabaseEntry[] Inverse;
        public UVLayerDatabaseEntry[] Interior;
    }
}
