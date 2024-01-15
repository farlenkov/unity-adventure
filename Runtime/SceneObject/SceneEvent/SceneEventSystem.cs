using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityGameLoop;
using UnityUtility;

namespace UnityAdventure
{
    public partial class SceneEventSystem : GameLoopSystem<GameLoop>
    {
        protected override void OnUpdate()
        {
            Entities
                .WithoutBurst()
                .ForEach((SceneEvent sceneEvent) =>
                {
                    Handle(sceneEvent);

                }).Run();
        }

        public static void Handle(SceneEvent sceneEvent)
        {
            if (!FlowNode.TryGetByObjectEvent(
                sceneEvent.ObjectID, 
                sceneEvent.EventName, 
                out var flowNodes))
                return;

            foreach (var flowNode in flowNodes)
            {
                Log.Info($"[SceneTriggerSystem: Handle] {sceneEvent.EventName} > {flowNode.gameObject.name}");
                flowNode.Execute();
            }
        }
    }
}
