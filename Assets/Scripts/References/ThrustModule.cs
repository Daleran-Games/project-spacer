using UnityEngine;

namespace ProjectSpacer
{

    public class ThrustModule : MonoBehaviour
    {

        public float thrust;

        //TEMP PUBLIC
        public float throttle;
        //TEMP PUBLIC

        public Vector3 Orientation;
        ControlSystem controlSystem;



        // Use this for initialization
        public void Initialize()
        {
            controlSystem = transform.root.GetComponent<ControlSystem>();
            Orientation = Vector3.zero;
            setOrientation();
            //controlSystem.ModifyThrust (Orientation, thrust, true);

        }

        void FixedUpdate()
        {
            if (shouldThrusterFire(controlSystem.GetThrustVector(), controlSystem.GetTorqueScalar()))
                throttle = controlSystem.GetTorqueFractional() + controlSystem.GetTranslationFractional();
            else
                throttle = 0f;
        }

        void OnDestroy()
        {
            //controlSystem.ModifyThrust (Orientation, thrust, false);
        }

        public float getThrottle()
        {
            return throttle;
        }

        private bool confirmDirection(float angle)
        {
            if (transform.localEulerAngles.z > (angle - GV.directionError) && transform.localEulerAngles.z < (angle + GV.directionError))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void setOrientation()
        {

            if (confirmDirection(0))
                Orientation = new Vector3(0f, 1f, 0f);
            if (confirmDirection(180))
                Orientation = new Vector3(0f, -1f, 0f);
            if (confirmDirection(90))
                Orientation = new Vector3(-1f, 0f, 0f);
            if (confirmDirection(270))
                Orientation = new Vector3(1f, 0f, 0f);

            if (confirmDirection(180) && transform.localPosition.x < (0 - GV.directionError) && transform.localPosition.y > (0 + GV.directionError))
                Orientation.z = -1f;
            if (confirmDirection(270) && transform.localPosition.x < (0 - GV.directionError) && transform.localPosition.y > (0 + GV.directionError))
                Orientation.z = 1f;
            if (confirmDirection(180) && transform.localPosition.x > (0 + GV.directionError) && transform.localPosition.y > (0 + GV.directionError))
                Orientation.z = 1f;
            if (confirmDirection(90) && transform.localPosition.x > (0 + GV.directionError) && transform.localPosition.y > (0 + GV.directionError))
                Orientation.z = -1f;
            if (confirmDirection(90) && transform.localPosition.x > (0 + GV.directionError) && transform.localPosition.y < (0 - GV.directionError))
                Orientation.z = 1f;
            if (confirmDirection(270) && transform.localPosition.x < (0 - GV.directionError) && transform.localPosition.y < (0 - GV.directionError))
                Orientation.z = -1f;
            if (confirmDirection(0) && transform.localPosition.x > (0 + GV.directionError) && transform.localPosition.y < (0 - GV.directionError))
                Orientation.z = -1f;
            if (confirmDirection(0) && transform.localPosition.x < (0 - GV.directionError) && transform.localPosition.y < (0 - GV.directionError))
                Orientation.z = 1f;
        }

        bool shouldThrusterFire(Vector2 tV, float tS)
        {

            if (GV.IsSameSign(tV.x, Orientation.x))
                return true;
            else if (GV.IsSameSign(tV.y, Orientation.y))
                return true;
            else if (GV.IsSameSign(tS, Orientation.z))
                return true;
            else
                return false;
        }



    }
}
