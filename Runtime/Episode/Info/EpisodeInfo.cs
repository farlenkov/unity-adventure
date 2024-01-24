using System;
using UnityEngine;
using UnityObjectInfo;

namespace UnityAdventure
{
    [CreateAssetMenu(menuName = "Adventure/EpisodeInfo", fileName = "EpisodeInfo")]
    public class EpisodeInfo : EntityInfo
    {
        public string Name;

        [HideInInspector] public Vector2 Position;
        [HideInInspector] public SceneAssetsInfoRef Scenes;

#if UNITY_EDITOR

        [ContextMenu("Load All")]
        void LoadAll()
        {
            Scenes.GetEditorAsset().LoadAll();
        }

#endif
    }

    [Serializable]
    public class EpisodeInfoRef : InfoRef<EpisodeInfo> { }

    public class EpisodeInfoList : InfoList<EpisodeInfo> { }
}