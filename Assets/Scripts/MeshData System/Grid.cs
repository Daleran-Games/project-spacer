using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Grid : MonoBehaviour {

    GameObject parent;
    public Controller GridController;

    MeshSystem GridMeshSystem;
    public CollisionSystem GridCollisionSystem;
    public ControlSystem GridControlSystem;

	public SavedGrid Saved;
    public Info GridInfo;

    public Dictionary<Vector2Int, Tile> TileData;
    public Vector2 GridCenter;

	public void InitializeGrid (SavedGrid savedGrid, Controller cont) {

        TileData = new Dictionary<Vector2Int, Tile>();
        GridCenter = new Vector2(0f, 0f);

        parent = gameObject;
		Saved = savedGrid;
        GridInfo = Saved.GridInfo;
        BuildSavedGrid();

        GridMeshSystem = parent.GetOrAddComponent<MeshSystem> ();
        GridMeshSystem.InitializeSystem();
        GridMeshSystem.BuildMesh(GridCenter);

        GridControlSystem = parent.GetOrAddComponent<ControlSystem>();
        GridControlSystem.InitializeSystem();

        GridCollisionSystem = parent.GetOrAddComponent<CollisionSystem>();
        GridCollisionSystem.InitializeSystem();

        GridController = cont;
        GridController.InitializeController();

        GridControlSystem.AssignController(GridController);
			
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
                    TileData.Add(new Vector2Int(x, y), Saved.TileRows[y].SavedElements[x].Tile.BuildTile(Saved.TileRows[y].SavedElements[x].Rotation, Saved.TileRows[y].SavedElements[x].Flipped));
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

        GridCenter = new Vector2(((maxX - minX)/2f)+(GV.tileSize * 0.5f),((maxY - minY)/2f)+(GV.tileSize * 0.5f));

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
