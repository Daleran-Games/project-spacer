using UnityEngine;

namespace ProjectSpacer
{

    [System.Serializable]
    public class InfoBlueprint
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        string _iconPath;
        public string IconPath
        {
            get { return _iconPath; }
            set { _iconPath = value; }
        }

        public InfoBlueprint(string name, string description, string icon)
        {
            Name = name;
            Description = description;
            IconPath = icon;
        }

    }
}
