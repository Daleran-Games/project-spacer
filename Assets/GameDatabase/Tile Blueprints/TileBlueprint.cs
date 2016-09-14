using UnityEngine;

namespace ProjectSpacer
{
    public class TileBlueprint
    {
        string _hull;
        string _armor;
        string _module;
 
        public TileBlueprint (string hull, string armor, string module)
        {
            _hull = hull;
            _armor = armor;
            _module = module;
        }


    }
}
