using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataLayer {

	public DataLayerType Type;
	public Tile[,] TileData;

	public DataLayer (DataLayerType t, int x, int y) {
		Type = t;
		TileData = new Tile[x,y];
	}

	public void ResizeDataLayer (int x, int y) {


	}


}
