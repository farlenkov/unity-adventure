using System;
using UnityEngine;

namespace UnityAdventure
{
    public class PlayerLookSource : EntityBehaviour
    {
        [NonSerialized]
        public PlayerLookTarget Target;

        [NonSerialized]
        public float TargetDistance;
    }
}
