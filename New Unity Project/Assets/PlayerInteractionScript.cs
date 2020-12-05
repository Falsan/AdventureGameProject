using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the actual logic for player actions

public class PlayerInteractionScript : MonoBehaviour {

    public static PlayerInteractionScript instance;
    public GameObject activeWorldObject;
    private List<string> items = new List<string>();

    GameObject[] worldObjects;

    // Use this for initialization
    public void Setup () {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        worldObjects = GameObject.FindGameObjectsWithTag("WorldObject");

    }

    public void ListInventory()
    {
        ConsoleOutputManagerScript.instance.PrintNewText("Your Inventory Contains:");

        for (int iter = 0; iter < items.Count; iter++)
        {
            ConsoleOutputManagerScript.instance.PrintNewText(items[iter]);
        }
    }

    public void AddToItems(string name)
    {
        items.Add(name);
    }

    public bool CheckIfItemIsInInventory(string name)
    {

        if (items.Contains(name))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void MoveTo(string name)
    {
        worldObjects = GameObject.FindGameObjectsWithTag("WorldObject");

        for (int iter = 0;  iter < worldObjects.Length; iter++)
        {
            if(worldObjects[iter].GetComponent<WorldObjectDescriptionScript>().GetName() == name)
            {
                activeWorldObject = worldObjects[iter];
                activeWorldObject.GetComponent<WorldObjectDescriptionScript>().SendRoomDescriptionToPrint();
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
