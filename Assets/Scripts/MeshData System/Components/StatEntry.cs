using UnityEngine;

namespace ProjectSpacer
{

    [System.Serializable]
    public class StatEntry
    {

        [SerializeField]
        public StatType Stat;
        [SerializeField]
        public float Value;
    }
}