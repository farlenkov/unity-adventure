using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    public sealed class SceneObject : MonoBehaviour
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

        static Dictionary<string, SceneObject> ByID = new ();

        public static bool TryGetByID(string id, out SceneObject sceneObject)
        {
            return ByID.TryGetValue(id, out sceneObject);
        }

#if UNITY_EDITOR

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