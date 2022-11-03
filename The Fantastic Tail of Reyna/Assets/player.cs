using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed;
    Vector2 Direction;
    BoxCollider2D box;

    int wallLayer = 1 << 10;
    int interactableLayer = 1 << 8;

    public float Range = 2f;
    interactable[] interactables;
    public interactable selected;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        interactables = FindObjectsOfType<interactable>();
    }

    private void Update()
    {
        CheckInteractable();           
    }

    void CheckInteractable()
    {
        float DistFromSelected = 0;
        Vector2 interactableDirection;

        foreach (interactable interactable in interactables)
        {
            if(selected != null)
            {
                DistFromSelected = Pythagoreans(selected.transform.position , transform.position);
            }

            interactableDirection = interactable.transform.position - transform.position;

            RaycastHit2D selectedCheck = Physics2D.Raycast(transform.position, interactableDirection, Range, interactableLayer);

            if (selected != null)
            {
                if (selectedCheck == true)
                {
                    selected = selectedCheck.transform.GetComponent<interactable>();
                }
                else
                {
                    selected = null;
                }
            }
            else
            {
                if (selectedCheck == true)
                {
                    if (Pythagoreans(selectedCheck.transform.position, transform.position) > DistFromSelected)
                    {
                        selected = selectedCheck.transform.GetComponent<interactable>();
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        //movement and movement checks

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

    float Pythagoreans(Vector2 FarPoint, Vector2 ClosePoint)
    {
        return Mathf.Sqrt((FarPoint.x - ClosePoint.x)*(FarPoint.x - ClosePoint.x) + (FarPoint.y - ClosePoint.y)*(FarPoint.y - ClosePoint.y));
    }
}
