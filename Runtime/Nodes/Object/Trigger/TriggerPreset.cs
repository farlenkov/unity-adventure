using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    [CreateAssetMenu(menuName = "Adventure/SceneTriggerPreset", fileName = "SceneTriggerPreset")]
    public class TriggerObjectPreset : ScriptableObject
    {
        public LayerMask IncludeLayers;
        public LayerMask ExcludeLayers;
    }
}
