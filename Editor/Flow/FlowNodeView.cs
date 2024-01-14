namespace UnityAdventure
{
    public abstract class FlowNodeView<T> : AdventureNodeView<T> where T : FlowNode
    {
        protected override void OnInit()
        {
            base.OnInit();
            AddToClassList("FlowNodeView");
            AddInPort("In", "In");
        }

        protected void AddRefList(string title, SceneObjectRef[] refList)
        {
            if (refList.Length == 0)
                return;

            AddLabel(title);

            foreach(var refItem in refList)
            {
                if (!SceneObject.TryGetByID(refItem.ID, out var sceneObject))
                    continue;

                AddLabel($"-  {sceneObject.gameObject.name}");
            }
        }
    }
}
