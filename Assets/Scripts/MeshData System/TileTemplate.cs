using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewTile", menuName = "Data/Templates/Tile Template", order = 0)]
public class TileTemplate : ScriptableObject {

	public Info TileInfo;
	public bool IsCollidable;
	public List<TileFX> TileEffects;
	public DataLayerType TileDataLayer;

	public List<TileConnectionInput> Connections;

	public List<StatInput> Stats;
	public List<Modifier> Modifiers;



	public Tile BuildTile () {

		TileConnectionType[,] con = BuildConnectionArray ();
		Tile newTile = new Tile (TileInfo, con, IsCollidable, TileDataLayer, TileEffects, this);

        /*
		foreach (StatInput s in Stats) {
			newTile.Stats.Add (s.BuildStat ());
		}

		foreach (Modifier m in Modifiers) {
			newTile.Modifers.Add (m);
		}
        */
		return newTile;
	}


	TileConnectionType[,] BuildConnectionArray() {

		TileConnectionType[,] con = new TileConnectionType[Connections[0].ConnectionRow.Count,Connections.Count];

		for (int i=0; i < Connections.Count; i++){
			for (int j = 0; j < Connections [i].ConnectionRow.Count; j++) {
				con [i, j] = Connections [i].ConnectionRow [j];
			}
		}

		return con;

	}


}
