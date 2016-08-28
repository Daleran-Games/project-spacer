using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewTile", menuName = "Data/Templates/Tile Template", order = 0)]
public class TileTemplate : ScriptableObject {

	public Info TileInfo;
    public Vector2Int TileUV;
    public bool IsCollidable;

    public float Thrust;
    public float Mass;


	public Tile BuildTile (Orientation or) {

		return new Tile(TileInfo, TileUV, or, IsCollidable, Thrust, Mass); 
    }



}
