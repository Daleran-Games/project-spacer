using UnityEngine;
using System.Collections;

namespace ProjectSpacer.Database
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "NewModuleTile", menuName = "Database/Tiles/Module", order = 2)]
    public class ModuleDatabaseEntry : ScriptableObject
    {
 
        public InfoDatabaseEntry ModuleInfo;
        public bool OverrideHullShape = false;
        public CollisionLayer ModuleCollision;
        public Type4[] AllowableSites;

        public QuadDatabaseEntry[] Quads;
        public StatBaseDatabaseEntry[] ModuleStats;
        public EffectDatabaseEntry[] Effects;

        public ModuleDatabaseEntry(InfoDatabaseEntry moduleInfo, bool overrideShape, CollisionLayer col, QuadDatabaseEntry[] quads, StatBaseDatabaseEntry[] stats)
        {
            ModuleInfo = moduleInfo;
            OverrideHullShape = overrideShape;

            ModuleCollision = col;
            Quads = quads;
            ModuleStats = stats;
        }

        public ModuleDatabaseEntry(InfoDatabaseEntry moduleInfo, bool overrideShape, CollisionLayer col, QuadDatabaseEntry[] quads, StatBaseDatabaseEntry[] stats, EffectDatabaseEntry[] effects)
        {
            ModuleInfo = moduleInfo;
            OverrideHullShape = overrideShape;

            ModuleCollision = col;
            Quads = quads;
            ModuleStats = stats;
            Effects = effects;

        }
    }

}
