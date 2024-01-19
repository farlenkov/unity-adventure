using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace UnityAdventure
{
    public class SceneVideo : SceneSwitchable
    {
        [field: SerializeField]
        public VideoPlayer Player { get; private set; }

        [field: SerializeField]
        public SceneVideoSaveTime SaveTimeOnSwitch { get; private set; }

        double savedTime;
        float turnOffTime = -1;

        protected override void OnSwitch(SceneSwitch sceneSwitch, bool isActive)
        {
            if (Player == null)
                return;

            if (isActive)
            {
                Player.Play();

                switch (SaveTimeOnSwitch)
                {
                    case SceneVideoSaveTime.Freeze:
                        Player.time = savedTime;
                        break;

                    case SceneVideoSaveTime.Continue:
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
    }
}
