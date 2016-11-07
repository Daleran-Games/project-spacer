using UnityEngine;
using System.Collections;

namespace ProjectSpacer
{
    [System.Serializable]
    public class ResourceUseElement
    {
        public Resource UsedResource;
        public float Rate = 0f;
        public UseTypes UseType = UseTypes.ProduceOnActive;
        
        public enum UseTypes
        {
            UseOnEnable,
            UseOnActive,
            ProduceOnEnable,
            ProduceOnActive
        }
       


    }
}
