using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressionmanager : MonoBehaviour
{
    private void Start()
    {
        GetComponent<dialougeTrigger>().startDialouge();
    }
}
