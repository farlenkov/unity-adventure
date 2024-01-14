using Unity.Entities;
using UnityGameLoop;

namespace UnityAdventure
{
    public partial class EventsClearSystem : GameLoopSystem<GameLoop>
    {
        protected override void OnUpdate()
        {
            ClearSpawnEvents();
            ClearLookEvents();
            ClearDestroyEvents();
        }

        void ClearSpawnEvents()
        {
            Entities
                .WithStructuralChanges()
                .ForEach((Entity entity, SpawnEvent spawnEvent) =>
                {
                    EntityManager.RemoveComponent<SpawnEvent>(entity);

                }).Run();
        }

        void ClearDestroyEvents()
        {
            Entities
                .WithStructuralChanges()
                .ForEach((Entity entity, DestroyEvent destroyEvent) =>
                {
                    EntityManager.DestroyEntity(entity);

                }).Run();
        }

        void ClearLookEvents()
        {
            Entities
                .WithStructuralChanges()
                .ForEach((Entity entity, PlayerLookEvent lookEvent) =>
                {
                    //if (lookEvent.OldTarget == null)
                    //    Log.Info($"[PlayerLookSystem] Start Looking At: {lookEvent.NewTarget.gameObject.name}");
                    //else if (lookEvent.NewTarget != null)
                    //    Log.Info($"[PlayerLookSystem] Change Looking At: {lookEvent.OldTarget.gameObject.name} > {lookEvent.NewTarget.gameObject.name}");
                    //else
                    //    Log.Info($"[PlayerLookSystem] Stop Looking At: {lookEvent.OldTarget.gameObject.name}");

                    EntityManager.RemoveComponent<PlayerLookEvent>(entity);

                }).Run();
        }
    }
}
