using System;
using Unity.Entities;
using UnityEngine;

namespace UnityAdventure
{
    public static class EntityManagerExt
    {
        public static Entity SpawnObject<T>(
            this EntityManager entityManager,
            T objectComponent) where T : MonoBehaviour, IComponentData
        {
            var entity = entityManager.CreateEntity();
            entityManager.AddComponentObject(entity, objectComponent);
            entityManager.AddComponentData(entity, new SpawnEvent());
            return entity;
        }

        public static void DestroyObject(
            this EntityManager entityManager,
            Entity entity)
        {
            try
            {
                entityManager.AddComponentData(entity, new DestroyEvent());
            }
            catch (Exception ex)
            {

            }
        }
    }
}
