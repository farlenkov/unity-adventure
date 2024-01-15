using Unity.Entities;
using UnityEngine;
using UnityServiceRegistry;

namespace UnityAdventure
{
    public abstract class EntityBehaviour : MonoBehaviour, IComponentData
    {
        public EntityManager EntityManager { get; private set; }
        public Entity Entity { get; private set; }
        public EventManager EventManager { get; private set; }

        protected virtual void Start()
        {
            ServiceRegistry.GetService(out EntityManager entityManager);
            ServiceRegistry.GetService(out EventManager eventManager);

            EntityManager = entityManager;
            EventManager = eventManager;
                        
            Entity = entityManager.SpawnObject(this);
        }

        protected virtual void OnDestroy()
        {
            EntityManager.DestroyObject(Entity);
        }
    }
}
