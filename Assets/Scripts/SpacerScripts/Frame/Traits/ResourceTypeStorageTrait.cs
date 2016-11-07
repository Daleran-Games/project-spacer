using UnityEngine;
using System.Collections.Generic;
using DalLib.Unity;



namespace ProjectSpacer
{
    public class ResourceTypeStorageTrait : ItemStorageTrait
    {
        public ResourceTypes ResourceType = ResourceTypes.Solid;

        [ReadOnly]
        public Resource StoredResource;
    }
}

