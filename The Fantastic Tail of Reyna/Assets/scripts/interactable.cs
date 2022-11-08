using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    public door door;
    public dialougeTrigger dialougeTrigger;

    public void Interact()
    {
        if (door != null)
        {
            door.TP();
        }
        else if (dialougeTrigger != null)
        {
            dialougeTrigger.starDialouge();
        }
    }
}
