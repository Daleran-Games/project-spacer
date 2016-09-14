using UnityEngine;

namespace ProjectSpacer
{
    public class EffectBlueprint
    {
        string _name;
        Vector2 _offset;
        State[] _activeStates;

        public EffectBlueprint (string name, Vector2 offset, State[] states)
        {
            _name = name;
            _offset = offset;
            _activeStates = states;
        }
    }
}
