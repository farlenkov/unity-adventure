namespace UnityAdventure
{
    public class SceneObjectNodeView : AdventureNodeView<SceneObject>
    {
        protected override void OnInit()
        {
            base.OnInit();
            AddToClassList("SceneObjectNodeView");

            var comps = Target.GetComponents<SceneComponent>();

            if (comps.Length == 0)
            {
                AddLabel("[ Empty ]");
                return;
            }

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
            AddOutPort(SceneTrigger.EnterEventName, "Trigger: OnEnter");
            AddOutPort(SceneTrigger.ExitEventName, "Trigger: OnExit");
        }

        void AddComponent(SceneDoor sceneDoor)
        {
            AddOutPort(SceneDoor.OpenEventName, "Door: OnOpen");
            AddOutPort(SceneDoor.CloseEventName, "Door: OnClose");
        }

        void AddComponent(SceneLock sceneLock)
        {
            AddOutPort(SceneLock.OpenEventName, "Lock: OnOpen");
            AddOutPort(SceneLock.CloseEventName, "Lock: OnClose");
        }
    }
}
