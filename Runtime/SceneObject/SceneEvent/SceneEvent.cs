using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace UnityAdventure
{
    public class SceneEvent : IComponentData
    {
        public string ObjectID;
        public string EventName;
    }
}
