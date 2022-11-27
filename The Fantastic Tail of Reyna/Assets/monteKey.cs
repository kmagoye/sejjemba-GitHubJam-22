using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monteKey : MonoBehaviour
{
    public Rigidbody2D rb2d;

    monteCat cat;

    SpriteRenderer sprite;

    public bool held = false;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (held)
        {
            sprite.enabled = false;

            rb2d.transform.position = cat.transform.position;
        }
        else
        {
            sprite.enabled = true;
        }
    }

    public void Move(monteCat Cat, int speed, int delay)
    {
        StartCoroutine(move(Cat.transform.position, speed, delay, true, false));

        cat = Cat;
    }

    public IEnumerator move(Vector2 target,int speed, int delay, bool startShuffle, bool Won) 
    {
        int y = 1;

        Vector2 direction = target - rb2d.position;

        while (y < speed)
        {
            transform.Translate(direction / speed);

            y++;

            yield return new WaitForFixedUpdate();
        }

        rb2d.position = target;

        int z = 1;

        while (z < delay)
        {
            z++;

            yield return new WaitForFixedUpdate();
        }


        if (startShuffle)
        {
            held = cat.hasKey = true;
            FindObjectOfType<monteGame>().shuffle(FindObjectOfType<monteGame>().shuffleAmount);
        }
        else
        {
            if (!Won)
            {
                int q = 1;

                while (q < delay * 2)
                {
                    q++;

                    yield return new WaitForFixedUpdate();
                }

                FindObjectOfType<monteGame>().giveKey();
            }
            else
            {
                held = cat.hasKey = false;
                cat = null;

                FindObjectOfType<monteGame>().dialougeTrigger.startDialouge();
            }
        }
    }
}
