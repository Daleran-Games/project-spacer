using UnityEngine;
using DalLib.Unity;

namespace ProjectSpacer
{

    public abstract class Controller : MonoBehaviour
    {

        protected Frame frame;

        public void InitializeController()
        {
            frame = gameObject.GetRequiredComponent<Frame>();

        }

        public abstract void InitializeControllerExtension();

        public abstract Vector2 GetTranslateVector();
        public abstract Vector2 GetDirectionVector();

    }
}
