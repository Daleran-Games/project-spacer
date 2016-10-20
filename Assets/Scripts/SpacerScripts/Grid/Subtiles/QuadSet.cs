using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProjectSpacer
{
    public class QuadSet
    {
        Dictionary<MeshLayer, QuadData> _quads;

        public QuadSet ()
        {
            _quads = new Dictionary<MeshLayer, QuadData>();
        }

        public bool TryAddQuad (MeshLayer layer, QuadData quad)
        {
            if(_quads.ContainsKey(layer))
            {
                return false;
            }
            else
            {
                _quads.Add(layer, quad);
                return true;
            }
        }
        
        public bool TryGetQuad (MeshLayer layer, out QuadData quad)
        {
            if (_quads.ContainsKey(layer))
            {
                if (_quads.TryGetValue(layer, out quad))
                {
                    return true;
                }
                
            }
            quad = null;
            return false;
        }
        


    }
}

