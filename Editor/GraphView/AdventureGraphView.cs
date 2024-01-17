using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityUtility;

namespace UnityAdventure
{
    public class AdventureGraphView : UnityGraphEditor.GraphView
    {
        Dictionary<Type, Type> ObjectToNodeType = new()
        {
            { typeof(DoorToggleAction), typeof(DoorToggleNodeView) },
            { typeof(LockToggleAction), typeof(LockToggleNodeView) },
            { typeof(ObjectToggleAction), typeof(ObjectToggleNodeView) },
            { typeof(DelayAction), typeof(DelayNodeView) },
            { typeof(StartAction), typeof(StartNodeView) },
            { typeof(RepeatAction), typeof(RepeatNodeView) },
            { typeof(LightToggleAction), typeof(LightToggleNodeView) }
        };

        protected override void OnEdgeCreate(Edge edge)
        {
            var fromNodeView = edge.output.node as AdventureNodeView;
            var toNodeView = edge.input.node as AdventureNodeView;
            var flowNode = toNodeView.GetType().GetField(nameof(FlowNodeView<FlowNode>.Target)).GetValue(toNodeView) as FlowNode;

            flowNode.TryAddTriggerSource(
                fromNodeView.viewDataKey, 
                fromNodeView.Data.gameObject.name,
                edge.output.userData.ToString(),
                fromNodeView.Data.gameObject.GetRootName());

            EditorUtility.SetDirty(flowNode);
        }

        protected override void OnEdgeRemove(Edge edge)
        {
            var fromNodeView = edge.output.node as AdventureNodeView;
            var toNodeView = edge.input.node as AdventureNodeView;
            var flowNode = toNodeView.GetType().GetField(nameof(FlowNodeView<FlowNode>.Target)).GetValue(toNodeView) as FlowNode;

            flowNode.TryRemoveTriggerSource(
                fromNodeView.viewDataKey,
                edge.output.userData.ToString());

            EditorUtility.SetDirty(flowNode);
        }

        protected override void OnGraphDestroy()
        {

        }

        protected override void AddStyle()
        {
            base.AddStyle();

            var style = AssetDatabase.LoadAssetAtPath<StyleSheet>("Packages/com.farlenkov.unity-adventure/Editor/GraphView/GraphStyles.uss");
            styleSheets.Add(style);
        }

        internal void Refresh()
        {
            ClearNodes();
            CreateSceneNodes();
            CreateFlowNodes();
            CreateEdges();
        }

        void CreateSceneNodes()
        {
            var sceneObjects = AdventureNode.FindAllNodes<SceneObject>();

            foreach (var sceneObject in sceneObjects)
            {
                var data = sceneObject.GetComponent<NodeViewData>() ?? sceneObject.gameObject.AddComponent<NodeViewData>();
                var view = new SceneObjectNodeView();

                view.Graph = this;
                view.Data = data;
                view.Target = sceneObject;

                view.Init();
                AddElement(view);
            }
        }

        void CreateFlowNodes()
        {
            var flowObjects = AdventureNode.FindAllNodes<FlowNode>();

            foreach (var flowObject in flowObjects)
            {
                if (!ObjectToNodeType.TryGetValue(flowObject.GetType(), out var nodeType))
                {
                    Log.Error($"NodeView type not defined for {flowObject.GetType()}");
                    continue;
                }

                var data = flowObject.GetComponent<NodeViewData>() ?? flowObject.gameObject.AddComponent<NodeViewData>();
                var view = Activator.CreateInstance(nodeType) as AdventureNodeView;
                view.Graph = this;
                view.Data = data;

                nodeType.GetField(nameof(FlowNodeView<FlowNode>.Target)).SetValue(view, flowObject);
                view.Init();
                AddElement(view);
            }
        }

        void CreateEdges()
        {
            foreach (var node in nodes)
                if (node is AdventureNodeView view)
                    view.CreateEdges();
        }
    }
}