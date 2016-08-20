using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stat  {

	/// <summary>
	/// The stat type. The type includes infomration about the stat and the absolute minimum and maximums.
	/// </summary>
	public StatTemplate Template;

	/// <summary>
	/// The minimum value the Stat can have during gameplay. Modifers can change this.
	/// </summary>
	public float MinValue {get; private set;}

	/// <summary>
	/// The maximum value the Stat can have during gameplay. Modifers can change this.
	/// </summary>
	public float MaxValue {get; private set;}

	/// <summary>
	/// The original unmodified stat. Also doubles as the original maximum value before modifers have been applied. Cannot be changed after creation.
	/// </summary>
	public float BaseValue {get; private set;}


	private float currentValue;

	/// <summary>
	/// The current value of the stat which will effect gameplay. Can be changed by both modifiers and sytems for gameplay purposes.
	/// </summary>
	public float CurrentValue {
		get { return currentValue; }
		set { 
			currentValue = Mathf.Clamp (Mathf.Clamp(value, MinValue, MaxValue),Template.AbsMin,Template.AbsMax);
		}
	}

	/// A list of modifer references currently affecting this stat.
	List<Modifier> Modifiers;


	public Stat (float min, float max, float b, StatTemplate t) {

		if (b < min)
			MinValue = b;
		else
			MinValue = min;

		if (b > max)
			MaxValue = b;
		else
			MaxValue = max;

		BaseValue = b;
		CurrentValue = b;
		Template = t;
		Modifiers = new List<Modifier> ();
	}

	public void AddModifier (Modifier mod) {
		Modifiers.Add (mod);
	}

	public void RemoveModifier (Modifier mod) {
		Modifiers.Remove (mod);
	}

	public List<Modifier> GetModifiers () {
		return Modifiers;
	}

	void ApplyModifier (Modifier m) {
		switch (m.modBy) {
		case ModifyType.ADD_BOTH:
			CurrentValue += m.amount;
			MaxValue += m.amount;
			break;
		case ModifyType.ADD_CURRENT:
			CurrentValue += m.amount;
			break;
		case ModifyType.ADD_MAX:
			MaxValue += m.amount;
			break;
		case ModifyType.MULTIPLY_BOTH:
			CurrentValue = CurrentValue * m.amount;
			MaxValue = MaxValue *  m.amount;
			break;
		case ModifyType.MULTIPLY_CURRENT:
			CurrentValue = CurrentValue * m.amount;
			break;
		case ModifyType.MULTIPLY_MAX:
			MaxValue = MaxValue *  m.amount;
			break;
		default:
			Debug.LogError ("Apply MOdifier Unkown Type");
			break;
		}
	}

	void CeaseModifier (Modifier m) {
		switch (m.modBy) {
		case ModifyType.ADD_BOTH:
			CurrentValue -= m.amount;
			MaxValue -= m.amount;
			break;
		case ModifyType.ADD_CURRENT:
			CurrentValue -= m.amount;
			break;
		case ModifyType.ADD_MAX:
			MaxValue -= m.amount;
			break;
		case ModifyType.MULTIPLY_BOTH:
			CurrentValue = CurrentValue * m.amount;
			MaxValue = MaxValue *  m.amount;
			break;
		case ModifyType.MULTIPLY_CURRENT:
			CurrentValue = CurrentValue * m.amount;
			break;
		case ModifyType.MULTIPLY_MAX:
			MaxValue = MaxValue *  m.amount;
			break;
		default:
			Debug.LogError ("Apply Modifier Unkown Type");
			break;
		}
	}

	void ApplyAllCurrentModifiers () {
		foreach (Modifier m in Modifiers) {
			ApplyModifier (m);
		}
	}

}
