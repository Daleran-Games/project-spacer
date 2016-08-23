using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class DataLayer {

	public DataLayerType Type;
	public Tile[,] TileData;

	public DataLayer (DataLayerType t, int x, int y) {
		Type = t;
		TileData = new Tile[x,y];
	}

    public void AddTile (Vector2Int loc, TileTemplate tt)
    {
        TileData[loc.x, loc.y] = tt.BuildTile();

    }

    public void ResizeDataLayer (int x, int y) {


	}


}
