using UnityEngine;
using System.Collections.Generic;

namespace ProjectSpacer
{
    public class GameDatabase : MonoBehaviour
    {
        public Dictionary<string, GridEffect> Effects = new Dictionary<string, GridEffect>();
        

        void SetStatInfo ()
        {
            ThrustStatBlueprint.SetInfo("Thrust","Provides thrust in a the direction of the engine.", "UI/Graphics/Icons/Stats/thrust.png");
            MassStatBlueprint.SetInfo("Mass","Adds to the overall mass which requires more energy to move.", "UI/Graphics/Icons/Stats/mass.png");
            ConditionStatBlueprint.SetInfo("Condition", "The amound of damge this can recieve before breaking and becoming destroyed..", "UI/Graphics/Icons/Stats/condition.png");
        }

        void BuildHullTiles()
        {

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