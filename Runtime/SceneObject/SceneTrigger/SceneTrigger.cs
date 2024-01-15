using UnityEngine;
using UnityUtility;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    public class SceneTrigger : SceneComponent
    {
        public SceneTriggerPreset Preset;

        public const string EnterEventName = "OnTriggerEnter";
        public const string ExitEventName = "OnTriggerExit";

        SceneEvent enterEvent;
        SceneEvent exitEvent;

        protected override void Start()
        {
            base.Start();

            enterEvent = new() 
            { 
                EventName = EnterEventName, 
                ObjectID = SceneObject.ID
            };

            exitEvent = new() 
            { 
                EventName = ExitEventName,
                ObjectID = SceneObject.ID
            };
        }

        void OnTriggerEnter(Collider other)
        {
            if (IsValid(other.gameObject))
                AddEvent(enterEvent);
        }

        void OnTriggerExit(Collider other)
        {
            if (IsValid(other.gameObject))
                AddEvent(exitEvent);
        }

        bool IsValid(GameObject gameObject)
        {
            if (Preset == null)
                return true;

            if (Preset.ExcludeLayers > 0 &&
                gameObject.InLayers(Preset.ExcludeLayers))
                return false;

            if (Preset.IncludeLayers > 0 &&
                !gameObject.InLayers(Preset.IncludeLayers))
                return false;

            return true;
        }
    }
}
