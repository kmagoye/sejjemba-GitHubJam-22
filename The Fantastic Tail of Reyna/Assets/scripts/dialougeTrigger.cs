using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialougeTrigger : MonoBehaviour
{
    public List<dialougeClass> Dialouges;
    Queue<dialougeClass> dialouges;

    private void Start()
    {
        dialouges = new Queue<dialougeClass>();

        foreach (dialougeClass dialouge in Dialouges)
        {
            dialouges.Enqueue(dialouge);
        }

        dialouges.Dequeue(); // the first thing in the menus always freaks out so skip it and start in the second spot
    }

    public void starDialouge()
    {
        if (dialouges.Count > 0)
        {
            FindObjectOfType<dialougeManager>().startDialouge(dialouges.Dequeue());
        }
    }
}
