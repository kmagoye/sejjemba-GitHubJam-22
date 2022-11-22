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
    }
}
