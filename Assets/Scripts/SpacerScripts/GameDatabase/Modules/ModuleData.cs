using UnityEngine;
using System.Collections;


namespace ProjectSpacer.Database
{
    [CreateAssetMenu(fileName = "NewModuleData", menuName = "Database/Modules/ModuleData", order = 0)]
    public class ModuleData : ScriptableObject
    {

        public string ModuleName = "NewModule";
        public Sprite ModuleSprite;

        public bool HasPhysics = false;
        public float ModuleMass = 0f;
        public bool Collidable = false;
        public Collider2D ModuleCollider;

        public bool HasCondition = false;
        public float MaxCondition = 0f;
        public float MaxArmor = 0f;

        public bool GeneratesThrust = false;
        

    }
}


