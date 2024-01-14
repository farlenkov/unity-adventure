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
            var selectedObject = ObjectField(label.text, prop.ID, position);

            if (EditorGUI.EndChangeCheck())
            {
                if (selectedObject == null)
                {
                    prop.ID = null;
                    prop.SceneName = null;
                }
                else
                {
                    prop.ID = selectedObject.ID;
                    prop.SceneName = selectedObject.gameObject.GetRootName();
                }
                
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

        public static SceneObject ObjectField(
            string label,
            string id,
            Rect position)
        {
            SceneObject.TryGetByID(id, out var selectedObject);

            return (SceneObject)EditorGUI.ObjectField(
                position, 
                label, 
                selectedObject, 
                typeof(SceneObject), 
                true);
        }
    }
}
