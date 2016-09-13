using UnityEngine;
using System;

namespace ProjectSpacer
{
    public class ThrustStatBlueprint : StatBlueprint
    {
        float _thrust;
        static string _name;
        static string _description;
        static string _iconPath;
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

        public static void SetInfo(string name, string description, string icon)
        {
            _name = name;
            _description = description;
            _iconPath = icon;
        }

    }
}
