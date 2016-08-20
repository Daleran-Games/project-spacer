using UnityEngine;
using System.Collections;

[System.Serializable]
public class TileSprite {


	[SerializeField] public TileSpriteType SpriteType;
	[SerializeField] public Texture SpriteTexture;
	[SerializeField] public Vector2Int PixelSize;
	[SerializeField] public Vector2Int TextureUV;

}
