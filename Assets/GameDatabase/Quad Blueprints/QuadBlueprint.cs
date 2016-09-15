using UnityEngine;
using System.Collections;

namespace ProjectSpacer
{
    //Blueprints are immutable data structures that hold information on how to create the mutable more robust versions of themselves.
    [System.Serializable]
    public class QuadBlueprint
    {
        QuadShape _quadShape = QuadShape.FLAT;
        public QuadShape Shape 
        {
            get { return _quadShape; }
            protected set { _quadShape = value; }
        }

        Direction _quadDirection = Direction.UP;
        public Direction QuadDirection
        {
            get { return _quadDirection; }
            protected set { _quadDirection = value; }
        }

        UVBlueprint _quadUV = new UVBlueprint(Vector2Int.zero, false, false);
        public UVBlueprint QuadUV
        {
            get { return _quadUV; }
            protected set { _quadUV = value; }
        }

        MeshLayer _quadMeshLayer = MeshLayer.GRID_FLOOR;
        public MeshLayer QuadMeshLayer
        {
            get { return _quadMeshLayer; }
            protected set { _quadMeshLayer = value; }
        }

        public QuadBlueprint(QuadShape qShape, UVBlueprint uv, MeshLayer layer)
        {
            Shape = qShape;
            QuadUV = uv;
            QuadMeshLayer = layer;
        }

        public QuadBlueprint(QuadShape qShape, Direction qDirection, UVBlueprint uv, MeshLayer layer)
        {
            Shape = qShape;
            QuadDirection = qDirection;
            QuadUV = uv;
            QuadMeshLayer = layer;

        }
    }
}