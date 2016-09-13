using UnityEngine;
using System.Collections;

namespace ProjectSpacer
{
    public class QuadInverseDown : QuadData
    {
        public QuadInverseDown(MeshLayer quadLayer, QuadShape quadShape, Vector2Int quadTileAtlasCoord, Direction quadDirection, bool flipUV, bool isColorable, Color32 quadColor)
        {
            BuildQuad(quadLayer, quadShape, quadTileAtlasCoord, quadDirection, flipUV, isColorable, quadColor);
        }

        protected override void BuildVertices()
        {
            vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer));
            vertices.Add(new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize));
            vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer));
            vertices.Add(new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer));
            vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer));
            vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer));
        }

        public override void Rotate (bool right)
        {
            if (isBuilt == false)
            {
                Debug.LogError("PS ERROR: Quad not yet built. Build quad first");
            }
            else
            {
                SwitchDirection(right);
                if (right == true)
                {
                    vertices[0] = new Vector3(vertices[0].x, vertices[0].y + GV.tileSize, vertices[0].z);
                    vertices[1] = new Vector3(vertices[1].x + GV.tileSize, vertices[1].y, vertices[1].z);
                    vertices[2] = new Vector3(vertices[2].x, vertices[2].y - GV.tileSize, vertices[2].z);
                    vertices[3] = new Vector3(vertices[3].x - GV.tileSize, vertices[3].y, vertices[3].z);
                    vertices[4] = new Vector3(vertices[4].x, vertices[4].y + GV.tileSize, vertices[4].z);
                    vertices[5] = new Vector3(vertices[5].x, vertices[5].y - GV.tileSize, vertices[5].z);
                }
                else
                {
                    vertices[0] = new Vector3(vertices[0].x + GV.tileSize, vertices[0].y, vertices[0].z);
                    vertices[1] = new Vector3(vertices[1].x, vertices[1].y - GV.tileSize, vertices[1].z);
                    vertices[2] = new Vector3(vertices[2].x - GV.tileSize, vertices[2].y, vertices[2].z);
                    vertices[3] = new Vector3(vertices[3].x, vertices[3].y + GV.tileSize, vertices[3].z);
                    vertices[4] = new Vector3(vertices[4].x + GV.tileSize, vertices[4].y, vertices[4].z);
                    vertices[5] = new Vector3(vertices[5].x - GV.tileSize, vertices[5].y, vertices[5].z);
                }
            }

        }

        protected override void BuildTriangles()
        {
            triangles.Add(0);
            triangles.Add(1);
            triangles.Add(2);
            triangles.Add(4);
            triangles.Add(5);
            triangles.Add(3);
        }

        protected override void ApplyDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.UP:

                    break;
                case Direction.RIGHT:
                    vertices[0] = new Vector3(vertices[0].x, vertices[0].y + GV.tileSize, vertices[0].z);
                    vertices[1] = new Vector3(vertices[1].x + GV.tileSize, vertices[1].y, vertices[1].z);
                    vertices[2] = new Vector3(vertices[2].x, vertices[2].y - GV.tileSize, vertices[2].z);
                    vertices[3] = new Vector3(vertices[3].x - GV.tileSize, vertices[3].y, vertices[3].z);
                    vertices[4] = new Vector3(vertices[4].x, vertices[4].y + GV.tileSize, vertices[4].z);
                    vertices[5] = new Vector3(vertices[5].x, vertices[5].y - GV.tileSize, vertices[5].z);
                    break;
                case Direction.LEFT:
                    vertices[0] = new Vector3(vertices[0].x + GV.tileSize, vertices[0].y, vertices[0].z);
                    vertices[1] = new Vector3(vertices[1].x, vertices[1].y - GV.tileSize, vertices[1].z);
                    vertices[2] = new Vector3(vertices[2].x - GV.tileSize, vertices[2].y, vertices[2].z);
                    vertices[3] = new Vector3(vertices[3].x, vertices[3].y + GV.tileSize, vertices[3].z);
                    vertices[4] = new Vector3(vertices[4].x + GV.tileSize, vertices[4].y, vertices[4].z);
                    vertices[5] = vertices[5] = new Vector3(vertices[5].x - GV.tileSize, vertices[5].y, vertices[5].z);
                    break;
                case Direction.DOWN:
                    vertices[0] = new Vector3(vertices[0].x + GV.tileSize, vertices[0].y + GV.tileSize, vertices[0].z);
                    vertices[1] = new Vector3(vertices[1].x + GV.tileSize, vertices[1].y - GV.tileSize, vertices[1].z);
                    vertices[2] = new Vector3(vertices[2].x - GV.tileSize, vertices[2].y - GV.tileSize, vertices[2].z);
                    vertices[3] = new Vector3(vertices[3].x - GV.tileSize, vertices[3].y + GV.tileSize, vertices[3].z);
                    vertices[4] = new Vector3(vertices[4].x + GV.tileSize, vertices[4].y + GV.tileSize, vertices[4].z);
                    vertices[5] = new Vector3(vertices[5].x - GV.tileSize, vertices[5].y - GV.tileSize, vertices[5].z);
                    break;
                default:
                    Debug.LogError("PS ERROR: " + direction.ToString() + " not a valid direction.");
                    break;
            }
        }

        protected override void BuildUV(bool fl)
        {
            if (fl == false)
            {
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));

            }
            else if (fl == true)
            {
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));
                
            }
        }


    }
}

