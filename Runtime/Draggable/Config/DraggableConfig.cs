using UnityEngine;
using UnityEngine.InputSystem;
using UnityUtility;

namespace UnityAdventure
{
    [CreateAssetMenu(menuName = "Adventure/DraggableConfig")]
    public class DraggableConfig : ScriptableObject
    {
        [field: SerializeField]
        public InputActionReference GrabInputAction { get; private set; }

        [field: SerializeField]
        public float GrabDistance { get; private set; }

        [field: SerializeField]
        public float BreakDistance { get; private set; }

        [SerializeField]
        [HideInInspector]
        float breakDistanceSqt;

        public float BreakDistanceSqt => breakDistanceSqt;

        // STATIC

        public static DraggableConfig Load()
        {
            var configs = Resources.LoadAll<DraggableConfig>("");

            if (configs.Length == 0)
                return null;

            if (configs.Length > 1)
                Log.WarningEditor("[DraggableConfig: Load] More than one config found");

            return configs[0];
        }

#if UNITY_EDITOR

        void OnValidate()
        {
            breakDistanceSqt = BreakDistance * BreakDistance;
        }

#endif
    }
}
