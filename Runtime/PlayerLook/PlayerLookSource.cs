using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityServiceRegistry;

namespace UnityAdventure
{
    public class PlayerLookSource : MonoBehaviour, IComponentData
    {
        EntityManager entityManager; 
        Entity myEntity;

        void Start()
        {
            ServiceRegistry.GetService(out entityManager);
            myEntity = entityManager.SpawnObject(this);
        }

        void OnDestroy()
        {
            entityManager.DestroyObject(myEntity);
        }
    }
}
