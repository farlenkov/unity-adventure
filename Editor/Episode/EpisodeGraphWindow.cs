using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityObjectInfo;

namespace UnityAdventure
{
    public class EpisodeGraphWindow : UnityGraphEditor.GraphWindow
    {
        EpisodeGraphView graphView;

        public void CreateGUI()
        {
            graphView = new EpisodeGraphView();
            rootVisualElement.Add(graphView);
        }

        // STATIC

        [MenuItem("Window/Adventure/Episode Graph")]
        public static void Init()
        {
            GetWindow<EpisodeGraphWindow>("Episode Graph");
        }
    }
}
