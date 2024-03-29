using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using UnityUtility;

namespace UnityAdventure
{
    public abstract class SceneNodeView : UnityGraphEditor.NodeView
    {
        public NodeViewData Data;
        public AdventureGraphView Graph;
        internal abstract void CreateEdges();

        protected override void OnInit()
        {
            style.position = Position.Absolute;
            style.left = Data.Position.x;
            style.top = Data.Position.y;
        }

        public override void SavePosition()
        {
            var pos = GetPosition();
            Data.Position = new Vector2(pos.xMin, pos.yMin);
            EditorUtility.SetDirty(Data);
        }

        protected Port AddInPort(string userData, string name)
        {
            return AddInPort<SceneNodeView>(userData, name);
        }

        protected Port AddOutPort(string userData, string name)
        {
            return AddOutPort<SceneNodeView>(userData, name);
        }
    }

    public abstract class SceneNodeView<T> : SceneNodeView
        where T : AdventureNode
    {
        public T Target;

        protected override void OnInit()
        {
            base.OnInit();
            viewDataKey = Target.ID;
            title = Target.gameObject.name;
        }

        public override void OnSelected()
        {
            base.OnSelected();
            Selection.activeObject = Target.gameObject;
        }

        internal override void CreateEdges()
        {
            if (Target == null)
                return;

            if (Target is not FlowNode flowNode)
                return;

            if (flowNode.TriggerSources == null)
                return;

            var inPort = Ports["In"];

            foreach (var triggerSource in flowNode.TriggerSources)
            {
                if (!Graph.TryGetNode(triggerSource.ObjectID, out var node))
                {
                    Log.Error($"[AdventureNodeView: CreateEdges] Node not found: {triggerSource.SceneName} > {triggerSource.ObjectName} ID: {triggerSource.ObjectID} (for '{flowNode.gameObject.name}' in '{flowNode.gameObject.GetRootName()}')");
                    continue;
                }

                if (!node.Ports.TryGetValue(triggerSource.TriggerName, out var outPort))
                {
                    Log.Error($"[AdventureNodeView: CreateEdges] Out port not found: {triggerSource.SceneName} > {triggerSource.ObjectName} Port: {triggerSource.TriggerName}");
                    continue;
                }

                var edge = new Edge();
                edge.output = outPort;
                edge.input = inPort;

                Graph.AddElement(edge);
            }
        }
    }
}