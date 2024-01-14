namespace UnityAdventure
{
    public class DoorToggleNodeView : FlowNodeView<DoorToggleAction>
    {
        protected override void OnInit()
        {
            base.OnInit();
            AddOutPort("Out", "Out");
            AddRefList("Open", Target.Open);
            AddRefList("Close", Target.Close);
        }
    }
}
