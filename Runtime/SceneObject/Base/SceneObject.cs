using Unity.Entities;
using UnityEngine;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    public sealed class SceneObject : AdventureNode
    {
        protected override void Start()
        {
            base.Start();

            var sceneComponents = GetComponents<SceneComponent>();

            for (var i = 0; i < sceneComponents.Length; i++)
            {
                var sceneComponent = sceneComponents[i];
                EntityManager.AddComponentObject(Entity, sceneComponent);
            }
        }
    }
}