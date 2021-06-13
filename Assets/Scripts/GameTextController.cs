using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameTextController : MonoBehaviour
{
    public static GameTextController Instance;
    public AudioClip SecretAudio;
    public PlayableDirector IntroAudio;
    public PlayableDirector GoodJobCrate;
    public PlayableDirector CrateJob;
    public PlayableDirector GoblinSpotted;
    public PlayableDirector FirstGoblinKilled;
    public PlayableDirector BossFightStarted;
    public PlayableDirector GameOver;
    public Animator Curtains;

    private AudioSource _as;

    public bool HasSaidSecretAudio;

    void Start()
    {
        Instance = this;
        _as = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (GameOver.state == PlayState.Playing)
        {
            if (GameOver.time > 35)
            {
                Curtains.SetTrigger("Close");
            }
            else if (GameOver.time > 43)
            {
                SceneManager.LoadScene("ThanksForPlaying");
            }
        }
    }

    public void Intro()
    {
        StartCoroutine(WaitFor(2, () =>
        {
            IntroAudio.Play();
        }));
    }

    public void OnCrate()
    {
        StartCoroutine(WaitFor(.5f, () =>
        {
            GoodJobCrate.Play();
        }));
    }

    public void OnCrate2()
    {
        StartCoroutine(WaitFor(.5f, () =>
        {
            CrateJob.Play();
        }));
    }

    public void SecretWoodsText()
    {
        if (HasSaidSecretAudio)
        {
            return;
        }

        HasSaidSecretAudio = true;
        _as.clip = SecretAudio;
        _as.Play();
    }

    public IEnumerator WaitFor(float seconds, Action a)
    {
        yield return new WaitForSeconds(seconds);
        a();
    }
}
