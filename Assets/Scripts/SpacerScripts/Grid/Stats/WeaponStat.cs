using UnityEngine;
using System;

namespace ProjectSpacer
{
    public class WeaponStat : IStat
    {

        public float FireRate=0f;
        public float Recoil=0f;
        public float ThermalDamage=0f;
        public Vector2 Offset = Vector2.zero;
        public GameObject WeaponProjectile;
        private static Info _weaponInfo = new Info("Weapon");

        public Type Type
        {
            get { return typeof(WeaponStat); }
        }

        public Info StatInfo
        {
            get
            {
                return _weaponInfo;
            }
        }

        public WeaponStat ()
        {

        }

        public WeaponStat(float fireRate, float recoil, float thermalDmg, Vector2 bulletOffset, GameObject projectile)
        {
            FireRate = fireRate;
            Recoil = recoil;
            ThermalDamage = thermalDmg;
            Offset = bulletOffset;
            WeaponProjectile = projectile;
        }
    }
}
