using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rapBattleSet : MonoBehaviour
{
    wordBankSlot[] slots;
    wordBankElement[] words;

    private void Start()
    {
        slots = GetComponentsInChildren<wordBankSlot>();
        words = GetComponentsInChildren<wordBankElement>();
    }

    public void move(Vector2 movement)
    {
        transform.Translate(movement);

        foreach(wordBankElement word in words)
        {
            word.origin = word.transform.position;
        }
    }

    private void Update()
    {
        int z = 0;

        foreach(wordBankElement word in words)
        {
            if (word.moving)
            {
                z++;
            }
        }

        if (z == 0)
        {
            int x = 0;
            int y = 0;

            foreach (wordBankSlot slot in slots)
            {
                if (slot.Word != null)
                {
                    x++;

                    if (slot.Word.correct)
                    {
                        y++;
                    }
                }
            }

            if (x == slots.Length)
            {
                if (y == slots.Length)
                {
                    foreach (wordBankSlot slot in slots)
                    {
                        slot.Word = null;
                    }

                    move(new Vector2(0,-10));

                    FindObjectOfType<rapBattleGame>().respond();
                }
                else
                {
                    foreach (wordBankSlot slot in slots)
                    {
                        StartCoroutine(slot.Word.move(slot.Word.origin));

                        slot.Word = null;
                    }
                }
            }
        }
    }
}
