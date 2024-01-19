using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(InteractableObject))]
    public class SwitchObject : SceneComponent
    {
        [field: SerializeField]
        public bool IsActive { get; private set; }

        public event Action<SwitchObject, bool> OnSwitch;

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
            OnSwitch?.Invoke(this, IsActive);

            var eventName = IsActive ? ActivateEventName : DeactivateEventName;

            Log.Info($"[SceneSwitch: OnInteract] '{gameObject.name}' > {eventName}");
            TriggerEvent(eventName);
        }
    }
}