using UnityEngine;
using System.Collections;

namespace ProjectSpacer
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Spacer/Items/Item", order = 0)]
    public class Item : ScriptableObject
    {
        public Sprite ItemIcon;
        public string Name = "DefaultName";
        [TextArea]
        public string Description = "DefaultDescription";
        public float MassPerUnit = 0f;

    }
}
