using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProjectSpacer.Database
{
    [CreateAssetMenu(fileName = "NewArmorTile", menuName = "Database/Tiles/Armor", order = 1)]
    public class ArmorDatabaseEntry : ScriptableObject
    {

        public InfoDatabaseEntry ArmorInfo;
        public UVLayerDEType4 UVs;
        public StatBaseDatabaseEntry[] ArmorStats;


        public ArmorDatabaseEntry(InfoDatabaseEntry armorInfo, StatBaseDatabaseEntry[] stats, UVLayerDEType4 uvs)
        {
            ArmorInfo = armorInfo;
            UVs = uvs;
            ArmorStats = stats;

        }

    }
}
