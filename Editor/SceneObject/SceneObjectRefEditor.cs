using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityUtility;

namespace UnityAdventure
{
    [CustomPropertyDrawer(typeof(SceneObjectRef), true)]
    public class SceneObjectRefEditor : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 16;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var prop = (SceneObjectRef)property.GetTargetObjectOfProperty();
            
            if (prop == null)
            {
                ObjectField(label.text, null, position);
                return;
            }

            EditorGUI.BeginChangeCheck();
            var newId = ObjectField(label.text, prop.ID, position);

            if (EditorGUI.EndChangeCheck())
            {
                prop.ID = newId;

                var targetObject = property.serializedObject.targetObject;
                EditorUtility.SetDirty(targetObject);
                
                if (targetObject is Component comp)
                {
                    if (comp.gameObject != null &&
                        comp.gameObject.scene != null)
                    {
                        EditorSceneManager.MarkSceneDirty(comp.gameObject.scene);
                    }
                }
            }
        }

        public static string ObjectField(
            string label,
            string id,
            Rect position)
        {
            var objectList = GameObject.FindObjectsByType<SceneObject>(
                FindObjectsInactive.Include, 
                FindObjectsSortMode.None);

            var selectedObject = (SceneObject)null;

            for (var i = 0; i < objectList.Length; i++)
            {
                var obj = objectList[i];

                if (obj.ID == id)
                {
                    selectedObject = obj;
                    break;
                }
            }

            selectedObject = (SceneObject)EditorGUI.ObjectField(position, label, selectedObject, typeof(SceneObject), true);
            return selectedObject?.ID;
        }
    }
}
