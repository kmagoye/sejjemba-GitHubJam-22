using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialougeManager : MonoBehaviour
{
    Queue<string> scentences;

    player player;

    void Start()
    {
        player = FindObjectOfType<player>();

        scentences = new Queue<string>();
    }

    public void startDialouge(dialougeClass dialouge)
    {
        scentences.Clear();

        foreach(string scentence in dialouge.scentences)
        {
            scentences.Enqueue(scentence);
        }

        displayNextScentence();

        StartCoroutine(waitForKeyLift());
    }

    public void displayNextScentence()
    {
        if (scentences.Count == 0)
        {
            endDialouge();
            return;
        }

        Type(scentences.Dequeue());
    }

    public void endDialouge()
    {
        player.inConvo = false;
    }

    void Type(string words)
    {
        print(words);
    }

    IEnumerator waitForKeyLift()
    {
        while (Input.GetKeyDown("x"))
        {
            yield return new WaitForEndOfFrame();
        }

        player.inConvo = true;
    }
}
