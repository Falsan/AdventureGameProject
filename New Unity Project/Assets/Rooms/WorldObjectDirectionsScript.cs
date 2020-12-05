using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectDirectionsScript : MonoBehaviour {

    Dictionary<string, string> directionsHash;

	// Use this for initialization
	void Awake () {
        directionsHash = new Dictionary<string, string>();
	}

    public void AssignNewDirection(string commandCalled, string worldObjectToLoad)
    {
        directionsHash.Add(commandCalled, worldObjectToLoad);
    }

    public bool CheckIfDirectionExists(string commandCalled)
    {
        return directionsHash.ContainsKey(commandCalled);
    }

    public void MoveToNewRoom(string command)
    {
        //move to this room
        PlayerInteractionScript.instance.MoveTo(directionsHash[command]);
    }
	
}
