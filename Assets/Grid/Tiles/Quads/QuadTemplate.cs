using UnityEngine;

namespace ProjectSpacer
{

    [CreateAssetMenu(fileName = "NewQuad", menuName = "Data/Templates/Quad Template", order = 1)]
    public class QuadTemplate : ScriptableObject
    {
        public MeshLayer layer;
        public QuadShape shape;
        public Vector2Int atlasCoord;
        public bool colorable;

        public QuadData BuildQuad(Direction initialDirection, bool flipUV, Color32 color)
        {

            switch (shape)
            {
              
                case QuadShape.FLAT:
                    return new QuadData(layer, shape, atlasCoord, initialDirection, flipUV,colorable,color);
                case QuadShape.CORNER:
                     return new QuadCorner(layer, shape, atlasCoord, initialDirection, flipUV, colorable, color);
                case QuadShape.CORNER_DOWN:
                    return new QuadCornerDown(layer, shape, atlasCoord, initialDirection, flipUV, colorable, color);
                case QuadShape.CORNER_UP:
                     return new QuadCornerUp(layer, shape, atlasCoord, initialDirection, flipUV, colorable, color);
                case QuadShape.INVERSE_DOWN:
                     return new QuadInverseDown(layer, shape, atlasCoord, initialDirection, flipUV, colorable, color);
                case QuadShape.INVERSE_UP:
                     return new QuadInverseUp(layer, shape, atlasCoord, initialDirection, flipUV, colorable, color);
                case QuadShape.WALL:
                     return new QuadWall(layer, shape, atlasCoord, initialDirection, flipUV, colorable, color);
                case QuadShape.WALL_CORNER:
                     return new QuadWallCorner(layer, shape, atlasCoord, initialDirection, flipUV, colorable, color);
                case QuadShape.SLOPE_DOWN:
                    return new QuadSlopeDown(layer, shape, atlasCoord, initialDirection, flipUV, colorable, color);
                case QuadShape.SLOPE_UP:
                    return new QuadSlopeUp(layer, shape, atlasCoord, initialDirection, flipUV, colorable, color);
                default:
                     return new QuadData(layer, shape, atlasCoord, initialDirection, flipUV, colorable, color);
            }

        }

    }
}
