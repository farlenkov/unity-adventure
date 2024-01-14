namespace UnityAdventure
{
    public class SceneObjectNodeView : AdventureNodeView<SceneObject>
    {
        protected override void OnInit()
        {
            base.OnInit();
            AddToClassList("SceneObjectNodeView");

            var comps = Target.GetComponents<SceneComponent>();

            foreach (var comp in comps)
            {
                switch (comp)
                {
                    case SceneTrigger sceneTrigger:
                        AddComponent(sceneTrigger);
                        break;

                    case SceneDoor sceneDoor:
                        AddComponent(sceneDoor);
                        break;

                    case SceneLock sceneLock:
                        AddComponent(sceneLock);
                        break;

                    default:
                        AddLabel(comp.GetType().Name);
                        break;
                }
            }
        }

        void AddComponent(SceneTrigger sceneTrigger)
        {
            AddOutPort("OnEnterTrigger", "Trigger: OnEnter");
            AddOutPort("OnExitTrigger", "Trigger: OnExit");
        }

        void AddComponent(SceneDoor sceneDoor)
        {
            AddOutPort("OnDoorOpen", "Door: OnOpen");
            AddOutPort("OnDoorClose", "Door: OnClose");
        }

        void AddComponent(SceneLock sceneLock)
        {
            AddOutPort("OnLockOpen", "Lock: OnOpen");
            AddOutPort("OnLockClose", "Lock: OnClose");
        }
    }
}
