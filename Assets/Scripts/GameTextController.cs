using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class GameTextController : MonoBehaviour
{
    public static GameTextController Instance;
    public AudioClip SecretAudio;
    //public AudioClip Audio1;
    public PlayableDirector Audio2;

    private AudioSource _as;

    public bool HasSaidAudio1;
    public bool HasSaidAudio2;
    public bool HasSaidAudio3;
    public bool HasSaidSecretAudio;

    void Start()
    {
        Instance = this;
        _as = GetComponent<AudioSource>();
    }

    private void Update()
    {
    }

    public void Intro()
    {
        StartCoroutine(WaitFor(2, () =>
        {
            HasSaidAudio1 = true;
            HasSaidAudio2 = true;
            Audio2.Play();
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
            if (!_as.isPlaying && Audio2.state != PlayState.Playing)
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
