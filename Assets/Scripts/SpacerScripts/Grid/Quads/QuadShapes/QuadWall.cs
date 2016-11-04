using UnityEngine;
using DalLib.Math;

namespace ProjectSpacer
{
    public class QuadWall : QuadData
    {
        public QuadWall(MeshLayer quadLayer, QuadShape quadShape, Vector2Int quadTileAtlasCoord, Direction quadDirection, bool flipUV, bool isColorable, Color32 quadColor)
        {
            BuildQuad(quadLayer, quadShape, quadTileAtlasCoord, quadDirection, flipUV, isColorable, quadColor);
        }

        protected override void BuildVertices()
        {
            vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize));
            vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer));
            vertices.Add(new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer));
            vertices.Add(new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize));
        }

    }
}

