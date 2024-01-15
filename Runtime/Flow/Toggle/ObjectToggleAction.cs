using System;
using UnityUtility;

namespace UnityAdventure
{
    public class ObjectToggleAction : FlowNode
    {
        public AdventureNodeRef[] Activate;
        public AdventureNodeRef[] Deactivate;

        public override void Execute()
        {
            Toggle(Activate, true);
            Toggle(Deactivate, false);
            TriggerOut();
        }

        void Toggle(AdventureNodeRef[] nodeRefs, bool activate)
        {
            if (nodeRefs?.Length == 0)
                return;

            for (int i = 0; i < nodeRefs.Length; i++)
            {
                var nodeRef = nodeRefs[i];

                if (!TryGetByID(nodeRef.ID, out var node))
                    continue;

                node.gameObject.SetActive(activate);
                Log.Info($"[ObjectToggleAction] {node.gameObject.name} > {activate}");
            }
        }
    }
}
