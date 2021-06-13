using System.Collections;
using UnityEngine;

public class GameTextController : MonoBehaviour
{
    public static GameTextController Instance;
    public AudioClip Audio1;

    private AudioSource _as;

    void Start()
    {
        Instance = this;
        _as = GetComponent<AudioSource>();
    }

    public void Intro()
    {
        StartCoroutine(WaitFor());
    }

    public IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(2);
        _as.clip = Audio1;
        _as.Play();
    }
}
