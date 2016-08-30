using UnityEngine;

namespace ProjectSpacer
{

    [System.Serializable]
    public class SavedGridElement
    {

        [SerializeField]
        public TileTemplate Tile;
        [SerializeField]
        public Direction Rotation;
        [SerializeField]
        public bool Flipped;

    }
}
