using System;
using UnityEngine;

namespace ProjectSpacer
{

    public class TargetController : Controller
    {

        public GameObject target;
        Vector2 localVelocity;
        Vector2 translateVector = Vector2.zero;
        Vector2 directionVector = Vector2.zero;

        public override void InitializeControllerExtension()
        {

        }

        void Update()
        {
            if (target == null)
            {
                if (FindObjectOfType<PlayerController>() != null)
                {
                    target = FindObjectOfType<PlayerController>().gameObject;
                }
            }
        }

        void FixedUpdate()
        {
            localVelocity = transform.InverseTransformDirection(frame.FrameRigidbody.velocity);

            if (target != null)
            {
                directionVector = (Vector2)(target.transform.position - transform.position);
            }

            translateVector = -localVelocity;
        }

        public override Vector2 GetTranslateVector()
        {
            return translateVector;
        }

        public override Vector2 GetDirectionVector()
        {
            return directionVector;
        }


    }
}
