using UnityEngine;
using System.Collections;
using DalLib.Unity;

namespace ProjectSpacer
{
    public abstract class FrameSystem : MonoBehaviour
    {
        protected Frame frame;

        public void InitializeSystem ()
        {
            frame = gameObject.GetRequiredComponent<Frame>();
            InitializeSystemExtension();
        }

        public abstract void InitializeSystemExtension();

    }
}

