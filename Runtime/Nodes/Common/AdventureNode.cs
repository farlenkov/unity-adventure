using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    public abstract class AdventureNode : EntityBehaviour
    {
        [SerializeField]
        [ReadOnly]
        string id;

        public string ID => id;
        bool isAddedToIndex;

        protected virtual void Awake()
        {
            isAddedToIndex = ByID.TryAdd(id, this);
        }

        protected override void OnDestroy()
        {
            if (isAddedToIndex)
                ByID.Remove(id);

            base.OnDestroy();
        }

        // STATIC

        static Dictionary<string, AdventureNode> ByID = new();

#if !UNITY_EDITOR

        public static bool TryGetByID(string id, out SceneObject sceneObject)
        {
            return ByID.TryGetValue(id, out sceneObject);
        }

#else

        public static bool TryGetByID(string id, out AdventureNode adventureNode)
        {
            var nodeList = FindObjectsByType<AdventureNode>(
                FindObjectsInactive.Include,
                FindObjectsSortMode.None);

            for (var i = 0; i < nodeList.Length; i++)
            {
                var obj = nodeList[i];

                if (obj.ID == id)
                {
                    adventureNode = obj;
                    return true;
                }
            }

            adventureNode = null;
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
