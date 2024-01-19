using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    public class LightObject : SwitchableObject
    {
        [field: SerializeField]
        public Light Light { get; private set; }

        protected override void Start()
        {
            base.Start();

            if (Switch != null &&
                Light != null)
                Light.enabled = Switch.IsActive;
        }

        protected override void OnSwitch(SwitchObject switchObject, bool isActive)
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
