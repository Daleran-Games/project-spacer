using UnityEngine;

namespace ProjectSpacer
{

    public class AIController : Controller
    {

        public GameObject Target; //Temporarty value that will have the AI chase an editor selected target


        // Update is called once per frame
        void FixedUpdate()
        {

            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetDir = MousePos - transform.position;
            Vector2 velocity = gridRigidBody.velocity;

            if (getRangeToTargetFloat(Target) >= 30f)
            {
                movementVector = Vector2.up;
            }
            else if ((getRangeToTargetFloat(Target) < 25f))
            {
                movementVector = Vector2.down;
            }
            else
                movementVector = Vector2.zero;

            aimPoint = getRangeToTargetVector(Target);

            //grid.logic.Move (MVMT, getRangeToTargetVector(Target), false);


        }



        float getRangeToTargetFloat(GameObject target)
        {
            return (target.transform.position - gridRigidBody.transform.position).magnitude;
        }

        Vector2 getRangeToTargetVector(GameObject target)
        {
            return (Vector2)(target.transform.position - gridRigidBody.transform.position);
        }

        float getOptimalRange()
        {
            return 100f;
        }



    }
}
