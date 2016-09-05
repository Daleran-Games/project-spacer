using UnityEngine;
using System;

namespace ProjectSpacer
{
    public class ThrustStat : Stat
    {
        public float Thrust;
        public Direction ThrustDirection;
        public bool CWThrust;
  
        static Info thrustInfo;

        public ThrustStat(float thrustAmount, Tile tile, Vector2Int tilePosition)
        {
            Thrust = thrustAmount;
            ThrustDirection = getThrustDirection(tile.direction);

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
        /*
        bool getThrustRotation(Direction dir, Vector2Int pos)
        {

        }
        */
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
