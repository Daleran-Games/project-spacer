using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NewTileShape", menuName = "Data/Graphics/Tile Shape", order = 1)]
public class TileShape : ScriptableObject {

	public float deformUpperLeft=0f;
	public float deformUpperRight=0f;
	public float deformLowerRight=0f;
	public float deformLowerLeft=0f;

}
