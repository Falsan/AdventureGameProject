using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectDescriptionScript : MonoBehaviour {

    string description;
    string worldObjectName;

	// Use this for initialization
	void Start () {
		
	}

    public void AssignNewDescription(string newDescription)
    {
        description = newDescription;
    }

    public void AssignName(string newName)
    {
        worldObjectName = newName;
    }

    public string GetName()
    {
        return worldObjectName;
    }

    public void SendRoomDescriptionToPrint()
    {
        ConsoleOutputManagerScript.instance.PrintNewText(description);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
