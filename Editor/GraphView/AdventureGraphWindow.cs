using UnityEditor;

namespace UnityAdventure
{
    public class AdventureGraphWindow : UnityGraphEditor.GraphWindow
    {
        AdventureGraphView graphView;

        public void CreateGUI()
        {
            graphView = new AdventureGraphView();
            rootVisualElement.Add(graphView); 
            OnHierarchyChange();
        }

        void OnHierarchyChange()
        {
            graphView.Refresh();
        }

        // STATIC

        [MenuItem("Window/Adventure Graph")]
        public static void Init()
        {
            GetWindow<AdventureGraphWindow>("Adventure Graph");
        }
    }
}