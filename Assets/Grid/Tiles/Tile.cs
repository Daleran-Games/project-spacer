using System.Collections.Generic;

namespace ProjectSpacer
{

    public class Tile
    {

        public Info TileInfo = GV.defaultInfo;

        public Direction direction = Direction.UP;
        public bool flipped = false;

        public CollisionLayer collisionLayer = CollisionLayer.ENTITY;

        public Dictionary<StatType, float> statCollection = new Dictionary<StatType, float>();
        public List<QuadData> tileQuads = new List<QuadData>();

        public Tile()
        {

        }

        public Tile(Info i, Direction dir, bool fl, CollisionLayer cl, Dictionary<StatType, float> sc, List<QuadData> tq)
        {

            TileInfo = i;
            direction = dir;
            flipped = fl;
            collisionLayer = cl;
            statCollection = sc;
            tileQuads.AddRange(tq);

        }


        public void RotateTile(Direction dir)
        {

        }

        public void FlipTile()
        {

        }

    }
}
