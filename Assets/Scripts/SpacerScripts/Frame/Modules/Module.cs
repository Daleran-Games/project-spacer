using UnityEngine;
using ProjectSpacer.Database;
using System.Collections;
using DalLib.Unity;

namespace ProjectSpacer
{
    public class Module : MonoBehaviour
    {
        public string Name = "DefaultName";
        [TextArea]
        public string Description = "DefaultDescription";
        public float Mass = 0.0f;


        [SerializeField]
        [ReadOnly]
        private bool moduleActivated = false;
        [SerializeField]
        [ReadOnly]
        private bool moduleEnabled = true;

        public void SetActive (bool activate)
        {
            if (activate == true)
            {
                if (moduleEnabled == false)
                    return;
                else
                    moduleActivated = true;
            } else
            {
                moduleActivated = false;
            }
        }

        public void SetEnabled (bool enabled)
        {
            if (enabled == true)
            {
                moduleEnabled = true;
            } else
            {
                moduleEnabled = false;

                if (moduleActivated == true)
                {
                    SetActive(false);
                }
            }
        }

        public bool GetActiveState ()
        {
            return moduleActivated;
        }

        public bool GetEnableState ()
        {
            return moduleEnabled;
        }

    }
}


