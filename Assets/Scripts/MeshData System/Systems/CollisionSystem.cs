using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionSystem : MonoBehaviour {

    public GameObject parent;
    public GameObject colliderObject;
    public Grid grid;

    public List<Collider2D> Colliders = new List<Collider2D>();


    public void InitializeSystem()
    {
        parent = gameObject;
        grid = parent.GetRequiredComponent<Grid>();

        colliderObject = new GameObject();
        colliderObject.name = parent.name + " Colliders";
        colliderObject.transform.parent = parent.transform;
        buildColliders();

    }

    void buildColliders ()
    {
        foreach (KeyValuePair<Vector2Int, Tile> kvp in grid.TileData)
        {
            if(kvp.Value.IsCollidable == true)
            {
                BoxCollider2D newCollider = colliderObject.AddComponent<BoxCollider2D>();
                newCollider.size = new Vector2(GlobalVariables.tileSize, GlobalVariables.tileSize);
                newCollider.offset = new Vector2(kvp.Key.x - grid.GridCenter.x + GlobalVariables.halfTileSize, kvp.Key.y - grid.GridCenter.y + GlobalVariables.halfTileSize);
            }
        }
    }
}
