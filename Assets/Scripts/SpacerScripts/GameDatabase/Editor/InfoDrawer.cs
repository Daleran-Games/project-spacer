using UnityEngine;
using UnityEditor;

namespace ProjectSpacer.Database
{
   [CustomPropertyDrawer(typeof(InfoDatabaseEntry))]
    public class InfoDrawer : PropertyDrawer
    {

        SerializedProperty icon, name, desc;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            //get the X and Y values
            icon = property.FindPropertyRelative("Icon");
            name = property.FindPropertyRelative("Name");
            desc= property.FindPropertyRelative("Description");

            Rect contentPosition = EditorGUI.PrefixLabel(position, new GUIContent("Info"));

            //Check if there is enough space to put the name on the same line (to save space)
            if (position.height > 64f)
            {
                position.height = 64f;
                EditorGUI.indentLevel += 1;
                contentPosition = EditorGUI.IndentedRect(position);
                contentPosition.y += 18f;
            }

            float half = contentPosition.width / 2;
            GUI.skin.label.padding = new RectOffset(3, 3, 6, 6);

            //show the X and Y from the point
            EditorGUIUtility.labelWidth = 60f;
            EditorGUI.indentLevel = 0;
            float iconWidth = 64f;

            Rect newContentPosition = contentPosition;
            newContentPosition.width = iconWidth;

            // Begin/end property & change check make each field
            // behave correctly when multi-object editing.
            EditorGUI.BeginProperty(newContentPosition, label, icon);
            {
                EditorGUI.BeginChangeCheck();
                Object newVal = EditorGUI.ObjectField(newContentPosition,icon.objectReferenceValue,typeof(Sprite),false);
                if (EditorGUI.EndChangeCheck())
                    icon.objectReferenceValue = newVal;
            }
            EditorGUI.EndProperty();

            contentPosition.x += iconWidth;
            contentPosition.width -= iconWidth;
            contentPosition.height *= 0.25f;

            EditorGUI.BeginProperty(newContentPosition, label, name);
            {
                EditorGUI.BeginChangeCheck();
                string newVal = EditorGUI.TextField(contentPosition, GUIContent.none,name.stringValue);
                if (EditorGUI.EndChangeCheck())
                    name.stringValue = newVal;
            }
            EditorGUI.EndProperty();

            contentPosition.y += 16f;
            contentPosition.height *= 3f;

            GUIStyle wrapTextArea = EditorStyles.textArea;
            wrapTextArea.wordWrap = true;

            EditorGUI.BeginProperty(newContentPosition, label, desc);
            {
                EditorGUI.BeginChangeCheck();
                string newVal = EditorGUI.TextArea(contentPosition, desc.stringValue, wrapTextArea);
                if (EditorGUI.EndChangeCheck())
                    desc.stringValue = newVal;
            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return Screen.width < 333 ? (64f + 18f) : 64f;
        }

    }
}