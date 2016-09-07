using UnityEngine;

namespace ProjectSpacer
{

    [System.Serializable]
    public class StatEntry
    {

        [SerializeField]
        public StatType Stat;
        [SerializeField]
        public float Value1;
        [SerializeField]
        public float Value2;
        [SerializeField]
        public float Value3;
        [SerializeField]
        public Vector2 StatVector;
        [SerializeField]
        public GameObject StatObject;
    }
}