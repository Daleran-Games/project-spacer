using UnityEngine;
using System.Collections;
using DalLib.Math;

namespace ProjectSpacer
{
    public class QuadCorner : QuadData
    {
        public QuadCorner(MeshLayer quadLayer, QuadShape quadShape, Vector2Int quadTileAtlasCoord, Direction quadDirection, bool flipUV, bool isColorable, Color32 quadColor)
        {
            BuildQuad(quadLayer, quadShape, quadTileAtlasCoord, quadDirection, flipUV, isColorable, quadColor);
        }

        protected override void BuildVertices()
        {
            vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer));
            vertices.Add(new Vector3(0f, 0f, zLayer));
            vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer));
            vertices.Add(new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer));
        }



    }
}

