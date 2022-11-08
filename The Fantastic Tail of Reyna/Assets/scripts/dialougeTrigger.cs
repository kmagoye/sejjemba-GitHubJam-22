using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialougeTrigger : MonoBehaviour
{
    public dialougeClass dialouge;

    public void starDialouge()
    {
        FindObjectOfType<dialougeManager>().startDialouge(dialouge);
    }
}
