using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class GameTextController : MonoBehaviour
{
    public static GameTextController Instance;
    public AudioClip SecretAudio;
    public PlayableDirector IntroAudio;
    public PlayableDirector GoodJobCrate;
    public PlayableDirector CrateJob;

    private AudioSource _as;

    public bool HasSaidSecretAudio;

    void Start()
    {
        Instance = this;
        _as = GetComponent<AudioSource>();
    }

    public void Intro()
    {
        StartCoroutine(WaitFor(2, () =>
        {
            IntroAudio.Play();
            // todo: remove
            IntroAudio.time = 60f;
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
        StartCoroutine(SecretWoodsText2());
    }
    private IEnumerator SecretWoodsText2()
    {
        while (!HasSaidSecretAudio)
        {
            if (!_as.isPlaying && (IntroAudio.state != PlayState.Playing || IntroAudio.time > 60))
            {
                HasSaidSecretAudio = true;
                _as.clip = SecretAudio;
                _as.Play();
            }

            yield return null;            
        }
    }

    public IEnumerator WaitFor(float seconds, Action a)
    {
        yield return new WaitForSeconds(seconds);
        a();
    }
}
