using UnityEngine;
using System.Collections.Generic;

namespace ProjectSpacer
{

    [System.Serializable]
    public class ThrustBlock
    {
        public float Up = 0f;
        public float Down = 0f;
        public float Right = 0f;
        public float Left = 0f;
        public float CCW = 0f;
        public float CW = 0f;

        private Grid _grid;



        public ThrustBlock(Grid grid)
        {
            _grid = grid;

        }

        public void Clear ()
        {
            Up = 0f;
            Down = 0f;
            Right = 0f;
            Left = 0f;
            CCW = 0f;
            CW = 0f;
        }

        public void AddTile (Tile tile)
        {
            tile.TileEnabled += OnEnableDisable;
            if (tile.Enabled == State.ENABLED)
            {

            }
        }

        public void RemoveTile(Tile tile)
        {
            tile.TileEnabled -= OnEnableDisable;
        }

        void OnEnableDisable (Tile tile, State state)
        {

        }

        void ModifyThrust (Direction dir, float amount, bool add)
        {
            if (add == false)
                amount = amount * -1f;

            switch (dir)
            {
                case Direction.UP:
                    Up += amount;
                    break;
                case Direction.DOWN:
                    Down += amount;
                    break;
                case Direction.RIGHT:
                    Right += amount;
                    break;
                case Direction.LEFT:
                    Left += amount;
                    break;
                default:
                    Debug.LogError("PS ERROR: " + dir.ToString() + " not a valid orientation for thrust direction");
                    break;
            }
        }

        void ModifyThrust(Rotation rot, float amount, bool add)
        {
            if (add == false)
                amount = amount * -1f;

            switch (rot)
            {
                case Rotation.CCW:
                    CCW += amount;
                    break;
                case Rotation.CW:
                    CW += amount;
                    break;
                case Rotation.NONE:
                    break;
                default:
                    Debug.LogError("PS ERROR: " + rot.ToString() + " not a valid orientation for thrust rotation");
                    break;
            }
        }

    }
}
