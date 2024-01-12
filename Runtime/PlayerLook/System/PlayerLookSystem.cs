using Unity.Entities;
using UnityEngine;
using UnityGameLoop;
using UnityUtility;

namespace UnityAdventure
{
    public partial class PlayerLookSystem : GameLoopSystem<GameLoop>
    {
        PlayerLookConfig lookConfig;
        PlayerLookEvent reusableLookEvent = new PlayerLookEvent();
        RaycastHit[] hits = new RaycastHit[10];
        float nextUpdateTime;

        protected override bool NeedUpdate => (ElapsedTime >= nextUpdateTime);

        protected override void OnInit()
        {
            base.OnInit();
            lookConfig = PlayerLookConfig.Load();
        }

        protected override void OnUpdate()
        {
            Entities
                .WithoutBurst()
                .WithStructuralChanges()
                .ForEach((
                    Entity entity,
                    PlayerLookSource lookSource) =>
                {
                    Cast(entity, lookSource);

                }).Run();
        }

        void Cast(Entity entity, PlayerLookSource lookSource)
        {
            nextUpdateTime = ElapsedTime + lookConfig.UpdateInterval;

            var lookTransform = lookSource.transform;

            var hitsCount = Physics.RaycastNonAlloc(
                lookTransform.position,
                lookTransform.forward,
                hits,
                lookConfig.MaxDistance,
                lookConfig.CastMask);

            if (hitsCount == 0)
            {
                Miss(entity, lookSource);
                return;
            }

            hits.Sort(hitsCount);

            for (var i = 0; i < hitsCount; i++)
            {
                var hit = hits[i];
                var gameObject = hit.collider.gameObject;

                if (!gameObject.InLayers(lookConfig.TargetMask))
                {
                    Miss(entity, lookSource);
                    break;
                }

                var newTarget = gameObject.GetComponent<PlayerLookTarget>();
                
                if (newTarget == null)
                {
                    Miss(entity, lookSource);
                    break;
                }

                if (newTarget != lookSource.Target)
                    Hit(entity, lookSource, newTarget);

                break;
            }
        }

        void Hit(Entity entity, PlayerLookSource lookSource, PlayerLookTarget newTarget)
        {
            reusableLookEvent.NewTarget = newTarget;
            reusableLookEvent.OldTarget = lookSource.Target;
            EntityManager.AddComponentData(entity, reusableLookEvent);

            lookSource.Target = newTarget;
        }

        void Miss(Entity entity, PlayerLookSource lookSource)
        {
            if (lookSource.Target != null)
            {
                reusableLookEvent.NewTarget = null;
                reusableLookEvent.OldTarget = lookSource.Target;
                EntityManager.AddComponentData(entity, reusableLookEvent);

                lookSource.Target = null;
            }
        }
    }
}