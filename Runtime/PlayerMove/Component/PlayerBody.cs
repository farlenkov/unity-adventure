using UnityEngine;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerBody : EntityBehaviour
    {
        [field: SerializeField]
        public Rigidbody Rigidbody { get; private set; }

        [field: SerializeField]
        public CapsuleCollider Capsule { get; private set; }
    }
}
