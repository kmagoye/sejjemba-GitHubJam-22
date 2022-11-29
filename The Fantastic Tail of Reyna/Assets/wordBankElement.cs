using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordBankElement : MonoBehaviour
{
    public bool correct;

    public Vector2 origin;

    Rigidbody2D rb2d;

    public bool moving = false;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public IEnumerator move(Vector2 target)
    {
        moving = true;

        int x = 0;

        while (x < 20)
        {
            Vector2 direction = target - new Vector2(transform.position.x, transform.position.y);

            transform.Translate(direction / 7);

            x++;

            yield return new WaitForFixedUpdate();
        }

        rb2d.position = target;

        moving = false;
    }
}
