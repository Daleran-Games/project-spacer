using UnityEngine;
using System.Collections;

[System.Serializable]
public class TileSprite {


	[SerializeField] public TileSpriteType SpriteType;
	[SerializeField] public Texture2D SpriteTexture;
    [SerializeField] public Color Tint;
    [SerializeField] public Vector2Int TextureUV_LL;
    [SerializeField] public Vector2Int TextureUV_UR;

    public Color[,] GetTextureColorGrid()
    {

        Color[,] tiles = new Color[TextureUV_UR.x- TextureUV_LL.x, TextureUV_UR.y - TextureUV_LL.y];

        for (int y = 0; y < tiles.GetLength(0); y++)
        {
            for (int x = 0; x < tiles.GetLength(1); x++)
            {
                Color newColor = SpriteTexture.GetPixel(x + TextureUV_LL.x, y + TextureUV_LL.y);

                newColor = Color.Lerp(newColor,Tint, 0.5f);

                tiles[x, y] = newColor;
            }
        }

        return tiles;
    }

}
