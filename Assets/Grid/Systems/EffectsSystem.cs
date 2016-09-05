using UnityEngine;
using System.Collections.Generic;

namespace ProjectSpacer
{

    public class EffectsSystem : MonoBehaviour
    {

        GameObject effectParent;
        Grid grid;
        List<GameObject> watchedEffects = new List<GameObject>();

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
                if (kvp.Value.TileEffects.Count > 0)
                {
                    foreach (GameObject ge in kvp.Value.TileEffects)
                    {
                        GameObject newEffect = Instantiate(ge, effectParent.transform) as GameObject;
                        newEffect.transform.position = (Vector3)grid.ToLocalSpace(kvp.Key);
                        newEffect.transform.Rotate(GV.GetRotationFromDirection(kvp.Value.direction));
                        newEffect.SetActive(false);
                        watchedEffects.Add(newEffect);
                    }
                }
            }
        }

        
    }
}
