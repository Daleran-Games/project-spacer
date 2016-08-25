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
        CurrentStates = new List<TileState>();
		CurrentStates.Add (TileState.DEFAULT);
		
	}

	public void RotateTile (Orientation o) {
		
	}
    
    public TileSprite getTileSprite(MeshLayerType mlt, TileSpriteType tst)
    {
        foreach (TileFX tfx in TileEffects)
        {
            if (tfx.Layer == mlt)
            {
                foreach (TileSprite ts in tfx.Sprites)
                {
                    if (ts.SpriteType == tst)
                        return ts;
                }
            }
        }
        Debug.LogError("PS ERROR: TileSprite Not Found for MeshLayer: " + mlt + " Type: " + tst);
        return null;
        

    }

}
