using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DataSystem : MonoBehaviour, IGridSystem {

	public Grid parentGrid;
	public List<DataLayer> dataLayers;

	public int GridSizeX;
	public int GridSizeY;

	void Start () {




	}


	public void BuildDataLayers (SavedGrid s) {

        parentGrid = GetComponent<Grid>();
        dataLayers = new List<DataLayer>();

        for (int i = 0; i < s.TileRows.Count; i++) {
			for (int j = 0; j < s.TileRows [i].Tiles.Count; j++) {
				if (s.TileRows [i].Tiles [j] != null) {
					if (ContainsTileLayer(s.TileRows[i].Tiles[j])) {
                        AddTileToDataLayer (new Vector2Int (j, i), s.TileRows [i].Tiles [j], s.TileRows [i].Tiles [j].TileDataLayer);
					} else {
						dataLayers.Add (new DataLayer (s.TileRows [i].Tiles [j].TileDataLayer,GetMaxDimmensionsX(s),GetMaxDimmensionsY(s)));
                        AddTileToDataLayer(new Vector2Int(j, i), s.TileRows[i].Tiles[j], s.TileRows[i].Tiles[j].TileDataLayer);
                    }
						
				} 
			}
		}

        GridSizeX = GetMaxDimmensionsX(s);
        GridSizeY = GetMaxDimmensionsY(s);

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

    public List<MeshLayerType> GetMeshLayerTypes ()
    {
        List<MeshLayerType> foundTypes = new List<MeshLayerType>();
        foreach (DataLayer dl in dataLayers)
        {

            for (int i = 0; i < dl.TileData.GetLength(0); i++)
            {
                for (int j = 0; j < dl.TileData.GetLength(1); j++)
                {
                    if (dl.TileData[i,j] != null)
                    {
                      
                        foreach (TileFX fx in dl.TileData[i, j].TileEffects)
                        {
                            
                            if (!foundTypes.Contains(fx.Layer))
                            {
                                foundTypes.Add(fx.Layer);
                            }
                        }
                    }
                }
            }
        }

        return foundTypes;
    }

	public int GetMaxDimmensionsX (SavedGrid s) {

        int maxSoFar = 0;
        foreach (SavedGridLine sgl in s.TileRows)
        {
            if (sgl.Tiles.Count > maxSoFar)
                maxSoFar = sgl.Tiles.Count;
        }
        return maxSoFar;

	}

	public int GetMaxDimmensionsY (SavedGrid s) {

       return s.TileRows.Count;
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
            GetDataLayerOfType(type).AddTile(loc, tile);
		} else
			Debug.LogError ("Data Layer does not exsist");
	}


		

}
