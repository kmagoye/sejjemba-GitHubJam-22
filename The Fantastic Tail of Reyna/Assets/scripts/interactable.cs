using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    public door door;
    public dialougeTrigger dialougeTrigger;

    public bool selected;

    private void Update()
    {
        if(FindObjectOfType<player>().selected != null && FindObjectOfType<player>().selected.transform.name == name)
        {
            selected = true;
        }
        else
        {
            selected = false;
        }
    }

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
