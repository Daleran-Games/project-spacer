using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Tile {

	public Info TileInfo;
    public Vector2Int TileUV;
    public Orientation TileOrient;
    public bool IsCollidable;

    public float Thrust;
    public float Mass;

    public Tile (Info i, Vector2Int tUV, Orientation or, bool collidable, float th, float ms) {

        TileInfo = i;
        TileUV = tUV;
        TileOrient = or;
        IsCollidable = collidable;

        Thrust = th;
        Mass = ms;
		
	}

}
