using UnityEngine;
using UnityEditor.Experimental.GraphView;

namespace UnityAdventure
{
    public class AdventureGraphView : UnityGraphEditor.GraphView
    {
        protected override void OnEdgeCreate(Edge edge)
        {

        }

        protected override void OnEdgeRemove(Edge edge)
        {

        }

        protected override void OnGraphDestroy()
        {

        }

        internal void Refresh()
        {
            ClearNodes();
            CreateNodes();
        }

        void CreateNodes()
        {
            var sceneObjects = GameObject.FindObjectsOfType<SceneObject>();

            foreach (var sceneObject in sceneObjects)
                CreateView(sceneObject);
        }

        void CreateView(SceneObject sceneObject)
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
}
