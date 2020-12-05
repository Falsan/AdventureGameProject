using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleOutputManagerScript : MonoBehaviour {

    public static ConsoleOutputManagerScript instance;
    public GameObject textPrefab;
    GameObject canvas;

    List<GameObject> consoleOutputs;

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

        consoleOutputs = new List<GameObject>();

        canvas = GameObject.FindGameObjectWithTag("UserUiCanvas");
    }
	
	public void PrintNewText(string text)
    {
        //First we figure out how far we need to shunt everything up

        float dynamicHeight = 30.0f;
        //Debug.Log(text.Length);
        if (text.Length > 100)
        {
            float numberOfIterations = text.Length / 100;
            dynamicHeight = dynamicHeight * numberOfIterations;
        }

        Vector3 shuntUp = new Vector3(0.0f, dynamicHeight); //then we shunt everything up

        for(int iter = 0; iter < consoleOutputs.Count; iter++)
        {
            consoleOutputs[iter].transform.Translate(shuntUp);
        }

        //then we add the new text and put it where we want it to be
        GameObject newText = Instantiate(textPrefab);

        

        newText.GetComponent<Text>().text = text;

        newText.GetComponent<Text>().color = Color.white;

        newText.gameObject.transform.parent = canvas.transform;

        Vector3 startPos = new Vector3(-47.0f, -150.0f, 0);

        newText.GetComponent<RectTransform>().anchoredPosition = startPos; //now the text is at the start position but it's still on the first line we need to shunt it up with everything else...
        newText.GetComponent<RectTransform>().sizeDelta = new Vector2(800, dynamicHeight);
        newText.transform.Translate(shuntUp);

        //then move down to the next line!
        Vector3 fudge = new Vector3(0.0f, -30.0f);
        newText.transform.Translate(fudge);

        consoleOutputs.Add(newText);

        if(consoleOutputs.Count > 12)
        {
            Destroy(consoleOutputs[0]);
            consoleOutputs.RemoveAt(0);
        }
    }
}
