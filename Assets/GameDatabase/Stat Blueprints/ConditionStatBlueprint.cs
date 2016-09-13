using System;
using UnityEngine;

namespace ProjectSpacer
{
    public class ConditionStatBlueprint : StatBlueprint
    {
        float _conditionMax;
        float _conditionBreak;
        static string _name;
        static string _description;
        static string _iconPath;
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

        public static void SetInfo(string name, string description, string icon)
        {
            _name = name;
            _description = description;
            _iconPath = icon;
        }

    }
}
