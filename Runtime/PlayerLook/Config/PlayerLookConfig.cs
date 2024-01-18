using UnityConfig;
using UnityEngine;

namespace UnityAdventure
{
    [CreateAssetMenu(menuName = "Adventure/PlayerLookConfig", fileName = "PlayerLookConfig")]
    public class PlayerLookConfig : SingleConfig<PlayerLookConfig>
    {
        public LayerMask CastMask;
        public LayerMask TargetMask;
        public float MaxDistance = 2f;
        public float UpdateInterval = 0.25f;
    }
}
