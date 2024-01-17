namespace UnityAdventure
{
    public class LightToggleNodeView : FlowNodeView<LightToggleAction>
    {
        protected override void OnInit()
        {
            base.OnInit();

            AddOutPort(FlowNode.OutEventName, "Out");
            AddRefList("Turn On", Target.TurnOn);
            AddRefList("Turn Off", Target.TurnOff);
        }
    }
}
