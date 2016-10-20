using UnityEngine;

namespace ProjectSpacer
{

    [System.Serializable]
    public class SavedGridElement
    {

        [SerializeField]
        public TileTemplate Tile;
        [SerializeField]
        public Direction Rotation = Direction.UP;
        [SerializeField]
        public bool Flipped = false;
        [SerializeField]
        public Color32 TileColor = GV.defaultTileColor;

    }
}
