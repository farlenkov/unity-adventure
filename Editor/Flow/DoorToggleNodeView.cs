namespace UnityAdventure
{
    public class DoorToggleNodeView : FlowNodeView<DoorToggleAction>
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
