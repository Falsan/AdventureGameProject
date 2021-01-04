using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextActionScript : MonoBehaviour
{
    private string contextActionID;
    private string contextActionName;
    private int UIPosition;
    private string successfulScene;
    private string failureScene;
    private string actionToDo; //this will be what kind of action we are doing, either a comparison, assignment or increment
    private string variableToCheck; //this will be the variable, player or world, we are checking or incrementing
    private string valueToCheck; //this will be the value we are checking it is or assigning

    private ActiveSceneManager sceneManager; //reference to the scene manager

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("Scene Manager").GetComponent<ActiveSceneManager>(); //we're assuming here that there will be a scene manager in the scene to trigger this behaviour
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetContextActionID()
    {
        return contextActionID;
    }

    public void AssignContextActionValues(string ID, string name,
        string UIpos, string action, string successScene, string failScene)
    {
        contextActionID = ID;
        contextActionName = name;
        UIPosition = int.Parse(UIpos);
        successfulScene = successScene;
        failureScene = failScene;

        if (action == "")
        {
            action = "No Action";
        }
        else
        {
            string[] actionSections = action.Split(','); //seperate out the action keyword from the rest of the actual action

            actionToDo = actionSections[0];
            variableToCheck = actionSections[1];
            valueToCheck = actionSections[2];
        }
    }

    public void TriggerContextAction()
    {
        //We'll need to write in some behaviour here about how we select the scene to send over, but we need the world and player state stuff to do that so for now we'll just yeet the success scene name across

        sceneManager.TriggerSceneChange(successfulScene); //yeet!
    }
}
