using UnityEngine;
using System.Collections;

[System.Serializable]
public class SavedGridElement{

    [SerializeField] public TileTemplate Tile;
    [SerializeField] public Direction Rotation;
    [SerializeField] public bool Flipped;

}
