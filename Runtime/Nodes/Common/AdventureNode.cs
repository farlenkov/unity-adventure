using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGameLoop;
using UnityServiceRegistry;
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

        public EventManager EventManager { get; private set; }

        protected virtual void Awake()
        {
            isAddedToIndex = ByID.TryAdd(id, this);
        }

        protected override void Start()
        {
            base.Start();

            ServiceRegistry.GetService(out EventManager eventManager);
            EventManager = eventManager;
        }

        protected override void OnDestroy()
        {
            if (isAddedToIndex)
                ByID.Remove(id);

            base.OnDestroy();
        }

        // STATIC

        static Dictionary<string, AdventureNode> ByID = new();

        public static T[] FindAllNodes<T>() where T : AdventureNode
        {
            return FindObjectsByType<T>(
                FindObjectsInactive.Include,
                FindObjectsSortMode.None);
        }

#if !UNITY_EDITOR

        public static bool TryGetByID(string id, out SceneObject sceneObject)
        {
            return ByID.TryGetValue(id, out sceneObject);
        }

#else

        public static bool TryGetByID(string id, out AdventureNode adventureNode)
        {
            var nodeList = FindAllNodes<AdventureNode>();

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
            // NEW ID FOR NEW OBJECT

            if (string.IsNullOrEmpty(id))
            {
                CreateNewID();
                return;
            }

            // NEW ID FOR DUPLICATE

            var nodeList = FindAllNodes<AdventureNode>();

            for (var i = 0; i < nodeList.Length; i++)
            {
                var obj = nodeList[i];

                if (obj.ID == id &&
                    obj != this)
                {
                    CreateNewID();
                    return;
                }
            }
        }

        [ContextMenu("Refresh ID")]
        void RefreshID()
        {
            CreateNewID();
            UnityEditor.EditorUtility.SetDirty(this);
        }

        void CreateNewID()
        {
            id = Guid.NewGuid().ToString();
            Log.Info($"[AdventureNode: CreateNewID] '{gameObject.name}' = {id}");
        }

#endif
    }
}
