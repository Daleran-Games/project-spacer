using UnityEngine;
using System.Collections;

namespace ProjectSpacer
{

    [System.Serializable]
    public class ResourceStorageElement
    {

        public Resource StoredResource;
        public float Amount = 0f;
        public float AmountMax = 0f;

    }
}