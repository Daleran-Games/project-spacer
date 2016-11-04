using UnityEngine;
using System;
using DalLib.Math;

namespace ProjectSpacer
{
    public class ThrustStat : IStat
    {

        public enum ThrusterMode
        {
            Rotational,
            Translate,
            Travel
        }

        public float Thrust =0f;
        public Direction ThrustDirection;
        public Rotation ThrustRotation;
        public float Torque = 0f;
        public ThrusterMode ThrustMode = ThrusterMode.Translate;
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
            ThrustDirection = getThrustDirection(Direction.Up);
            ThrustRotation = getThrustRotation(Direction.Up, Vector2Int.zero);
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
                case Direction.Up:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Up;
                case Direction.Right:
                    return Direction.Left;
                case Direction.Left:
                    return Direction.Right;
                default:
                    Debug.LogError("PS ERROR: " + dir.ToString() + " not a valid orientation for thrust direction");
                    return Direction.Up; 
            }
        }

        Rotation getThrustRotation(Direction dir, Vector2Int localPos)
        {
            switch (dir)
            {
                case Direction.Up:
                    if (localPos.x > 0)
                    {
                        Torque = 0f;
                        return Rotation.CW;
                    }
                    else if (localPos.x < 0)
                    {
                        Torque = 0f;
                        return Rotation.CCW;
                    }
                    else
                    {
                        Torque = 0f;
                        return Rotation.NONE;
                    }
                case Direction.Down:
                    if (localPos.x > 0)
                        return Rotation.CCW;
                    else if (localPos.x < 0)
                        return Rotation.CW;
                    else
                        return Rotation.NONE;
                case Direction.Right:
                    if (localPos.y > 0)
                        return Rotation.CCW;
                    else if (localPos.y < 0)
                        return Rotation.CW;
                    else
                        return Rotation.NONE;
                case Direction.Left:
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
