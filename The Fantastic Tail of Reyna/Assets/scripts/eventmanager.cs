using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventmanager : MonoBehaviour
{
    public void triggerEvent(string eventName)
    {
        if(eventName == "coffee")
        {
            FindObjectOfType<player>().caffinated = true;
        }

        if (eventName == "lair key obtained")
        {
            FindObjectOfType<progressionmanager>().lairDoorKeyObtained = true;

            FindObjectOfType<monteGame>().gameEnd();
        }

        if(eventName == "returned to woods")
        {
            FindObjectOfType<progressionmanager>().returnToWoods();
        }

        if(eventName == "herding cats")
        {

        }

        if(eventName == "end of game")
        {

        }

        if(eventName == "breakfast")
        {
            FindObjectOfType<pancakeGame>().gameStart();
        }

        if(eventName == "breakfast start")
        { 
            FindObjectOfType<pancakeGame>().spawnPancake();

            FindObjectOfType<player>().enabled = false;
        }

        if(eventName == "breakfast end")
        {
            FindObjectOfType<pancakeGame>().gameEnd();

            FindObjectOfType<progressionmanager>().castledoor.enabled = true;
        }

        if(eventName == "cat battle")
        {
            FindObjectOfType<monteGame>().gameStart();
        }


        if(eventName == "monte start")
        {
            FindObjectOfType<monteGame>().giveKey();
        }
    }
}
