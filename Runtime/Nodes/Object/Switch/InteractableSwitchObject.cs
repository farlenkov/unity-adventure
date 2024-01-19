using UnityEngine;
using UnityUtility;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(InteractableObject))]
    public class InteractableSwitchObject : SwitchObject
    {
        public const string ActivateEventName = "OnSwitchActivate";
        public const string DeactivateEventName = "OnSwitchDeactivate";

        protected override void Start()
        {
            base.Start();
            GetComponent<InteractableObject>().OnInteract += OnInteract;
        }

        void OnInteract()
        {
            SetIsActive(!IsActive);

            var eventName = IsActive ? ActivateEventName : DeactivateEventName;

            Log.Info($"[SceneSwitch: OnInteract] '{gameObject.name}' > {eventName}");
            TriggerEvent(eventName);
        }
    }
}
