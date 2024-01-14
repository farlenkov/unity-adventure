using UnityEditor;
using UnityEngine;

namespace UnityAdventure
{
    [CustomEditor(typeof(FlowNode), true)]
    public class FlowNodeEditor : Editor
    {
        protected FlowNode Target => target as FlowNode;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            DrawTriggerSources();
        }

        void DrawTriggerSources()
        {
            GUILayout.Label($"Trigger Sources ({Target.TriggerSources.Count})");

            foreach (var triggerSource in Target.TriggerSources)
                GUILayout.Label($"{triggerSource.TriggerName}  >  {triggerSource.ObjectName} ({triggerSource.SceneName})");
        }
    }
}
