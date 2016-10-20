using UnityEngine;
using System;
using System.Collections;

namespace ProjectSpacer
{
    public class ConditionStat : IStat
    {

        public float Condition=0f;
        public float ConditionMax=0f;
        public float ConditionBreak=0f;
        private static Info _conditionInfo = new Info("Condition");

        public Type Type
        {
            get { return typeof(ConditionStat); }
        }

        public Info StatInfo
        {
            get
            {
                return _conditionInfo;
            }
        }


        public ConditionStat()
        {

        }

        public ConditionStat (float condBreak, float condMax)
        {
            ConditionBreak = condBreak;
            Condition = condMax;
            ConditionMax = condMax;
        }
    }
}
