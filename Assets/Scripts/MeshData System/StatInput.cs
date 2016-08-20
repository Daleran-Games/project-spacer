using UnityEngine;
using System.Collections;

[System.Serializable]
public class StatInput {

	public StatTemplate Template;
	public float MinValue;
	public float MaxValue;
	public float BaseValue;

	public Stat BuildStat() {
		return new Stat (MinValue, MaxValue, BaseValue, Template);
	}

}
