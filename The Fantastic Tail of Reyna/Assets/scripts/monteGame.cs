using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class monteGame : MonoBehaviour
{
    public CinemachineVirtualCamera monteCamera;
    public CinemachineVirtualCamera returnCamera;

    public dialougeTrigger dialougeTrigger;

    monteCat[] cats;

    public GameObject slot;

    monteSlot[] slots;

    public int speed;

    public int shuffleDelay;

    public int shuffleAmount;

    public bool clickTime = false;

    private void Update()
    {
        if (clickTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                bool won = false;

                RaycastHit2D hit = Physics2D.Raycast(FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition), transform.position, 0.01f);

                if (hit != null)
                {
                    if (hit.transform.CompareTag("cat"))
                    {
                        if (hit.transform.GetComponent<monteCat>().hasKey)
                        {
                            won = true;
                        }
                    }

                    returnKey(won);

                    clickTime = false;
                }
            }
        }
    }

    public void gameStart()
    {
        FindObjectOfType<player>().inGame = true;

        FindObjectOfType<camera_manager>().SetCamera(monteCamera);

        dialougeTrigger = GetComponent<dialougeTrigger>();
        dialougeTrigger.startDialouge();

        cats = FindObjectsOfType<monteCat>();

        foreach(monteCat cat in cats)
        {
            Instantiate(slot, transform);
        }

        slots = FindObjectsOfType<monteSlot>();

        int x = 0;

        foreach(monteSlot slot in slots)
        {
            slot.name = x.ToString();

            slot.rb2d.position = cats[x].transform.position;

            slot.setLocation();

            x++;
        }
    }

    public void gameEnd()
    {
        FindObjectOfType<player>().inGame = false;

        FindObjectOfType<camera_manager>().SetCamera(returnCamera);
    }

    public void giveKey()
    {
        FindObjectOfType<monteKey>().Move(cats[Random.Range(0, 7)], speed, shuffleDelay);

        //FindObjectOfType<monteKey>().rb2d.position = cats[Random.Range(0, 7)].transform.position;
    }

    private void returnKey(bool Won)
    {
        StartCoroutine(FindObjectOfType<monteKey>().move(transform.position, speed, shuffleDelay, false, Won));

        FindObjectOfType<monteKey>().held = false;
    }

    public void shuffle(int times)
    {
        List<List<monteSlot>> slotArray = new List<List<monteSlot>>();

        for(int i = 0; i < times; i++)
        {
            List<int> x = new List<int>();
            x = randomList();

            List<monteSlot> y = new List<monteSlot>();

            for (int q = 0; q < 8; q++)
            {
                y.Add(slots[x[q]]);
            }

            slotArray.Add(y);
        }

        for (int i = 0; i < 8; i++)
        {
            List<monteSlot> z = new List<monteSlot>();

            for(int q = 0; q < slotArray.Count; q++)
            {
                z.Add(slotArray[q][i]);
            }

            cats[i].receivePath(z,speed,shuffleDelay);
        }
    }

    List<int> randomList()
    {
        List<int> x = new List<int>();
        List<int> y = new List<int>();

        for (int i = 0; i < 8; i++)
        {
            x.Add(i);
        }

        for (int i = 0; i < 8; i++)
        {
            int z = Random.Range(0, x.Count);

            y.Add(x[z]);
            x.RemoveAt(z);
        }

        return y;
    }
}

