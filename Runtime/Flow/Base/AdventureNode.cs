using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    public abstract class AdventureNode : MonoBehaviour
    {
        [SerializeField]
        [ReadOnly]
        string id;

        public string ID => id;
        bool isAddedToIndex;

        void Awake()
        {
            isAddedToIndex = ByID.TryAdd(id, this);
        }

        void OnDestroy()
        {
            if (isAddedToIndex)
                ByID.Remove(id);
        }

        // STATIC

        static Dictionary<string, AdventureNode> ByID = new();

#if !UNITY_EDITOR

        public static bool TryGetByID(string id, out SceneObject sceneObject)
        {
            return ByID.TryGetValue(id, out sceneObject);
        }

#else

        public static bool TryGetByID(string id, out SceneObject sceneObject)
        {
            var objectList = FindObjectsByType<SceneObject>(
                FindObjectsInactive.Include,
                FindObjectsSortMode.None);

            for (var i = 0; i < objectList.Length; i++)
            {
                var obj = objectList[i];

                if (obj.ID == id)
                {
                    sceneObject = obj;
                    return true;
                }
            }

            sceneObject = null;
            return false;
        }

        void OnValidate()
        {
            if (string.IsNullOrEmpty(id))
                id = Guid.NewGuid().ToString();
        }

        [ContextMenu("Refresh ID")]
        void RefreshID()
        {
            id = Guid.NewGuid().ToString();
            UnityEditor.EditorUtility.SetDirty(this);
        }

#endif
    }
}
