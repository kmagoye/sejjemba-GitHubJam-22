using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monteCat : MonoBehaviour
{
    public bool hasKey;
    Rigidbody2D rb2d;

    public int Speed = 10;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void receivePath(List<monteSlot> slotPath)
    {
        Queue<Vector2> targets = new Queue<Vector2>();

        foreach(monteSlot slot in slotPath)
        {
            targets.Enqueue(slot.location);
        }

        StartCoroutine(Move(targets, Speed));

    }

    IEnumerator Move(Queue<Vector2> targets, int speed)
    {
        int x = targets.Count;

        //print(string.Join(",", targets));

        for(int i = 0; i < x; i++)
        {
            int y = 1;

            Vector2 target = targets.Dequeue();

            Vector2 direction =  target - rb2d.position;

            print(direction);

            while(y < speed)
            {
                transform.Translate(direction/speed * y);

                y++;

                yield return new WaitForFixedUpdate();
            }

            rb2d.position = target;
        }
    }
}
