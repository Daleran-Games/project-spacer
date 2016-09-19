using UnityEngine;

namespace ProjectSpacer
{

    public static class GV
    {

        //INFO//
        // ID Variables
        public static Info defaultInfo = new Info();
        public static string defaultName = "NO NAME";
        public static string defaultDesc = "NO DESCRIPTION";
        public static string defaultFlav = "NO FLAVOR TEXT";
        public static Color defaultInfoColor = new Color(0f, 0f, 0f);
        public static Sprite defaultInfoIcon;

        //GRAPHICS//
        //Tile Atlas Variables
        public static float tileSize = 1.0f;
        public static float halfTileSize = tileSize * 0.5f;
        public static int pixelResolution = 32;
        public static int atlasPixelSize = 512;
        public static Material atlas;
        public static float uvTileSize = ((float)pixelResolution / (float)atlasPixelSize);
        public static float uvError = uvTileSize / (2 * (float)pixelResolution);
        public static Color32 defaultTileColor = new Color32(255,255,255,255);
        public static byte defaultTileAlpha = 255;

        //PHYSICS//
        //Control Variables
        public static float torqueFactor = 3f;
        public static float headingDeadZone = 0.001f;
        public static float velocityDeadZone = 0.01f;
        public static float directionError = 0.001f;
        public static float playerRotateRadian = 0.05f;

        //Collision Variables
        public static float collisionDamageModifer = 0.01f;
        public static float collisionRate = 1f;

        //UTILITY FUNCTIONS//

        public static bool IsSameSign(float a, float b)
        {
            if (a * b > 0)
                return true;
            else
                return false;
        }

        public static float GetZFromMeshLayer(MeshLayer ml)
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
                    z = -0.5f;
                    break;
                case MeshLayer.GRID_MODULE_LOW:
                    z = -0.2f;
                    break;
                case MeshLayer.GRID_MODULE_Half:
                    z = -0.5f;
                    break;
                case MeshLayer.GRID_CEILING:
                    z = -1f;
                    break;
                case MeshLayer.GRID_TOP:
                    z = -1.01f;
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

        public static Vector3 GetRotationFromDirection (Direction dir)
        {
            switch(dir)
            {
                case Direction.UP:
                    return new Vector3(0f,0f,0f);
                case Direction.RIGHT:
                    return new Vector3(0f,0f,270f);
                case Direction.LEFT:
                    return new Vector3(0f, 0f, 90f);
                case Direction.DOWN:
                    return new Vector3(0f,0f,180f);
                default:
                    Debug.LogError("PS ERROR: " + dir + " not a valid direction.");
                    return new Vector3(0f, 0f, 0f);
            }
        }

    }
}
