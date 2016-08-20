using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewStat", menuName = "Data/Templates/Stat Template", order = 1)]
public class StatTemplate : ScriptableObject {

	public Info StatInfo;
	public float AbsMin;
	public float AbsMax;


}
