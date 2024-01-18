using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityAdventure
{
    [CreateAssetMenu(menuName = "Adventure/PlayerMoveConfig", fileName = "PlayerMoveConfig")]
    public class PlayerMoveConfig : BaseConfig
    {
        [field: SerializeField]
        public InputActionReference LookInputAction { get; private set; }

        [field: SerializeField]
        public InputActionReference MoveInputAction { get; private set; }

        [field: SerializeField]
        public InputActionReference JumpInputAction { get; private set; }

        [field: SerializeField]
        public InputActionReference CrouchInputAction { get; private set; }

        [field: SerializeField]
        public InputActionReference SprintInputAction { get; private set; }

        [field: SerializeField]
        public float BaseSpeed { get; private set; }

        [field: SerializeField]
        public float SprintSpeed { get; private set; }

        [field: SerializeField]
        public float LerpSpeed { get; private set; }

        // STATIC

        public static PlayerMoveConfig Load() => Load<PlayerMoveConfig>();
    }
}
