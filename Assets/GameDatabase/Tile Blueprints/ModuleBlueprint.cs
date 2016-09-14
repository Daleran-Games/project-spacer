using UnityEngine;
using System.Collections;

namespace ProjectSpacer
{
    public class ModuleBlueprint 
    {
        string _name;
        string _description;
        string _iconPath;

        bool _overrideHullShape = false;

        CollisionLayer _moduleCollision;
        QuadBlueprint[] _quads;
        StatBlueprint[] _moduleStats;
        EffectBlueprint[] _effects;

        public ModuleBlueprint(string name, string desc, string icon, bool overrideShape, CollisionLayer col, QuadBlueprint[] quads, StatBlueprint[] stats)
        {
            _name = name;
            _description = desc;
            _iconPath = icon;
            _overrideHullShape = overrideShape;

            _moduleCollision = col;
            _quads = quads;
            _moduleStats = stats;
        }

        public ModuleBlueprint(string name, string desc, string icon, bool overrideShape, CollisionLayer col, QuadBlueprint[] quads, StatBlueprint[] stats, EffectBlueprint[] effects)
        {
            _name = name;
            _description = desc;
            _iconPath = icon;
            _overrideHullShape = overrideShape;

            _moduleCollision = col;
            _quads = quads;
            _moduleStats = stats;
            _effects = effects;

        }
    }

}
