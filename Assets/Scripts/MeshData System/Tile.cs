using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Tile {

	public Info TileInfo;
	public Vector2Int TileSize;
	public TileConnectionType[,] Connections;
	public bool IsCollidable;
	public DataLayerType TileDataLayer;
	public List<TileFX> TileEffects;

	public Orientation TileOrient;
	public TileTemplate Template;

	public List<Stat> Stats;
	public List<Modifier> Modifers;
	public List<TileState> CurrentStates;

	public Tile (Info i, TileConnectionType[,] con, bool c, DataLayerType t, List<TileFX> a, TileTemplate tt) {
		TileInfo = i;
		TileSize = new Vector2Int (con.GetLength(0)-2,con.GetLength(1)-2);
		Connections = con;
		IsCollidable = c;
		TileDataLayer = t;
		TileEffects = a;
		Template = tt;
		TileOrient = Orientation.UP;
		CurrentStates.Add (TileState.DEFAULT);
		
	}

	public void RotateTile (Orientation o) {
		
	}

}
