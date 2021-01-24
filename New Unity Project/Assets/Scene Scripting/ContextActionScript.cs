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
    private string operation; //the operation we are comparing/assigning with
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
            operation = actionSections[2];
            valueToCheck = actionSections[3];
        }
    }

    public void TriggerContextAction()
    {
        //We'll basically this chooses whether we do a success or fail scene, the default is just to succeed, we don't need to put in a fail condition for ever scene change

        bool successOrFail = true;

        if (actionToDo == "UpdateWorld")
        {
            WorldStatusScript.instance.UpdateWorldStatus(variableToCheck, operation, valueToCheck);
        }
        else if (actionToDo == "UpdatePlayer")
        {
            PlayerStatusScript.instance.UpdatePlayerStatus(variableToCheck, operation, valueToCheck);
        }
        else if (actionToDo == "CheckWorld")
        {
            successOrFail = WorldStatusScript.instance.CheckWorldStatus(variableToCheck, operation, valueToCheck);
        }
        else if (actionToDo == "CheckPlayer")
        {
            successOrFail = PlayerStatusScript.instance.CheckPlayerStatus(variableToCheck, operation, valueToCheck);
        }

        if (successOrFail)
        {
            sceneManager.TriggerSceneChange(successfulScene); //yeet!
        }
        else
        {
            sceneManager.TriggerSceneChange(failureScene); //yeet!
        }
    }
}
