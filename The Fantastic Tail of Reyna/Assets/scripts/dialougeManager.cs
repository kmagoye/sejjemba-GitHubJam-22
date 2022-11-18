using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class dialougeManager : MonoBehaviour
{
    Queue<string> scentences;
    Queue<string> names;

    player player;

    public SpriteRenderer textBox;
    public TMP_Text nameSlot;
    public TMP_Text scentenceSlot;
    public TMP_Text continueText;

    bool conversing = false;

    bool typing = false;

    void Start()
    {
        player = FindObjectOfType<player>();

        scentences = new Queue<string>();
        names = new Queue<string>();

        nameSlot.text = scentenceSlot.text = null;
    }

    private void Update()
    {
        textBox.enabled = conversing;
        if (conversing)
        {
            continueText.enabled = !typing;
        }
        else
        {
            continueText.enabled = false;
        }
    }

    public void startDialouge(dialougeClass dialouge)
    {
        conversing = true;

        scentences.Clear();
        names.Clear();

        foreach(string scentence in dialouge.scentences)
        {
            scentences.Enqueue(scentence);
        }

        foreach (string name in dialouge.name)
        {
            names.Enqueue(name);
        }

        displayNextScentence();

        StartCoroutine(waitForKeyLift());
    }

    public void displayNextScentence()
    {
        if (!typing)
        {
            if (scentences.Count == 0)
            {
                endDialouge();
                return;
            }

            Type(scentences.Dequeue(), names.Dequeue());
        }
    }

    public void endDialouge()
    {
        player.inConvo = false;

        conversing = false;

        nameSlot.text = scentenceSlot.text = null;
    }

    void Type(string scentence, string name)
    {
        StartCoroutine(typeWriterEffect(scentence,scentenceSlot));

        nameSlot.text = name + ":";
    }

    IEnumerator waitForKeyLift()
    {
        while (Input.GetKeyDown("x"))
        {
            yield return new WaitForEndOfFrame();
        }

        player.inConvo = true;
    }

    IEnumerator typeWriterEffect(string desriedText, TMP_Text location)
    {
        typing = true;

        char[] characters = desriedText.ToCharArray();

        int characterAmnt = characters.Length;

        int x = 0;

        string typedCharacters = null;

        while(x < characterAmnt)
        {
            typedCharacters = typedCharacters + characters[x];

            location.text = typedCharacters;

            x++;

            yield return new WaitForFixedUpdate();
        }

        typing = false;
    }
}
