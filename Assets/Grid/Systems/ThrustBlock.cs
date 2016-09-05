using UnityEngine;
using System.Collections.Generic;

namespace ProjectSpacer
{

    [System.Serializable]
    public class ThrustBlock
    {

        public float up=0f, down = 0f, right = 0f, left = 0f, cw = 0f, ccw=0f;

        public List<Tile> UpTiles = new List<Tile>();
        public List<Tile> DownTiles = new List<Tile>();
        public List<Tile> LeftTiles = new List<Tile>();
        public List<Tile> RightTiles = new List<Tile>();
        public List<Tile> CWTiles = new List<Tile>();
        public List<Tile> CCWTiles = new List<Tile>();

        Grid grid;

        public ThrustBlock(Grid g)
        {
            this.Clear();
            grid = g;
    
        }


        public float getTotalThrust()
        {

            return up - down - left + right;
        }

        public void Clear()
        {
            up = 0f;
            down = 0f;
            right = 0f;
            left = 0f;
            cw = 0f;
            ccw = 0f;
        }

        public void AddTile (Tile tile, Vector2Int pos)
        {
            ModifyThrust(tile, pos, true);
        }

        public void RemoveTile(Tile tile, Vector2Int pos)
        {
            ModifyThrust(tile, pos, false);
        }

        void ModifyThrust(Tile tile, Vector2Int pos, bool add)
        {
            Vector2 localPos = new Vector2(pos.x - grid.GridCenter.x + GV.halfTileSize, pos.y - grid.GridCenter.y + GV.halfTileSize);

            float amount = 0f;
            if (tile.statCollection.TryGetValue(StatType.Thrust, out amount))
            {
                if (add == false)
                    amount = amount * -1f;
            }
            else
            {
                return;
            }

            switch (tile.direction)
            {
                case Direction.UP:

                    down -= amount;
                    UpTiles.Add(tile);

                    if (localPos.x > 0)
                    {
                        cw -= amount;
                        CWTiles.Add(tile);
                    }
                    else if (localPos.x < 0)
                    {
                        ccw += amount;
                        CCWTiles.Add(tile);
                    }
                    break;
                case Direction.DOWN:

                    up += amount;
                    DownTiles.Add(tile);

                    if (localPos.x > 0)
                    {
                        ccw += amount;
                        CCWTiles.Add(tile);
                    }
                    else if (localPos.x < 0)
                    {
                        cw -= amount;
                        CWTiles.Add(tile);
                    }


                    break;
                case Direction.RIGHT:

                    left -= amount;
                    RightTiles.Add(tile);

                    if (localPos.y > 0)
                    {
                        ccw += amount;
                        CCWTiles.Add(tile);
                    }
                    else if (localPos.y < 0)
                    {
                        cw -= amount;
                        CWTiles.Add(tile);
                    }


                    break;
                case Direction.LEFT:

                    right += amount;
                    LeftTiles.Add(tile);

                    if (localPos.y > 0)
                    {
                        cw -= amount;
                        CWTiles.Add(tile);
                    }
                    else if (localPos.y < 0)
                    {
                        ccw += amount;
                        CCWTiles.Add(tile);
                    }

                    break;

                default:
                    Debug.LogError("PS ERROR: " + tile.direction.ToString() + " not a valid orientation for thrust direction");
                    break;
            }
        }

    }
}
