using UnityEngine;

namespace ProjectSpacer
{

    public class TargetController : Controller
    {

        public GameObject target;
        Vector2 _localVelocity;
        Vector2 _translateVector = Vector2.zero;
        Vector2 _directionVector = Vector2.zero;

        void Update()
        {
            if (target == null)
                target = FindObjectOfType<PlayerController>().gameObject;
        }

        void FixedUpdate()
        {
            _localVelocity = transform.InverseTransformDirection(_grid.GridRigidbody.velocity);

            if (target != null)
            {
                _directionVector = (Vector2)(target.transform.position - transform.position);
            }

            _translateVector = -_localVelocity;
        }

        public override Vector2 GetTranslateVector()
        {
            return _translateVector;
        }

        public override Vector2 GetDirectionVector()
        {
            return _directionVector;
        }

    }
}
