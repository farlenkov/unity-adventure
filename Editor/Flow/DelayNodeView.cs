namespace UnityAdventure
{
    public class DelayNodeView : FlowNodeView<DelayAction>
    {
        protected override void OnInit()
        {
            base.OnInit();
            AddOutPort(FlowNode.OutEventName, "Out");
            AddLabel($"Min: {Target.Min}");
            AddLabel($"Max: {Target.Max}");
        }
    }
}
