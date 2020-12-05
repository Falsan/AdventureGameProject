using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WorldGenerationScript : MonoBehaviour {

    public static WorldGenerationScript instance;
    public GameObject worldObjectPrefab;

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

       PlayerInteractionScript.instance.activeWorldObject.GetComponent<WorldObjectDescriptionScript>().SendRoomDescriptionToPrint();
    }

    void LoadWorld()
    {
        string path = Application.dataPath + "/Resources/World";

        string[] fileNames = Directory.GetFiles(path, "*.txt");

        for (int iter = 0; iter < fileNames.Length; iter++)
        {
            string fullName = fileNames[iter];
            fullName.Replace("\\", "/");
            CreateRoomObject(fullName);
        }
    }

    void CreateRoomObject(string roomFile)
    {
        GameObject newWorldObject = Instantiate(worldObjectPrefab);

        StreamReader fileLineDetermine = new StreamReader(roomFile);

        int linesNumber = fileLineDetermine.ReadToEnd().Length;

        fileLineDetermine.Close();

        StreamReader file = new StreamReader(roomFile);

        for(int iter = 0; iter <= linesNumber; iter++)
        {
            string line = file.ReadLine();

            if (line == null)
            {

            }
            else
            {
                ParseLine(line, newWorldObject);
            }
        }
    }

    void ParseLine(string line, GameObject worldObject)
    {
        char seperator = '\t';
        string[] lineSections = line.Split(seperator);

        if(lineSections[0] == "dir")
        {
            string directionCommand = lineSections[1];
            string goingTo = lineSections[2];

            if(worldObject.GetComponent<WorldObjectDirectionsScript>() == null)
            {
                worldObject.AddComponent<WorldObjectDirectionsScript>();
            }

            worldObject.GetComponent<WorldObjectDirectionsScript>().AssignNewDirection(directionCommand, goingTo);
        }
        else if (lineSections[0] == "des")
        {
            string description = lineSections[1];

            if (worldObject.GetComponent<WorldObjectDescriptionScript>() == null)
            {
                worldObject.AddComponent<WorldObjectDescriptionScript>();
            }

            worldObject.GetComponent<WorldObjectDescriptionScript>().AssignNewDescription(description);
        }
        else if (lineSections[0] == "has")
        {
            string item = lineSections[1];
            string hiddenStatus = lineSections[2];

            if (worldObject.GetComponent<WorldObjectItemsScript>() == null)
            {
                worldObject.AddComponent<WorldObjectItemsScript>();
            }

            worldObject.GetComponent<WorldObjectItemsScript>().LoadItemData(item, hiddenStatus);
        }
        else if (lineSections[0] == "nam")
        {
            string name = lineSections[1];

            if (worldObject.GetComponent<WorldObjectDescriptionScript>() == null)
            {
                worldObject.AddComponent<WorldObjectDescriptionScript>();
            }

            worldObject.GetComponent<WorldObjectDescriptionScript>().AssignName(name);
            worldObject.name = name;
        }
        else if (lineSections[0] == "npc")
        {
            string name = lineSections[1];

            //DO WE NEED THIS? CAN WE HAVE MULTIPLE NPCS IN A ROOM???
            if (worldObject.GetComponent<NPCObjectScript>() == null)
            {
                worldObject.AddComponent<NPCObjectScript>();
            }

            worldObject.GetComponent<NPCObjectScript>().AssignName(name);
        }
        else if (lineSections[0] == "use")
        {
            string name = lineSections[1];
            string itemToBeUsedWith = lineSections[2];
            string useText = lineSections[3];
            string contextAction = lineSections[4];

            UseActionObject thisObject = worldObject.AddComponent<UseActionObject>();

            thisObject.AssignUseActionName(name);
            thisObject.AssignItemToBeUsedWith(itemToBeUsedWith);
            thisObject.AssignUseDescriptionText(useText);
            thisObject.AssignContextAction(contextAction);

            if(thisObject.GetContextAction() == "item")
            {
                string itemResult = lineSections[5];
                thisObject.AssignResultItem(itemResult);
            }
        }
        else if (lineSections[0] == "dor")
        {
            string name = lineSections[1];
            string lockedOrNot = lineSections[2];
            string room = lineSections[3];

            DoorObject thisObject = worldObject.AddComponent<DoorObject>();

            thisObject.AssignDoorObjectName(name);
            thisObject.AssignLockedOrNot(lockedOrNot);
            thisObject.AssignRoomToGoTo(room);
        }
        else if (lineSections[0] == "START")
        {
            GameObject.Find("GameManager").AddComponent<PlayerInteractionScript>();
            GameObject.Find("GameManager").GetComponent<PlayerInteractionScript>().Setup();
            PlayerInteractionScript.instance.activeWorldObject = worldObject;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
