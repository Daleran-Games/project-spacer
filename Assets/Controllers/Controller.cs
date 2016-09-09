using UnityEngine;

namespace ProjectSpacer
{

    public abstract class Controller : MonoBehaviour
    {

        protected Grid _grid;

        public virtual void InitializeController()
        {
            _grid = gameObject.GetRequiredComponent<Grid>();

        }

        public abstract Vector2 GetTranslateVector();
        public abstract Vector2 GetDirectionVector();

    }
}
