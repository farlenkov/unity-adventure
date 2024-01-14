namespace UnityAdventure
{
    public class ObjectToggleNodeView : FlowNodeView<ObjectToggleAction>
    {
        protected override void OnInit()
        {
            base.OnInit();
            AddOutPort("Out", "Out");
            AddRefList("Activate", Target.Activate);
            AddRefList("Deactivate", Target.Deactivate);
        }
    }
}
