using UnityEngine;

namespace ProjectSpacer.Database
{
    [System.Serializable]
    public class EffectDatabaseEntry
    {
        public Vector2 Offset;
        public State[] ActiveStates;
        public GameObject[] Effects;

    }
}
