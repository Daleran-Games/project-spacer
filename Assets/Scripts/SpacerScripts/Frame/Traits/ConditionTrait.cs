using UnityEngine;
using ProjectSpacer.Database;
using System.Collections;

namespace ProjectSpacer
{
    public class ConditionTrait : Trait
    {

        public float CurrentCondition = 0f;
        public float MaxCondition = 0f;

        public void ApplyDamage (float amount)
        {
            CurrentCondition -= amount;

            if (CurrentCondition < 0)
                CurrentCondition = 0;
        }

        public void ApplyRepair (float amount)
        {
            CurrentCondition += amount;

            if (CurrentCondition > MaxCondition)
                CurrentCondition = MaxCondition;
        }


    }
}


