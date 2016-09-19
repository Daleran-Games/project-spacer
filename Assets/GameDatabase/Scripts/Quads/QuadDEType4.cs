using UnityEngine;

namespace ProjectSpacer.Database
{
    [System.Serializable]
    public class QuadDEType4
    {
        public QuadDatabaseEntry[] Corner;
        public QuadDatabaseEntry[] Edge;
        public QuadDatabaseEntry[] Inverse;
        public QuadDatabaseEntry[] Interior;
    }
}
