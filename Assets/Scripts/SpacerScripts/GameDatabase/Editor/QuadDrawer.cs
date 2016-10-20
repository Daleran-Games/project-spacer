using UnityEngine;
using UnityEditor;

namespace ProjectSpacer.Database
{
   [CustomPropertyDrawer(typeof(QuadDatabaseEntry))]
    public class QuadDrawer : PropertyDrawer
    {

        SerializedProperty shape, dir, layer, uv;
        string name;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            //get the name before it's gone
            name = property.displayName;

            //get the X and Y values
            shape = property.FindPropertyRelative("Shape");
            dir = property.FindPropertyRelative("QuadDirection");
            layer = property.FindPropertyRelative("QuadMeshLayer");
            uv = property.FindPropertyRelative("QuadUV");


            Rect contentPosition = EditorGUI.PrefixLabel(position, new GUIContent(name));

            //Check if there is enough space to put the name on the same line (to save space)
            if (position.height > 48f)
            {
                position.height = 48f;
                EditorGUI.indentLevel += 1;
                contentPosition = EditorGUI.IndentedRect(position);
                contentPosition.y += 18f;
            }

            float half = contentPosition.width / 2;
            float third = contentPosition.width / 3;
            GUI.skin.label.padding = new RectOffset(3, 3, 6, 6);

            //show the X and Y from the point
            EditorGUIUtility.labelWidth = 40f;
            contentPosition.width *= 0.33f;
            contentPosition.height = 18f;
            EditorGUI.indentLevel = 0;

            // Begin/end property & change check make each field
            // behave correctly when multi-object editing.
            EditorGUI.BeginProperty(contentPosition, label, shape);
            {
                EditorGUI.PropertyField(contentPosition, shape, GUIContent.none);
            }
            EditorGUI.EndProperty();

            contentPosition.x += third;

            EditorGUI.BeginProperty(contentPosition, label, dir);
            {
                EditorGUI.PropertyField(contentPosition, dir, GUIContent.none);
            }
            EditorGUI.EndProperty();

            contentPosition.x += third;

            EditorGUI.BeginProperty(contentPosition, label, layer);
            {
                EditorGUI.PropertyField(contentPosition, layer, GUIContent.none);
            }
            EditorGUI.EndProperty();

            contentPosition.x -= 2f * third;
            contentPosition.y += 18f;
            contentPosition.width *= 3f;
            contentPosition.height = 32f;

            EditorGUI.BeginProperty(contentPosition, label, uv);
            {
                EditorGUI.PropertyField(contentPosition, uv, GUIContent.none);
            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return Screen.width < 333 ? (48f + 18f) : 48f;
        }

    }
}