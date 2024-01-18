using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityGameLoop;

namespace UnityAdventure
{
    public partial class PlayerRotateSystem : GameLoopSystem<GameLoop>
    {
        PlayerMoveConfig config;
        InputAction lookAction;

        protected override void OnInit()
        {
            base.OnInit();

            config = PlayerMoveConfig.Load();
            lookAction = config.LookInputAction;
            lookAction.Enable();
        }

        protected override void OnUpdate()
        {
            Entities
                .WithoutBurst()
                .ForEach((PlayerHorizontalRotation horizontalRotation) =>
                {
                    OnUpdate(horizontalRotation);

                }).Run();
        }
        
        void OnUpdate(PlayerHorizontalRotation horizontalRotation)
        {
            Entities
                .WithoutBurst()
                .ForEach((PlayerVerticalRotation verticalRotation) =>
                {
                    OnUpdate(horizontalRotation, verticalRotation);

                }).Run();
        }

        void OnUpdate(
            PlayerHorizontalRotation horizontalRotation, 
            PlayerVerticalRotation verticalRotation)
        {
            var moveInput = lookAction.ReadValue<Vector2>();
            horizontalRotation.transform.Rotate(Vector3.up * moveInput.x);
            verticalRotation.transform.Rotate(Vector3.right * moveInput.y);
        }
    }
}
