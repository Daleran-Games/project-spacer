using UnityEngine;
using System.Collections.Generic;
using DalLib.Unity;
using DalLib.Math;

namespace ProjectSpacer
{

    public class CollisionSystem : MonoBehaviour
    {

        public GameObject colliderObject;
        public Grid grid;

        public GameObject WorldCollisionObject;
        public GameObject HangerCollisionObject;
        public GameObject FloorCollisionObject;
        public GameObject WallCollisionObject;

        public void InitializeSystem()
        {
            grid = gameObject.GetRequiredComponent<Grid>();

            colliderObject = new GameObject();
            colliderObject.name = gameObject.name + " Colliders";
            colliderObject.transform.parent = transform;
            buildColliders();

        }

        void buildColliders()
        {
            foreach (KeyValuePair<Vector2Int, Tile> kvp in grid.TileData)
            {
                switch (kvp.Value.GetMaxCollisionLayer())
                {
                    case CollisionLayer.WORLD:
                        if (WorldCollisionObject == null)
                        {
                            WorldCollisionObject = new GameObject();
                            WorldCollisionObject.name = gameObject.name + " World Colliders";
                            WorldCollisionObject.transform.parent = colliderObject.transform;
                        }
                        BuildNewCollider(WorldCollisionObject, kvp);
                        break;
                    case CollisionLayer.HANGER:
                        if (HangerCollisionObject == null)
                        {
                            HangerCollisionObject = new GameObject();
                            HangerCollisionObject.name = gameObject.name + " Hanger Colliders";
                            HangerCollisionObject.transform.parent = colliderObject.transform;
                        }
                        BuildNewCollider(HangerCollisionObject, kvp);
                        break;
                    case CollisionLayer.FLOOR:
                        if (FloorCollisionObject == null)
                        {
                            FloorCollisionObject = new GameObject();
                            FloorCollisionObject.name = gameObject.name + " Floor Colliders";
                            FloorCollisionObject.transform.parent = colliderObject.transform;
                        }
                        BuildNewCollider(FloorCollisionObject, kvp);
                        break;
                    case CollisionLayer.WALL:
                        if (WallCollisionObject == null)
                        {
                            WallCollisionObject = new GameObject();
                            WallCollisionObject.name = gameObject.name + " Wall Colliders";
                            WallCollisionObject.transform.parent = colliderObject.transform;
                        }
                        BuildNewCollider(WallCollisionObject, kvp);
                        break;
                    default:
                        Debug.LogError("PS ERROR: " + kvp.Value.GetMaxCollisionLayer().ToString() + " not a valid Grid collision layer");
                        break;
                }


            }
        }

        void BuildNewCollider(GameObject collisionObj, KeyValuePair<Vector2Int, Tile> kvp)
        {
            BoxCollider2D newCollider = collisionObj.AddComponent<BoxCollider2D>();
            newCollider.size = new Vector2(GV.tileSize, GV.tileSize);
            newCollider.offset = (Vector2)transform.position + new Vector2(kvp.Key.x - grid.GridCenter.x + GV.halfTileSize, kvp.Key.y - grid.GridCenter.y + GV.halfTileSize);
        }
    }
}
