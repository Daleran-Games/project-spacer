using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProjectSpacer
{
    public class Quad4Set
    {

        Dictionary<Type4, QuadSet> _quadSets;

        public Quad4Set ()
        {
            _quadSets = new Dictionary<Type4, QuadSet>();
        }

        public bool TryAddQuad(Type4 type, QuadSet quadSet)
        {
            if (_quadSets.ContainsKey(type))
            {
                return false;
            }
            else
            {
                _quadSets.Add(type, quadSet);
                return true;
            }
        }

        public bool TryGetQuad(Type4 type, out QuadSet quadSet)
        {
            if (_quadSets.ContainsKey(type))
            {
                if (_quadSets.TryGetValue(type, out quadSet))
                {
                    return true;
                }

            }
            quadSet = null;
            return false;
        }

    }
}
