using UnityEngine;
using System.Collections.Generic;
using DalLib.Math;

namespace ProjectSpacer
{
    public class Tile
    {
        public Info TileInfo = GV.defaultInfo;

        public Type4 TileQuad4Type = Type4.INTERIOR;
        public Direction TileDirection = Direction.Up;

        /*
        public HullSubTile TileHull;
        public ArmorSubTile TileArmor;
        public ModuleSubTile TileModule;
        */

        public Vector2Int GridCoordinate = Vector2Int.zero;

        public Tile NorthTile;
        public Tile EastTile;
        public Tile WestTile;
        public Tile SouthTile;

        public Tile(Info info, Direction direct, bool flipUV, CollisionLayer colLayer, StatCollection stats, List<QuadData> quads, List<GameObject> effects)
        {

            TileInfo = info;

        }

        public CollisionLayer GetMaxCollisionLayer ()
        {
            return CollisionLayer.FLOOR;
        }

        public bool ContainsStat<T> ()
        {
            return true;
        }

        public SubTile GetSubTileWithStat<T>()
        {
            return null;
        }

        public SubTile[] GetSubTilesWithStat<T>()
        {
            return null;
        }

        public T GetTotalStat<T> () where T : IStat
        {
            return default(T);
        }

        public MeshData GetMeshData (Vector2Int pos)
        {
            return null;
        }

        public bool ContainsEffects ()
        {
            return false;
        }

    }
}
