using UnityEngine;
using System;
using System.Collections.Generic;
using DalLib.Math;
using DalLib.Unity;

namespace ProjectSpacer
{
    public class Grid : MonoBehaviour
    {

        public Controller GridController;
        public Rigidbody2D GridRigidbody;

        MeshSystem GridMeshSystem;
        public CollisionSystem GridCollisionSystem;
        public ControlSystem GridControlSystem;
        public EffectsSystem GridEffectsSystem;

        public SavedGrid Saved;
        public Info GridInfo;

        public Dictionary<Vector2Int, Tile> TileData;
        public Vector2 GridCenter;

        public delegate void ControllerEvent(Controller cont);
        public ControllerEvent ControllerAssigned;
        public ControllerEvent ControllerUnassigned;

        public delegate void GridTileEvent(Tile tile, Vector2Int pos);
        public GridTileEvent TileAdded;
        public GridTileEvent TileRemoved;

        public delegate void GridSystemEvent(int priority);
        public GridSystemEvent InitializeSystem;
        public GridSystemEvent DeinitializeSystem;

        public void InitializeGrid(SavedGrid savedGrid, Controller cont)
        {

            TileData = new Dictionary<Vector2Int, Tile>();
            GridCenter = (Vector2)transform.position;

            GridRigidbody = gameObject.GetOrAddComponent<Rigidbody2D>();
            GridRigidbody.gravityScale = 0f;
            GridRigidbody.angularDrag = 0f;
            GridRigidbody.drag = 0f;

            Saved = savedGrid;
            GridInfo = Saved.GridInfo;
            BuildSavedGrid();

            GridMeshSystem = gameObject.GetOrAddComponent<MeshSystem>();
            GridMeshSystem.InitializeSystem();
            GridMeshSystem.BuildMesh(GridCenter);

            GridControlSystem = gameObject.GetOrAddComponent<ControlSystem>();
            GridControlSystem.InitializeSystem();

            GridCollisionSystem = gameObject.GetOrAddComponent<CollisionSystem>();
            GridCollisionSystem.InitializeSystem();

            GridController = cont;
            GridController.InitializeController();

            ControllerAssigned(GridController);

            GridEffectsSystem = gameObject.GetOrAddComponent<EffectsSystem>();
            GridEffectsSystem.InitializeSystem();

        }

        public void BuildSavedGrid()
        {
            int sizeX = 0;
            foreach (SavedGridLine sgl in Saved.TileRows)
            {
                if (sgl.SavedElements.Count > sizeX)
                    sizeX = sgl.SavedElements.Count;
            }

            int sizeY = Saved.TileRows.Count;

            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    if (Saved.TileRows[y].SavedElements[x].Tile != null)
                    {
                        TileData.Add(new Vector2Int(x, y), Saved.TileRows[y].SavedElements[x].Tile.BuildTile(Saved.TileRows[y].SavedElements[x].Rotation, new Vector2Int(x, y), Saved.TileRows[y].SavedElements[x].Flipped, Saved.TileRows[y].SavedElements[x].TileColor));
                        RecalculateCenter();
                    }

                }
            }

            RecalculateCenter();
        }

        public Vector2 ToLocalSpace (Vector2Int gridCoord)
        {
            return new Vector2(gridCoord.x - GridCenter.x + GV.halfTileSize, gridCoord.y - GridCenter.y + GV.halfTileSize);
        }

        public void RecalculateCenter()
        {
            float minX = GetMinX();
            float minY = GetMinY();
            float maxX = GetMaxX();
            float maxY = GetMaxY();

            GridCenter = new Vector2(((maxX - minX) / 2f) + (GV.tileSize * 0.5f), ((maxY - minY) / 2f) + (GV.tileSize * 0.5f));
        }

        public int GetMinX()
        {
            int x = 0;
            foreach (Vector2Int coord in TileData.Keys)
            {
                if (coord.x < x)
                    x = coord.x;
            }
            return x;
        }

        public int GetMaxX()
        {
            int x = 0;
            foreach (Vector2Int coord in TileData.Keys)
            {
                if (coord.x > x)
                    x = coord.x;
            }
            return x;
        }

        public int GetMinY()
        {
            int y = 0;
            foreach (Vector2Int coord in TileData.Keys)
            {
                if (coord.y < y)
                    y = coord.y;
            }
            return y;
        }

        public int GetMaxY()
        {
            int y = 0;
            foreach (Vector2Int coord in TileData.Keys)
            {
                if (coord.y > y)
                    y = coord.y;
            }
            return y;
        }

    }
}
