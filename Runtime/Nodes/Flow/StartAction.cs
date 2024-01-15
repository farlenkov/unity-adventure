using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    public class StartAction : FlowNode
    {
        protected override void Start()
        {
            base.Start();
            StartCoroutine(DelayedStart());
        }

        IEnumerator DelayedStart()
        {
            yield return null;
            TriggerOutEvent();
        }

        public override void Execute()
        {
            TriggerOutEvent();
        }
    }
}
