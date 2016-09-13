using UnityEngine;
using System.Collections;

namespace ProjectSpacer
{
    public class ModuleBlueprint 
    {
        string _name;
        string _description;
        string _iconPath;

        bool _overrideHullShape = false;

        public ModuleBlueprint(string name, string desc, string icon, bool overrideShape)
        {
            _name = name;
            _description = desc;
            _iconPath = icon;
            _overrideHullShape = overrideShape;
        }
    }

}
