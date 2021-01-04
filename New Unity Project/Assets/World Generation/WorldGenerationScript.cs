using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WorldGenerationScript : MonoBehaviour {

    public static WorldGenerationScript instance;
    public GameObject sceneObjectPrefab;

    // Use this for initialization
    void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        LoadWorld();

        // PlayerInteractionScript.instance.activeWorldObject.GetComponent<WorldObjectDescriptionScript>().SendRoomDescriptionToPrint();
    }

    void LoadWorld()
    {
        string path = Application.dataPath + "/Resources/World";

        string[] fileNames = Directory.GetFiles(path, "*.txt");

        for (int iter = 0; iter < fileNames.Length; iter++)
        {
            string fullName = fileNames[iter];
            fullName.Replace("\\", "/");
            CreateSceneObject(fullName);
        }
    }

    void CreateSceneObject(string sceneFile)
    {
        GameObject newSceneObject = Instantiate(sceneObjectPrefab);

        StreamReader fileLineDetermine = new StreamReader(sceneFile);

        int linesNumber = fileLineDetermine.ReadToEnd().Length;

        fileLineDetermine.Close();

        StreamReader file = new StreamReader(sceneFile);

        for(int iter = 0; iter <= linesNumber; iter++)
        {
            string line = file.ReadLine();

            if (line == null)
            {

            }
            else
            {
                ParseLine(line, newSceneObject);
            }
        }
    }

    void ParseLine(string line, GameObject sceneObject)
    {
        char seperator = '|'; //pipe delimited files

        string[] lineSections = line.Split(seperator);

        if (lineSections[0] == "scn")
        {
            string sceneName = lineSections[1];
            string sceneText = lineSections[2];

            if (sceneObject.GetComponent<SceneObjectScript>() == null)
            {
                sceneObject.AddComponent<SceneObjectScript>();
            }

            sceneObject.GetComponent<SceneObjectScript>().AssignSceneAttributes(sceneName, sceneText);
        }
        else if (lineSections[0] == "cta")
        {
            string contextActionID = lineSections[1];
            string contextActionName = lineSections[2];
            string UIpos = lineSections[3];
            string action = lineSections[4];
            string successScene = lineSections[5];
            string failScene = lineSections[6];

            bool doWork = true;

            ContextActionScript[] contextActions = sceneObject.GetComponents<ContextActionScript>();

            for(int iter = 0; contextActions.Length > iter; iter++)
            {
                if(contextActions[iter].GetContextActionID() == contextActionID) //why is this here? This is to check if we haven't loaded this context action already
                {
                    doWork = false;
                }
            }

            if (doWork == true)
            {
                sceneObject.AddComponent<ContextActionScript>();
            }

            contextActions = sceneObject.GetComponents<ContextActionScript>();

            for (int iter = 0; contextActions.Length > iter; iter++)
            {
                if (contextActions[iter].GetContextActionID() == null) 
                {
                    contextActions[iter].AssignContextActionValues(contextActionID, contextActionName, UIpos,
                        action, successScene, failScene);
                }
            }

        }
        else if(line == "START") //special behaviour to set the first scene on the start of a new game
        {
            if (sceneObject.GetComponent<SceneObjectScript>() == null)
            {
                sceneObject.AddComponent<SceneObjectScript>();
            }

            sceneObject.GetComponent<SceneObjectScript>().SetActiveScene(true);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
