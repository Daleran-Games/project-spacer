using UnityEngine;
using System;

namespace ProjectSpacer
{
    public class ThrustStat : Stat
    {
        public float Thrust;
  
       static Info thrustInfo;

        public override int CompareTo(object obj)
        {
            if (obj == null) return 1;

            ThrustStat testStat = obj as ThrustStat;
            if (testStat != null)
                return this.Thrust.CompareTo(testStat.Thrust);
            else
                throw new ArgumentException("Object is not a Thrust");
        }

        public bool Equals(ThrustStat other)
        {
            if (other == null)
                return false;

            if (this.Thrust == other.Thrust)
                return true;
            else
                return false;
        }

        public override bool Equals(Stat other)
        {
            if (other == null)
                return false;

            ThrustStat thrustStat = other as ThrustStat;
            if (thrustStat == null)
                return false;
            else
                return Equals(thrustStat);
        }

        public override Info GetInfo()
        {
            return thrustInfo;
        }

        public override void SetInfo(Info info)
        {
            thrustInfo = info;
        }


    }
}
