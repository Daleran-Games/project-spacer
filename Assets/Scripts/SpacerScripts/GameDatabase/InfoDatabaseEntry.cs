using UnityEngine;

namespace ProjectSpacer.Database
{

    [System.Serializable]
    public class InfoDatabaseEntry
    {
        public Sprite Icon;
        public string Name;
        public string Description;
        

        public InfoDatabaseEntry(string name, string description, Sprite icon)
        {
            Name = name;
            Description = description;
            Icon = icon;
        }

    }
}
