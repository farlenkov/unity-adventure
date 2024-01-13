using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    public class SceneObjectNodeView : AdventureNodeView<SceneObject>
    {
        protected override void OnInit()
        {
            base.OnInit();
            viewDataKey = Target.ID;
            title = Target.gameObject.name;
        }
    }
}
