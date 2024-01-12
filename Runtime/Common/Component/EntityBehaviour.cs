using Unity.Entities;
using UnityEngine;
using UnityServiceRegistry;

namespace UnityAdventure
{
    public abstract class EntityBehaviour : MonoBehaviour, IComponentData
    {
        EntityManager entityManager;
        Entity myEntity;

        protected virtual void Start()
        {
            ServiceRegistry.GetService(out entityManager);
            myEntity = entityManager.SpawnObject(this);
        }

        protected virtual void OnDestroy()
        {
            entityManager.DestroyObject(myEntity);
        }
    }
}
