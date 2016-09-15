using System;
using UnityEngine;

namespace ProjectSpacer
{
    [System.Serializable]
    public class ConditionStatBlueprint : StatBlueprint
    {
        float _conditionMax;
        float _conditionBreak;

        static InfoBlueprint _statInfo;
        public override InfoBlueprint StatInfo
        {
            get { return _statInfo; }
            protected set { _statInfo = value; }
        }
        public static void SetInfo(InfoBlueprint info)
        {
            _statInfo = info;
        }

        static Type _statType { get { return typeof(ConditionStatBlueprint); } }

        public ConditionStatBlueprint(float max, float condBreak)
        {
            _conditionBreak = condBreak;
            _conditionMax = max;
        }

        public override Type GetStatType()
        {
            return _statType;
        }

        public override float GetPrimaryValue()
        {
            return _conditionMax;
        }

    }
}
