using UnityEngine;

namespace ProjectSpacer
{
    [System.Serializable]
    public class EffectBlueprint
    {
        Vector2 _offset;
        State[] _activeStates;

        public EffectBlueprint (Vector2 offset, State[] states)
        {
            _offset = offset;
            _activeStates = states;
        }
    }
}
