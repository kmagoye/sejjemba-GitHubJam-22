using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monteSlot : MonoBehaviour
{
    public Vector2 location;

    public Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    public void setLocation()
    {
        location = rb2d.position;
    }
}
