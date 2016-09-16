using UnityEngine;
using System.Collections;

namespace ProjectSpacer
{
    [System.Serializable]
    public class ModuleBlueprint 
    {
        InfoBlueprint _moduleInfo;
        public InfoBlueprint ModuleInfo
        {
            get { return _moduleInfo; }
            set { _moduleInfo = value; }
        }

        bool _overrideHullShape = false;

        CollisionLayer _moduleCollision;
        QuadBlueprint[] _quads;
        StatBlueprint[] _moduleStats;
        EffectBlueprint[] _effects;

        public ModuleBlueprint(InfoBlueprint moduleInfo, bool overrideShape, CollisionLayer col, QuadBlueprint[] quads, StatBlueprint[] stats)
        {
            ModuleInfo = moduleInfo;
            _overrideHullShape = overrideShape;

            _moduleCollision = col;
            _quads = quads;
            _moduleStats = stats;
        }

        public ModuleBlueprint(InfoBlueprint moduleInfo, bool overrideShape, CollisionLayer col, QuadBlueprint[] quads, StatBlueprint[] stats, EffectBlueprint[] effects)
        {
            ModuleInfo = moduleInfo;
            _overrideHullShape = overrideShape;

            _moduleCollision = col;
            _quads = quads;
            _moduleStats = stats;
            _effects = effects;

        }
    }

}
