using UnityEngine;
using System.Collections.Generic;

namespace ProjectSpacer
{

    [CreateAssetMenu(fileName = "NewGrid", menuName = "Data/Grid", order = 0)]
    public class SavedGrid : ScriptableObject
    {

        public Info GridInfo;
        public List<SavedGridLine> TileRows;



    }
}
