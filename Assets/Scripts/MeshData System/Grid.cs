using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Grid : MonoBehaviour {

    GameObject parent;

    MeshSystem GridMeshSystem;
    public CollisionSystem GridCollisionSystem;

	public SavedGrid Saved;
    public Info GridInfo;

    public Dictionary<Vector2Int, Tile> TileData;
    public Vector2 GridCenter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitializeGrid (SavedGrid savedGrid, Material texAtlas) {
        TileData = new Dictionary<Vector2Int, Tile>();
        GridCenter = new Vector2(0f, 0f);

        parent = gameObject;
		Saved = savedGrid;
        GridInfo = Saved.GridInfo;
        BuildSavedGrid();
        Debug.Log(GridCenter);

        GridMeshSystem = parent.gameObject.GetOrAddComponent<MeshSystem> ();
        GridMeshSystem.AddTextureAtlas(texAtlas);
        GridMeshSystem.InitializeSystem();
        GridMeshSystem.BuildMesh(GridCenter);

        GridCollisionSystem = parent.gameObject.GetOrAddComponent<CollisionSystem>();
        GridCollisionSystem.InitializeSystem();
			
	}

    public void BuildSavedGrid ()
    {
        int sizeX = 0;
        foreach (SavedGridLine sgl in Saved.TileRows)
        {
            if (sgl.SavedElements.Count > sizeX)
                sizeX = sgl.SavedElements.Count;
        }

        int sizeY = Saved.TileRows.Count;



        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                if (Saved.TileRows[y].SavedElements[x].Tile != null)
                    TileData.Add(new Vector2Int(x, y), Saved.TileRows[y].SavedElements[x].Tile.BuildTile(Saved.TileRows[y].SavedElements[x].Rotation));
            }
        }

        RecalculateCenter();
    }

    public void RecalculateCenter ()
    {
        float minX = GetMinX();
        float minY = GetMinY();
        float maxX = GetMaxX();
        float maxY = GetMaxY();

        GridCenter = new Vector2(((maxX - minX)/2f)+(GlobalVariables.tileSize * 0.5f),((maxY - minY)/2f)+(GlobalVariables.tileSize * 0.5f));

    }

    public int GetMinX ()
    {
        int x = 0;
        foreach (Vector2Int coord in TileData.Keys)
        {
            if (coord.x < x)
                x = coord.x;
        }
        return x;
    }

    public int GetMaxX ()
    {
        int x = 0;
        foreach (Vector2Int coord in TileData.Keys)
        {
            if (coord.x > x)
                x = coord.x;
        }
        return x;
    }

    public int GetMinY()
    {
        int y = 0;
        foreach (Vector2Int coord in TileData.Keys)
        {
            if (coord.y < y)
                y = coord.y;
        }
        return y;
    }

    public int GetMaxY()
    {
        int y = 0;
        foreach (Vector2Int coord in TileData.Keys)
        {
            if (coord.y > y)
                y = coord.y;
        }
        return y;
    }


}
