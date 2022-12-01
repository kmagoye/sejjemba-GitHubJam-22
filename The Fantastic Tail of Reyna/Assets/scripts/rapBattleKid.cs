using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class rapBattleKid : MonoBehaviour
{
    public Transform target;
    public Transform home;

    public bool atHome = true;

    Rigidbody2D rb2d;

    public string rapLyrics;

    public GameObject textBox;

    public TMP_Text rapSlot;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        rb2d.position = home.position;
    }

    public void rap()
    {
        rapSlot.alignment = TextAlignmentOptions.TopLeft;

        StartCoroutine(typeWriterEffect(rapLyrics, rapSlot));

        textBox.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void clear()
    {
        textBox.GetComponent<SpriteRenderer>().enabled = false;

        rapSlot.text = null;
    }

    public IEnumerator move(int speed, Vector2 Target, Vector2 offset)
    {
        Target += offset;

        int x = 0;

        while (x < 60)
        {
            Vector2 direction = Target - new Vector2(transform.position.x, transform.position.y);

            transform.Translate(direction/speed);

            x++;

            yield return new WaitForFixedUpdate();
        }

        rb2d.position = Target;
    }

    IEnumerator typeWriterEffect(string desriedText, TMP_Text location)
    {
        char[] characters = desriedText.ToCharArray();

        int characterAmnt = characters.Length;

        int x = 0;

        string typedCharacters = null;

        while (x < characterAmnt)
        {
            typedCharacters = typedCharacters + characters[x];

            location.text = typedCharacters;

            x++;

            yield return new WaitForFixedUpdate();
        }
    }
}
