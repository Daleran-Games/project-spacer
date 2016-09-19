using UnityEngine;
using System;


namespace ProjectSpacer.Database
{
    [System.Serializable]

    public class MassStatDatabaseEntry : StatBaseDatabaseEntry
    {
        float _mass;
        public float Mass
        {
            get { return _mass; }
            private set { _mass = value; }
        }

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

        public override Type StatType { get { return typeof(MassStatDatabaseEntry); } }

        public MassStatDatabaseEntry(float mass)
        {
            _mass = mass;
        }


        public override float GetPrimaryValue()
        {
            return _mass;
        }

    }
}
