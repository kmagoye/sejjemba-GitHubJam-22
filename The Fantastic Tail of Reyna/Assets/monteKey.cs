using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monteKey : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public void Move(Vector2 vector2)
    {
        rb2d.position = vector2;   
    }
}
