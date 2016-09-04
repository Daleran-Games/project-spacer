using UnityEngine;
using System;

namespace ProjectSpacer
{
    public class WeaponStat : Stat
    {
        public float FireRate;
        public Projectile WeaponProjectile;
        public float Recoil;
        public float ThermalDamage;
        public Vector2 Offset;
  
       Info WeaponInfo;

        public override int CompareTo(object obj)
        {
            if (obj == null) return 1;

            WeaponStat testStat = obj as WeaponStat;
            if (testStat != null)
                return this.FireRate.CompareTo(testStat.FireRate);
            else
                throw new ArgumentException("Object is not a Weapon");
        }

        public bool Equals(WeaponStat other)
        {
            if (other == null)
                return false;

            if (this.FireRate == other.FireRate)
                return true;
            else
                return false;
        }

        public override bool Equals(Stat other)
        {
            if (other == null)
                return false;

            WeaponStat weaponStat = other as WeaponStat;
            if (weaponStat == null)
                return false;
            else
                return Equals(weaponStat);
        }

        public override Info GetInfo()
        {
            return WeaponInfo;
        }

        public override void SetInfo(Info info)
        {
            WeaponInfo = info;
        }



    }
}
