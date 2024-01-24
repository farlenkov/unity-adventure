using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityUtility;

namespace UnityAdventure
{
    public abstract class AdventureGraphView : UnityGraphEditor.GraphView
    {
        protected abstract void Refresh();

        public AdventureGraphView() : base() 
        {
            EditorApplication.hierarchyChanged += Refresh;
            Refresh();
        }

        protected override void OnGraphDestroy()
        {
            EditorApplication.hierarchyChanged -= Refresh;
        }

        protected override void AddStyle()
        {
            base.AddStyle();

            var style = AssetDatabase.LoadAssetAtPath<StyleSheet>("Packages/com.farlenkov.unity-adventure/Editor/GraphView/GraphStyles.uss");
            styleSheets.Add(style);
        }
    }
}