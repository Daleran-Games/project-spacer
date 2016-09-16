using UnityEngine;
using System.Collections;

namespace ProjectSpacer 
{
    [System.Serializable]
    public class HullBlueprint 
    {
        InfoBlueprint _hullInfo;
        public InfoBlueprint HullInfo
        {
            get { return _hullInfo; }
            set { _hullInfo = value; }
        }

        Type4Set<CollisionLayer> _hullCollision;
        Type4Set<QuadBlueprint[]> _quads;
        StatBlueprint[] _hullStats;

        public HullBlueprint(InfoBlueprint hullInfo, Type4Set<CollisionLayer> col, StatBlueprint[] stats, Type4Set<QuadBlueprint[]> quads)
        {
            HullInfo = hullInfo;
            _hullCollision = col;

            _hullStats = stats;
            _quads = quads;

        }

    }
}

