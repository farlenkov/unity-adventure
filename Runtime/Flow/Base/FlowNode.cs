using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    public abstract class FlowNode : AdventureNode
    {
        [SerializeField]
        [HideInInspector]
        List<TriggerSource> triggerSources;

        public IReadOnlyList<TriggerSource> TriggerSources => triggerSources;

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
