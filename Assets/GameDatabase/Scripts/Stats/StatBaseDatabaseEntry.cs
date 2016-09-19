using System;
using UnityEngine;
using System.Collections;

namespace ProjectSpacer.Database
{
    [System.Serializable]
    public abstract class StatBaseDatabaseEntry 
    {
        public abstract InfoDatabaseEntry StatInfo { get; protected set; }
        public abstract Type StatType { get; }
        public abstract float GetPrimaryValue();

    }

}
