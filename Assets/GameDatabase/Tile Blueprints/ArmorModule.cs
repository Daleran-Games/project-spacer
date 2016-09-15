using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProjectSpacer
{
    [System.Serializable]
    public class ArmorBlueprint 
    {

        string _name;
        string _description;
        string _iconPath;

        Type4Set<QuadBlueprint[]> _quads;
        StatBlueprint[] _armorStats;


        public ArmorBlueprint(string name, string desc, string icon, StatBlueprint[] stats, Type4Set<QuadBlueprint[]> quads)
        {
            _name = name;
            _description = desc;
            _iconPath = icon;

            _quads = quads;
            _armorStats = stats;

        }

    }
}
