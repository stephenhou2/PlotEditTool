using GameEngine;

public class PlotEditScene : IScene
{
    public string GetSceneName()
    {
        return "PlotEditScene";
    }

    public void OnSceneEnter()
    {
        UIManager.Ins.OpenPanel<PlotEditorWindow>("Prefab/_PLOT_EDITOR");
    }

    public void OnSceneExit()
    {
        
    }

    public void OnSceneLateUpdate(float deltaTime)
    {
        
    }

    public void OnSceneUpdate(float deltaTime)
    {
        
    }
}
