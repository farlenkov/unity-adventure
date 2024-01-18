using UnityEngine;
using UnityEngine.InputSystem;
using UnityUtility;

namespace UnityAdventure
{
    [CreateAssetMenu(menuName = "Adventure/DraggableConfig", fileName = "DraggableConfig")]
    public class DraggableConfig : BaseConfig
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

        public static DraggableConfig Load() => Load<DraggableConfig>();

#if UNITY_EDITOR

        void OnValidate()
        {
            breakDistanceSqt = BreakDistance * BreakDistance;
        }

#endif
    }
}
