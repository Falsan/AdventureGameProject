using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectScript : MonoBehaviour
{

    private bool isActiveScene = false;
    private string sceneName;
    private string sceneText;
    ContextActionScript[] contextActions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignSceneAttributes(string name, string text)
    {
        sceneName = name;
        sceneText = text;
        gameObject.name = name;
    }

    public void AssignContextActionsToScene()
    {
        contextActions = gameObject.GetComponents<ContextActionScript>();
    }

    public string GetSceneText()
    {
        return sceneText;
    }

    public string GetSceneName()
    {
        return sceneName;
    }

    public void SetActiveScene(bool toSet)
    {
        isActiveScene = toSet;

        if(isActiveScene == true && contextActions != null)
        {
            foreach(ContextActionScript contextAction in contextActions)
            {
                contextAction.AssignContextActionToUiButton();
            }
        }
    }

    public bool GetActiveScene()
    {
        return isActiveScene;
    }
}
