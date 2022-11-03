using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed;
    float x;
    Vector2 Direction;
    public CircleCollider2D interactRadius;
    int Wall = 1 << 10;
    bool right = true;
    bool left = true;
    bool up = true;
    bool down = true;
    Rigidbody2D rb2d;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        x = 1 / moveSpeed;
        Direction = new Vector2(Input.GetAxisRaw("Horizontal") * x, Input.GetAxisRaw("Vertical") * x);

        checkWall();

        move();
    }

    void checkWall()
    {
        RaycastHit2D Right = Physics2D.Raycast(new Vector2(transform.position.x + 0.51f, transform.position.y + 1), new Vector2(0,-1), 1f, Wall);

        if (Right)
        {
            right = false;
        }
        else
        {
            right = true;
        }

        RaycastHit2D Left = Physics2D.Raycast(new Vector2(transform.position.x - 0.51f, transform.position.y + 1), new Vector2(0, -1), 1f, Wall);

        if (Left)
        {
            left = false;
        }
        else
        {
            left = true;
        }

        RaycastHit2D Up = Physics2D.Raycast(new Vector2(transform.position.x + 1, transform.position.y + 0.51f), new Vector2(-1, 0), 1f, Wall);

        if (Up)
        {
            up = false;
        }
        else
        {
            up = true;
        }

        Debug.DrawRay(new Vector2(transform.position.x + 0.5f, transform.position.y - 0.25f), new Vector2(-1, 0), Color.red);
        RaycastHit2D Down = Physics2D.Raycast(new Vector2(transform.position.x + 1, transform.position.y - 0.51f), new Vector2(-1, 0), 1f, Wall);

        if (Down)
        {
            down = false;
        }
        else
        {
            down = true;
        }
    }

    void move()
    {
        if ((Input.GetKey("right") ^ Input.GetKey("d")) && right)
        {
            transform.Translate(new Vector2(x,0));
        }
        if ((Input.GetKey("left") ^ Input.GetKey("a")) && left)
        {
            transform.Translate(new Vector2(-x, 0));
        }
        if ((Input.GetKey("up") ^ Input.GetKey("w")) && up)
        {
            transform.Translate(new Vector2(0, x));
        }
        if ((Input.GetKey("down") ^ Input.GetKey("s")) && down)
        {
            transform.Translate(new Vector2(0, -x));
        }
    }
}
