using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Now I know what you're thinking, this looks mighty similar to the Player status script, that's because it is!
//World Status is seperated semantically so that the system makes a bit more sense from a user/writer perspective

public class WorldStatusScript : MonoBehaviour
{
    public static WorldStatusScript instance;
    private Dictionary<string, int> WorldVariables;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        WorldVariables = new Dictionary<string, int>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateWorldStatus(string variableToUpdate, string operation, string valueToUpdate)
    {

        //Convert our values to an int
        int valueToUpdateInt = 0;
        try
        {
            valueToUpdateInt = Int32.Parse(valueToUpdate);
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{valueToUpdate}'");
        }

        if (WorldVariables.TryGetValue(variableToUpdate, out int value)) //this checks to see if our key actually exists
        {
            PerformOperation(variableToUpdate, operation, valueToUpdateInt);
        }
        else //if we don't just create it as a 0 for now
        {
            WorldVariables[variableToUpdate] = 0;
            PerformOperation(variableToUpdate, operation, valueToUpdateInt);
        }
    }

    private void PerformOperation(string variableToUpdate, string operation, int valueToUpdate)
    {
        if (operation == "=")
        {
            WorldVariables[variableToUpdate] = valueToUpdate;
        }
        else if (operation == "+")
        {
            WorldVariables[variableToUpdate] += valueToUpdate;
        }
        else if (operation == "-")
        {
            WorldVariables[variableToUpdate] -= valueToUpdate;
        }
    }

    public bool CheckWorldStatus(string variableToCompare, string operation, string valueToCompare)
    {
        //Convert our values to an int
        int valueToCompareInt = 0;
        bool result = false;
        try
        {
            valueToCompareInt = Int32.Parse(valueToCompare);
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{valueToCompare}'");
        }

        if (WorldVariables.TryGetValue(variableToCompare, out int value)) //this checks to see if our key actually exists
        {
            result = PerformCheck(variableToCompare, operation, valueToCompareInt);
        }
        else //if we don't just create it as a 0 for now
        {
            WorldVariables[variableToCompare] = 0;
            result = PerformCheck(variableToCompare, operation, valueToCompareInt);
        }

        return result;
    }

    private bool PerformCheck(string variableToCompare, string operation, int valueToCompare)
    {
        bool result = false;

        if (operation == "=")
        {
            if (WorldVariables[variableToCompare] == valueToCompare)
            {
                result = true;
            }
            else
            {
                result = false;
            }
        }
        else if (operation == ">")
        {
            if (WorldVariables[variableToCompare] > valueToCompare)
            {
                result = true;
            }
            else
            {
                result = false;
            }
        }
        else if (operation == "<")
        {
            if (WorldVariables[variableToCompare] < valueToCompare)
            {
                result = true;
            }
            else
            {
                result = false;
            }
        }

        return result;
    }
}
