using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    public class DoorObject : SceneComponent
    {
        public const string OpenEventName = "OnDoorOpen";
        public const string CloseEventName = "OnDoorClose";
    }
}
