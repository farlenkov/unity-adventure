namespace UnityAdventure
{
    public class LockToggleNodeView : FlowNodeView<LockToggleAction>
    {
        protected override void OnInit()
        {
            base.OnInit();
            AddOutPort(FlowNode.OutEventName, "Out");
            AddRefList("Open", Target.Open);
            AddRefList("Close", Target.Close);
        }
    }
}
