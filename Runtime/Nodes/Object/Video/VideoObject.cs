using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace UnityAdventure
{
    public class VideoObject : SwitchableObject
    {
        [field: SerializeField]
        public VideoPlayer VideoPlayer { get; private set; }

        [field: SerializeField]
        public VideoObjectSaveTime SaveTimeOnSwitch { get; private set; }

        double savedTime;
        float turnOffTime = -1;

        protected override void OnSwitch(SwitchObject switchObject, bool isActive)
        {
            if (VideoPlayer == null)
                return;

            if (isActive)
            {
                VideoPlayer.Play();

                switch (SaveTimeOnSwitch)
                {
                    case VideoObjectSaveTime.Freeze:
                        VideoPlayer.time = savedTime;
                        break;

                    case VideoObjectSaveTime.Continue:
                        VideoPlayer.time = savedTime + (turnOffTime < 0 ? 0 : Time.time - turnOffTime);
                        break;
                }
            }
            else
            {
                savedTime = VideoPlayer.time;
                turnOffTime = Time.time;
                VideoPlayer.Stop();
            }
        }

#if UNITY_EDITOR

        void OnValidate()
        {
            if (VideoPlayer == null)
                VideoPlayer = GetComponent<VideoPlayer>();
        }

#endif
    }
}
