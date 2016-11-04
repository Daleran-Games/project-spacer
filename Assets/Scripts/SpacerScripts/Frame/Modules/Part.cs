using UnityEngine;
using ProjectSpacer.Database;
using System.Collections;

namespace ProjectSpacer
{
    public class Part : MonoBehaviour
    {
        public string ModuleName = "NewModule";
        public float PartMass = 0f;

        [SerializeField]
        private bool partActivated;
        [SerializeField]
        private bool partEnabled;

        public void SetPartActive (bool activate)
        {
            if (activate == true)
            {
                if (partEnabled == false)
                    return;
                else
                    partActivated = true;
            } else
            {
                partActivated = false;
            }
        }

        public void SetPartEnabled (bool enabled)
        {
            if (enabled == true)
            {
                partEnabled = true;
            } else
            {
                partEnabled = false;

                if (partActivated == true)
                {
                    SetPartActive(false);
                }
            }
        }

    }
}


