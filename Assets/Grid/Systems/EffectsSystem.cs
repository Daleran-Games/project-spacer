using UnityEngine;
using System.Collections.Generic;

namespace ProjectSpacer
{

    public class EffectsSystem : MonoBehaviour
    {

        GameObject effectParent;
        Grid grid;
        List<GridEffect> watchedEffects;

        // Use this for initialization
        void Start()
        {
            

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void InitializeSystem()
        {
            grid = gameObject.GetRequiredComponent<Grid>();
            effectParent = new GameObject();
            effectParent.name = gameObject.name + " Effects";
            effectParent.transform.parent = transform;

            foreach (KeyValuePair<Vector2Int, Tile> kvp in grid.TileData)
            {
                watchedEffects.AddRange(kvp.Value.TileEffects);
            }


        }
    }
}
