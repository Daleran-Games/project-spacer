using UnityEngine;
using System;
using System.Collections;
using DalLib.Math;

namespace ProjectSpacer.Database
{
    [System.Serializable]
    public class QuadDatabaseEntry
    { 

        public QuadShape Shape = QuadShape.FLAT;
        public Direction QuadDirection = Direction.Up;
        public MeshLayer QuadMeshLayer = MeshLayer.GRID_FLOOR;
        public UVDatabaseEntry QuadUV = new UVDatabaseEntry(Vector2Int.zero);



        public QuadDatabaseEntry(QuadShape qShape, UVDatabaseEntry uv, MeshLayer layer)
        {
            Shape = qShape;
            QuadDirection = Direction.Up;
            QuadUV = uv;
            QuadMeshLayer = layer;
        }

        public QuadDatabaseEntry(QuadShape qShape, Direction qDirection, UVDatabaseEntry uv, MeshLayer layer)
        {
            Shape = qShape;
            QuadDirection = qDirection;
            QuadUV = uv;
            QuadMeshLayer = layer;

        }
    }
}