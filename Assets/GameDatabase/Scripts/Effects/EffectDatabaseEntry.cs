using UnityEngine;

namespace ProjectSpacer.Database
{
    [System.Serializable]
    public class EffectDatabaseEntry
    {
        Vector2 _offset;
        State[] _activeStates;

        public EffectDatabaseEntry(Vector2 offset, State[] states)
        {
            _offset = offset;
            _activeStates = states;
        }
    }
}
