using UnityEngine;
using DalLib.Unity;

namespace ProjectSpacer
{

    public class TargetTest : MonoBehaviour
    {

        public SavedGrid SavedTestGrid;
        Grid TestGrid;

        void Start()
        {
            gameObject.name = SavedTestGrid.GridInfo.name;
            gameObject.AddComponent<Grid>();
            TestGrid = gameObject.GetRequiredComponent<Grid>();
            gameObject.AddComponent<TargetController>();
            TestGrid.InitializeGrid(SavedTestGrid, gameObject.GetRequiredComponent<TargetController>());
        }
    }
}
