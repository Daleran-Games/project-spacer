using System;
using UnityEngine;
using System.Collections;

namespace ProjectSpacer
{
    [System.Serializable]
    public abstract class StatBlueprint 
    {
        public abstract InfoBlueprint StatInfo { get; protected set; }
        public abstract Type GetStatType();
        public abstract float GetPrimaryValue();

    }

}
