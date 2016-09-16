using UnityEngine;
using System;

namespace ProjectSpacer
{
    [System.Serializable]
    public class MassStatBlueprint : StatBlueprint
    {
        float _mass;

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

        static Type _statType { get { return typeof(MassStatBlueprint); } }

        public MassStatBlueprint(float mass)
        {
            _mass = mass;
        }

        public override Type GetStatType()
        {
            return _statType;
        }

        public override float GetPrimaryValue()
        {
            return _mass;
        }

    }
}
