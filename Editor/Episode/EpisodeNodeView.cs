using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

namespace UnityAdventure
{
    public class EpisodeNodeView : UnityGraphEditor.NodeView
    {
        public EpisodeInfo Data;

        protected override void OnInit()
        {
            style.position = Position.Absolute;
            style.left = Data.Position.x;
            style.top = Data.Position.y;

            AddToClassList("EpisodeNodeView");

            viewDataKey = Data.ID.ToString();
            title = Data.name;

            // SCENES

            AddLabel("Scenes");
            var scenes = Data.Scenes.GetEditorAsset();

            foreach (var scene in scenes.SceneAssets)
            {
                if (scene != null)
                    AddLabel($"-  {scene.name}");
            }
        }

        public override void OnSelected()
        {
            base.OnSelected();
            Selection.activeObject = Data;
        }

        public override void SavePosition()
        {
            var pos = GetPosition();
            Data.Position = new Vector2(pos.xMin, pos.yMin);
            EditorUtility.SetDirty(Data);
        }
    }
}
