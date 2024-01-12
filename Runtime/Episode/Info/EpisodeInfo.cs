using System;
using UnityEngine;
using UnityObjectInfo;
using System.IO;


#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace UnityAdventure
{
    [CreateAssetMenu(menuName = "Adventure/EpisodeInfo", fileName = "EpisodeInfo")]
    public class EpisodeInfo : EntityInfo
    {
        public string Name;

        [HideInInspector] public SceneAssetsInfoRef Scenes;
    }

    [Serializable]
    public class EpisodeInfoRef : InfoRef<EpisodeInfo> { }

    public class EpisodeInfoList : InfoList<EpisodeInfo> { }
}