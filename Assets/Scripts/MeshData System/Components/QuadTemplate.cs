using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewQuad", menuName = "Data/Templates/Quad Template", order = 1)]
public class QuadTemplate : ScriptableObject
{
    public MeshLayer layer;
    public TileShape shape;
    public Vector2Int atlasCoord;

    public QuadData BuildQuad (Direction dir, bool fl)
    {
        return new QuadData(layer, shape,atlasCoord, dir, fl);
    }

}
