using UnityEngine;
using System.Collections.Generic;
using System;


namespace ProjectSpacer
{
    [Serializable]
    public class EffectElement
    {
        public bool ActivateOnActive = false;
        public bool ActivateOnNotActive = false;
        public bool ActivateOnEnabled = false;
        public bool ActivateOnDisabled = false;

        public List<GameObject> Effects = new List<GameObject>();


    }
}