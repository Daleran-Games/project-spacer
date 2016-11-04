using UnityEngine;
using System.Collections;
using DalLib.Math;

namespace ProjectSpacer
{
    public class QuadCornerUp : QuadData
    {
        public QuadCornerUp(MeshLayer quadLayer, QuadShape quadShape, Vector2Int quadTileAtlasCoord, Direction quadDirection, bool flipUV, bool isColorable, Color32 quadColor)
        {
            BuildQuad(quadLayer, quadShape, quadTileAtlasCoord, quadDirection, flipUV, isColorable, quadColor);
        }

        protected override void BuildVertices()
        {
            vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer - GV.tileSize));
            vertices.Add(new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer - GV.tileSize));
            vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer - GV.tileSize));
            vertices.Add(new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer));
        }



    }
}

