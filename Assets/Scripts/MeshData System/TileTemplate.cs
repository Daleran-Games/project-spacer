using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewTile", menuName = "Data/Templates/Tile Template", order = 0)]
public class TileTemplate : ScriptableObject {

	public Info TileInfo;
    public CollisionLayer CollisionType;

    public List<StatEntry> TileStats;
    public List<QuadTemplate> TileQuads;

    public Tile BuildTile (Direction dir, bool flipped) {

		return new Tile(TileInfo, dir, flipped, CollisionType, BuildStatCollection(), BuildQuadData(dir, flipped)); 

    }

    Dictionary<StatType, float> BuildStatCollection ()
    {
        Dictionary<StatType, float> stats = new Dictionary<StatType, float>();
        foreach (StatEntry se in TileStats)
        {
            stats.Add(se.Stat,se.Value);
        }
        return stats;
    }

    List<QuadData> BuildQuadData (Direction dir, bool fl)
    {
        List<QuadData> quads = new List<QuadData>();
        
        foreach (QuadTemplate qt in TileQuads)
        {
            quads.Add(qt.BuildQuad(dir, fl));
        }

        return quads;
    }

}
