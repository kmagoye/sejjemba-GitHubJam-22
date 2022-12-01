using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rapBattlePlayer : MonoBehaviour
{
    wordBankElement word = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition), transform.position, 0.01f);

            if (word != null)
            {
                if (hit.transform.CompareTag("slot"))
                {
                    StartCoroutine(word.move(hit.transform.position));

                    hit.transform.GetComponent<wordBankSlot>().Word = word;

                    word = null;
                }
            }
            else
            {
                if (hit.transform.CompareTag("word"))
                {
                    word = hit.transform.GetComponent<wordBankElement>();
                }
            }
        }
    }
}
