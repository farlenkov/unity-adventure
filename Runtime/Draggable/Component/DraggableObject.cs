using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent (typeof(PlayerLookTarget))]
    public class DraggableObject : MonoBehaviour
    {
        [field: SerializeField]
        public Rigidbody Rigidbody { get; private set; }

        [field: SerializeField]
        public DraggableType Type { get; private set; }
    }
}
