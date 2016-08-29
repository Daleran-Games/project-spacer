using UnityEngine;
using System.Collections;

public static class GV {

    //INFO//
    // ID Variables
    public static uint nextID = 0;
    public static Info defaultInfo = new Info();
    public static string defaultName = "NO NAME";
    public static string defaultDesc = "NO DESCRIPTION";
    public static string defaultFlav = "NO FLAVOR TEXT";
    public static Color defaultInfoColor = new Color(0f, 0f, 0f);
    public static Sprite defaultInfoIcon;

    //AUDIO//
    public static float sfxVolume = 1.0f;
    public static float musicVolume = 1.0f;
    
    //GRAPHICS//
    //Tile Atlas Variables
    public static float tileSize = 1.0f;
    public static float halfTileSize = tileSize * 0.5f;
    public static int pixelResolution = 32;
    public static int atlasPixelSize = 512;
    public static Material atlas;
    public static float uvTileSize = ((float)pixelResolution / (float)atlasPixelSize);
    public static float uvError = uvTileSize / (2 * (float)pixelResolution);

    //PHYSICS//
    //Control Variables
    public static float torqueFactor = 3f;
    public static float headingDeadZone = 0.001f;
    public static float PIDTorqueTuner = 45f;
    public static float velocityDeadZone = 0.3f;
    public static float maxVelocityTuner = 3f;
    public static float directionError = 0.1f;
    public static float playerRotateRadian = 0.05f;
    public static float throttleCutOff = 0.05f;

    //Collision Variables
    public static float collisionDamageModifer = 0.01f;
    public static float collisionRate = 1f;

    //UTILITY FUNCTIONS//

    public static bool IsSameSign (float a, float b) {
		if (a * b > 0)
			return true;
		else 
			return false;
	}

	public static void AdvanceID () {
		nextID++;
	}

    public static float GetZFromMeshLayer (MeshLayer ml)
    {
        float z = 0f;
        switch (ml)
        {
            case MeshLayer.WORLD_BASE:
                z = 3.1f;
                break;
            case MeshLayer.WORLD_FLOOR:
                z = 3f;
                break;
            case MeshLayer.HANGER_BASE:
                z = 2.1f;
                break;
            case MeshLayer.HANGER_FLOOR:
                z = 2f;
                break;
            case MeshLayer.GRID_BASE:
                z = 1f;
                break;
            case MeshLayer.GRID_UTIL_DUCT:
                z = 0.4f;
                break;
            case MeshLayer.GRID_UTIL_ELEC:
                z = 0.7f;
                break;
            case MeshLayer.GRID_FLOOR:
                z = 0f;
                break;
            case MeshLayer.ENTITY:
                z = -0.1f;
                break;
            case MeshLayer.GRID_MODULE:
                z = -0.8f;
                break;
            case MeshLayer.GRID_WALL:
                z = -1f;
                break;
            case MeshLayer.GRID_CEILING:
                z = -1f;
                break;
            case MeshLayer.GRID_TOP:
                z = -1.1f;
                break;
            case MeshLayer.HANGER_CEILING:
                z = -2f;
                break;
            case MeshLayer.HANGER_TOP:
                z = -2.1f;
                break;
            case MeshLayer.WORLD_CEILING:
                z = -3f;
                break;
            case MeshLayer.WORLD_TOP:
                z = -3.1f;
                break;
            default:
                Debug.LogError("PS ERROR: " + ml.ToString() + " not a valid MeshLayer. Setting to default value of 0.0f.");
                break;
        }
        return z;
    }

}
