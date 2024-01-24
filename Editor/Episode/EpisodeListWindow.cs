using UnityEditor;
using UnityObjectInfo;

namespace UnityAdventure
{
    public class EpisodeListWindow : SceneAssetsWindow<EpisodeInfo>
    {
        [MenuItem("Window/Adventure/Episode List")]
        static void Init()
        {
            GetWindow<EpisodeListWindow>("Episode List");
        }

        protected override SceneAssetsInfo[] GetScenes(EpisodeInfo selectedEntity)
        {
            return new SceneAssetsInfo[] { selectedEntity.Scenes.GetEditorAsset() };
        }
    }
}
