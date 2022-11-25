using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class monteGame : MonoBehaviour
{
    player player;
    public CinemachineVirtualCamera monteCamera;
    public CinemachineVirtualCamera returnCamera;

    dialougeTrigger dialougeTrigger;

    monteCat[] cats;

    public GameObject slot;

    monteSlot[] slots;

    private void Start()
    {
        
    }

    public void gameStart()
    {
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

        shuffle(1);
    }

    public void giveKey()
    {
        FindObjectOfType<monteKey>().rb2d.position = cats[Random.Range(0, 7)].transform.position;
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

            cats[i].receivePath(z);
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

