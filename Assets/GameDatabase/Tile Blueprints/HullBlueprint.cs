
namespace ProjectSpacer
{
    [System.Serializable]
    public class HullBlueprint 
    {
        string _name;
        string _description;
        string _iconPath;

        Type4Set<CollisionLayer> _hullCollision;
        Type4Set<QuadBlueprint[]> _quads;
        StatBlueprint[] _hullStats;

        public HullBlueprint(string name, string desc, string icon, Type4Set<CollisionLayer> col, StatBlueprint[] stats, Type4Set<QuadBlueprint[]> quads)
        {
            _name = name;
            _description = desc;
            _iconPath = icon;
            _hullCollision = col;

            _hullStats = stats;
            _quads = quads;

        }

    }
}

