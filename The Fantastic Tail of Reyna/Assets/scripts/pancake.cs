using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pancake : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float gravityMultiplier;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        rb2d.gravityScale = 1 + gravityMultiplier * FindObjectOfType<pancakeScore>().score;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.1f);

        if(hit == true)
        {
            if (hit.transform.CompareTag("Player"))
            {
                FindObjectOfType<pancakeScore>().Add();
            }
            if (hit.transform.CompareTag("lava"))
            {
                FindObjectOfType<pancakeScore>().Subtract();
            }

            Destroy(gameObject);
        }
    }
}
