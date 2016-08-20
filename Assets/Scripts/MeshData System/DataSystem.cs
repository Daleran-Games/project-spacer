using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DataSystem : GridSystem {

	Grid parentGrid;
	List<DataLayer> dataLayers;

	public int GridSizeX;
	public int GridSizeY;

	void Start () {

		parentGrid = GetComponent<Grid> ();
		dataLayers = new List<DataLayer> ();
		BuildDataLayers (parentGrid.Saved);

	}


	void BuildDataLayers (SavedGrid s) {

		for (int i = 0; i < s.TileRows.Count; i++) {
			for (int j = 0; j < s.TileRows [i].Tiles.Count; j++) {
				if (s.TileRows [i].Tiles [j] != null) {
					if (ContainsTileLayer(s.TileRows[i].Tiles[j])) {
						AddTileToDataLayer (new Vector2Int (j, i), s.TileRows [i].Tiles [j], s.TileRows [i].Tiles [j].TileDataLayer);
					} else {
						//dataLayers.Add (new DataLayer (s.TileRows [i].Tiles [j].TileDataLayer));
					}
						
				} 
			}
		}


	}

	public List<DataLayer> GetDataLayers () {
		return dataLayers;
	}

	public DataLayer GetDataLayerOfType(DataLayerType t) {
		foreach (DataLayer dl in dataLayers) {
			if (dl.Type == t)
				return dl;
		}

		return null;
	}

	public int GetMaxDimmensionsX (DataLayerType t) {
		DataLayer d = GetDataLayerOfType (t);



		return 0;
	}

	public int GetMaxDimmensionsY (DataLayerType t) {


		return 0;
	}

	bool ContainsTileLayer (TileTemplate t) {

		bool r = false;

		foreach (DataLayer d in dataLayers) {
			if (d.Type == t.TileDataLayer)
				r = true;
		}

		return r;
		
	}

	void AddTileToDataLayer (Vector2Int loc, TileTemplate tile, DataLayerType type) {
		if (ContainsTileLayer (tile)) {
			//GetDataLayerOfType (type).TileData.Add (loc, tile.BuildTile());
		} else
			Debug.LogError ("Data Layer does not exsist");
	}


		

}
