using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed;
    float effectiveMoveSpeed;

    Vector2 Direction;
    BoxCollider2D box;
    Rigidbody2D rb2d;

    int wallLayer = 1 << 10;
    int interactableLayer = 1 << 8;

    public interactable selected;

    public bool inConvo = false;
    dialougeManager dialougeManager;

    public bool caffinated = false;

    public bool inGame;

    Animator Animator;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        dialougeManager = FindObjectOfType<dialougeManager>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!caffinated)
        {
            effectiveMoveSpeed =  moveSpeed;
        }
        else
        {
            effectiveMoveSpeed = moveSpeed * 2;
        }

        CheckInteractable();

        if (Input.GetKeyDown("x"))
        {
            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && inConvo == false && inGame == false)
            {
                if (selected != null)
                {
                    selected.Interact();
                }
            }
            if (inConvo)
            {
                dialougeManager.displayNextScentence();
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

        Direction = new Vector2(Input.GetAxisRaw("Horizontal") * effectiveMoveSpeed * Time.deltaTime, 0);

        RaycastHit2D hit = Physics2D.BoxCast(transform.position,box.size, 0f, Direction, 1 * moveSpeed * Time.deltaTime, wallLayer);

        //moving in x 

        if (!hit && !inConvo)
        {
            transform.Translate(Direction);
        }

        //same deal for y direction

        Direction = new Vector2(0, Input.GetAxisRaw("Vertical") * effectiveMoveSpeed * Time.deltaTime);

        hit = Physics2D.BoxCast(transform.position, box.size, 0f, Direction, 1 * moveSpeed * Time.deltaTime, wallLayer);

        if (!hit && !inConvo)
        {
            transform.Translate(Direction);
        }

        setAnimator();
    }
    void setAnimator()
    {
        bool moving = false;

        if (Input.GetAxisRaw("Horizontal") + Input.GetAxisRaw("Vertical") != 0)
        {
            moving = true;
        }

        Animator.SetBool("moving", moving);

        Animator.SetInteger("x", Mathf.RoundToInt(Input.GetAxisRaw("Horizontal")));

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            Animator.SetInteger("y", Mathf.RoundToInt(Input.GetAxisRaw("Vertical")));
        }
    }

    public void TP(Vector2 targetPosition)
    {
        caffinated = false;

        rb2d.position = targetPosition;
    }
}
