using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ContextActionButton : MonoBehaviour
{
    public int contextActionNumber; //this is how the contextactionscript tells which button to assign itself to
    private ContextActionScript contextAction;
    Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        contextActionNumber = int.Parse(Regex.Match(gameObject.name, @"\d$").ToString()); //What does this crazy line do? It grabs the digit at the end of the game object name
        textBox = gameObject.GetComponentInChildren<Text>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange()
    {
        contextAction.TriggerContextAction();
    }

    public void BindContextActionToButton(ContextActionScript action, string actionName)
    {
        contextAction = action;
        textBox.text = actionName;
        gameObject.SetActive(true);
    }

}
