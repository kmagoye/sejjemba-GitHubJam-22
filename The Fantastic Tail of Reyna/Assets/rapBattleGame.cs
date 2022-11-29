using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class rapBattleGame : MonoBehaviour
{
    public CinemachineVirtualCamera gameCamera;
    public CinemachineVirtualCamera returnCamera;

    public AudioClip beat;

    public List<rapBattleKid> kids;

    public int kidSpeed;

    dialougeTrigger dialougeTrigger;

    public GameObject progressBar;

    int round = 0;

    bool beatPlaying;

    public List<string> unfinishedResponses;
    public List<string> responses;
    public GameObject inputBox;

    public List<GameObject> sets;

    public TMP_Text responseBox;

    private void Update()
    {
        if (beatPlaying)
        {
            progressBar.transform.localScale = new Vector3(beat.length - FindObjectOfType<soundManager>().GetComponent<AudioSource>().time,1,1);
        }
    }

    public void gameStart()
    {
        FindObjectOfType<player>().inGame = true;

        FindObjectOfType<camera_manager>().SetCamera(gameCamera);

        dialougeTrigger = GetComponent<dialougeTrigger>();

        foreach(rapBattleKid kid in kids)
        {
            StartCoroutine(kid.move(kidSpeed, kid.target.position, new Vector2(0, 2 * (kids.IndexOf(kid) - 1))));
        }

        dialougeTrigger.startDialouge();
    }

    public void gameEnd()
    {
        FindObjectOfType<soundManager>().setMusic(null);

        FindObjectOfType<camera_manager>().SetCamera(returnCamera);

        FindObjectOfType<player>().inGame = false;
    }

    public void roundStart()
    {
        if(round == 0)
        {
            foreach (rapBattleKid kid in kids)
            {
                if (kids.IndexOf(kid) == 0)
                {
                    StartCoroutine(kid.move(kidSpeed, kid.target.position, new Vector2(0,0)));
                }
                else
                {
                    StartCoroutine(kid.move(kidSpeed, kid.home.position, new Vector2(0, 0)));
                }
            }
        }
        else if(round == 3)
        {
            foreach (rapBattleKid kid in kids)
            {
                StartCoroutine(kid.move(kidSpeed, kid.target.position, new Vector2(0, 2 * (kids.IndexOf(kid) - 1))));
            }

            dialougeTrigger.startDialouge();

            kids[1].clear();

            return;
        }
        else
        {
            foreach (rapBattleKid kid in kids)
            {
                if (kids.IndexOf(kid) == round)
                {
                    StartCoroutine(kid.move(kidSpeed, kid.target.position, new Vector2(0, 0)));
                }
            }
        }

        FindObjectOfType<soundManager>().setMusic(beat);

        beatPlaying = true;

        kids[round].rap();

        inputBox.GetComponentInChildren<TMP_Text>().text = unfinishedResponses[round];
        inputBox.GetComponent<SpriteRenderer>().enabled = true;

        sets[round].GetComponent<rapBattleSet>().move(new Vector2(0,10));
    }

    public void respond()
    {
        inputBox.GetComponent<SpriteRenderer>().enabled = false;

        inputBox.GetComponentInChildren<TMP_Text>().text = null;

        responseBox.text = null;

        responseBox.alignment = TextAlignmentOptions.TopRight;

        StartCoroutine(typeWriterEffect(responses[round], responseBox));
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

        StartCoroutine(kids[round].move(kidSpeed, kids[round].home.position, new Vector2(0,0)));

        yield return new WaitForSeconds(beat.length - FindObjectOfType<soundManager>().GetComponent<AudioSource>().time);

        round++;

        roundStart();
    }
}
