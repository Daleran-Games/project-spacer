using UnityEngine;
using System.Collections;

public static class GlobalVariables {

	public static float collisionDamageModifer = 0.01f;
	public static float collisionRate = 1f;
	public static float torqueFactor = 1f;
	public static float headingDeadZone = 0.01f;
	public static float PIDTorqueTuner = 45f;
	public static float velocityDeadZone = 0.3f;
	public static float maxVelocityTuner = 3f;
	public static float directionError = 0.1f;
	public static float playerRotateRadian = 0.05f;
	public static float throttleCutOff = 0.05f;


	public static float SFXVolume = 1.0f;
	public static float MusicVolume = 1.0f;
	public static int nextID = 0;

	public static Color defaultInfoColor;
	public static Sprite defaultInfoIcon;

    public static float tileSize = 1.0f;
    public static float halfTileSize = tileSize * 0.5f;
    public static int pixelResolution = 32;

	public static bool SameSign (float a, float b) {

		if (a * b > 0)
			return true;
		else 
			return false;

	}

	public static void AdvanceID () {
		nextID++;
	}

}
