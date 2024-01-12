using Unity.Entities;

namespace UnityAdventure
{
    public class PlayerLookEvent : IComponentData
    {
        public PlayerLookTarget NewTarget;
        public PlayerLookTarget OldTarget;
    }
}
