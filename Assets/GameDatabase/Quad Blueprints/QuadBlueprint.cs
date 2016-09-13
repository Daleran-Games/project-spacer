using UnityEngine;
using System.Collections;

namespace ProjectSpacer
{
    //Blueprints are immutable data structures that hold information on how to create the mutable more robust versions of themselves.
    public class QuadBlueprint
    {
        QuadShape _quadShape;
        public QuadShape Shape
        {
            get { return _quadShape; }
            protected set { _quadShape = value; }
        }

        Direction _quadDirection;
        public Direction QuadDirection
        {
            get { return _quadDirection; }
            protected set { _quadDirection = value; }
        }

        UVBlueprint _quadUV;
        public UVBlueprint QuadUV
        {
            get { return _quadUV; }
            protected set { _quadUV = value; }
        }

        MeshLayer _quadMeshLayer;
        public MeshLayer QuadMeshLayer
        {
            get { return _quadMeshLayer; }
            protected set { _quadMeshLayer = value; }
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