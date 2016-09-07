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
        public List<GameObject> TileEffects;


        public Tile BuildTile(Direction tileDirection, Vector2Int pos, bool flipped, Color32 tileColor)
        {

            return new Tile(TileInfo, tileDirection, flipped, CollisionType, BuildStatCollection(tileDirection, pos), BuildQuadData(tileDirection, flipped,tileColor), TileEffects);

        }

        List<Stat> BuildStatCollection(Direction dir, Vector2Int pos)
        {
            List<Stat> stats = new List<Stat>();
            foreach (StatEntry se in TileStats)
            {
                switch (se.Stat)
                {
                    case StatType.Mass:
                        stats.Add(new MassStat(se.Value1));
                        break;
                    case StatType.Thrust:
                        stats.Add(new ThrustStat(se.Value1, dir, pos));
                        break;
                    case StatType.Condition:
                        stats.Add(new ConditionStat(se.Value1, se.Value2));
                        break;
                    case StatType.Weapon:
                        stats.Add(new WeaponStat(se.Value1,se.Value2,se.Value3,se.StatVector,se.StatObject));
                        break;
                    default:
                        Debug.LogError("PS ERROR: " + se.Stat.ToString()+" not a valid stat");
                        break;
                }
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
