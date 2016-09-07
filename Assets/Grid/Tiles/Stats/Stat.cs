using UnityEngine;
using System;
using System.Collections;

namespace ProjectSpacer 
{
    [System.Serializable]
    public abstract class Stat : IComparable, IEquatable<Stat>
    {
        public abstract Info GetInfo();
        public abstract void SetInfo(Info info);

        public abstract int CompareTo(object obj);
        public abstract bool Equals(Stat other);
    }
}
