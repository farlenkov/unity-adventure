using UnityEngine;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    public class SceneLock : SceneComponent
    {
        public const string OpenEventName = "OnLockOpen";
        public const string CloseEventName = "OnLockClose";
    }
}
