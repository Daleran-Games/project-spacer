using UnityEngine;
using System.Collections.Generic;


namespace ProjectSpacer
{

    public class ControlSystem : MonoBehaviour
    {

        public float maxSpeed;
        public Vector2 thrustVector;
        public float torqueScalar;
        public ThrustBlock thrustBlock;
        public float translateThrottle;

        VectorPID gridSteeringPID = new VectorPID(0.5f, 0.01f, 1.5f);


        //TEMP PUBLIC
        public float steering = 0f;
        public float PID;
        public float aimAngle;

        public GameObject parent;
        Grid grid;

        //TEMP PUBLIC
        public Controller controller;

        public virtual void InitializeSystem()
        {

            parent = gameObject;
            grid = parent.GetRequiredComponent<Grid>();

            thrustBlock = new ThrustBlock(grid);

            UpdateSystem();

            maxSpeed = (thrustBlock.getTotalThrust() / grid.GridRigidbody.mass) * GV.maxVelocityTuner;
        }

        void FixedUpdate()
        {
            if (controller != null)
                Move(controller.GetMovementVector(), controller.GetDriectionVector());
        }

        public void AssignController(Controller cont)
        {
            controller = cont;

            if (controller is PlayerController)
            {
                parent.tag = "Player";
            }
        }

        public ThrustBlock GetThrustBlock()
        {
            return thrustBlock;
        }

        public void UpdateSystem()
        {
            float newMass = 0f;
            thrustBlock.Clear();

            foreach (KeyValuePair<Vector2Int, Tile> kvp in grid.TileData)
            {
                foreach (Stat t in kvp.Value.tileStats)
                {
                    if (t is ThrustStat)
                    {
                        thrustBlock.AddTile(kvp.Value, kvp.Key);
                    }

                    if (t is MassStat)
                    {
                        newMass += ((MassStat)t).Mass;
                    }
                }
            }

            grid.GridRigidbody.mass = newMass;
        }

        public virtual float GetMaxSpeed()
        {
            return maxSpeed;
        }

        public virtual Vector2 GetThrustVector()
        {
            return thrustVector;
        }

        public virtual float GetTorqueScalar()
        {
            return torqueScalar;
        }

        public virtual float GetTranslationFractional()
        {
            return translateThrottle;
        }

        public virtual float GetTorqueFractional()
        {
            if (torqueScalar > 0f)
                return torqueScalar / thrustBlock.ccw;
            else if (torqueScalar < 0f)
                return torqueScalar / thrustBlock.cw;
            else
                return 0f;
        }



        public virtual void Move(Vector2 movmentVector, Vector2 direction)
        {
            Rotate(direction);
            thrustVector = setThrustVector(movmentVector);
            grid.GridRigidbody.AddRelativeForce(thrustVector);
        }

        public virtual void Rotate(Vector2 direction)
        {


            if (direction != Vector2.zero)
            {
                aimAngle = Vector2.Angle(grid.GridRigidbody.transform.up, direction) / 180f;

                if (Vector3.Cross(grid.GridRigidbody.transform.up, direction).z > 0)
                    aimAngle = aimAngle * -1f;

                PID = gridSteeringPID.Update(aimAngle, Time.fixedDeltaTime);

                if (aimAngle > 0)
                {
                    steering = thrustBlock.ccw;
                }
                else if (aimAngle < 0)
                {
                    steering = -thrustBlock.cw;
                } 

                if (PID < GV.headingDeadZone && PID > -GV.headingDeadZone)
                {
                    steering = 0f;
                }
                    
                torqueScalar = PID * steering * GV.torqueFactor;
                grid.GridRigidbody.AddTorque(-torqueScalar);
            }

        }

        Vector2 setThrustVector(Vector2 dir)
        {

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
            return thrustVector;
        }



    }
}
