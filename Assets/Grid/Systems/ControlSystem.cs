using UnityEngine;
using System.Collections.Generic;


namespace ProjectSpacer
{

    public class ControlSystem : MonoBehaviour
    {

        public Vector2 thrustVector;

        List<SubTile> _thrustTiles = new List<SubTile>();

        VectorPID _steeringPID = new VectorPID(0.5f, 0.01f, 1.5f);
        float _steering = 0f;
        float _PID;
        float _aimAngle;

        public GameObject parent;
        Grid _grid;

        //TEMP PUBLIC
        public Controller controller;

        public virtual void InitializeSystem()
        {

            parent = gameObject;
            _grid = parent.GetRequiredComponent<Grid>();

            _grid.ControllerAssigned += OnControllerAssigned;
            _grid.ControllerUnassigned += OnControllerUnassigned;

            UpdateSystem();

        }

        void FixedUpdate ()
        {

            if (controller != null)
            {
                thrustVector = setThrustVector(controller.GetTranslateVector());
                _grid.GridRigidbody.AddRelativeForce(thrustVector);
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
            float newMass = 0f;

            foreach (KeyValuePair<Vector2Int, Tile> kvp in _grid.TileData)
            {

                if (kvp.Value.ContainsStat<ThrustStat>())
                    _thrustTiles.Add(kvp.Value.GetSubTileWithStat<ThrustStat>());

                if (kvp.Value.ContainsStat<MassStat>())
                    newMass += kvp.Value.GetTotalStat<MassStat>().Mass;
            }

            _grid.GridRigidbody.mass = newMass;
        }

        public void Rotate(Vector2 direction)
        {

            if (direction != Vector2.zero)
            {
                _aimAngle = Vector2.Angle(_grid.GridRigidbody.transform.up, direction) / 180f;

                if (Vector3.Cross(_grid.GridRigidbody.transform.up, direction).z > 0)
                    _aimAngle = _aimAngle * -1f;

                _PID = _steeringPID.Update(_aimAngle, Time.fixedDeltaTime);

                if (_aimAngle > 0)
                {
                    _steering = 0f;

                }
                else if (_aimAngle < 0)
                {
                    _steering = 0f;
                }

                if (_PID < GV.headingDeadZone && _PID > -GV.headingDeadZone)
                {
                    _steering = 0f;
                }
                _grid.GridRigidbody.AddTorque(-_PID * _steering * GV.torqueFactor);
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
