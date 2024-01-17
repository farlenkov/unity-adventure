using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;

namespace UnityAdventure
{
    [RequireComponent(typeof(InteractableObject))]
    public class SceneSwitch : SceneComponent
    {
        [field: SerializeField]
        public bool IsActive { get; private set; }

        public const string ActivateEventName = "OnSwitchActivate";
        public const string DeactivateEventName = "OnSwitchDeactivate";

        protected override void Start()
        {
            base.Start();
            GetComponent<InteractableObject>().OnInteract += OnInteract; ;
        }

        void OnInteract()
        {
            IsActive = !IsActive;
            var eventName = IsActive ? ActivateEventName : DeactivateEventName;

            Log.Info($"[SceneSwitch: OnInteract] '{gameObject.name}' > {eventName}");
            TriggerEvent(eventName);
        }
    }
}
