using UnityEngine;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    public class LockObject : SceneComponent
    {
        public const string OpenEventName = "OnLockOpen";
        public const string CloseEventName = "OnLockClose";
    }
}
