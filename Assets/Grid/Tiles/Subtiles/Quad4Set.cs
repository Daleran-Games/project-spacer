using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProjectSpacer
{
    public class Quad4Set
    {

        Dictionary<Quad4Type, QuadSet> _quadSets;

        public Quad4Set ()
        {
            _quadSets = new Dictionary<Quad4Type, QuadSet>();
        }

        public bool TryAddQuad(Quad4Type type, QuadSet quadSet)
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

        public bool TryGetQuad(Quad4Type type, out QuadSet quadSet)
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
