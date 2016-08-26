using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshSystem : MonoBehaviour {

	public GameObject parent;
	public Grid grid;

    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    public Mesh mesh;
    public Material textureAtlas;
    public MeshData meshData;


	public void InitializeSystem () {
        parent = gameObject;
        grid = parent.GetRequiredComponent<Grid>();
        meshFilter = parent.GetOrAddComponent<MeshFilter>();
        meshRenderer = parent.GetOrAddComponent<MeshRenderer>();
        meshRenderer.material = textureAtlas;
        meshData = new MeshData();

    }

    public void AddTextureAtlas (Material texAt)
    {
        textureAtlas = texAt;
  
    }

    public void BuildMesh (Vector2 center)
    {
        meshData.Clear();

        foreach (KeyValuePair<Vector2Int, Tile> kvp in grid.TileData)
        {
            meshData.AddQuad(new Vector2 (kvp.Key.x - (center.x - GlobalVariables.halfTileSize),kvp.Key.y - (center.y - GlobalVariables.halfTileSize)),kvp.Value.TileUV, kvp.Value.TileOrient, textureAtlas);
        }

        mesh = new Mesh();
        mesh.vertices = meshData.vertices.ToArray();
        mesh.triangles = meshData.triangles.ToArray();
        mesh.uv = meshData.uv.ToArray();
        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;

    }




}
