using System;
using UnityEngine;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    public abstract class SwitchObject : SceneComponent
    {
        [field: SerializeField]
        public bool IsActive { get; private set; }

        public event Action<SwitchObject, bool> OnSwitch;

        protected void SetIsActive(bool isActive)
        {
            if (IsActive != isActive)
            {
                IsActive = isActive;
                OnSwitch?.Invoke(this, IsActive);
            }
        }
    }
}
