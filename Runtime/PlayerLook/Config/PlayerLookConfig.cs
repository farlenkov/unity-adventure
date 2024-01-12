using UnityEngine;

namespace UnityAdventure
{
    [CreateAssetMenu(menuName = "Adventure/PlayerLookConfig")]
    public class PlayerLookConfig : ScriptableObject
    {
        public LayerMask CastMask;
        public LayerMask TargetMask;
        public float MaxDistance = 2f;
        public float UpdateInterval = 0.25f;

        // STATIC

        public static PlayerLookConfig Load()
        {
            var configs = Resources.LoadAll<PlayerLookConfig>("");

            return configs.Length > 0
                ? configs[0] 
                : null;
        }
    }
}
