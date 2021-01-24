using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusScript : MonoBehaviour
{

    public static PlayerStatusScript instance;
    private Dictionary<string, int> playerVariables;
    
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

        playerVariables = new Dictionary<string, int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayerStatus(string variableToUpdate, string operation, string valueToUpdate)
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

        if (playerVariables.TryGetValue(variableToUpdate, out int value)) //this checks to see if our key actually exists
        {
            PerformOperation(variableToUpdate, operation, valueToUpdateInt);
        }
        else //if we don't just create it as a 0 for now
        {
            playerVariables[variableToUpdate] = 0;
            PerformOperation(variableToUpdate, operation, valueToUpdateInt);
        }
    }

    private void PerformOperation(string variableToUpdate, string operation, int valueToUpdate)
    {
        if(operation == "=")
        {
            playerVariables[variableToUpdate] = valueToUpdate;
        }
        else if(operation == "+")
        {
            playerVariables[variableToUpdate] += valueToUpdate;
        }
        else if (operation == "-")
        {
            playerVariables[variableToUpdate] -= valueToUpdate;
        }
    }

    public bool CheckPlayerStatus(string variableToCompare, string operation, string valueToCompare)
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

        if (playerVariables.TryGetValue(variableToCompare, out int value)) //this checks to see if our key actually exists
        {
            result = PerformCheck(variableToCompare, operation, valueToCompareInt);
        }
        else //if we don't just create it as a 0 for now
        {
            playerVariables[variableToCompare] = 0;
            result = PerformCheck(variableToCompare, operation, valueToCompareInt);
        }

        return result;
    }

    private bool PerformCheck(string variableToCompare, string operation, int valueToCompare)
    {
        bool result = false;

        if (operation == "=")
        {
            if(playerVariables[variableToCompare] == valueToCompare)
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
            if (playerVariables[variableToCompare] > valueToCompare)
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
            if (playerVariables[variableToCompare] < valueToCompare)
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
