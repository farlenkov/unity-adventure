namespace UnityAdventure
{
    public class LockToggleNodeView : FlowNodeView<LockToggleAction>
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
