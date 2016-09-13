using UnityEngine;
using System;

namespace ProjectSpacer
{
    public class MassStatBlueprint : StatBlueprint
    {
        float _mass;
        static string _name;
        static string _description;
        static string _iconPath;
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

        public static void SetInfo(string name, string description, string icon)
        {
            _name = name;
            _description = description;
            _iconPath = icon;
        }

    }
}
