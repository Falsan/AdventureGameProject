using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectItemsScript : MonoBehaviour {

    List<ItemObject> items = new List<ItemObject>();

    // Use this for initialization
    void Start () {
		
	}

    public void LoadItemData(string name, string hiddenStatus)
    {
        ItemObject newItem = new ItemObject();

        newItem.AssignName(name);
        newItem.SetIsHidden(hiddenStatus);

        items.Add(newItem);
    }

    public void RevealHiddenItems()
    {

        bool foundSomething = false;

        for (int iter = 0; iter < items.Count; iter++)
        {
            if (items[iter].GetIsHidden() == true)
            {
                foundSomething = true;

                items[iter].SetIsHidden("false");

                ConsoleOutputManagerScript.instance.PrintNewText("Find "+items[iter].GetName());
            }
        }

        if (foundSomething == false)
        {
            ConsoleOutputManagerScript.instance.PrintNewText("Find nothing of interest...");
        }

    }

    public bool FindItem(string itemName)
    {
        for(int iter = 0; iter < items.Count; iter++)
        {
            if(items[iter].GetName() == itemName && items[iter].GetIsHidden() == false)
            {
                return true;
            }
        }

        return false;
    }

    public void RemoveItem(string itemName)
    {
        for (int iter = 0; iter < items.Count; iter++)
        {
            if (items[iter].GetName() == itemName)
            {
                items.RemoveAt(iter);
                return;
            }
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
