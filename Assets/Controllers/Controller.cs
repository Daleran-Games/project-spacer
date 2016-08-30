using UnityEngine;

namespace ProjectSpacer
{

    public abstract class Controller : MonoBehaviour
    {

        protected Vector2 aimPoint = new Vector2(0f, 0f); // location relative to the ship the weapons should aim at
        protected Vector2 movementVector = new Vector2(0f, 0f); //vector that the ship should translate towards with a throttle modifer of the magnitude Magnitude must be between 0 and 1.
        protected Vector2 directionVector = new Vector2(0f, 0f); // vector that the ship should rotate twoards with a throttle modifer of the magnitude. Magnitude must be between 0 and 1.
        protected Rigidbody2D gridRigidBody;
        protected bool isFiring;


        public virtual void InitializeController()
        {
            gridRigidBody = gameObject.GetRequiredComponent<Rigidbody2D>();

        }

        public virtual Vector2 GetMovementVector()
        {
            return movementVector;
        }

        public virtual Vector2 GetAimPoint()
        {
            return aimPoint;
        }

        public virtual Vector2 GetDriectionVector()
        {
            return directionVector;
        }

        public virtual bool IsFiring()
        {
            return isFiring;
        }

    }
}
