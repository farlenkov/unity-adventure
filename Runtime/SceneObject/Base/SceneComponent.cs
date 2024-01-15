using Unity.Entities;
using UnityEngine;
using UnityServiceRegistry;

namespace UnityAdventure
{
    [RequireComponent(typeof(SceneObject))]
    public abstract class SceneComponent : MonoBehaviour, IComponentData
    {        
        protected EntityManager EntityManager => SceneObject.EntityManager;
        protected Entity Entity => SceneObject.Entity;
        protected SceneObject SceneObject { get; private set; }

        protected virtual void Start()
        {
            SceneObject = GetComponent<SceneObject>();
        }

        protected void AddEvent(SceneEvent sceneEvent)
        {
            EntityManager.AddComponentObject(Entity, sceneEvent);
        }
    }
}
