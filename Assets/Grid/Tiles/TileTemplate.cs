using UnityEngine;
using System.Collections.Generic;

namespace ProjectSpacer
{


    [CreateAssetMenu(fileName = "NewTile", menuName = "Data/Templates/Tile Template", order = 0)]
    public class TileTemplate : ScriptableObject
    {

        public Info TileInfo;
        public CollisionLayer CollisionType;
        
        public List<StatEntry> TileStats;
        public List<QuadTemplate> TileQuads;
        public List<GridEffect> TileEffects;

        public Tile BuildTile(Direction tileDirection, bool flipped, Color32 tileColor)
        {

            return new Tile(TileInfo, tileDirection, flipped, CollisionType, BuildStatCollection(), BuildQuadData(tileDirection, flipped,tileColor), TileEffects);

        }

        Dictionary<StatType, float> BuildStatCollection()
        {
            Dictionary<StatType, float> stats = new Dictionary<StatType, float>();
            foreach (StatEntry se in TileStats)
            {
                stats.Add(se.Stat, se.Value);
            }
            return stats;
        }

        List<QuadData> BuildQuadData(Direction quadDirection, bool flipUV, Color32 quadColor)
        {
            List<QuadData> quads = new List<QuadData>();

            foreach (QuadTemplate qt in TileQuads)
            {
                quads.Add(qt.BuildQuad(quadDirection, flipUV ,quadColor));
            }

            return quads;
        }


    }
}
