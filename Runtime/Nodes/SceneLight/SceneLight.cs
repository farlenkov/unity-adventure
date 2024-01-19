using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    public class SceneLight : SceneSwitchable
    {
        [field: SerializeField]
        public Light Light { get; private set; }

        protected override void OnSwitch(SceneSwitch sceneSwitch, bool isActive)
        {
            if (Light != null) 
                Light.enabled = isActive;
        }
    }
}
