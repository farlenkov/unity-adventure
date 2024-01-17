using UnityEngine;
using UnityEngine.InputSystem;
using UnityUtility;

namespace UnityAdventure
{
    [CreateAssetMenu(menuName = "Adventure/InteractableConfig")]
    public class InteractableConfig : ScriptableObject
    {
        [field: SerializeField]
        public InputActionReference InteractInputAction { get; private set; }

        [field: SerializeField]
        public float InteractDistance { get; private set; }

        // STATIC

        public static InteractableConfig Load()
        {
            var configs = Resources.LoadAll<InteractableConfig>("");

            if (configs.Length == 0)
                return null;

            if (configs.Length > 1)
                Log.WarningEditor("[InteractableConfig: Load] More than one config found");

            return configs[0];
        }
    }
}
