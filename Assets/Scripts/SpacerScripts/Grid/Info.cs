using UnityEngine;

namespace ProjectSpacer
{

    [System.Serializable]
    public class Info
    {

        public string name = GV.defaultName;
        public string description = GV.defaultDesc;
        public Sprite icon = GV.defaultInfoIcon;

        public Info(string n, string d, Sprite i)
        {

            name = n;
            description = d;
            icon = i;
        }

        public Info(string n, string d)
        {

            name = n;
            description = d;

        }

        public Info(string n)
        {

            name = n;

        }

        public Info()
        {

        }


    }
}