using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSceneManager : MonoBehaviour
{

    public static ActiveSceneManager instance;
    GameObject[] arrayOfSceneObjects;
    SceneObjectScript activeSceneObjectScript;
    public GameObject activeSceneObject;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        
    }

    public void SetUpAllSceneObjectsInList() //Importantly this gets called only after world generation has finished mucking about
    {
        arrayOfSceneObjects = GameObject.FindGameObjectsWithTag("SceneObject");

        foreach (GameObject obj in arrayOfSceneObjects)
        {
            if (obj.GetComponent<SceneObjectScript>().GetActiveScene())
            { 
                activeSceneObject = obj;
                activeSceneObjectScript = obj.GetComponent<SceneObjectScript>();
                activeSceneObjectScript.SetActiveScene(true);
                break;
            }
        }
    }

    public void TriggerSceneChange(string newScene)
    {
        //this is where we will change the scene to the requested scene

        activeSceneObjectScript.SetActiveScene(false);

        foreach (GameObject obj in arrayOfSceneObjects)
        {
            if (obj.name == newScene)
            {
                activeSceneObject = obj;
                activeSceneObjectScript = obj.GetComponent<SceneObjectScript>();
                activeSceneObjectScript.SetActiveScene(true);
                ConsoleEventManager.instance.SendTextToBePrinted(activeSceneObjectScript.GetSceneText()); //shoot the active scene text to the console
                break;
            }
        }


    }
}
