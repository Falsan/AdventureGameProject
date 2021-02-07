using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handles what happens with commands put into the console

public class ConsoleEventManager : MonoBehaviour {

    public static ConsoleEventManager instance;

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
    }

    public void SendTextToBePrinted(string text)
    {
        //Take the raw scene text 

        //Process to tweak any variables where needed

        ConsoleOutputManagerScript.instance.PrintNewText(text);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
