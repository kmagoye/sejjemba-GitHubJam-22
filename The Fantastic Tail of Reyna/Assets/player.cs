using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed;
    Vector2 Direction;
    BoxCollider2D box;
    int wallLayer = 1 << 10;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0);

        RaycastHit2D hit = Physics2D.BoxCast(transform.position,box.size, 0f, Direction, 1 * moveSpeed * Time.deltaTime, wallLayer);

        if (hit == false)
        {
            transform.Translate(Direction);
        }

        Direction = new Vector2(0, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime);

        hit = Physics2D.BoxCast(transform.position, box.size, 0f, Direction, 1 * moveSpeed * Time.deltaTime, wallLayer);

        if (hit == false)
        {
            transform.Translate(Direction);
        }
    }
}
