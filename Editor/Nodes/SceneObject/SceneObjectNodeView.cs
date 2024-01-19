using System;

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
                    case TriggerObject triggerObject:
                        AddComponent(triggerObject);
                        break;

                    case DoorObject doorObject:
                        AddComponent(doorObject);
                        break;

                    case LockObject lockObject:
                        AddComponent(lockObject);
                        break;

                    case InteractableObject interactableObject:
                        AddComponent(interactableObject);
                        break;

                    case InteractableSwitchObject switchObject:
                        AddComponent(switchObject);
                        break;

                    default:
                        AddLabel(comp.GetType().Name);
                        break;
                }
            }
        }

        void AddComponent(InteractableSwitchObject switchObject)
        {
            AddOutPort(InteractableSwitchObject.ActivateEventName, "Switch: OnActivate");
            AddOutPort(InteractableSwitchObject.DeactivateEventName, "Switch: OnDeactivate");
        }

        void AddComponent(InteractableObject interactableObject)
        {
            AddOutPort(InteractableObject.InteractEventName, InteractableObject.InteractEventName);
        }

        void AddComponent(TriggerObject triggerObject)
        {
            AddOutPort(TriggerObject.EnterEventName, "Trigger: OnEnter");
            AddOutPort(TriggerObject.ExitEventName, "Trigger: OnExit");
        }

        void AddComponent(DoorObject doorObject)
        {
            AddOutPort(DoorObject.OpenEventName, "Door: OnOpen");
            AddOutPort(DoorObject.CloseEventName, "Door: OnClose");
        }

        void AddComponent(LockObject lockObject)
        {
            AddOutPort(LockObject.OpenEventName, "Lock: OnOpen");
            AddOutPort(LockObject.CloseEventName, "Lock: OnClose");
        }
    }
}
