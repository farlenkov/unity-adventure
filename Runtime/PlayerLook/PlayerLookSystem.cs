using Unity.Entities;
using UnityEngine;
using UnityGameLoop;
using UnityUtility;

namespace UnityAdventure
{
    public partial class PlayerLookSystem : GameLoopSystem<GameLoop>
    {
        RaycastHit[] hits = new RaycastHit[10];
        PlayerLookConfig lookConfig;
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
                .ForEach((PlayerLookSource lookSource) =>
                {
                    Cast(lookSource);

                }).Run();
        }

        void Cast(PlayerLookSource lookSource)
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
                //Log.Info("[PlayerLookSystem] FALSE");
                return;
            }

            hits.Sort(hitsCount);

            for (var i = 0; i < hitsCount; i++)
            {
                var hit = hits[i];
                var gameObject = hit.collider.gameObject;

                if (gameObject.InLayers(lookConfig.TargetMask))
                    Log.Info($"[PlayerLookSystem] Look At: {gameObject.name}");
                //else
                //    Log.Info($"[PlayerLookSystem] FALSE {gameObject.name}");

                break;
            }
        }
    }
}