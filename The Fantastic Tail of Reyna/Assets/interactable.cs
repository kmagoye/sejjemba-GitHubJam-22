using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    public bool inRange = false;
    public float Range = 0f;
    int playerLayer = 1 << 9;
    player Player;

    private void Start()
    {
        Player = FindObjectOfType<player>();
        
    }

    private void Update()
    {
        Vector2 playerDirection = Player.transform.position - transform.position;

        inRange = Physics2D.Raycast(transform.position, playerDirection, Range, playerLayer);

        DrawCircle(transform.position, Range, 180, Color.green);
    }

    void DrawCircle(Vector3 position, float radius, int segments, Color color)
    {
        if (radius <= 0.0f || segments <= 0)
        {
            return;
        }

        float angleStep = (360.0f / segments);

        angleStep *= Mathf.Deg2Rad;

        Vector3 lineStart = Vector3.zero;
        Vector3 lineEnd = Vector3.zero;

        for (int i = 0; i < segments; i++)
        {
            lineStart.x = Mathf.Cos(angleStep * i);
            lineStart.y = Mathf.Sin(angleStep * i);

            lineEnd.x = Mathf.Cos(angleStep * (i + 1));
            lineEnd.y = Mathf.Sin(angleStep * (i + 1));

            lineStart *= radius;
            lineEnd *= radius;

            lineStart += position;
            lineEnd += position;

            Debug.DrawLine(lineStart, lineEnd, color);
        }
    }
}
