using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ProjectSpacer
{
    [CreateAssetMenu(fileName = "NewResource", menuName = "Spacer/Items/Resource", order = 1)]
    public class Resource : Item
    {
        public ResourceTypes ResourceType = ResourceTypes.Solid;
        public bool CanBeStoredAsItem = false;
      
    }

}
