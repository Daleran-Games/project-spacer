using UnityEngine;
using System.Collections;

public static class VectorExtension {

	public static Vector2Int ToVector2Int (this Vector2 v) {
		return new Vector2Int (Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));	

	}

	public static Vector2Int ToVector2Int (this Vector3 v) {
		return new Vector2Int (Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));	

	}
}
