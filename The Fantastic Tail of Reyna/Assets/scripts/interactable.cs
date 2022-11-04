using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    public door door;

    public void Interact()
    {
        if (door != null)
        {
            door.TP();
        }
    }
}
