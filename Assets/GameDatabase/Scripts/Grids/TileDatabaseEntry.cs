using UnityEngine;

namespace ProjectSpacer.Database
{
    [System.Serializable]
    public class TileDatabaseEntry
    {
        string _hull;
        string _armor;
        string _module;
 
        public TileDatabaseEntry (string hull, string armor, string module)
        {
            _hull = hull;
            _armor = armor;
            _module = module;
        }


    }
}
