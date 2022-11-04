using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed;
    Vector2 Direction;
    BoxCollider2D box;
    Rigidbody2D rb2d;

    int wallLayer = 1 << 10;
    int interactableLayer = 1 << 8;

    public float Range = 2f;
    interactable[] interactables;
    public interactable selected;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        interactables = FindObjectsOfType<interactable>();
    }

    private void Update()
    {
        CheckInteractable();

        if (Input.GetKeyDown("x") && Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            if(selected != null)
            {
                selected.Interact();
            }
        }
    }

    void CheckInteractable()
    {
        //checking if player is within a interactable's hit box

        RaycastHit2D selectedCheck = Physics2D.BoxCast(transform.position, box.size, 0f, Direction, 1 * moveSpeed * Time.deltaTime, interactableLayer);

        if (selectedCheck == true)
        {
            selected = selectedCheck.transform.GetComponent<interactable>();
        }
        else
        {
            selected = null;
        }
    }

    private void FixedUpdate()
    {
        //checking for a wall in x direction

        Direction = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0);

        RaycastHit2D hit = Physics2D.BoxCast(transform.position,box.size, 0f, Direction, 1 * moveSpeed * Time.deltaTime, wallLayer);

        //moving in x 

        if (hit == false)
        {
            transform.Translate(Direction);
        }

        //same deal for y direction

        Direction = new Vector2(0, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime);

        hit = Physics2D.BoxCast(transform.position, box.size, 0f, Direction, 1 * moveSpeed * Time.deltaTime, wallLayer);

        if (hit == false)
        {
            transform.Translate(Direction);
        }
    }

    public void TP(Vector2 targetPosition)
    {
        rb2d.position = targetPosition;
    }
}
