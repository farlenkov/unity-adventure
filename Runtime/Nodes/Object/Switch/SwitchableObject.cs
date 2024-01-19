using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    public abstract class SwitchableObject : SceneComponent
    {
        [field: SerializeField]
        public SwitchObject Switch { get; private set; }

        protected abstract void OnSwitch(SwitchObject sceneSwitch, bool isActive);

        protected override void Start()
        {
            base.Start();
            
            if (Switch != null)
                Switch.OnSwitch += OnSwitch;
        }

        protected virtual void OnDestroy()
        {
            if (Switch != null)
                Switch.OnSwitch -= OnSwitch;
        }
    }
}
