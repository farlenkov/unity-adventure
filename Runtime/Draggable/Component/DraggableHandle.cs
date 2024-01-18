using System;
using UnityEngine;
using UnityGameLoop;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(ConfigurableJoint))]
    public class DraggableHandle : EntityBehaviour
    {
        [field: SerializeField]
        public ConfigurableJoint ConfigurableJoint { get; private set; }

        [NonSerialized]
        public DraggableObject Target;
    }
}
