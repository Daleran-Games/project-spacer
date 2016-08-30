using UnityEngine;

namespace ProjectSpacer
{

    public class TargetController : Controller
    {

        public GameObject target;
        Vector2 localVelocity;

        void Update()
        {
            if (target == null)
                target = FindObjectOfType<PlayerController>().gameObject;
        }

        void FixedUpdate()
        {
            localVelocity = transform.InverseTransformDirection(gridRigidBody.velocity).normalized;

            if (target != null)
            {
                directionVector = (Vector2)(target.transform.position - transform.position);
            }

            movementVector = -localVelocity;

        }


    }
}
