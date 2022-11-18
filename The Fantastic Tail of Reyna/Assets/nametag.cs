using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class nametag : MonoBehaviour
{
    TMP_Text nameTag;

    interactable parent;

    private void Start()
    {
        nameTag = GetComponentInChildren<TMP_Text>();

        parent = GetComponentInParent<interactable>();

        nameTag.text = parent.name;
    }


    private void Update()
    {
        nameTag.enabled = parent.selected;
    }
}
