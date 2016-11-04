using UnityEngine;

namespace ProjectSpacer.Database
{
    [System.Serializable]
    public class TileDatabaseEntry
    {
        public ArmorDatabaseEntry Armor;
        public HullDatabaseEntry Hull;
        public ModuleDatabaseEntry Module;
        public Type4 TileType4;
        public Direction ModuleDirection;
        public Color32 TileColor;
    }
}
