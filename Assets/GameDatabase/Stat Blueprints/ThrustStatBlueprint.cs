using UnityEngine;
using System;

namespace ProjectSpacer
{
    [System.Serializable]
    public class ThrustStatBlueprint : StatBlueprint
    {
        float _thrust;

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

        static Type _statType { get { return typeof(ThrustStatBlueprint); } }


        public ThrustStatBlueprint(float thrust, Direction thrustDirections)
        {
            _thrust = thrust;
        }

        public override Type GetStatType()
        {
            return _statType;
        }

        public override float GetPrimaryValue()
        {
            return _thrust;
        }

    }
}
