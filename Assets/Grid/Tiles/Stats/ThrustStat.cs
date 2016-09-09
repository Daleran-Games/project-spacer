using UnityEngine;
using System;

namespace ProjectSpacer
{
    public class ThrustStat : IStat
    {

        public enum ThrusterMode
        {
            CONTROL,
            MANUEVER,
            TRAVEL
        }

        public float Thrust =0f;
        public Direction ThrustDirection;
        public Rotation ThrustRotation;
        public float Torque = 0f;
        public ThrusterMode ThrustMode = ThrusterMode.MANUEVER;
        private static Info _thrustInfo = new Info("Thrust");

        public Type Type
        {
            get { return typeof(ThrustStat); }
        }

        public Info StatInfo
        {
            get
            {
                return _thrustInfo;
            }
        }

        public ThrustStat()
        {
            ThrustDirection = getThrustDirection(Direction.UP);
            ThrustRotation = getThrustRotation(Direction.UP, Vector2Int.zero);
        }

        public ThrustStat(float thrustAmount, Direction tileDirection, Vector2Int tilePosition, ThrusterMode thrustMode)
        {
            Thrust = thrustAmount;
            ThrustDirection = getThrustDirection(tileDirection);
            ThrustRotation = getThrustRotation(tileDirection, tilePosition);
            ThrustMode = thrustMode;
        }

        Direction getThrustDirection (Direction dir)
        {
            switch(dir)
            {
                case Direction.UP:
                    return Direction.DOWN;
                case Direction.DOWN:
                    return Direction.UP;
                case Direction.RIGHT:
                    return Direction.LEFT;
                case Direction.LEFT:
                    return Direction.RIGHT;
                default:
                    Debug.LogError("PS ERROR: " + dir.ToString() + " not a valid orientation for thrust direction");
                    return Direction.UP; 
            }
        }

        Rotation getThrustRotation(Direction dir, Vector2Int localPos)
        {
            switch (dir)
            {
                case Direction.UP:
                    if (localPos.x > 0)
                        return Rotation.CW;
                    else if (localPos.x < 0)
                        return Rotation.CCW;
                    else
                        return Rotation.NONE;
                case Direction.DOWN:
                    if (localPos.x > 0)
                        return Rotation.CCW;
                    else if (localPos.x < 0)
                        return Rotation.CW;
                    else
                        return Rotation.NONE;
                case Direction.RIGHT:
                    if (localPos.y > 0)
                        return Rotation.CCW;
                    else if (localPos.y < 0)
                        return Rotation.CW;
                    else
                        return Rotation.NONE;
                case Direction.LEFT:
                    if (localPos.y > 0)
                        return Rotation.CW;
                    else if (localPos.y < 0)
                        return Rotation.CCW;
                    else
                        return Rotation.NONE;
                default:
                    Debug.LogError("PS ERROR: " + dir.ToString() + " not a valid orientation for thrust rotation");
                    return Rotation.NONE;
            }
        }
    }
}
