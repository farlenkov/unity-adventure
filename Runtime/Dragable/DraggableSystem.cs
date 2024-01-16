using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityGameLoop;
using UnityUtility;

namespace UnityAdventure
{
    public partial class DraggableSystem : GameLoopSystem<GameLoop>
    {
        DraggableConfig config;
        InputAction grabAction;

        protected override void OnInit()
        {
            base.OnInit();
            config = DraggableConfig.Load();
            grabAction = config.GrabInputAction.action;
        }

        protected override void OnUpdate()
        {
            Entities
                .WithoutBurst()
                .ForEach((DraggableHandle draggableHandle) =>
                {
                    OnUpdate(draggableHandle);

                }).Run();
        }

        void OnUpdate(DraggableHandle draggableHandle)
        {
            if (draggableHandle.Target == null)
            {
                if (grabAction.WasPressedThisFrame())
                    TryGrab(draggableHandle);
            }
            else
            {
                if (grabAction.WasReleasedThisFrame())
                    Drop(draggableHandle);
                else
                    TryBreak(draggableHandle);
            }
        }

        void TryGrab(DraggableHandle draggableHandle)
        {
            Entities
                .WithoutBurst()
                .ForEach((PlayerLookSource lookSource) =>
                {
                    if (lookSource.Target != null)
                        if (lookSource.Target.TryGetComponent<DraggableObject>(out var draggableObject))
                            Grab(lookSource.TargetDistance, draggableHandle, draggableObject);

                }).Run();
        }

        void Grab(
            float distance,
            DraggableHandle draggableHandle,
            DraggableObject draggableObject)
        {
            //Log.Info($"TryGrab '{draggableObject.gameObject.name}'");

            draggableHandle.transform.localPosition = new Vector3(0, 0, distance);
            draggableHandle.ConfigurableJoint.connectedBody = draggableObject.Rigidbody;
            draggableHandle.Target = draggableObject;
        }

        void TryBreak(DraggableHandle draggableHandle)
        {
            var handlePos = draggableHandle.transform.position;
            var objectPos = draggableHandle.Target.transform.position;

            if ((handlePos - objectPos).sqrMagnitude > config.BreakDistanceSqt)
                Drop(draggableHandle);
        }

        void Drop(DraggableHandle draggableHandle)
        {
            //Log.Info($"TryDrop '{draggableHandle.Target.gameObject.name}'");

            draggableHandle.ConfigurableJoint.connectedBody = null;
            draggableHandle.Target = null;
        }
    }
}
