using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressionmanager : MonoBehaviour
{
    public dialougeTrigger skatersOne;
    public dialougeTrigger fence;

    public GameObject skatersIntended;
    public GameObject skatersAlternate;

    int x = 1;

    bool intended = true;

    private void Start()
    {
        //GetComponent<dialougeTrigger>().startDialouge();
    }

    private void Update()
    {
        while (x == 1)
        {
            if (fence.dialouges.Count < 1)
            {
                print("a");
                if (skatersOne.dialouges.Count > 0)
                {
                    intended = false;
                }
                if (skatersOne.dialouges.Count == 0)
                {
                    intended = true;
                }

                if (intended)
                {
                    skatersIntended.GetComponent<Rigidbody2D>().position = skatersOne.transform.position;
                }
                else
                {
                    skatersAlternate.GetComponent<Rigidbody2D>().position = skatersOne.transform.position;
                }

                skatersOne.transform.Translate(new Vector2(1000, 1000));

                x--;
            }
        }
    }
}
