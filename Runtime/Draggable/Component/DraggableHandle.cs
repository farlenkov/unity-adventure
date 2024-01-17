using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
