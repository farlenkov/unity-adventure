using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    [CreateAssetMenu(menuName = "Adventure/SceneTriggerPreset")]
    public class SceneTriggerPreset : ScriptableObject
    {
        public LayerMask IncludeLayers;
        public LayerMask ExcludeLayers;
    }
}
