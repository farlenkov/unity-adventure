using System;
using UnityEngine;

namespace UnityAdventure
{
    public class LightToggleAction : FlowNode
    {
        public AdventureNodeRef[] TurnOn;
        public AdventureNodeRef[] TurnOff;

        public override void Execute()
        {
            Toggle(TurnOn, true);
            Toggle(TurnOff, false);
            TriggerOutEvent();
        }

        void Toggle(AdventureNodeRef[] nodeRefs, bool enabled)
        {
            if (nodeRefs?.Length == 0)
                return;

            for (int i = 0; i < nodeRefs.Length; i++)
            {
                var nodeRef = nodeRefs[i];

                if (!TryGetByID(nodeRef.ID, out var node))
                    continue;

                if (!node.TryGetComponent(out Light light))
                    continue;

                light.enabled = enabled;
            }
        }
    }
}
