using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;

namespace UnityAdventure
{
    public abstract class BaseConfig : ScriptableObject
    {
        protected static T Load<T>() where T : BaseConfig
        {
            var configs = Resources.LoadAll<T>("");

            if (configs.Length == 0)
                return null;

            if (configs.Length > 1)
                Log.WarningEditor($"[{typeof(T).Name}: Load] More than one config found");

            return configs[0];
        }
    }
}
