using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    public class LightObject : SwitchableObject
    {
        [field: SerializeField]
        public Light Light { get; private set; }

        protected override void OnSwitch(SwitchObject sceneSwitch, bool isActive)
        {
            if (Light != null)
                Light.enabled = isActive;
        }

#if UNITY_EDITOR

        void OnValidate()
        {
            if (Light == null)
                Light = GetComponent<Light>();
        }

#endif
    }
}
