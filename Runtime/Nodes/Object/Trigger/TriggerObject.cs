using UnityEngine;
using UnityUtility;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    public class TriggerObject : SwitchObject
    {
        int enterCounter;

        public TriggerObjectPreset Preset;

        public const string EnterEventName = "OnTriggerEnter";
        public const string ExitEventName = "OnTriggerExit";

        protected override void Start()
        {
            base.Start();
            SetIsActive(false);
        }

        void OnTriggerEnter(Collider other)
        {
            if (IsValid(other.gameObject))
            {
                enterCounter++;
                SetIsActive(enterCounter > 0);
                TriggerEvent(EnterEventName);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (IsValid(other.gameObject))
            {
                enterCounter--;
                SetIsActive(enterCounter > 0);
                TriggerEvent(ExitEventName);
            }
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
