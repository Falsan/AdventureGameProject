using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonScript : MonoBehaviour {

    void Action()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
