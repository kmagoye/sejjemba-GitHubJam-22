using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressionmanager : MonoBehaviour
{
    public BoxCollider2D castledoor;

    public dialougeTrigger skatersOne;
    public dialougeTrigger fence;
    public GameObject skatersIntended;
    public GameObject skatersAlternate;
    public GameObject fenceDoor;
    public bool wonRapBattle = false;

    public GameObject catHerdIntended;
    public GameObject catHerdAlternate;
    public dialougeTrigger lairDoorDialouge;
    public GameObject lairDoor;
    public bool lairDoorKeyObtained = false;

    bool intendedSkaterPath = true;

    int x = 1;
    int y = 1;
    int z = 1;

    private void Start()
    {
         GetComponent<dialougeTrigger>().startDialouge();

        castledoor.enabled = false;
    }

    private void Update()
    {
        lairDoor.GetComponent<BoxCollider2D>().enabled = lairDoorKeyObtained;

        if (x == 1)
        {
            if (fence.dialouges.Count == 0)
            {
                if (skatersOne.dialouges.Count > 0)
                {
                    intendedSkaterPath = false;
                }
                if (skatersOne.dialouges.Count == 0)
                {
                    intendedSkaterPath = true;
                }

                if (intendedSkaterPath)
                {
                    skatersIntended.GetComponent<Rigidbody2D>().position = skatersOne.transform.position;
                }
                else
                {
                    skatersAlternate.GetComponent<Rigidbody2D>().position = skatersOne.transform.position;
                }

                skatersOne.GetComponent<BoxCollider2D>().enabled = false;

                x = 0;
            }
        }

        if(z == 1)
        {
            if (wonRapBattle)
            {
                fenceDoor.GetComponent<BoxCollider2D>().enabled = true;
                fenceDoor.GetComponent<SpriteRenderer>().enabled = true;

                fence.dialouges.Clear();

                z--;
            }
        }

        if(y == 1)
        {
            if(lairDoorDialouge.dialouges.Count == 0)
            {
                catHerdIntended.GetComponent<Rigidbody2D>().position = catHerdAlternate.transform.position;

                catHerdAlternate.GetComponent<BoxCollider2D>().enabled = false;

                y = 0;
            }

            if(lairDoorKeyObtained)
            {
                lairDoorDialouge.GetComponent<BoxCollider2D>().enabled = false;

                y = 0;
            }
        }
    }
}
