using UnityUtility;

namespace UnityAdventure
{
    public class EventManager
    {
        public void Trigger(string objectId, string eventName)
        {
            if (!FlowNode.TryGetByObjectEvent(
                objectId,
                eventName, 
                out var flowNodes))
                return;

            foreach (var flowNode in flowNodes)
            {
                //Log.Info($"[SceneTriggerSystem: Trigger] {eventName} > {flowNode.gameObject.name}");
                flowNode.Execute();
            }
        }
    }
}
