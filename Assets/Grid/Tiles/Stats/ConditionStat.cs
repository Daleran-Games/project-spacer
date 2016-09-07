using UnityEngine;
using System;

namespace ProjectSpacer
{
    public class ConditionStat : Stat
    {
        public float Condition;
        public float ConditionMax;
        public float ConditionBreak;
  
        static Info ConditionInfo;

        public ConditionStat (float condBreak, float condMax)
        {
            ConditionBreak = condBreak;
            Condition = condMax;
            ConditionMax = condMax;
        }

        public override int CompareTo(object obj)
        {
            if (obj == null) return 1;

            ConditionStat testStat = obj as ConditionStat;
            if (testStat != null)
                return this.Condition.CompareTo(testStat.Condition);
            else
                throw new ArgumentException("Object is not a Condition");
        }

        public bool Equals(ConditionStat other)
        {
            if (other == null)
                return false;

            if (this.Condition == other.Condition)
                return true;
            else
                return false;
        }

        public override bool Equals(Stat other)
        {
            if (other == null)
                return false;

            ConditionStat conditionStat = other as ConditionStat;
            if (conditionStat == null)
                return false;
            else
                return Equals(conditionStat);
        }

        public override Info GetInfo()
        {
            return ConditionInfo;
        }

        public override void SetInfo(Info info)
        {
            ConditionInfo = info;
        }



    }
}
