using UnityConfig;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityUtility;

namespace UnityAdventure
{
    [CreateAssetMenu(menuName = "Adventure/InteractableConfig", fileName = "InteractableConfig")]
    public class InteractableConfig : SingleConfig<InteractableConfig>
    {
        [field: SerializeField]
        public InputActionReference InteractInputAction { get; private set; }

        [field: SerializeField]
        public float InteractDistance { get; private set; }
    }
}
