using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace UnityAdventure
{
    public class VideoObject : SwitchableObject
    {
        [field: SerializeField]
        public VideoPlayer Player { get; private set; }

        [field: SerializeField]
        public VideoObjectSaveTime SaveTimeOnSwitch { get; private set; }

        double savedTime;
        float turnOffTime = -1;

        protected override void OnSwitch(SwitchObject sceneSwitch, bool isActive)
        {
            if (Player == null)
                return;

            if (isActive)
            {
                Player.Play();

                switch (SaveTimeOnSwitch)
                {
                    case VideoObjectSaveTime.Freeze:
                        Player.time = savedTime;
                        break;

                    case VideoObjectSaveTime.Continue:
                        Player.time = savedTime + (turnOffTime < 0 ? 0 : Time.time - turnOffTime);
                        break;
                }
            }
            else
            {
                savedTime = Player.time;
                turnOffTime = Time.time;
                Player.Stop();
            }
        }

#if UNITY_EDITOR

        void OnValidate()
        {
            if (Player == null)
                Player = GetComponent<VideoPlayer>();
        }

#endif
    }
}
