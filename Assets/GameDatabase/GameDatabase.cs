using UnityEngine;
using System.Collections.Generic;

namespace ProjectSpacer
{
    [System.Serializable]
    public class GameDatabase 
    {
        Dictionary<string, EffectBlueprint> _effects;
        Dictionary<string, HullBlueprint> _hulls;
        Dictionary<string, ArmorBlueprint> _armors;
        Dictionary<string, ModuleBlueprint> _modules;

        public GameDatabase ()
        {
            _effects = new Dictionary<string, EffectBlueprint>();
            _hulls = new Dictionary<string, HullBlueprint>();
            _armors = new Dictionary<string, ArmorBlueprint>();
            _modules = new Dictionary<string, ModuleBlueprint>();


        }

        void SetStatInfo (string filename)
        {

            

            ThrustStatBlueprint.SetInfo(new InfoBlueprint("Thrust","Provides thrust in a the direction of the engine.", "UI/Graphics/Icons/Stats/thrust.png"));
            MassStatBlueprint.SetInfo(new InfoBlueprint("Mass","Adds to the overall mass which requires more energy to move.", "UI/Graphics/Icons/Stats/mass.png"));
            ConditionStatBlueprint.SetInfo(new InfoBlueprint("Condition", "The amound of damge this can recieve before breaking and becoming destroyed..", "UI/Graphics/Icons/Stats/condition.png"));
        }

        void BuildStatInfoFile (string filename)
        {
            InfoBlueprint[] infoArray = new InfoBlueprint[3];
        }

        void BuildHullTiles()
        {
            Type4Set<CollisionLayer> slopeCols = new Type4Set<CollisionLayer>(CollisionLayer.WALL, CollisionLayer.WALL, CollisionLayer.WALL, CollisionLayer.FLOOR);
            StatBlueprint[] slopeStats = new StatBlueprint[1] { new MassStatBlueprint(100f) };
            QuadBlueprint[] slopeCornerQuad = new QuadBlueprint[2] { new QuadBlueprint(QuadShape.CORNER_DOWN, new UVBlueprint(new Vector2Int(0,15)),MeshLayer.GRID_CEILING), new QuadBlueprint(QuadShape.CORNER_UP, new UVBlueprint(new Vector2Int(0, 15)), MeshLayer.GRID_BASE) };
            QuadBlueprint[] slopeEdgeQuad = new QuadBlueprint[2] { new QuadBlueprint(QuadShape.SLOPE_DOWN, new UVBlueprint(new Vector2Int(2, 15)), MeshLayer.GRID_CEILING), new QuadBlueprint(QuadShape.SLOPE_UP, new UVBlueprint(new Vector2Int(2, 15)), MeshLayer.GRID_BASE) };
            QuadBlueprint[] slopeInverseQuad = new QuadBlueprint[2] { new QuadBlueprint(QuadShape.INVERSE_DOWN, new UVBlueprint(new Vector2Int(1, 15)), MeshLayer.GRID_CEILING), new QuadBlueprint(QuadShape.INVERSE_UP, new UVBlueprint(new Vector2Int(1, 15)), MeshLayer.GRID_BASE) };
            QuadBlueprint[] slopeInteriorQuad = new QuadBlueprint[2] { new QuadBlueprint(QuadShape.FLAT, new UVBlueprint(new Vector2Int(2, 15)), MeshLayer.GRID_CEILING), new QuadBlueprint(QuadShape.FLAT, new UVBlueprint(new Vector2Int(2, 15)), MeshLayer.GRID_BASE) };

            Type4Set<QuadBlueprint[]> slopeQuads = new Type4Set<QuadBlueprint[]>(slopeCornerQuad,slopeEdgeQuad,slopeInverseQuad,slopeInteriorQuad);
            _hulls.Add("Slope Hull", new HullBlueprint(new InfoBlueprint("Slope Hull", "", "UI/Graphics/Icons/Tiles/Slope.png"),slopeCols,slopeStats, slopeQuads ));

        }

        void BuildArmorTiles()
        {

        }

        void BuildModuleTiles()
        {

        }

        void BuildSavedGrids ()
        {

        }

    }
}