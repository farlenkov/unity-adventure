using UnityEngine;
using UnityEngine.InputSystem;
using UnityUtility;

namespace UnityAdventure
{
    [CreateAssetMenu(menuName = "Adventure/InteractableConfig", fileName = "InteractableConfig")]
    public class InteractableConfig : BaseConfig
    {
        [field: SerializeField]
        public InputActionReference InteractInputAction { get; private set; }

        [field: SerializeField]
        public float InteractDistance { get; private set; }

        // STATIC

        public static InteractableConfig Load() => Load<InteractableConfig>();
    }
}
