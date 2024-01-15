namespace UnityAdventure
{
    public class RepeatNodeView : FlowNodeView<RepeatAction>
    {
        protected override void OnInit()
        {
            base.OnInit();
            AddOutPort(FlowNode.OutEventName, "Out");

            if (Target.CiclesMin == Target.CiclesMax)
                AddLabel($"Cicles: {Target.CiclesMin}");
            else
                AddLabel($"Cicles: {Target.CiclesMin} - {Target.CiclesMax}");

            if (Target.IntervalMin == Target.IntervalMax)
                AddLabel($"Interval: {Target.IntervalMin}");
            else
                AddLabel($"Interval: {Target.IntervalMin} - {Target.IntervalMax}");
        }
    }
}
