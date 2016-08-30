using UnityEngine;


namespace ProjectSpacer
{

    public class DamageModule : MonoBehaviour
    {

        public int Health;
        public int HealthMax;
        public int Armor;
        public bool IsPenetrated;


        public void Initialize()
        {

            SetHealth(Health, HealthMax, Armor);
            IsPenetrated = false;
            Health = HealthMax;

            if (Armor > HealthMax)
                Armor = HealthMax;

        }


        public virtual void SetHealth(int hlth, int hlthMax, int arm)
        {
            Health = hlth;
            HealthMax = hlthMax;
            Armor = arm;

        }

        public virtual void Damage(int amount)
        {

            Health -= amount;

            if (Health < Armor && IsPenetrated == false)
                OnPenetration();

            if (Health <= 0)
            {
                Health = 0;
                OnDestroyed();
            }

        }

        public virtual void Repair(int amount)
        {

            Health += amount;

            if (Health > Armor && IsPenetrated == true)
                IsPenetrated = false;

            if (Health > HealthMax)
                Health = HealthMax;

        }

        public virtual void OnPenetration()
        {
            IsPenetrated = true;

        }


        public virtual void OnDestroyed()
        {

            Destroy(gameObject);

        }
    }
}
