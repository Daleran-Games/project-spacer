using UnityEngine;
using System;

namespace ProjectSpacer
{
    public class ThrustStat : Stat
    {

        public enum Rotation
        {
            CW,
            CCW,
            NONE
        }

        public float Thrust;
        public Direction ThrustDirection;
        public Rotation ThrustRotation;
  
        static Info thrustInfo;

        public ThrustStat(float thrustAmount, Direction tileDirection, Vector2Int tilePosition)
        {
            Thrust = thrustAmount;
            ThrustDirection = getThrustDirection(tileDirection);
            ThrustRotation = getThrustRotation(tileDirection, tilePosition);
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

        public override int CompareTo(object obj)
        {
            if (obj == null) return 1;

            ThrustStat testStat = obj as ThrustStat;
            if (testStat != null)
                return this.Thrust.CompareTo(testStat.Thrust);
            else
                throw new ArgumentException("Object is not a Thrust");
        }

        public bool Equals(ThrustStat other)
        {
            if (other == null)
                return false;

            if (this.Thrust == other.Thrust)
                return true;
            else
                return false;
        }

        public override bool Equals(Stat other)
        {
            if (other == null)
                return false;

            ThrustStat thrustStat = other as ThrustStat;
            if (thrustStat == null)
                return false;
            else
                return Equals(thrustStat);
        }

        public override Info GetInfo()
        {
            return thrustInfo;
        }

        public override void SetInfo(Info info)
        {
            thrustInfo = info;
        }


    }
}
