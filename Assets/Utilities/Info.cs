using UnityEngine;

namespace ProjectSpacer
{

    [System.Serializable]
    public class Info
    {

        public string name = GV.defaultName;
        public string description = GV.defaultDesc;
        public string flavorText = GV.defaultFlav;
        public Color textColor = GV.defaultInfoColor;
        public Sprite icon = GV.defaultInfoIcon;

        public Info(string n, string d, string f, Color c, Sprite i)
        {

            name = n;
            description = d;
            flavorText = f;
            textColor = c;
            icon = i;
        }

        public Info(string n, string d, string f)
        {

            name = n;
            description = d;
            flavorText = f;

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