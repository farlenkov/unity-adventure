using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    public class DelayAction : FlowNode
    {
        public float Min;
        public float Max;

        public override void Execute()
        {
            StartCoroutine(Delay());
        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(Random.Range(Min, Max));
            TriggerOut();
        }
    }
}
