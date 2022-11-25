using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pancakePlayer : MonoBehaviour
{
    public float moveSpeed;
    BoxCollider2D box;
    int wallLayer = 1 << 10;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        Vector2 Direction = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Direction, (box.size.x / 2) * transform.localScale.x + 0.1f, wallLayer);

        if (!hit)
        {
            transform.Translate(Direction);
        }
    }
}
