using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityAdventure
{
    [CreateAssetMenu(menuName = "Adventure/DraggableConfig")]
    public class DraggableConfig : ScriptableObject
    {
        [field: SerializeField]
        public InputActionReference GrabInputAction { get; private set; }

        [field: SerializeField]
        public float BreakDistance { get; private set; }

        public float BreakDistanceSqt { get; private set; }

        // STATIC

        public static DraggableConfig Load()
        {
            var configs = Resources.LoadAll<DraggableConfig>("");

            if (configs.Length == 0)
                return null;

            var config = configs[0];
            config.BreakDistanceSqt = config.BreakDistance * config.BreakDistance;
            return config;
        }
    }
}
