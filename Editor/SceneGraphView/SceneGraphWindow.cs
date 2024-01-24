using UnityEditor;

namespace UnityAdventure
{
    public class AdventureGraphWindow : UnityGraphEditor.GraphWindow
    {
        SceneGraphView graphView;

        public void CreateGUI()
        {
            graphView = new SceneGraphView();
            rootVisualElement.Add(graphView);
        }

        // STATIC

        [MenuItem("Window/Adventure/Scene Graph")]
        public static void Init()
        {
            GetWindow<AdventureGraphWindow>("Scene Graph");
        }
    }
}
