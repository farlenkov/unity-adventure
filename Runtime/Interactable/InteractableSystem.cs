using System;
using Unity.Entities;
using UnityEngine.InputSystem;
using UnityGameLoop;
using UnityUtility;

namespace UnityAdventure
{
    public partial class InteractableSystem : GameLoopSystem<GameLoop>
    {
        InteractableConfig config;
        InputAction interactAction;

        protected override void OnInit()
        {
            base.OnInit();

            config = InteractableConfig.Load();
            interactAction = config.InteractInputAction.action;
        }

        protected override void OnUpdate()
        {
            Entities
                .WithoutBurst()
                .ForEach((PlayerLookSource lookSource) =>
                {
                    if (lookSource.Target == null)
                        return;

                    if (lookSource.TargetDistance > config.InteractDistance)
                        return;

                    if (!interactAction.WasPressedThisFrame())
                        return;

                    if (!lookSource.Target.TryGetComponent(out InteractableObject interactableObject))
                        return;

                    TryInteract(interactableObject);

                }).Run();
        }

        void TryInteract(InteractableObject interactableObject)
        {
            Log.Info($"TryInteract '{interactableObject.gameObject.name}'");
            interactableObject.Interract();
        }
    }
}
