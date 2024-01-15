using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    public class SceneDoor : SceneComponent
    {
        public const string OpenEventName = "OnDoorOpen";
        public const string CloseEventName = "OnDoorClose";
    }
}
