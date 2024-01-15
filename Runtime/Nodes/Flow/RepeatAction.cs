using System.Collections;
using UnityEngine;

namespace UnityAdventure
{
    public class RepeatAction : FlowNode
    {
        public int CiclesMin;
        public int CiclesMax;

        public float IntervalMin;
        public float IntervalMax;

        public override void Execute()
        {
            StartCoroutine(Repeat());
        }

        IEnumerator Repeat()
        {
            var cicles = Random.Range(CiclesMin, CiclesMax);

            for (int i = 0; i < cicles; i++)
            {
                TriggerOutEvent();
                yield return new WaitForSeconds(Random.Range(IntervalMin, IntervalMax));
            }
        }
    }
}