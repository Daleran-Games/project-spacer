using UnityEngine;
using System;

namespace ProjectSpacer
{
    public class MassStat : IStat
    {

        public float Mass = 0f;
        private static Info _statInfo = new Info("Mass","An object's mass effects the rate at which an object can change it's velocity.","The more you have, the less nimple you are.");

        public Type Type
        {
            get { return typeof(MassStat); }
        }

        public Info StatInfo
        {
            get
            {
                return _statInfo;
            }
        }

        public MassStat()
        {

        }

        public MassStat(float mass)
        {
            Mass = mass;
        }


    }
}
