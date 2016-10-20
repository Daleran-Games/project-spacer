using System;
using UnityEngine;


namespace ProjectSpacer.Database
{
    [System.Serializable]

    public class ConditionStatDatabaseEntry : StatBaseDatabaseEntry
    {
        
        [SerializeField]
        static InfoDatabaseEntry _statInfo;
        public override InfoDatabaseEntry StatInfo
        {
            get { return _statInfo; }
            protected set { _statInfo = value; }
        }
        public static void SetInfo(InfoDatabaseEntry info)
        {
            _statInfo = info;
        }

        public override Type StatType { get { return typeof(ConditionStatDatabaseEntry); } }

        float _conditionMax;
        public float ConditionMax
        {
            get
            {
                return _conditionMax;
            }

            set
            {
                _conditionMax = value;
            }
        }

        float _conditionBreak;
        public float ConditionBreak
        {
            get
            {
                return _conditionBreak;
            }

            set
            {
                _conditionBreak = value;
            }
        }

        public ConditionStatDatabaseEntry(float max, float condBreak)
        {
            ConditionBreak = condBreak;
            ConditionMax = max;
        }

        public override float GetPrimaryValue()
        {
            return ConditionMax;
        }

    }
}
