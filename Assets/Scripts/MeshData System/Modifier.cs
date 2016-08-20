using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NewModifier", menuName = "Data/Templates/Modifier", order = 3)]
public class Modifier : ScriptableObject {

	public Info StatModInfo;
	public StatTemplate moddedStat;
	public ModifyType modBy;
	public float amount;
}
