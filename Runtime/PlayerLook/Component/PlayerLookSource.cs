using System;
using UnityGameLoop;

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
