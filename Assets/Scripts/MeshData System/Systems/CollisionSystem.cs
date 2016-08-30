using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionSystem : MonoBehaviour {

    public GameObject colliderObject;
    public Grid grid;

    public List<Collider2D> Colliders = new List<Collider2D>();


    public void InitializeSystem()
    {
        grid = gameObject.GetRequiredComponent<Grid>();

        colliderObject = new GameObject();
        colliderObject.name = gameObject.name + " Colliders";
        colliderObject.transform.parent = transform;
        buildColliders();

    }

    void buildColliders ()
    {
        foreach (KeyValuePair<Vector2Int, Tile> kvp in grid.TileData)
        {
            if(kvp.Value.collisionLayer == CollisionLayer.WALL)
            {
                BoxCollider2D newCollider = colliderObject.AddComponent<BoxCollider2D>();
                newCollider.size = new Vector2(GV.tileSize, GV.tileSize);
                newCollider.offset = (Vector2)transform.position + new Vector2(kvp.Key.x - grid.GridCenter.x + GV.halfTileSize, kvp.Key.y - grid.GridCenter.y + GV.halfTileSize);
            }
        }
    }
}
