using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace UnityAdventure
{
    public class EpisodeGraphView : AdventureGraphView
    {
        protected override void Refresh()
        {
            ClearNodes();
            CreateEpisodeNodes();
            CreateEdges();
        }

        private void CreateEpisodeNodes()
        {
            var allEpisodes = Resources.LoadAll<EpisodeInfo>("");

            foreach (var episode in allEpisodes)
            {
                var view = new EpisodeNodeView();
                view.Data = episode;

                view.Init();
                AddElement(view);
            }
        }

        private void CreateEdges()
        {

        }

        protected override void OnEdgeCreate(Edge edge)
        {

        }

        protected override void OnEdgeRemove(Edge edge)
        {

        }
    }
}
