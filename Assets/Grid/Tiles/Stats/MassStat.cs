using UnityEngine;
using System;

namespace ProjectSpacer
{
    public class MassStat : Stat
    {
        public float Mass;
  
        static Info massInfo;

        public MassStat(float mass)
        {
            Mass = mass;
        }

        public override int CompareTo(object obj)
        {
            if (obj == null) return 1;

            MassStat testStat = obj as MassStat;
            if (testStat != null)
                return this.Mass.CompareTo(testStat.Mass);
            else
                throw new ArgumentException("Object is not a Mass");
        }

        public bool Equals(MassStat other)
        {
            if (other == null)
                return false;

            if (this.Mass == other.Mass)
                return true;
            else
                return false;
        }

        public override bool Equals(Stat other)
        {
            if (other == null)
                return false;

            MassStat mass = other as MassStat;
            if (mass == null)
                return false;
            else
                return Equals(mass);
        }

        public override Info GetInfo()
        {
            return massInfo;
        }

        public override void SetInfo(Info info)
        {
            massInfo = info;
        }

   

    }
}
