using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityObjectInfo;

namespace UnityAdventure
{
    public class EpisodesWindow : SceneAssetsWindow<EpisodeInfo>
    {
        [MenuItem("Window/Adventure/Episodes")]
        static void Init()
        {
            GetWindow<EpisodesWindow>("Episodes");
        }

        protected override SceneAssetsInfo[] GetScenes(EpisodeInfo selectedEntity)
        {
            return new SceneAssetsInfo[]
            {
                selectedEntity.Scenes.GetEditorAsset()
            };
        }
    }
}
