using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventmanager : MonoBehaviour
{
    public void triggerEvent(string eventName)
    {
        if (eventName == "coffee")
        {
            FindObjectOfType<player>().caffinated = true;

            FindObjectOfType<progressionmanager>().coffee.sprite = FindObjectOfType<progressionmanager>().drunkCoffee;
        }

        if (eventName == "lair key obtained")
        {
            FindObjectOfType<progressionmanager>().lairDoorKeyObtained = true;

            FindObjectOfType<monteGame>().gameEnd();
        }

        if (eventName == "rap battle")
        {
            FindObjectOfType<rapBattleGame>().gameStart();
        }

        if (eventName == "rap battle start")
        {
            FindObjectOfType<rapBattleGame>().roundStart();
        }

        if (eventName == "battle rap end")
        {
            FindObjectOfType<rapBattleGame>().gameEnd();
            FindObjectOfType<progressionmanager>().wonRapBattle = true;
        }

        if (eventName == "breakfast")
        {
            FindObjectOfType<pancakeGame>().gameStart();
        }

        if (eventName == "breakfast start")
        {
            FindObjectOfType<pancakeGame>().spawnPancake();

            FindObjectOfType<player>().enabled = false;
        }

        if (eventName == "breakfast end")
        {
            FindObjectOfType<pancakeGame>().gameEnd();

            FindObjectOfType<progressionmanager>().castledoor.enabled = true;
        }

        if (eventName == "cat battle")
        {
            FindObjectOfType<monteGame>().gameStart();
        }

        if (eventName == "monte start")
        {
            FindObjectOfType<monteGame>().giveKey();
        }

        if (eventName == "game end")
        {
            FindObjectOfType<camera_manager>().SetCamera(FindObjectOfType<progressionmanager>().end);
        }

        if (eventName == "game start")
        {
            FindObjectOfType<camera_manager>().SetCamera(FindObjectOfType<progressionmanager>().bedroom);
            FindObjectOfType<progressionmanager>().GetComponent<dialougeTrigger>().startDialouge();
        }
    }
}
