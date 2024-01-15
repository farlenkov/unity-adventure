using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;

namespace UnityAdventure
{
    public abstract class FlowNode : AdventureNode
    {
        [SerializeField]
        [ReadOnly]
        //[HideInInspector]
        List<TriggerSource> triggerSources;

        SceneEvent outEvent;

        public IReadOnlyList<TriggerSource> TriggerSources => triggerSources;

        public abstract void Execute();

        protected override void Awake()
        {
            base.Awake();

            outEvent = new()
            {
                EventName = OutEventName,
                ObjectID = ID
            };

            foreach (var triggerSource in triggerSources)
            {
                ByObjectEvent
                    .GetItem(triggerSource.ObjectID)
                    .GetItem(triggerSource.TriggerName)
                    .Add(this);
            }
        }

        protected override void OnDestroy()
        {
            foreach (var triggerSource in triggerSources)
            {
                ByObjectEvent
                    .GetItem(triggerSource.ObjectID)
                    .GetItem(triggerSource.TriggerName)
                    .Remove(this);
            }

            base.OnDestroy();
        }

        protected void TriggerOut()
        {
            // TODO ...
            SceneEventSystem.Handle(outEvent);
        }

        // STATIC

        public const string OutEventName = "Out";

        static Dictionary<string, Dictionary<string, List<FlowNode>>> ByObjectEvent = new();

        public static bool TryGetByObjectEvent(
            string objectId,
            string eventName,
            out IReadOnlyList<FlowNode> result)
        {
            if (!ByObjectEvent.TryGetValue(objectId, out var byEvent))
            {
                result = null; 
                return false;
            }
            
            if (!byEvent.TryGetValue(eventName, out var flowNodes))
            {
                result = null;
                return false;
            }

            result = flowNodes;
            return true;
        }

        // STATIC

        [Serializable]
        public class TriggerSource
        {
            public string TriggerName;
            public string ObjectID;
            public string ObjectName;
            public string SceneName;
        }

#if UNITY_EDITOR

        public bool TryAddTriggerSource(
            string objectID,
            string objectName,
            string triggerName,
            string sceneName)
        {
            foreach (var item in triggerSources)
            {
                if (item.ObjectID == objectID &&
                    item.TriggerName == triggerName)
                    return false;
            }

            triggerSources.Add(new TriggerSource()
            {
                ObjectID = objectID,
                TriggerName = triggerName,
                ObjectName = objectName,
                SceneName = sceneName
            });

            return true;
        }

#endif
    }
}
