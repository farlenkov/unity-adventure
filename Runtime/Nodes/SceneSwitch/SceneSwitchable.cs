using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    public abstract class SceneSwitchable : SceneComponent
    {
        [field: SerializeField]
        public SceneSwitch Switch { get; private set; }

        protected abstract void OnSwitch(SceneSwitch sceneSwitch, bool isActive);

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
