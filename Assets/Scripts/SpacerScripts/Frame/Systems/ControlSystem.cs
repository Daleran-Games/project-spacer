using UnityEngine;
using System.Collections.Generic;
using DalLib.Math;
using DalLib.Unity;

namespace ProjectSpacer
{

    public class ControlSystem : FrameSystem
    {

        public Vector2 thrustVector;

        VectorPID steeringPID = new VectorPID(0.5f, 0.01f, 1.5f);
        [SerializeField]
        float steering = 0f;
        [SerializeField]
        float PID;
        [SerializeField]
        float aimAngle;

        [SerializeField]
        public GameObject parent;


        //TEMP PUBLIC
        public Controller controller;

        public override void InitializeSystemExtension()
        {

            parent = gameObject;

            frame.ControllerAssigned += OnControllerAssigned;
            frame.ControllerUnassigned += OnControllerUnassigned;

            UpdateSystem();

        }

        void FixedUpdate ()
        {

            if (controller != null)
            {
                thrustVector = setThrustVector(controller.GetTranslateVector());
                frame.FrameRigidbody.AddRelativeForce(thrustVector);
                Rotate(controller.GetDirectionVector());
            }

        }

        

        void OnControllerAssigned(Controller cont)
        {
            controller = cont;

            if (controller is PlayerController)
            {
                parent.tag = "Player";
            }

        }

        void OnControllerUnassigned (Controller cont)
        {
            if (controller is PlayerController)
            {
                parent.tag = "Untagged";
            }
            controller = null;
        }

        void UpdateSystem()
        {

        }

        public void Rotate(Vector2 direction)
        {

            if (direction != Vector2.zero)
            {
                aimAngle = Vector2.Angle(frame.FrameRigidbody.transform.up, direction) / 180f;

                if (Vector3.Cross(frame.FrameRigidbody.transform.up, direction).z > 0)
                    aimAngle = aimAngle * -1f;

                PID = steeringPID.Update(aimAngle, Time.fixedDeltaTime);

                if (aimAngle > 0)
                {
                    steering = 0f;

                }
                else if (aimAngle < 0)
                {
                    steering = 0f;
                }

                if (PID < GV.headingDeadZone && PID > -GV.headingDeadZone)
                {
                    steering = 0f;
                }
                frame.FrameRigidbody.AddTorque(-PID * steering * GV.torqueFactor);
            }

        }


        Vector2 setThrustVector(Vector2 dir)
        {

            /*
            translateThrottle = dir.magnitude;
            thrustVector = Vector2.zero;
            float slope = dir.y / dir.x;

            if (dir.x == 0f && dir.y == 0f)
            {
                return thrustVector * dir.magnitude;
            }
            else if (dir.x != 0f && dir.y == 0f)
            {
                if (dir.x > 0f)
                {
                    thrustVector.x = thrustBlock.right;
                    return thrustVector * dir.magnitude;
                }
                else
                {
                    thrustVector.x = thrustBlock.left;
                    return thrustVector * dir.magnitude;
                }
            }
            else if (dir.x == 0f && dir.y != 0f)
            {
                if (dir.y > 0f)
                {
                    thrustVector.y = thrustBlock.up;
                    return thrustVector * dir.magnitude;
                }
                else
                {
                    thrustVector.y = thrustBlock.down;
                    return thrustVector * dir.magnitude;
                }
            }
            else if (dir.x > 0f)
            {
                float fr = slope * thrustBlock.right;
                if (slope > (thrustBlock.up / thrustBlock.right))
                {
                    return new Vector2(dir.x / dir.y * thrustBlock.up, thrustBlock.up) * dir.magnitude;
                }
                else if (slope == (thrustBlock.up / thrustBlock.right))
                {
                    return new Vector2(thrustBlock.right, thrustBlock.up) * dir.magnitude;
                }
                else if (slope < (thrustBlock.up / thrustBlock.right) && slope > (thrustBlock.down / thrustBlock.right))
                {
                    return new Vector2(thrustBlock.right, fr) * dir.magnitude;
                }
                else if (slope == (thrustBlock.down / thrustBlock.right))
                {
                    return new Vector2(thrustBlock.right, thrustBlock.down) * dir.magnitude;
                }
                else if (slope < (thrustBlock.down / thrustBlock.right))
                {
                    return new Vector2(dir.x / dir.y * thrustBlock.down, thrustBlock.down) * dir.magnitude;
                }
            }
            else
            {
                float fl = slope * thrustBlock.left;
                if (slope < (thrustBlock.up / thrustBlock.left))
                {
                    return new Vector2(dir.x / dir.y * thrustBlock.up, thrustBlock.up) * dir.magnitude;
                }
                else if (slope == (thrustBlock.up / thrustBlock.left))
                {
                    return new Vector2(thrustBlock.left, thrustBlock.up) * dir.magnitude;
                }
                else if (slope > (thrustBlock.up / thrustBlock.left) && slope < (thrustBlock.down / thrustBlock.left))
                {
                    return new Vector2(thrustBlock.left, fl) * dir.magnitude;
                }
                else if (slope == (thrustBlock.down / thrustBlock.left))
                {
                    return new Vector2(thrustBlock.left, thrustBlock.down) * dir.magnitude;
                }
                else if (slope > (thrustBlock.down / thrustBlock.left))
                {
                    return new Vector2(dir.x / dir.y * thrustBlock.down, thrustBlock.down) * dir.magnitude;
                }

            }

            Debug.Log("Thrust Block Error: getThrustVector");
            */

            //return thrustVector;
            return Vector2.zero;
        }

   

    }
}
