using UnityEngine;

namespace ProjectSpacer
{


    public class _Test : MonoBehaviour
    {

        public SavedGrid SavedTestGrid;
        Grid TestGrid;


        void Start()
        {

            gameObject.name = SavedTestGrid.GridInfo.name;
            gameObject.AddComponent<Grid>();
            TestGrid = gameObject.GetRequiredComponent<Grid>();
            gameObject.AddComponent<PlayerController>();
            TestGrid.InitializeGrid(SavedTestGrid, gameObject.GetRequiredComponent<PlayerController>());


        }


    }
}