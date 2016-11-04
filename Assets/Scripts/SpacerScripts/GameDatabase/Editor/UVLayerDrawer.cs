using UnityEngine;
using UnityEditor;

namespace ProjectSpacer.Database
{
   [CustomPropertyDrawer(typeof(UVLayerDatabaseEntry))]
    public class UVLayerDrawer : PropertyDrawer
    {

        SerializedProperty uv, color, flip, layer;
        string name;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            //get the name before it's gone
            name = property.displayName;

            //get the X and Y values
            uv = property.FindPropertyRelative("UV");
            color = property.FindPropertyRelative("Colorable");
            flip = property.FindPropertyRelative("FlipAcrossX");
            layer = property.FindPropertyRelative("UVLayer");


            Rect contentPosition = EditorGUI.PrefixLabel(position, new GUIContent(name));

            //Check if there is enough space to put the name on the same line (to save space)
            if (position.height > 32f)
            {
                position.height = 32f;
                EditorGUI.indentLevel += 1;
                contentPosition = EditorGUI.IndentedRect(position);
                contentPosition.y += 18f;
            }

            float half = contentPosition.width / 2;
            float third = contentPosition.width / 3;
            GUI.skin.label.padding = new RectOffset(3, 3, 6, 6);

            //show the X and Y from the point
            EditorGUIUtility.labelWidth = 40f;
            contentPosition.height *= 0.5f;
            EditorGUI.indentLevel = 0;

            // Begin/end property & change check make each field
            // behave correctly when multi-object editing.
            EditorGUI.BeginProperty(contentPosition, label, uv);
            {
                EditorGUI.PropertyField(contentPosition, uv, GUIContent.none);
            }
            EditorGUI.EndProperty();

            contentPosition.y += 18f;
            contentPosition.width *= (1f / 3f);

            EditorGUI.BeginProperty(contentPosition, label, color);
            {
                EditorGUI.BeginChangeCheck();
                bool newVal = EditorGUI.Toggle(contentPosition, new GUIContent("Color"), color.boolValue);
                if (EditorGUI.EndChangeCheck())
                    color.boolValue = newVal;
            }
            EditorGUI.EndProperty();

            contentPosition.x += third;

            EditorGUI.BeginProperty(contentPosition, label, flip);
            {
                EditorGUI.BeginChangeCheck();
                bool newVal = EditorGUI.Toggle(contentPosition, new GUIContent("Flip X"), flip.boolValue);
                if (EditorGUI.EndChangeCheck())
                    flip.boolValue = newVal;
            }
            EditorGUI.EndProperty();

            contentPosition.x += third;

            EditorGUI.BeginProperty(contentPosition, label, layer);
            {
                EditorGUI.PropertyField(contentPosition, layer, GUIContent.none);
            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return Screen.width < 333 ? (32f + 18f) : 32f;
        }

    }
}