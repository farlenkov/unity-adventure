using System.Collections;
using System.Collections.Generic;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace UnityAdventure
{
    public abstract class AdventureNodeView : UnityGraphEditor.NodeView
    {
        public NodeViewData Data;
        public AdventureGraphView Graph;

        protected override void OnInit()
        {
            style.position = Position.Absolute;
            style.left = Data.Position.x;
            style.top = Data.Position.y;
            RefreshExpandedState();
        }

        public override void SavePosition()
        {
            var pos = GetPosition();
            Data.Position = new Vector2(pos.xMin, pos.yMin);
            EditorUtility.SetDirty(Data);
        }
    }
    
    public abstract class AdventureNodeView<T> : AdventureNodeView
        where T : MonoBehaviour
    {
        public T Target;
    }
}
