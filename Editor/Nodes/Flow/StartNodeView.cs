namespace UnityAdventure
{
    public class StartNodeView : FlowNodeView<StartAction>
    {
        protected override void OnInit()
        {
            base.OnInit();
            AddOutPort(FlowNode.OutEventName, "Out");
        }
    }
}
