using UnityEngine;
using System.Collections;

[System.Serializable]
public class Info {

	public string name;
	public string description;
	public string flavorText;
	public Color textColor  = GlobalVariables.defaultInfoColor;
	public Sprite icon = GlobalVariables.defaultInfoIcon;

	public Info (string n, string d, string f, Color c, Sprite i) {

		name = n;
		description = d;
		flavorText = f;
		textColor = c;
		icon = i;
	}

	public Info (string n, string d, string f) {

		name = n;
		description = d;
		flavorText = f;

	}

	public Info (string n) {

		name = n;

	}

}
