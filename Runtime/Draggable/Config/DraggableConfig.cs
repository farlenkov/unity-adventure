using UnityConfig;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityAdventure
{
    [CreateAssetMenu(menuName = "Adventure/DraggableConfig", fileName = "DraggableConfig")]
    public class DraggableConfig : SingleConfig<DraggableConfig>
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

#if UNITY_EDITOR

        void OnValidate()
        {
            breakDistanceSqt = BreakDistance * BreakDistance;
        }

#endif
    }
}
