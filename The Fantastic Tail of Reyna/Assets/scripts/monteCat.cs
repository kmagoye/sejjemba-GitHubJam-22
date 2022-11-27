using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monteCat : MonoBehaviour
{
    public bool hasKey;
    Rigidbody2D rb2d;

    SpriteRenderer sprite;

    bool dim = false;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        dim = FindObjectOfType<monteKey>().held;

        if (dim)
        {
            sprite.color = Color.black;
        }
        else
        {
            sprite.color = Color.white;
        }
    }

    public void receivePath(List<monteSlot> slotPath, int Speed, int delay)
    {
        Queue<Vector2> targets = new Queue<Vector2>();

        foreach(monteSlot slot in slotPath)
        {
            targets.Enqueue(slot.location);
        }

        StartCoroutine(Move(targets, Speed, delay));

        
    }

    IEnumerator Move(Queue<Vector2> targets, int speed, int delay)
    {
        int x = targets.Count;

        for(int i = 0; i < x; i++)
        {
            int y = 1;

            Vector2 target = targets.Dequeue();

            Vector2 direction =  target - rb2d.position;

            while(y < speed)
            {
                transform.Translate(direction/speed);

                y++;

                yield return new WaitForFixedUpdate();
            }

            rb2d.position = target;

            int z = 1;

            while(z < delay)
            {
                z++;

                yield return new WaitForFixedUpdate();
            }
        }

        FindObjectOfType<monteGame>().clickTime = true;
    }
}
