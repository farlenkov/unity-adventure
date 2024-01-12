using System;
using UnityEngine;

namespace UnityAdventure
{
    [Serializable]
    public class SceneObjectRef
    {
        public string ID;

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is SceneObject info))
                return false;

            return ID == info.gameObject.name;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override string ToString()
        {
            return ID;
        }

        public static bool operator ==(SceneObjectRef ref1, SceneObjectRef ref2)
        {
            return ref1?.ID == ref2?.ID;
        }

        public static bool operator !=(SceneObjectRef ref1, SceneObjectRef ref2)
        {
            return ref1?.ID != ref2?.ID;
        }
    }
}
