using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MeshLayer : MonoBehaviour
{

    public MeshLayerType MeshLayerOrder = MeshLayerType.WORLD_BASE;
    public int sizeX = 1;
    public int sizeY = 1;
    public static int textureResolution = 32;
    public static float tileSize = 1.0f;
    public float zLayer;

    Mesh meshLayer;
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;

    List<Vector3> vertices = new List<Vector3>();
    List<Vector2> uv = new List<Vector2>();
    List<int> triangles = new List<int>();

    public void BuildMesh()
    {
        zLayer = (float)MeshLayerOrder;
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, zLayer);
        meshFilter = this.GetComponent<MeshFilter>();
        meshLayer = meshFilter.mesh;
        meshLayer.Clear();

        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                addQuad(x, y);
            }
        }

        meshLayer.vertices = vertices.ToArray();
        meshLayer.triangles = triangles.ToArray();
        meshLayer.uv = uv.ToArray();
        meshLayer.RecalculateNormals();
  
    }

    public void buildTexture(DataSystem ds)
    {
        int texWidth = sizeX * textureResolution;
        int texHeight = sizeY * textureResolution;
        Texture2D texture = new Texture2D(texWidth, texHeight);

        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                foreach (DataLayer dl in ds.dataLayers) 
                {

                    if (dl.TileData[x, y] != null)
                    {
                        Color[,] colorArray = dl.TileData[x, y].getTileSprite(MeshLayerOrder, TileSpriteType.DIFFUSE).GetTextureColorGrid();

                        for (int i = 0; i < colorArray.GetLength(0); i++)
                        {
                            for (int j = 0; j < colorArray.GetLength(1); j++)
                            {
                                texture.SetPixel(i + x * textureResolution, j + y * textureResolution, colorArray[i, j]);
                            }
                        }
                    }


                }
            }
        }

        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.Apply();

        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sharedMaterials[0].mainTexture = texture;

    }


    void addQuad(int x, int y)
    {
        vertices.Add(new Vector3((float)x + 0, (float)y + 0, 0));
        vertices.Add(new Vector3((float)x + 0, (float)y + tileSize, 0));
        vertices.Add(new Vector3((float)x + tileSize, (float)y + tileSize, 0));
        vertices.Add(new Vector3((float)x + tileSize, (float)y + 0, 0));

        triangles.Add(vertices.Count - 4);
        triangles.Add(vertices.Count - 3);
        triangles.Add(vertices.Count - 2);
        triangles.Add(vertices.Count - 4);
        triangles.Add(vertices.Count - 2);
        triangles.Add(vertices.Count - 1);

        uv.Add(new Vector2((float)x / sizeX, (float)y / sizeY));
        uv.Add(new Vector2((float)x / sizeX, (tileSize + (float)y) / sizeY));
        uv.Add(new Vector2((tileSize + (float)x) / sizeX, (tileSize + (float)y) / sizeY));
        uv.Add(new Vector2((tileSize + (float)x) / sizeX, (float)y / sizeY));
    }

}
