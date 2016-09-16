using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProjectSpacer
{
    [System.Serializable]
    public class ArmorBlueprint 
    {

        InfoBlueprint _armorInfo;
        public InfoBlueprint ArmorInfo
        {
            get { return _armorInfo; }
            set { _armorInfo = value; }
        }

        Type4Set<QuadBlueprint[]> _quads;
        StatBlueprint[] _armorStats;


        public ArmorBlueprint(InfoBlueprint armorInfo, StatBlueprint[] stats, Type4Set<QuadBlueprint[]> quads)
        {
            ArmorInfo = armorInfo;

            _quads = quads;
            _armorStats = stats;

        }

    }
}
