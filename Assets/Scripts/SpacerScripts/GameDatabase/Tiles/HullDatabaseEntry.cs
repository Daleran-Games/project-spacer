using UnityEngine;
using System.Collections;


namespace ProjectSpacer.Database
{
    [CreateAssetMenu(fileName = "NewHullTile", menuName = "Database/Tiles/Hull", order = 0)]
    public class HullDatabaseEntry : ScriptableObject
    {
        public InfoDatabaseEntry HullInfo;
        public CollisionLayerType4 HullCollision;
        public QuadDEType4 Quads;
        public StatBaseDatabaseEntry[] HullStats;


        public HullDatabaseEntry(InfoDatabaseEntry hullInfo, CollisionLayerType4 col, StatBaseDatabaseEntry[] stats, QuadDEType4 quads)
        {
            HullInfo = hullInfo;
            HullCollision = col;
            Quads = quads;
            HullStats = stats;
        }

    }
}

