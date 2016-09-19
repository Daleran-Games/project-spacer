using UnityEngine;
using System;


namespace ProjectSpacer.Database
{
    [Serializable]
    public class ThrustStatDatabaseEntry : StatBaseDatabaseEntry
    {
        float _thrust;

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

        public override Type StatType { get { return typeof(ThrustStatDatabaseEntry); } }

        public float Thrust
        {
            get
            {
                return _thrust;
            }

            set
            {
                _thrust = value;
            }
        }

        public ThrustStatDatabaseEntry(float thrust, Direction thrustDirections)
        {
            Thrust = thrust;
        }


        public override float GetPrimaryValue()
        {
            return Thrust;
        }

    }
}
