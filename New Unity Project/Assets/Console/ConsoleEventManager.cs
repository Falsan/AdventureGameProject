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

   // public void ParseNewCommand(string newCommand)
   // {
   //     if (newCommand.StartsWith("moveto"))
   //     {
   //         string[] commandElements = newCommand.Split(' ');
   //         DoorObject[] doors = PlayerInteractionScript.instance.activeWorldObject.GetComponents<DoorObject>();
   //
   //         if (commandElements.Length > 1)
   //         {
   //             bool goneThroughDoor = false;
   //
   //             for (int iter = 0; iter < doors.Length; iter++)
   //             {
   //                 if (doors[iter].GetDoorName() == commandElements[1])
   //                 {
   //                     if (doors[iter].GetIsLocked())
   //                     {
   //                         SendTextToBePrinted("The door is locked");
   //                     }
   //                     else
   //                     {
   //                         PlayerInteractionScript.instance.MoveTo(doors[iter].GetRoomToGoTo());
   //                     }
   //
   //                     goneThroughDoor = true;
   //                 }
   //             }
   //
   //             if (!goneThroughDoor)
   //             {
   //                 if (PlayerInteractionScript.instance.activeWorldObject.GetComponent<WorldObjectDirectionsScript>().CheckIfDirectionExists(commandElements[1]))
   //                 {
   //                     PlayerInteractionScript.instance.activeWorldObject.GetComponent<WorldObjectDirectionsScript>().MoveToNewRoom(commandElements[1]);
   //                 }
   //                 else
   //                 {
   //                     SendTextToBePrinted("You cannot move to this");
   //                 }
   //             }
   //         }
   //         else
   //         {
   //             SendTextToBePrinted("Move to what?");
   //         }
   //     }
   //     else if (newCommand.StartsWith("talkto"))
   //     {
   //         string[] commandElements = newCommand.Split(' ');
   //
   //         if (commandElements.Length > 2)
   //         {
   //             if (PlayerInteractionScript.instance.activeWorldObject.GetComponent<NPCObjectScript>().NPCName == commandElements[1])
   //             {
   //                 PlayerInteractionScript.instance.activeWorldObject.GetComponent<NPCObjectScript>().PrintResponseToTopic(commandElements[2]);
   //             }
   //             else
   //             {
   //                 SendTextToBePrinted("Who do you mean?");
   //             }
   //         }
   //         else if (commandElements.Length > 1)
   //         {
   //             SendTextToBePrinted("Talk to " + commandElements[1] + " about what?");
   //         }
   //         else
   //         {
   //             SendTextToBePrinted("Talk to what?");
   //         }
   //     }
   //     else if (newCommand.StartsWith("take"))
   //     {
   //         string[] commandElements = newCommand.Split(' ');
   //
   //         if (commandElements.Length > 1)
   //         {
   //             if (PlayerInteractionScript.instance.activeWorldObject.GetComponent<WorldObjectItemsScript>().FindItem(commandElements[1]))
   //             {
   //                 PlayerInteractionScript.instance.AddToItems(commandElements[1]);
   //                 PlayerInteractionScript.instance.activeWorldObject.GetComponent<WorldObjectItemsScript>().RemoveItem(commandElements[1]);
   //
   //                 SendTextToBePrinted(commandElements[1] + " has been picked up");
   //             }
   //             else
   //             {
   //                 SendTextToBePrinted("You cannot take this.");
   //             }
   //         }
   //         else
   //         {
   //             SendTextToBePrinted("Talk to what?");
   //         }
   //     }
   //     else if (newCommand.StartsWith("search"))
   //     {
   //         ConsoleOutputManagerScript.instance.PrintNewText("You search the room and...");
   //
   //         if (!PlayerInteractionScript.instance.activeWorldObject.GetComponent<WorldObjectItemsScript>())
   //         {
   //             ConsoleOutputManagerScript.instance.PrintNewText("Find nothing of interest...");
   //         }
   //         else
   //         {
   //             PlayerInteractionScript.instance.activeWorldObject.GetComponent<WorldObjectItemsScript>().RevealHiddenItems();
   //         }
   //     }
   //     else if (newCommand.StartsWith("listinventory"))
   //     {
   //         PlayerInteractionScript.instance.ListInventory();
   //     }
   //     else if (newCommand.StartsWith("listtopics"))
   //     {
   //         string[] commandElements = newCommand.Split(' ');
   //
   //         if (commandElements.Length > 1)
   //         {
   //             if (PlayerInteractionScript.instance.activeWorldObject.GetComponent<NPCObjectScript>().NPCName == commandElements[1])
   //             {
   //                 PlayerInteractionScript.instance.activeWorldObject.GetComponent<NPCObjectScript>().ListTopicsKnown();
   //             }
   //             else
   //             {
   //                 SendTextToBePrinted("Who do you mean?");
   //             }
   //         }
   //         else
   //         {
   //             SendTextToBePrinted("Talk to what?");
   //         }
   //     }
   //     else if (newCommand.StartsWith("look"))
   //     {
   //         string[] commandElements = newCommand.Split(' ');
   //
   //         if (commandElements.Length > 1)
   //         {
   //             if (commandElements[1] == "room" || commandElements[1] == PlayerInteractionScript.instance.activeWorldObject.GetComponent<WorldObjectDescriptionScript>().GetName())
   //             {
   //                 PlayerInteractionScript.instance.activeWorldObject.GetComponent<WorldObjectDescriptionScript>().SendRoomDescriptionToPrint();
   //             }
   //             else
   //             {
   //                 NPCObjectScript[] npcsPool = PlayerInteractionScript.instance.activeWorldObject.GetComponents<NPCObjectScript>();
   //
   //                 for (int iter = 0; iter < npcsPool.Length; iter++)
   //                 {
   //                     if (commandElements[1] == npcsPool[iter].NPCName)
   //                     {
   //                         SendTextToBePrinted(npcsPool[iter].NPCDescription);
   //                     }
   //                 }
   //             }
   //         }
   //         else
   //         {
   //             SendTextToBePrinted("Look at what?");
   //         }
   //     }
   //     else if (newCommand.StartsWith("use"))
   //     {
   //         string[] commandElements = newCommand.Split(' ');
   //         if (commandElements.Length > 1)
   //         {
   //             UseActionObject[] useActions = PlayerInteractionScript.instance.activeWorldObject.GetComponents<UseActionObject>();
   //
   //             for (int iter = 0; iter < useActions.Length; iter++)
   //             {
   //                 if (commandElements[1] == useActions[iter].GetActionName())
   //                 {
   //                     if (!PlayerInteractionScript.instance.CheckIfItemIsInInventory(useActions[iter].GetItemUsedWithName()))
   //                     {
   //                         SendTextToBePrinted("You don't have that item in your inventory");
   //                     }
   //                     else if (commandElements[2] == useActions[iter].GetItemUsedWithName())
   //                     {
   //                         SendTextToBePrinted(useActions[iter].GetDescriptionText());
   //                         useActions[iter].PerformContextAction();
   //                     }
   //                     else if (commandElements[2] == "with") //A catch in case people start saying "with"
   //                     {
   //                         if (!PlayerInteractionScript.instance.CheckIfItemIsInInventory(useActions[iter].GetItemUsedWithName()))
   //                         {
   //                             SendTextToBePrinted("You don't have that item in your inventory");
   //                         }
   //                         else if (commandElements[3] == useActions[iter].GetItemUsedWithName())
   //                         {
   //                             SendTextToBePrinted(useActions[iter].GetDescriptionText());
   //                             useActions[iter].PerformContextAction();
   //                         }
   //                         else
   //                         {
   //                             SendTextToBePrinted("Nothing happens.");
   //                         }
   //                     }
   //                     else
   //                     {
   //                         SendTextToBePrinted("Nothing happens.");
   //                     }
   //                 }
   //             }
   //         }
   //         else
   //         {
   //             SendTextToBePrinted("Use what with what?");
   //         }
   //     }
   //     else if (newCommand.StartsWith("help"))
   //     {
   //         string[] commandElements = newCommand.Split(' ');
   //
   //         if (commandElements.Length > 1)
   //         {
   //             if(commandElements[1] == "look")
   //             {
   //                 SendTextToBePrinted("You can use the look command to get a general description of an object or an NPC.");
   //                 SendTextToBePrinted("You can also use the word 'room' to get a description of your current room");
   //                 SendTextToBePrinted("Example use: look room, look ExampleItem");
   //             }
   //             else if (commandElements[1] == "listinventory")
   //             {
   //                 SendTextToBePrinted("This is a simple one word command which will list all the objects in your inventory");
   //                 SendTextToBePrinted("Example use: listinventory");
   //             }
   //             else if (commandElements[1] == "search")
   //             {
   //                 SendTextToBePrinted("You can use this to search a room for hidden items");
   //                 SendTextToBePrinted("Example use: search");
   //             }
   //             else if (commandElements[1] == "talkto")
   //             {
   //                 SendTextToBePrinted("You can use this to talk to NPCs about specific topics");
   //                 SendTextToBePrinted("Example use: talkto Carl Weather");
   //             }
   //             else if (commandElements[1] == "listtopics")
   //             {
   //                 SendTextToBePrinted("You can use this to list all the topics you can talk to an NPC about");
   //                 SendTextToBePrinted("Example use: listtopics Carl");
   //             }
   //             else if (commandElements[1] == "take")
   //             {
   //                 SendTextToBePrinted("You can use this to pick up an item");
   //                 SendTextToBePrinted("Example use: listtopics Carl");
   //             }
   //             else if (commandElements[1] == "moveto")
   //             {
   //                 SendTextToBePrinted("You can use this to move to another room, through a door or in a direction");
   //                 SendTextToBePrinted("Example use: moveto North");
   //             }
   //             else if (commandElements[1] == "use")
   //             {
   //                 SendTextToBePrinted("You can use this to use an item with another static piece of scenery or another item in your inventory");
   //                 SendTextToBePrinted("Example use: use key with RedDoor");
   //             }
   //         }
   //         else
   //         {
   //             SendTextToBePrinted("All commands should be in lowercase. Commands are as follows:");
   //             SendTextToBePrinted("use, look, listinventory, listtopics, search, talkto, moveto, take.");
   //             SendTextToBePrinted("If you want specific guidance on the use of a command then please type 'help' followed by the command");
   //         }
   //     }
   //     else
   //     {
   //         SendTextToBePrinted("I'm sorry, this command was not recognised");
   //     }
   // }
    void SendTextToBePrinted(string text)
    {
        ConsoleOutputManagerScript.instance.PrintNewText(text);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
