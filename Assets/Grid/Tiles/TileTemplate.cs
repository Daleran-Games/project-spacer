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

        StatCollection BuildStatCollection(Direction dir, Vector2Int pos)
        {
            StatCollection stats = new StatCollection();
            foreach (StatEntry se in TileStats)
            {
                switch (se.Stat)
                {
                    case StatType.Mass:
                        stats.AddStat<MassStat>(new MassStat(se.Value1));
                        break;
                    case StatType.Thrust:
                        stats.AddStat<ThrustStat>(new ThrustStat(se.Value1, dir, pos, se.ThrustMode));
                        break;
                    case StatType.Condition:
                        stats.AddStat<ConditionStat>(new ConditionStat(se.Value1, se.Value2));
                        break;
                    case StatType.Weapon:
                        stats.AddStat<WeaponStat>(new WeaponStat(se.Value1,se.Value2,se.Value3,se.StatVector,se.StatObject));
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
