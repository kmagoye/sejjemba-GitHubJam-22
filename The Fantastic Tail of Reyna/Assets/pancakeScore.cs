using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pancakeScore : MonoBehaviour
{
    TMP_Text scoreText;

    public int score = 0;

    private void Start()
    {
        scoreText = GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    public void Add()
    {
        score++;
    }

    public void Subtract()
    {
        if (score > 0)
        {
            score--;
        }
    }
}
    