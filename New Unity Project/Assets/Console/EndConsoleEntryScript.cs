using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//What is my purpose?
//You're just a call for the input field. You pass the commands to the event manager
//Oh my god...

public class EndConsoleEntryScript : MonoBehaviour {

    InputField console;
    string latestCommand;

	// Use this for initialization
	void Start () {
        console = gameObject.GetComponent<InputField>();
        console.Select();
        console.ActivateInputField();
    }

    void Action()
    {
        latestCommand = console.text;

        if (Input.GetKey(KeyCode.Return))
        {

            ConsoleEventManager.instance.ParseNewCommand(latestCommand);

            console.Select();
            console.ActivateInputField();
            console.text = "";
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
