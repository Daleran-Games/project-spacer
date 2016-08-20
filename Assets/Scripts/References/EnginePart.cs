using UnityEngine;
using System.Collections;

public class EnginePart :Part {

	public ParticleSystem engineExhaust;
	public GameObject spriteStandard;
	ThrustModule thruster;
	AudioSource thrusterSound;
	float startingEmission;

	void Start() {
		thruster = GetComponent<ThrustModule> ();
		engineExhaust = GetComponentInChildren<ParticleSystem> ();
		thrusterSound = GetComponentInChildren<AudioSource> ();
		startingEmission = engineExhaust.GetEmissionRate ();
		engineExhaust.SetEmissionRate (0f);
		thrusterSound.volume = 0.5f;
	}

	void Update () {
		if (thruster.getThrottle () > GlobalVariables.throttleCutOff) {
			engineExhaust.SetEmissionRate (thruster.getThrottle () * startingEmission*0.25f);
			thrusterSound.volume = Mathf.Clamp01(thruster.getThrottle ());
			if (thrusterSound.isPlaying == false)
				thrusterSound.Play ();
		} else {
			engineExhaust.SetEmissionRate (0f);
			thrusterSound.volume = 0f;
		}
	}



}
