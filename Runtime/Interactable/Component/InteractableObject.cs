using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerLookTarget))]
    public sealed class InteractableObject : SceneComponent
    {
        public const string InteractEventName = "OnInteract";

        public event Action OnInteract;

        public void Interract()
        {
            TriggerEvent(InteractEventName);
            OnInteract?.Invoke();
        }
    }
}
